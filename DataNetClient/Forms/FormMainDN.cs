using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using CQG;
using DADataManager;
using DADataManager.Models;
using DataAdminCommonLib;
using DataNetClient.Controls;
using DataNetClient.Core;
using DataNetClient.Core.ClientManager;
using DataNetClient.CQGDataCollector;
using DataNetClient.Properties;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Timer = System.Windows.Forms.Timer;


namespace DataNetClient.Forms
{
    public partial class FormMainDN : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        #region VARIABES

        private readonly MetroBillCommands _commands; // All application commands
        private StartControl _startControl;
        private MissingBarManager _missingBarManager;
        private CQGCEL _cel;
        private bool _isStartedCqg;
        private List<Brush> _lbxColors;
        private Logger _logger;
        private SymbolsEditControl _symbolsEditControl;
        private EditListControl _editListControl;
        private AddListControl _addListControl;
        private List<SymbolModel> _symbols = new List<SymbolModel>();
        private Thread _logonThread;
        private readonly DNetBusySymbolList _busySymbolList;
        private string _lastTip;
        private string _connectionToSharedDb;
        private string _connectionToSharedDbBar;
        private string _connectionToSharedDbHistorical;
        private string _connectionToLocalDb;
        private string _connectionToLocalDbBar;
        private string _connectionToLocalDbHistorical;

        private List<GroupItemModel> _groupItems;

        private bool _logined;
        private readonly object _lockRefreshSymbols = new object();
        private Semaphore _semaphoreWaitEndCollecting = new Semaphore(0, 1);

        private bool _emeilAfterFinishing;
        private bool _autocollect;
        private int _barStart;
        private int _barEnd;


        #endregion

        #region CLIENT-SERVER VARIABLES

        private DataClientClass _client;
        private IScsServiceClient<IDataAdminService> _clientService;
        private DataNetLogService _logClient;
        private IScsServiceClient<IDataNetLogService> _logClientService;
        private bool _serverStatusMaster;
        private bool _serverStatusSlave;
        private Timer _pingTimer;
        private object _offlineServerSymbol;
        private object _onlineServerSymbol;
        private bool _shouldStop;
        private readonly object _collectingLock = new object();
        private int _sortMode = 1;
        public bool _nowIsMaster = true;

        #endregion

        #region MAIN FUNCTIONS Constructor, Load, Shown, Resize, Closing

        public FormMainDN()
        {
            SuspendLayout();

            InitializeComponent();
            _commands = new MetroBillCommands
            {
                StartControlCommands = {Logon = new Command(), Exit = new Command()},
                NewSymbolCommands = {NewGroup = new Command(), Cancel = new Command(), EditGroup = new Command()},
                NewListCommands = {Add = new Command(), Cancel = new Command()},
                EditListCommands = {Save = new Command(), Cancel = new Command()}
            };

            _commands.StartControlCommands.Logon.Executed += StartControl_LogonClick;
            _commands.StartControlCommands.Exit.Executed += StartControl_ExitClick;

            _commands.NewSymbolCommands.Cancel.Executed += CancelNewSymbolExecuted;
            _commands.NewSymbolCommands.NewGroup.Executed += NewGroupNewSymbolExecuted;
            _commands.NewSymbolCommands.EditGroup.Executed += EditGroupNewSymbolExecuted;

            _commands.NewListCommands.Add.Executed += AddListControl_SaveClick;
            _commands.NewListCommands.Cancel.Executed += AddListControl_CancelClick;

            _commands.EditListCommands.Save.Executed += EditListControl_SaveClick;
            _commands.EditListCommands.Cancel.Executed += CancelEditListExecuted;


            //styledListControl1.ItemEditGroupClick += styledListControl1_ItemEditGroupClick;
            //groupList4.ItemEditGroupClick+=groupList4_ItemEditGroupClick;
            labelItemUserName.Text = @"ver " + Application.ProductVersion;

            _startControl = new StartControl {Commands = _commands};
            //_addUserControl = new AddUserControl {Commands = _commands, Tag = 0};

            Controls.Add(_startControl);
            _startControl.BringToFront();
            _startControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            ResumeLayout(false);
            _busySymbolList = new DNetBusySymbolList();
            Daily_NotChanchedValuesManager.Init();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ClientDatabaseManager.ConnectionStatusChanged += ClientDataManager_ConnectionStatusChanged;

                if (Settings.Default.L.X < 0 || Settings.Default.L.Y < 0) Settings.Default.L = new Point(0, 0);
                if (Settings.Default.S.Width < 0 || Settings.Default.S.Height < 0)
                    Settings.Default.S = new Size(800, 500);

                Size = Settings.Default.S;
                Location = Settings.Default.L;
                _emeilAfterFinishing= Settings.Default.IsSendReports;
                UpdateControlsSizeAndLocation();

                _logger = Logger.GetInstance(listViewLogger);
                _logger.LogAdd("Application Start", Category.Information);
                _missingBarManager = new MissingBarManager(_logger);


                _missingBarManager.MissingBarStart += DataCollector_MissingBarStart;
                _missingBarManager.MissingBarEnd += DataCollector_MissingBarEnd;

                _missingBarManager.Finished += DataCollector_Finished;
                _missingBarManager.Progress += _missingBarManager_Progress;



                ui_home_textBoxX_db.Text = Settings.Default.MainDB;
                ui_home_textBoxX_db_bar.Text = Settings.Default.dbBar;
                ui_home_textBoxX_db_historical.Text = Settings.Default.dbHistorical;
                ui_home_textBoxX_uid.Text = Settings.Default.User;
                ui_home_textBoxX_pwd.Text = Settings.Default.Password;
                ui_home_textBoxX_host.Text = Settings.Default.Host;
                //nudEndBar.Value = Settings.Default.valFinish;
                checkBoxX1.Checked = Settings.Default.SavePass;
                //**
                metroShell1.SelectedTab = metroTabItem1;

               

                ResetColorMarks();
                // todo
                _cel = new CQGCEL();
                _cel.APIConfiguration.TimeZoneCode = eTimeZone.tzGMT;
                _cel.APIConfiguration.ReadyStatusCheck = eReadyStatusCheck.rscOff;
                _cel.APIConfiguration.CollectionsThrowException = false;
                _cel.APIConfiguration.LogSeverity = eLogSeverity.lsDebug;
                _cel.APIConfiguration.MessageProcessingTimeout = 30000;

                _cel.DataConnectionStatusChanged += CEL_DataConnectionStatusChanged;
                CEL_DataConnectionStatusChanged(eConnectionStatus.csConnectionDown);
                _cel.DataError += CEL_DataError;
                _cel.IncorrectSymbol += CEL_IncorrectSymbol;
                _cel.HistoricalSessionsResolved += CEL_HistoricalSessionsResolved;
                _cel.InstrumentSubscribed += CEL_InstrumentSubscribed;

                FormAddSymbolsGroups.RefreshSYmbolsGroups += RefreshGridSymbolsGroups;
                FormAutocollect.RefreshGroups += RefreshGridGroups;


                //todo

               
                _pingTimer = new Timer();
                _pingTimer.Tick += TimerTick;
                _pingTimer.Interval = 1000;
                _pingTimer.Enabled = true;
                _onlineServerSymbol = _startControl.uiServerOnlineFakeSymbol.Symbol;
                _offlineServerSymbol = _startControl.uiOfflineFakeSymbol.Symbol;

                //todo
                //groupList4.ItemStateChanged +=groupList4_ItemStateChanged;
                
                //todo subscribe

                FormSettings.EmeilAfterFinishing += EmailChange;
                FormSettings.IsAutocollect += AutocollectChange;
                FormSettings.BarEnd += barEndChange;
                




                CQGDataCollectorManager.ItemStateChanged += CQGDataCollectorManager_ItemStateChanged;
                CQGDataCollectorManager.CollectedSymbolCountChanged +=
                    CQGDataCollectorManager_CollectedSymbolCountChanged;
                CQGDataCollectorManager.RunnedStateChanged += CQGDataCollectorManager_RunnedStateChanged;
                CQGDataCollectorManager.StartTimeChanged += CQGDataCollectorManager_StartTimeChanged;
                CQGDataCollectorManager.CQGStatusChanged += CQGDataCollectorManager_CQGStatusChanged;

                CQGDataCollectorManager.UnsuccessfulSymbol += CQGDataCollectorManager_UnsuccessfulSymbol;
                CQGDataCollectorManager.TickInsertingStarted += CQGDataCollectorManager_TickInsertingStarted;
                CQGDataCollectorManager.ProgressBarChanged += CQGDataCollectorManager_ProgressBarChanched;

                CQGDataCollectorManager.SendReport += CQGDataCollectorManager_SendReport;
                //todo
                Thread.Sleep(1000); // Fixed bug with closeing while starting//do not remove this
                _cel.Startup();


                //Restarting after crashing
                if (Settings.Default.IsCrashed)
                {
                    LoginToServer(Settings.Default.scUser1, Settings.Default.scPassword, Settings.Default.scHostSlave,
                        _nowIsMaster);

                }
                dataSet.Relations.Add("1", dataSet.Tables["my_tbl"].Columns["ID"],
                                        dataSet.Tables["tbl_sym"].Columns["ID"], false);
                //superGridControl1.DefaultVisualStyles.RowStyles.SelectedMouseOver.Background.Color1 = Color.Red;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogAdd("Error in loading. " + ex.Message, Category.Error);
                Close();
            }
        }

        private void AutocollectChange(bool flag)
        {
            _autocollect = flag;
            CQGDataCollectorManager.ChangeMode(_autocollect);
            
                buttonX_StartCollectGroups.Enabled = !_autocollect;
        }

        private void EmailChange(bool flag)
        {
            _emeilAfterFinishing = flag;
        }

        private void barEndChange(int barEnd)
        {
            _barEnd = barEnd;
        }

        private void CQGDataCollectorManager_SendReport(string subject, string text)
        {
            //todo
            if (_emeilAfterFinishing)
            {
                _logger.LogAdd(" Message sent to " + Settings.Default.Emails + ". With subject: " + subject,
                    Category.Information);
                SendEmails(Settings.Default.Emails, subject, text);
            }
        }

        private void SendEmails(string addresses, string subject, string text)
        {
            //throw new NotImplementedException();
            Console.WriteLine(text);

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            var adr = addresses.Split(',');
            var addressesCount = 0;
            foreach (var item in adr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    message.To.Add(item);
                    addressesCount++;
                }
            }
            message.From = new System.Net.Mail.MailAddress("ZectraDataNet@gmail.com");
            message.Subject = subject;
            message.Body = text;

            if (addressesCount > 0)
            {
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("ZectraDataNet", "zectra2014");

                smtp.Send(message);

            }
        }

        private void CQGDataCollectorManager_TickInsertingStarted(string symbols, int count)
        {
            _logger.LogAdd(@"  |  Symbol '" + symbols + "' inserting started. Total data count:" + count,
                Category.Information);
        }

        private void _missingBarManager_Progress(int progress)
        {
            Invoke((Action) (() => {
                                       progressBarItemCollecting.Value = progress;
            }));
        }

        private void CQGDataCollectorManager_UnsuccessfulSymbol(List<string> symbols)
        {
            foreach (var item in symbols)
            {
                _logger.LogAdd(@"  |  Symbol '" + item + "' [unsuccessful]", Category.Warning);
            }

        }

        private void CQGDataCollectorManager_CQGStatusChanged(bool isConnected)
        {
            CqgConnectionStatusChanged(isConnected);
        }


        private void FormMain_Shown(object sender, EventArgs e)
        {
            metroShell1.TitleText = @"Data Net v" + Application.ProductVersion;
            UpdateControlsSizeAndLocation();
            /*PingServerMaster();
            PingServerSlave();    */
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout();
            _pingTimer.Enabled = false;
            ClientDatabaseManager.CloseConnectionToDbSystem();

            if (checkBoxX1.Checked)
            {

                Settings.Default.dbHistorical = ui_home_textBoxX_db_historical.Text;
                Settings.Default.dbBar = ui_home_textBoxX_db_bar.Text;
                Settings.Default.MainDB = ui_home_textBoxX_db.Text;
                Settings.Default.User = ui_home_textBoxX_uid.Text;
                Settings.Default.Password = ui_home_textBoxX_pwd.Text;
                Settings.Default.Host = ui_home_textBoxX_host.Text;
            }
            else
            {
                Settings.Default.dbBar = "";
                Settings.Default.dbHistorical = "";
                Settings.Default.MainDB = "";
                Settings.Default.Host = "";
                Settings.Default.User = "";
                Settings.Default.Password = "";

            }
            Settings.Default.S = Size;
            Settings.Default.L = Location;

            Settings.Default.SavePass = checkBoxX1.Checked;
            Settings.Default.Save();

        }

        private Rectangle GetStartControlBounds()
        {
            var captionHeight = metroShell1.MetroTabStrip.GetCaptionHeight() + 2;
            var borderThickness = GetBorderThickness();
            return new Rectangle((int) borderThickness.Left, captionHeight, Width - (int) borderThickness.Horizontal,
                Height - captionHeight - 1);
        }

        private void UpdateControlsSizeAndLocation()
        {
            if (_startControl != null)
            {
                if (!_startControl.IsOpen)
                    _startControl.OpenBounds = GetStartControlBounds();
                else
                    _startControl.Bounds = GetStartControlBounds();
                if (!IsModalPanelDisplayed)
                    _startControl.BringToFront();
            }
            
        }

        #endregion

        #region CLIENT - SERVER LOGIC IMPLEMENTATION

        private void TimerTick(object sender, EventArgs e)
        {
            PingServer();
        }

        private void PingServer()
        {

            IPAddress ipgood1, ipgood2;
            if (IPAddress.TryParse(_startControl.ui_textBox_ip.Text, out ipgood1) &&
                IPAddress.TryParse(_startControl.ui_textBox_ip_slave.Text, out ipgood2))
            {

                Task.Factory.StartNew(PingThreadMaster);
                Task.Factory.StartNew(PingThreadSlave);

                if (_serverStatusMaster)
                {

                    _startControl.Invoke((Action) delegate
                    {
                        _startControl.uiServerStatus.Visible = true;
                        _startControl.uiServerStatus.Text = "Server is online";
                        _startControl.uiServerStatus.ForeColor = Color.Green;
                        _startControl.uiServerStatus.SymbolColor = Color.Green;
                        _startControl.uiServerStatus.Symbol = _onlineServerSymbol.ToString();

                    }
                        );
                }
                else
                {

                    _startControl.Invoke((Action) delegate
                    {
                        _startControl.uiServerStatus.Visible = true;
                        _startControl.uiServerStatus.Text = "Server is offline";
                        _startControl.uiServerStatus.ForeColor = Color.Crimson;
                        _startControl.uiServerStatus.SymbolColor = Color.Crimson;
                        _startControl.uiServerStatus.Symbol = _offlineServerSymbol.ToString();


                    }
                        );

                }
                //8888

                if (_serverStatusSlave)
                {
                    _startControl.Invoke((Action) delegate
                    {
                        _startControl.uiServerStatus2.Visible = true;
                        _startControl.uiServerStatus2.Text = "Server is online";
                        _startControl.uiServerStatus2.ForeColor = Color.Green;
                        _startControl.uiServerStatus2.SymbolColor = Color.Green;
                        _startControl.uiServerStatus2.Symbol = _onlineServerSymbol.ToString();

                    });
                }
                else
                {
                    _startControl.Invoke((Action) delegate
                    {
                        _startControl.uiServerStatus2.Visible = true;
                        _startControl.uiServerStatus2.Text = "Server is offline";
                        _startControl.uiServerStatus2.ForeColor = Color.Crimson;
                        _startControl.uiServerStatus2.SymbolColor = Color.Crimson;
                        _startControl.uiServerStatus2.Symbol = _offlineServerSymbol.ToString();


                    });
                }



            }
            else
            {
                _startControl.Invoke((Action) delegate
                {
                    _startControl.uiServerStatus.Visible = true;
                    _startControl.uiServerStatus.Text = "Incorrect IP address";
                    _startControl.uiServerStatus.ForeColor = Color.Crimson;
                    _startControl.uiServerStatus.SymbolColor = Color.Crimson;
                    _startControl.uiServerStatus.Symbol = _offlineServerSymbol.ToString();

                    _startControl.ui_buttonX_logon.Enabled = false;
                }
                    );
            }
            _startControl.Invoke((Action) delegate
            {
                _startControl.ui_buttonX_logon.Enabled = (_serverStatusMaster && _serverStatusSlave);
                _startControl.Refresh();
            });

        }



        private void PingThreadMaster()
        {
            var tcpClient = new TcpClient();
            try
            {
                var ip1 = IPAddress.Parse(_startControl.ui_textBox_ip.Text);
                tcpClient.Connect(ip1, 443);
                _serverStatusMaster = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _serverStatusMaster = false;

            }
        }

        private void PingThreadSlave()
        {
            var tcpClient = new TcpClient();
            try
            {
                var ip1 = IPAddress.Parse(_startControl.ui_textBox_ip_slave.Text);
                tcpClient.Connect(ip1, 443);
                _serverStatusSlave = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _serverStatusSlave = false;

            }

        }



        private void LoginToServer(string username, string password, string host, bool isMaster)
        {
            _logonThread = new Thread(
                () =>
                {
                    _pingTimer.Enabled = false;
                    _client = new DataClientClass(username);
                    _logClient = new DataNetLogService();
                    _logClientService =
                        ScsServiceClientBuilder.CreateClient<IDataNetLogService>(new ScsTcpEndPoint(host, 443),
                            _logClient);
                    _clientService =
                        ScsServiceClientBuilder.CreateClient<IDataAdminService>(new ScsTcpEndPoint(host, 443), _client);
                    _clientService.Connected += ScsClient_Connected;

                    try
                    {
                        _clientService.Connect();
                        _logClientService.Connect();

                        _client.login += LoggedIn;
                        _client.block += BlockedByAdmin;
                        _client.loginFailed += LoginFailed;
                        _client.changePrivilages += ChangedPrivileges;
                        _client.logout += DeletedClient;
                        _client.symblolListRecieved += GroupSymbolChange;
                        _client.symbolListChanged += RefreshSymbols;
                        _client.groupChanged += RefreshGroups;
                        //_client.logoutServer += ServerStatusChanged;
                        _client.busySymbolListReceived += BusySymbolChanged;
                        _client.symbolPermissionChanged += RefreshSymbols;
                        _clientService.Disconnected += OnServerCrashed;

                        var logmsg = new DataAdminMessageFactory.LogMessage
                        {
                            Symbol = username,
                            LogType = DataAdminMessageFactory.LogMessage.Log.Login,
                            Group = ""
                        };


                        _logClientService.ServiceProxy.SendSimpleLog(logmsg);
                        Settings.Default.scHost = _startControl.ui_textBox_ip.Text;
                        Settings.Default.scHostSlave = _startControl.ui_textBox_ip_slave.Text;
                        Invoke((Action) (() =>
                        {
                            labelItem_server.Text = isMaster ? "Master" : "Slave";
                            styleManager1.MetroColorParameters = new MetroColorGeneratorParameters(Color.White,
                                isMaster ? Color.Green : Color.YellowGreen);

                            metroStatusBar1.Refresh();
                        }));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (_startControl != null)
                            _startControl.Invoke((Action) (() =>
                            {
                                if (isMaster)
                                {
                                    ToastNotification.Show(_startControl, "Can't connect. IP is incorrect");
                                    _startControl.ui_buttonX_logon.Enabled = true;
                                }
                                else
                                {
                                    Logout();
                                }
                            }
                                ));

                        return;
                    }
                    var loginMsg = new DataAdminMessageFactory.LoginMessage(username, password, 'd');
                    try
                    {
                        _clientService.ServiceProxy.Login(loginMsg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(ex.Message);
                    }
                }) {Name = "LogonThread", IsBackground = true};

            _logonThread.Start();
        }


        private void OnServerCrashed(object sender, EventArgs e)
        {
            if (_nowIsMaster)
            {
                _nowIsMaster = false;

                LoginToServer(Settings.Default.scUser1, Settings.Default.scPassword, Settings.Default.scHostSlave,
                    _nowIsMaster);
            }
            else
            {
                _nowIsMaster = true;

                LoginToServer(Settings.Default.scUser1,
                    Settings.Default.scPassword,
                    Settings.Default.scHost, _nowIsMaster);
            }
        }

        private void BusySymbolChanged(string busySymbolList)
        {


            _busySymbolList.BusySymbols.Clear();
            var xml = new XmlDocument();
            xml.LoadXml(busySymbolList);

            var bsymbols = xml.GetElementsByTagName("BSymbol");

            foreach (XmlElement item in bsymbols)
            {

                var iddd = item.GetElementsByTagName("ID");
                var itemId = Convert.ToInt32(iddd.Item(0).InnerText);

                var bsm = new BusySymbol();
                bsm.ID = itemId;

                foreach (XmlElement tfitem in item.GetElementsByTagName("TimeFrame"))
                {
                    bsm.TimeFrames.Add(new TimeFrameModel()
                    {
                        TimeFrame = tfitem.InnerText
                    });
                }
                _busySymbolList.BusySymbols.Add(bsm);

            }



            Task.Factory.StartNew(RefreshSymbols).Wait();
        }

        private void DeletedClient(object sender, object msg)
        {
            MessageBox.Show(msg.ToString());

            Invoke((Action) Close);
        }

        private void LoginFailed(object sender, DataAdminMessageFactory.LoginMessage msg)
        {
            _startControl.Invoke((Action) (() =>
            {
                ToastNotification.Show(_startControl, msg.ServerMessage);
                _startControl.ui_buttonX_logon.Enabled = true;
            }));

        }

        private void ScsClient_Connected(object sender, EventArgs e)
        {

        }

        private void LoggedIn(object sender, DataAdminMessageFactory.ChangePrivilage msg)
        {

            labelItemUserName.Text = "<" + _client.UserName + ">  " + Settings.Default.scHost;

            _missingBarManager.AllowCollectingAndMissingBar();
            _logined = true;
            _shouldStop = true;

            var xml = new XmlDocument();
            xml.LoadXml(msg.ServerMessage);

            string host = "";
            string dbName = "";
            string dbNameBar = "";

            string dbNameHist = "";

            string usName = "";
            string passw = "";

            var connString = xml.GetElementsByTagName("ConnectionString");
            var attr = connString[0].Attributes;
            if (attr != null)
            {
                host = (attr["Host"].Value);
                dbName = attr["dbName"].Value;
                dbNameBar = attr["dbNameBar"].Value;
                dbNameHist = attr["dbNameHist"].Value;

                usName = attr["userName"].Value;
                passw = attr["password"].Value;
            }
            _connectionToSharedDb = "SERVER=" + host + "; DATABASE=" + dbName + "; UID=" + usName + "; PASSWORD=" +
                                    passw;
            _connectionToSharedDbBar = "SERVER=" + host + "; DATABASE=" + dbNameBar + "; UID=" + usName + "; PASSWORD=" +
                                       passw;
            _connectionToSharedDbHistorical = "SERVER=" + host + "; DATABASE=" + dbNameHist + "; UID=" + usName +
                                              "; PASSWORD=" + passw;


            SetPrivilages(msg);

            CQGDataCollectorManager.Init(_client.UserName);

            //#Crashing
            Invoke((Action) (() =>
            {
                if (Settings.Default.IsCrashed && Settings.Default.WasConnected)
                {
                    if (Settings.Default.WasConnectedToShared)
                        ConnectToShared();
                    else
                        ConnectToLocal();


                    ContinueCollectingData();

                }


            }));
        }

        private void ContinueCollectingData() //#Crash
        {
            //#Crashing

            new Thread(() =>
            {
                Thread.Sleep(3000);
                var listIndex = GetInQueueGroups(Settings.Default.InQueueGroups);
                var groups = "";
                foreach (var index in listIndex)
                {
                    var state = GroupState.InQueue;
                    if (index >= _groupItems.Count) return;

                    _groupItems[index].GroupState = state;
                    Invoke(
                        (Action) delegate
                        {
                            //groupList4.ChangeState(index, state);
                            StateChanged(state,index);
                        });

                    groups += _groupItems[index].GroupModel.GroupName + ", ";

                    CQGDataCollectorManager.ChangeState(index, state);
                }
                var lll = GetInQueueGroups(Settings.Default.InProgressGroup);
                if (lll.Count != 0)
                    _logger.LogAdd(
                        " Application was crashes when collected group: " + _groupItems[lll[0]].GroupModel.GroupName,
                        Category.Warning);
                if (!string.IsNullOrEmpty(groups))
                    _logger.LogAdd(" Continue collecting groups: " + groups, Category.Information);
                CQGDataCollectorManager.Start();


                Settings.Default.IsCrashed = false;
                Settings.Default.Save();
            }).Start();
        }

        private List<int> GetInQueueGroups(string str)
        {
            var res = new List<int>();
            var list = str;
            while (!string.IsNullOrEmpty(list))
            {
                var s = list.IndexOf("[") + 1;
                var e = list.IndexOf("]");
                var l = e - s;

                res.Add(Convert.ToInt32(list.Substring(s, l)));
                list = list.Substring(e + 1, list.Length - e - 1);
            }
            return res;
        }

        private void ChangedPrivileges(object sender, DataAdminMessageFactory.ChangePrivilage msg)
        {
            SetPrivilages(msg);

        }

        private void SetPrivilages(DataAdminMessageFactory.ChangePrivilage msg)
        {
            if (msg == null) return;

            var privileges = msg;

            _client.Privileges.AnyIPAllowed = privileges.AnyIPAllowed;
            _client.Privileges.CollectSQGAllowed = privileges.CollectSQGAllowed;
            _client.Privileges.DatanetEnabled = privileges.DatanetEnabled;
            _client.Privileges.LocalDBAllowed = privileges.LocalDBAllowed;
            _client.Privileges.MissingBarFAllowed = privileges.MissingBarFAllowed;
            _client.Privileges.SharedDBAllowed = privileges.SharedDBAllowed;
            _client.Privileges.TicknetEnabled = privileges.TicknetEnabled;

            string sharedDbstring;
            Color sharedDbColor;

            string localDbstring;
            Color localDbColor;

            if (_client.Privileges.SharedDBAllowed)
            {
                sharedDbstring = "AVAILABLE";
                sharedDbColor = Color.Green;
            }
            else
            {
                sharedDbstring = "UNAVAILABLE";
                sharedDbColor = Color.OrangeRed;
            }


            if (_client.Privileges.LocalDBAllowed)
            {
                localDbstring = "AVAILABLE";
                localDbColor = Color.Green;
            }
            else
            {
                localDbstring = "UNAVAILABLE";
                localDbColor = Color.OrangeRed;
            }

            Task.Factory.StartNew(delegate
            {
                ui_buttonX_localConnect.Invoke(
                    (Action) delegate { ui_buttonX_localConnect.Enabled = _client.Privileges.LocalDBAllowed; });

                ui_buttonX_shareConnect.Invoke((Action) delegate
                {
                    ui_buttonX_shareConnect.Enabled = _client.Privileges.SharedDBAllowed;
                });
                ui_LabelX_localAvaliable.Invoke((MethodInvoker) delegate
                {
                    ui_LabelX_localAvaliable.Text = localDbstring;
                    ui_LabelX_localAvaliable.ForeColor = localDbColor;
                });
                ui_LabelX_sharedAvaliable.Invoke((MethodInvoker) delegate
                {
                    ui_LabelX_sharedAvaliable.Text = sharedDbstring;
                    ui_LabelX_sharedAvaliable.ForeColor = sharedDbColor;
                });

                _startControl.Invoke((Action) (() => _startControl.Hide()));
            });
        }

        private void BlockedByAdmin(object sender, object msg)
        {
            _client.BlockedByAdmin = true;
        }

        private void GroupSymbolChange(object sender, string groupList)
        {
            var xml = new XmlDocument();
            xml.LoadXml(groupList);
            var elemUserId = xml.GetElementsByTagName("UserID");
            var attr = elemUserId[0].Attributes;
            if (attr != null)
                _client.UserID = Convert.ToInt32(attr["ID"].Value);

            if (_client.ConnectedToSharedDb)
            {
                RefreshSymbols();
                RefreshGroups();
                //RefreshGroups();
            }
        }



        public void SendLog(List<string> symbols, DataAdminMessageFactory.LogMessage.Log logtype, string groupName,
            string timeFrame, bool started, bool finished, bool failed = false, string comments = "")
        {
            var status = started
                ? DataAdminMessageFactory.LogMessage.Status.Started
                : DataAdminMessageFactory.LogMessage.Status.Finished;

            if (symbols.Count > 0)
            {
                var logMsg = new DataAdminMessageFactory.LogMessage(_client.UserID, DateTime.Now, "",
                    logtype, groupName, status)
                {
                    IsByDataNetBusy = true,
                    IsDataNetClient = true,
                    IsTickNetClient = false,
                    TimeFrame = timeFrame,
                    Comments = comments

                };
                if (failed) logMsg.OperationStatus = DataAdminMessageFactory.LogMessage.Status.Aborted;

                var symb = symbols.Aggregate("", (current, symbol) => current + (symbol + ","));
                var index = symb.Count() - 1;
                symb = symb.Remove(index);
                logMsg.Symbol = symb;
                if (started)
                {
                    var tries = 0;
                    var errorHappened = false;
                    do
                    {
                        errorHappened = false;


                        try
                        {
                            Task.Factory.StartNew(() => _logClientService.ServiceProxy.SendStartedOperationLog(
                                logMsg)).Wait();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errorHappened = true;
                            tries++;
                        }

                    } while (tries < 3 && errorHappened);

                }
                else if (finished)
                {
                    logMsg.IsByDataNetBusy = false;
                    Task.Factory.StartNew(() => _logClientService.ServiceProxy.SendFinishedOperationLog(logMsg)).Wait();
                }

            }
            else
            {
                var logMsg = new DataAdminMessageFactory.LogMessage(_client.UserID, DateTime.Now, "", logtype, groupName,
                    status);
                if (started)
                {
                    logMsg.IsByDataNetBusy = true;
                    logMsg.IsDataNetClient = true;
                    logMsg.TimeFrame = timeFrame;
                    Task.Factory.StartNew(() => _logClientService.ServiceProxy.SendStartedOperationLog(logMsg)).Wait();


                }
                else if (finished)
                {
                    logMsg.IsByDataNetBusy = false;
                    logMsg.IsDataNetClient = true;
                    logMsg.TimeFrame = timeFrame;
                    _logClientService.ServiceProxy.SendFinishedOperationLog(logMsg);
                }
            }
        }

        #endregion

        #region CEL: CQGStatusChanged, Subscribe,  TicksReslved, BarsResolved

        private void CqgConnectionStatusChanged(bool isConnectionUp)
        {
            if (isConnectionUp)
            {
                _startControl.ui_labelX_CQGstatus.Text = @"CQG started";
                labelItemStatusCQG.Text = @"CQG started";
                _isStartedCqg = true;

            }
            else
            {
                _startControl.ui_labelX_CQGstatus.Text = @"CQG not started";
                labelItemStatusCQG.Text = @"CQG not started";
                _isStartedCqg = false;

            }
            Refresh();
        }


        private void CEL_InstrumentSubscribed(string symbol, CQGInstrument cqg_instrument)
        {
            _missingBarManager.SessionAdd(cqg_instrument.Sessions, symbol);
        }

        private void CEL_HistoricalSessionsResolved(CQGSessionsCollection cqg_historical_sessions,
            CQGHistoricalSessionsRequest cqg_historical_sessions_request, CQGError cqg_error)
        {
            _missingBarManager.HolidaysAdd(cqg_historical_sessions, cqg_historical_sessions_request.Symbol);
        }

        private void CEL_DataConnectionStatusChanged(eConnectionStatus eConnectionStatus)
        {
            CqgConnectionStatusChanged(eConnectionStatus == eConnectionStatus.csConnectionUp);
        }

        private void CEL_DataError(object cqg_error, string error_description)
        {
            try
            {
                var error = cqg_error as CQGError;
                if (error != null)
                {
                    if (error.Code == 0x66)
                    {
                        error_description = error_description + " Restart the application.";
                    }
                    else if (error.Code == 0x7d)
                    {
                        error_description = error_description + " Turn on CQG Client and restart the application.";
                    }
                }
                //MessageBox.Show(error_description, "DataNet", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                _logger.LogAdd(error_description, Category.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogAdd("CEL data eroor. " + ex, Category.Error);
            }
        }

        private void CEL_IncorrectSymbol(string symbol_)
        {
            _logger.LogAdd("Incorrect symbol", Category.Warning);
        }

        #endregion

        #region SYMBOLS EDIT CONTROL

        private void SymbolsEditControl_UpdateSymbolsEvent()
        {
            _clientService.ServiceProxy.onSymbolListRecieved("");
        }

        private void SymbolsEditControl_UpdateGroupsEvent()
        {
            _clientService.ServiceProxy.onSymbolGroupListRecieved("");
        }

        private void ui_ToolStripMenuItem_EditSymbols_Click(object sender, EventArgs e)
        {
            OpenSymbolEditControl();
        }

        private void OpenSymbolEditControl()
        {
            //var name = gridGroup.Rows[gridGroup.CurrentRow.Index].Cells[0].Value;
            //Console.WriteLine(gridGroup.CurrentCell.ColumnIndex);
            _symbolsEditControl = new SymbolsEditControl(_client.UserID) {Commands = _commands};
            _symbolsEditControl.UpdateSymbolsEvent += SymbolsEditControl_UpdateSymbolsEvent;
            _symbolsEditControl.UpdateGroupsEvent += SymbolsEditControl_UpdateGroupsEvent;
            ShowModalPanel(_symbolsEditControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
        }

        private void CancelNewSymbolExecuted(object sender, EventArgs e)
        {
            CloseAddSymbolControl();
            RefreshSymbols();
            RefreshGroups();
        }

        private void CloseAddSymbolControl()
        {
            if (_symbolsEditControl == null) return;
            CloseModalPanel(_symbolsEditControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
            _symbolsEditControl.Dispose();
            _symbolsEditControl = null;
        }

        #endregion

        #region LOGIN & LOGOUT

        private void StartControl_LogonClick(object sender, EventArgs e)
        {

            Settings.Default.scUser1 = _startControl.ui_textBoxX_login.Text;
            Settings.Default.scPassword = _startControl.ui_textBoxX_password.Text;
            Settings.Default.scHost = _startControl.ui_textBox_ip.Text;
            Settings.Default.scHostSlave = _startControl.ui_textBox_ip_slave.Text;

            Settings.Default.Save();
            _startControl.ui_buttonX_logon.Enabled = false;

            _nowIsMaster = true;
            LoginToServer(Settings.Default.scUser1, Settings.Default.scPassword,
                Settings.Default.scHost, _nowIsMaster);

            
        }

        private void StartControl_ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroShell1_LogOutButtonClick(object sender, EventArgs e)
        {
            Logout();
            //var tt = Convert.ToInt16("TestInt");
        }

        private void Logout()
        {
            if (!_logined) return;
            _logined = false;

            if (_serverStatusMaster)
                if (_clientService != null && _clientService.ServiceProxy != null)
                    _clientService.ServiceProxy.Logout("d", _client.UserName);

            if (_logonThread != null) _logonThread.Abort();

            ClientDatabaseManager.CloseConnectionToDbSystem();

            Invoke((Action) delegate
            {
                metroTabItem2.Visible = false;
                metroTabItem3.Visible = false;
                metroShell1.SelectedTab = metroTabItem1;


                ClientDatabaseManager.CloseConnectionToDbSystem();
                RefreshGroups();
                RefreshSymbols();
                _client = null;
                _startControl.Dispose();
                _startControl = new StartControl {Commands = _commands};
                Controls.Add(_startControl);
                _startControl.BringToFront();
                _startControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
                UpdateControlsSizeAndLocation();
                _startControl.ui_textBox_ip.Text = Settings.Default.scHost;
                _pingTimer.Enabled = true;
            });

        }

        #endregion

        #region CONNECTION TO DB

        private void Ui_ButtonX_ShareConnect_Click(object sender, EventArgs e)
        {
            ConnectToShared();

            CQGDataCollectorManager.ChangeMode(_autocollect);
            buttonX_StartCollectGroups.Enabled = !_autocollect;

        }

        private void ConnectToShared()
        {
            if (ClientDatabaseManager.CurrentDbIsShared) return;

            ClientDatabaseManager.ConnectToShareDb(_connectionToSharedDb, _connectionToSharedDbBar,
                _connectionToSharedDbHistorical, "", _client.UserID);

            _client.ConnectedToSharedDb = true;
            _client.ConnectedToLocalDb = false;

            RefreshGroups();
            RefreshSymbols();
            Refresh();
            UpdateControlsSizeAndLocation();

            Settings.Default.WasConnected = ClientDatabaseManager.IsConnected();
            Settings.Default.WasConnectedToShared = ClientDatabaseManager.CurrentDbIsShared;
            Settings.Default.Save();

        }

        private void Ui_ButtonX_LocalConnect_Click(object sender, EventArgs e)
        {
            ConnectToLocal();

           CQGDataCollectorManager.ChangeMode(_autocollect);
           buttonX_StartCollectGroups.Enabled = !_autocollect;
           superGridControl1.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.Fill;
           superGridControl1.PrimaryGrid.PrimaryColumn.MinimumWidth = 50;
           superGridControl1.PrimaryGrid.PrimaryColumn.FillWeight = 50;
           superGridControl1.PrimaryGrid.LastVisibleColumn.FillWeight = 200;
           superGridControl1.PrimaryGrid.LastVisibleColumn.MinimumWidth = 100;
        }

        private void ConnectToLocal()
        {

            if (ClientDatabaseManager.IsConnected() && !ClientDatabaseManager.CurrentDbIsShared) return;

            var dbName = ui_home_textBoxX_db.Text;
            var dbNameBar = ui_home_textBoxX_db_bar.Text;
            var dbNameHist = ui_home_textBoxX_db_historical.Text;
            var host = ui_home_textBoxX_host.Text;
            var usName = ui_home_textBoxX_uid.Text;
            var passw = ui_home_textBoxX_pwd.Text;
            _connectionToLocalDb = "SERVER=" + host + "; DATABASE=" + dbName + "; UID=" + usName + "; PASSWORD=" + passw;
            _connectionToLocalDbBar = "SERVER=" + host + "; DATABASE=" + dbNameBar + "; UID=" + usName + "; PASSWORD=" +
                                      passw;
            _connectionToLocalDbHistorical = "SERVER=" + host + "; DATABASE=" + dbNameHist + "; UID=" + usName +
                                             "; PASSWORD=" + passw;


            ClientDatabaseManager.ConnectToLocalDb(_connectionToLocalDb, _connectionToLocalDbBar,
                _connectionToLocalDbHistorical, "", _client.UserID);
            _client.ConnectedToSharedDb = false;
            _client.ConnectedToLocalDb = true;

            RefreshGroups();
            RefreshSymbols();
            Refresh();
            UpdateControlsSizeAndLocation();

            Settings.Default.WasConnected = ClientDatabaseManager.IsConnected();
            Settings.Default.WasConnectedToShared = ClientDatabaseManager.CurrentDbIsShared;
            Settings.Default.Save();
        }

        private void ClientDataManager_ConnectionStatusChanged(bool connected, bool isShared)
        {
            var strConn = connected ? @"Connnected to " + (isShared ? @"Shared DB" : @"Local DB") : "Not connected";
            Invoke((Action) delegate
            {
                ui_status_labelItemStatusSB.Text = strConn;
                if (connected)
                {
                    metroTabItem2.Visible =
                        metroTabItem3.Visible =
                            metroTabItem5.Visible = true;
                    metroShell1.SelectedTab = metroTabItem2;
                    RefreshSymbols();
                    RefreshGroups();
                }
                else
                {
                    ToastNotification.Show(metroTabPanel1, @"Can't connect to DB", eToastPosition.TopCenter);
                    metroTabItem2.Visible =
                        metroTabItem3.Visible =
                            metroTabItem5.Visible = false;
                }
            });
        }

        #endregion

        #region Updates (RefreshSymbols, Groups)
        static DataSet1 dataSet = new DataSet1();
        
        private void RefreshGroups()
        {
            ClientDatabaseManager.GetUSerInfo(_client.UserID, out _autocollect, out _emeilAfterFinishing, out _barStart, out _barEnd);
            dataSet.Clear();
           
            //groupList4.ClearAllItems();
            if (_client == null) return;
            if (!_client.ConnectedToLocalDb && !_client.ConnectedToSharedDb) return;

            if (!ClientDatabaseManager.IsConnected()) return;

            _groupItems = new List<GroupItemModel>();

            var groups = ClientDatabaseManager.GetGroupsForUser(_client.UserID, ApplicationType.DataNet);

            //display
            groups = OrderListOfGroups(ClientDatabaseManager.SortingModeIsAsc, groups);

            //groupList4.SetItemsCount(groups.Count);
            for (int i = 0; i < groups.Count; i++)
            {
                var groupModel = groups[i];
                var symbols =
                    ClientDatabaseManager.GetSymbolsInGroup(groupModel.GroupId).Select(oo => oo.SymbolName).ToList();
                var sessions = ClientDatabaseManager.GetSessionsInGroup(groupModel.GroupId);

                _groupItems.Add(
                    new GroupItemModel
                    {
                        GroupModel = groupModel,
                        GroupState = GroupState.NotInQueue,
                        AllSymbols = symbols,
                        CollectedSymbols = new List<string>(),
                    });
                Invoke((Action) (() =>
                {
                    //styledListControl1.SetItem(i, groupModel.GroupName, GroupState.NotInQueue,
                     //   groupModel.End, "[" + symbols.Count + "]", symbols, sessions, groupModel.TimeFrame,
                     //   groupModel.IsAutoModeEnabled);
                    
                    //groupList4.ListForGroup = _groupItems[i];
                    //todo add all session
                    var session = ClientDatabaseManager.GetSessionsInGroup(groups[i].GroupId);
                    string s="", ss="";
                    if (session.Count > 0) s = session[0].TimeStart.ToString();
                    if (session.Count > 0) ss = session[0].Days;
                    string sss =_groupItems[i].CollectedSymbols.Count + "/" +
                                 _groupItems[i].AllSymbols.Count;
                    //groupList4.SetItem(i, groupModel, _groupItems[i], ClientDatabaseManager.GetSessionsInGroup(groups[i].GroupId));
                    //gridGroup.Rows.Add(groupModel.GroupName, groupModel.TimeFrame, groupModel.End, groupModel.CntType,
                      //  _groupItems[i].GroupState, sss,
                        //groupModel.IsAutoModeEnabled, s, ss);

                    var _userValues = new ArrayList
                    {
                        i,
                        groupModel.GroupName,
                        groupModel.TimeFrame,
                         groupModel.End.ToString(),
                         groupModel.CntType,
                        _groupItems[i].GroupState,
                        sss,
                        groupModel.IsAutoModeEnabled,
                        s,
                        ss
                    };

                    var _userRow = dataSet.my_tbl.NewRow();

                    _userRow.ItemArray = _userValues.ToArray();
                    dataSet.my_tbl.Rows.Add(_userRow);
                    dataSet.AcceptChanges();

                    List <SymbolModel> sm= ClientDatabaseManager.GetSymbolsInGroup(groupModel.GroupId);
                    var max = sm.Count >= session.Count ? sm.Count : session.Count;
                    for (int index = 0; index < max; index++)
                    {
                        string time = "";
                        string days = "";
                        string symbolName="";
                        if (index < session.Count)
                        {
                            time = session[index].TimeStart.ToString();
                            days = session[index].Days;
                        }
                        string mintime="";
                        string maxtime="";
                        if (index < sm.Count)
                        {
                            symbolName = sm[index].SymbolName;

                            if (groupModel.TimeFrame == "tick")
                            {
                                string minname = ClientDatabaseManager.GetTickTableFromSymbolMin(symbolName);
                                mintime = minname != "" ? ClientDatabaseManager.GetMinTime(minname).ToString() : "";
                                string maxname = ClientDatabaseManager.GetTickTableFromSymbolMax(symbolName);
                                maxtime = maxname != "" ? ClientDatabaseManager.GetMaxTime(maxname).ToString() : "";
                            }
                            else
                            {
                                mintime =
                                    ClientDatabaseManager.GetMinTimeBar(
                                        ClientDatabaseManager.GetBarTableFromSymbol(symbolName,
                                            CQGDataCollectorManager.GetTableType(
                                                CQGDataCollectorManager._historicalPeriod))).ToString();
                                maxtime =
                                    ClientDatabaseManager.GetMaxTimeBar(
                                        ClientDatabaseManager.GetBarTableFromSymbol(symbolName,
                                            CQGDataCollectorManager.GetTableType(
                                                CQGDataCollectorManager._historicalPeriod))).ToString();
                            }
                        }
                        var userValues = new ArrayList
                        {
                            i,
                            index+1,
                            symbolName,
                            "",
                            "",
                            "",
                            mintime,
                            maxtime,
                            "",
                            time,
                            days
                        };
                        var userRow = dataSet.tbl_sym.NewRow();
                        userRow.ItemArray = userValues.ToArray();
                        dataSet.tbl_sym.Rows.Add(userRow);
                        dataSet.AcceptChanges();
                    }
                }));
            }
            superGridControl1.PrimaryGrid.DataSource = dataSet;
            
            //styledListControl1.StateChangingEnabled = !switchButton_changeMode.Value;
            
            var listOfTime = new List<SessionModel>();
            var listOfNameSymbol = new List<string>();
            var listOfNameDays = new List<string>();
            foreach (var groupModel in _groupItems)
            {
                
                var lastCollectedDay = groupModel.GroupModel.End.DayOfWeek;
                var lastCollectedTime = groupModel.GroupModel.End;
                var todayDay = DateTime.Now.DayOfWeek;

                var sess = ClientDatabaseManager.GetSessionsInGroup(groupModel.GroupModel.GroupId);
                
                foreach (SessionModel ss in sess)
                {
                    var days = ConvertWeekDay(ss.Days);
                    foreach (DayOfWeek dayOfWeek in days)
                    {
                        if (Convert.ToInt32(dayOfWeek) < Convert.ToInt32(todayDay) && Convert.ToInt32(dayOfWeek) > Convert.ToInt32(lastCollectedDay))
                        {
                            //todo add
                            listOfTime.Add(ss);
                            listOfNameDays.Add(dayOfWeek.ToString());
                            listOfNameSymbol.Add(groupModel.GroupModel.GroupName);
                        }
                        if (Convert.ToInt32(dayOfWeek) == Convert.ToInt32(todayDay) && (lastCollectedTime.TimeOfDay < ss.TimeStart.TimeOfDay &&
                            ss.TimeStart.TimeOfDay < DateTime.Now.TimeOfDay))
                        {
                            //todo add
                            listOfTime.Add(ss);
                            listOfNameDays.Add(dayOfWeek.ToString());
                            listOfNameSymbol.Add(groupModel.GroupModel.GroupName);
                        }
                        if (Convert.ToInt32(dayOfWeek) == Convert.ToInt32(lastCollectedDay) && ss.TimeStart.TimeOfDay > lastCollectedTime.TimeOfDay &&
                            Convert.ToInt32(todayDay) != Convert.ToInt32(lastCollectedDay))
                        {
                            //todo add
                            listOfTime.Add(ss);
                            listOfNameDays.Add(dayOfWeek.ToString());
                            listOfNameSymbol.Add(groupModel.GroupModel.GroupName);
                        }
                  }
                }
            }
            var myform = new MyFormAuto(listOfTime,listOfNameSymbol,listOfNameDays);
            
            myform.ShowDialog();
            CQGDataCollectorManager.LoadGroups(_groupItems);
        }

        private static List<DayOfWeek> ConvertWeekDay(string days)
        {
            var daysof = new List<DayOfWeek>();

            if (days[0] != '_') daysof.Add(DayOfWeek.Sunday);
            if (days[1] != '_') daysof.Add(DayOfWeek.Monday);
            if (days[2] != '_') daysof.Add(DayOfWeek.Tuesday);
            if (days[3] != '_') daysof.Add(DayOfWeek.Wednesday);
            if (days[4] != '_') daysof.Add(DayOfWeek.Thursday);
            if (days[5] != '_') daysof.Add(DayOfWeek.Friday);
            if (days[6] != '_') daysof.Add(DayOfWeek.Saturday);
            
            //return (daysof.Contains(DateTime.Today.DayOfWeek));
            return daysof;
        }

        static int i;
        private static int totalrows;
        public static int minrows = 9999999;
        public static int maxrows;
        public static DateTime mintime;
        public static DateTime maxtime;

        public static void ChangeSymbolInformation(int ind,string symbol, bool isCorrect,int realyInsertedRowsCount,string comments,string totaltime, string minTime,string maxTime)
        {
            var index = 0;
            i = 0;
            foreach (DataRow sym in dataSet.Tables[0].Rows)
            {
                if (ind == index)
                {
                    var item = sym.GetChildRows("1");
                    
                    foreach (var variable in item)
                    {
                        if ((string) variable.ItemArray[2] == symbol)
                        {
                            dataSet.tbl_sym.Rows[i].BeginEdit();
                            dataSet.tbl_sym.Rows[i][3] = totaltime;
                            dataSet.tbl_sym.Rows[i][4] = realyInsertedRowsCount.ToString();
                            dataSet.tbl_sym.Rows[i][5] = isCorrect ? "[Successful]" : "[Unsuccessful]";
                            dataSet.tbl_sym.Rows[i][6] = minTime;
                            dataSet.tbl_sym.Rows[i][7] = maxTime;
                            dataSet.tbl_sym.Rows[i][8] = comments;
                            dataSet.tbl_sym.Rows[i].EndEdit();
                            dataSet.tbl_sym.AcceptChanges();
                            totalrows += realyInsertedRowsCount;
                        }
                        i++;
                    }
                }
                else
                {
                    var item = sym.GetChildRows("1");

                    foreach (var variable in item)
                    {
                        i++;
                    }
                }
                index++;
            }
        }

        private List<GroupModel> OrderListOfGroups(bool asc, List<GroupModel> list)
        {
            List<GroupModel> reslist = list;

            if (_sortMode == 1)
                reslist = list.OrderBy(oo => oo.GroupName).ToList();
            if (_sortMode == 2)
                reslist = list.OrderBy(oo => oo.TimeFrame).ToList();
            if (_sortMode == 3)
                reslist = list.OrderBy(oo => oo.End).ToList();

            if (asc) reslist.Reverse();

            return reslist;
        }

        private void RefreshSymbols()
        {
            lock (_lockRefreshSymbols)
            {
                if (_client == null) return;
                if (!_client.ConnectedToLocalDb && !_client.ConnectedToSharedDb) return;
                if (!ClientDatabaseManager.IsConnected()) return;

                ClientDatabaseManager.Commit();
                _symbols = ClientDatabaseManager.GetSymbols(_client.UserID, false);

                //ui_listBox_symbols.Invoke((Action) (() => listBox_daily_symbols.Items.Clear()));
                //ui_listBox_symbols.Invoke((Action) (() => ui_listBox_symbols.Items.Clear()));
                ui_listBox_symbolsForMissing.Invoke((Action) (() => ui_listBox_symbolsForMissing.Items.Clear()));

                foreach (var item in _symbols)
                {
                    var item1 = item;

                    //ui_listBox_symbols.Invoke((Action) (() => listBox_daily_symbols.Items.Add(item1.SymbolName)));
                   // ui_listBox_symbols.Invoke((Action) (() => ui_listBox_symbols.Items.Add(item1.SymbolName)));
                    ui_listBox_symbolsForMissing.Invoke(
                        (Action) (() => ui_listBox_symbolsForMissing.Items.Add(item1.SymbolName)));
                }
            }
        }

        #endregion

        #region UI ContextMenu Symbols

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* for (int i = 0; i < ui_listBox_symbols.Items.Count; i++)
            {
                ui_listBox_symbols.SetSelected(i, true);
            }*/
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < ui_listBox_symbols.Items.Count; i++)
            {
                ui_listBox_symbols.SetSelected(i, false);
            }*/
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ui_listBox_symbolsForMissing.Items.Count; i++)
            {
                ui_listBox_symbolsForMissing.SetSelected(i, true);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ui_listBox_symbolsForMissing.Items.Count; i++)
            {
                ui_listBox_symbolsForMissing.SetSelected(i, false);
            }
        }

        #endregion

        #region UI ContextMenus GROUPS

        private void NewGroupNewSymbolExecuted(object sender, EventArgs e)
        {
            CloseAddSymbolControl();

            _addListControl = new AddListControl {Commands = _commands, OpenSymbolControl = true};
            //ShowModalPanel(_addListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
            
        }

        private void EditGroupNewSymbolExecuted(object sender, EventArgs e)
        {
            if (_symbolsEditControl.ui_listBox_groups.SelectedItem == null)
            {
                ToastNotification.Show(_symbolsEditControl.ui_listBox_groups, "Pleasse, select group!");
                return;
            }

            var groupName = _symbolsEditControl.ui_listBox_groups.SelectedItem.ToString();
            var oldGroupInfo =
                ClientDatabaseManager.GetGroupsForUser(_client.UserID, ApplicationType.DataNet)
                    .First(oo => oo.GroupName == groupName);

            _editListControl = new EditListControl(oldGroupInfo.GroupId, oldGroupInfo)
            {
                Commands = _commands,
                textBoxXListName = {Text = oldGroupInfo.GroupName},
                OpenSymbolControl = true
            };

            foreach (var item in _editListControl.cmbHistoricalPeriod.Items)
            {
                if (item.ToString() == oldGroupInfo.TimeFrame)
                {
                    _editListControl.cmbHistoricalPeriod.SelectedItem = item;
                    _editListControl.cmbHistoricalPeriod.Text = item.ToString();
                }
            }

            foreach (var item in _editListControl.cmbContinuationType.Items)
            {
                if (item.ToString() == oldGroupInfo.CntType)
                {
                    _editListControl.cmbContinuationType.SelectedItem = item;
                    _editListControl.cmbContinuationType.Text = item.ToString();
                }
            }

            var symbols = ClientDatabaseManager.GetSymbolsInGroup(oldGroupInfo.GroupId);

            foreach (var symbol in symbols)
            {
                _editListControl.lbSelList.Items.Add(symbol.SymbolName);
            }

            CloseAddSymbolControl();

            ShowModalPanel(_editListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
        }


        private void AddListControl_CancelClick(object sender, EventArgs e)
        {
            CloseAddListControl();
        }

        private void AddListControl_SaveClick(object sender, EventArgs e)
        {
            var group = new GroupModel
            {
                GroupName = _addListControl.textBoxXListName.Text,
                TimeFrame = _addListControl.cmbHistoricalPeriod.SelectedItem.ToString(),
                Start = new DateTime(),
                End = new DateTime(),
                CntType = _addListControl.cmbContinuationType.SelectedItem.ToString()
            };

            if (!_groupItems.Exists(a => a.GroupModel.GroupName == group.GroupName) &&
                !ClientDatabaseManager.GetAllGroups(ApplicationType.DataNet).Exists(a => a.GroupName == group.GroupName))
            {
                if (ClientDatabaseManager.AddGroupOfSymbols(group))
                {
                    group.GroupId = ClientDatabaseManager.GetGroupIdByName(group.GroupName);

                    ClientDatabaseManager.AddGroupForUser(_client.UserID, group, ApplicationType.DataNet);
                    //groupList4.GroupModels = group;
                    var symbols =
                    ClientDatabaseManager.GetSymbolsInGroup(group.GroupId).Select(oo => oo.SymbolName).ToList();
                    var sessions = ClientDatabaseManager.GetSessionsInGroup(group.GroupId);
                    var groupItem = new GroupItemModel
                    {
                        GroupModel = group,
                        GroupState = GroupState.NotInQueue,
                        AllSymbols = symbols,
                        CollectedSymbols = new List<string>(),
                    };
                    //groupList4.GroupItems = groupItem;
                    //groupList4.AddItem(group,groupItem, new List<SessionModel>());
                    RefreshGroups();

                    _clientService.ServiceProxy.onSymbolGroupListRecieved("");

                    CloseAddListControl();
                }
            }
            else
            {
                ToastNotification.Show(_addListControl, @"List with this name is already exists!");
            }

        }

        private void CloseAddListControl()
        {
            //CloseModalPanel(_addListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
            //_addListControl.Dispose();
            //_addListControl = null;

        }

        private void CancelEditListExecuted(object sender, EventArgs e)
        {
            CloseEditListControl();
            RefreshGroups();
        }

        private void EditListControl_SaveClick(object sender, EventArgs e)
        {
            var group = new GroupModel
            {
                GroupName = _editListControl.textBoxXListName.Text,
                TimeFrame = _editListControl.cmbHistoricalPeriod.SelectedItem.ToString(),
                Start = new DateTime(),
                End = new DateTime(),
                CntType = _editListControl.cmbContinuationType.SelectedItem.ToString(),
                IsAutoModeEnabled = _editListControl.checkBox_AutoCollec.Checked,
            };

            var oldGroupName = _editListControl.OldGroupName;

            if ((!_groupItems.Exists(a => a.GroupModel.GroupName == group.GroupName) &&
                 _groupItems.Exists(a => a.GroupModel.GroupName == oldGroupName)) ||
                (group.GroupName == oldGroupName && _groupItems.Exists(a => a.GroupModel.GroupName == oldGroupName)))
            {
                var groupId = _groupItems.Find(a => a.GroupModel.GroupName == oldGroupName).GroupModel.GroupId;
                ClientDatabaseManager.EditGroupOfSymbols(groupId, group);
                var symbolsInGroup = ClientDatabaseManager.GetSymbolsInGroup(groupId);
                foreach (var item in _editListControl.lbSelList.Items)
                {
                    if (!symbolsInGroup.Exists(a => a.SymbolName == item.ToString()) &&
                        _symbols.Exists(a => a.SymbolName == item.ToString()))
                    {
                        var symbol = _symbols.Find(a => a.SymbolName == item.ToString());
                        ClientDatabaseManager.AddSymbolIntoGroup(groupId, symbol);


                    }
                }
                var ses = ClientDatabaseManager.GetSessionsInGroup(groupId);
                //groupList4.ClearAllSession();
                //groupList4.AddSession(groupId,ses);
                symbolsInGroup = ClientDatabaseManager.GetSymbolsInGroup(groupId);
                foreach (var symbol in symbolsInGroup)
                {
                    var exist = false;
                    foreach (var item in _editListControl.lbSelList.Items)
                    {
                        if (symbol.SymbolName == item.ToString()) exist = true;
                    }
                    if (!exist) ClientDatabaseManager.DeleteSymbolFromGroup(groupId, symbol.SymbolId);
                }

                RefreshGroups();

                CloseEditListControl();
            }
            else
            {
                ToastNotification.Show(_editListControl, @"List with this name is already exists!");
            }
        }

        private void CloseEditListControl()
        {
            var start = _editListControl.OpenSymbolControl;
            if (_editListControl == null) return;
            CloseModalPanel(_editListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
            _editListControl.Dispose();
            _editListControl = null;

            if (start)
            {
                OpenSymbolEditControl();
            }

            _clientService.ServiceProxy.onSymbolGroupListRecieved("");
        }

        #endregion

        #region UI OTHERS (ResetColors, DownClick, MouseMove)


        private void styledListControl1_ItemEditGroupClick(int itemIndex)
        {

            var groupName = _groupItems[itemIndex].GroupModel.GroupName;
            var oldGroupInfo = _groupItems[itemIndex].GroupModel;

            _editListControl = new EditListControl(oldGroupInfo.GroupId, oldGroupInfo)
            {
                Commands = _commands,
                textBoxXListName = {Text = oldGroupInfo.GroupName},
                OpenSymbolControl = false
            };

            foreach (var item in _editListControl.cmbHistoricalPeriod.Items)
            {
                if (item.ToString() == oldGroupInfo.TimeFrame)
                {
                    _editListControl.cmbHistoricalPeriod.SelectedItem = item;
                    _editListControl.cmbHistoricalPeriod.Text = item.ToString();
                }
            }

            foreach (var item in _editListControl.cmbContinuationType.Items)
            {
                if (item.ToString() == oldGroupInfo.CntType)
                {
                    _editListControl.cmbContinuationType.SelectedItem = item;
                    _editListControl.cmbContinuationType.Text = item.ToString();
                }
            }

            var symbols = ClientDatabaseManager.GetSymbolsInGroup(oldGroupInfo.GroupId);
            foreach (var symbol in symbols)
            {
                _editListControl.lbSelList.Items.Add(symbol.SymbolName);
            }

            ShowModalPanel(_editListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
        }


        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {
            var form2 = new FormSettings(_client.UserID);
            form2.ShowDialog();
        }


        private void ResetColorMarks()
        {
            _lbxColors = new List<Brush>();
        }

        private void listBoxSymbols_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var listBox = (ListBox) sender;
                int index = listBox.IndexFromPoint(e.Location);
                if (index > -1 && index < listBox.Items.Count)
                {
                    string tip = listBox.Items[index].ToString();
                    if (tip != _lastTip)
                    {
                        toolTip1.SetToolTip(listBox, tip);
                        _lastTip = tip;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogAdd("listBoxSymbols_MouseMove. " + ex.Message, Category.Error);
            }
        }

        private void progressBarItemCollecting_ValueChanged(object sender, EventArgs e)
        {
            Invoke((Action) (() =>
            {
                metroStatusBar1.Refresh();
                progressBarItemCollecting.Tooltip = progressBarItemCollecting.Value + "%";
            })
                );

        }

        #endregion

        #region COLLECING & MISSING BAR

        private void StartMissingBar(List<string> symbols, bool isAuto)
        {
            _semaphoreWaitEndCollecting = new Semaphore(0, 1);
            Invoke((Action) delegate
            {
                progressBarItemCollecting.Value = 0;
                ui_buttonX_localConnect.Enabled = false;
                ui_buttonX_shareConnect.Enabled = false;
                ui_metroTileItem_missingBar.Enabled = false;
                listViewResult.Groups.Clear();
                listViewResult.Items.Clear();
            });

            //todo
            var maxCount =ClientDatabaseManager.GetBarEnd(_client.UserID);;


            _missingBarManager.StartMissingBar(symbols, _cel, isAuto, maxCount);
        }

        /*
        private void StartCollectingSymbols(List<string> symbols,bool calledFromGroup, bool onlySymbol=false )
        {
            var thread = new Thread(()=>
                        {
                            lock(_collectingLock)
                            {
                                if (onlySymbol)
                                {
                                    _semaphoreWaitEndCollecting = new Semaphore(0, 1);
                                }
                                if (_shouldStop) return;
                                int rangeStart = 0, rangeEnd = 0, sessionFilter = 0;
                                DateTime rangeDateStart = new DateTime(),
                                         rangeDateEnd = new DateTime();
                                bool isBars = false;
                                string continuationType = null, historicalPeriod = null;

                                Invoke((Action) delegate
                                                    {
                                                        progressBarItemCollecting.Value = 0;
                                                        ui_buttonX_localConnect.Enabled = false;
                                                        ui_buttonX_shareConnect.Enabled = false;                                                 
                                                        ui_metroTileItem_missingBar.Enabled = false;

                                                        rangeStart = Convert.ToInt32(nudStartBar.Value);
                                                        rangeEnd = Convert.ToInt32(nudEndBar.Value);
                                                        sessionFilter = rdb1.Checked ? 1 : 31;
                                                        rangeDateStart = dateTimeInputStart.Value.Date;
                                                        rangeDateEnd = dateTimeInputEnd.Value;
                                                        isBars = radioButBars.Checked;
                                                        continuationType = cmbContinuationType.SelectedItem.ToString();
                                                        historicalPeriod = cmbHistoricalPeriod.SelectedItem.ToString();
                                                    });

                                if (_client.ConnectedToSharedDb)
                                {
                                    foreach (var busySymbol in _busySymbolList.BusySymbols)
                                    {
                                        var busySymbolName = _symbols.Find(a => a.SymbolId == busySymbol.ID).SymbolName;

                                        if (symbols.Exists(a => a == busySymbolName))
                                        {
                                            var ssmb =
                                                _busySymbolList.BusySymbols.Find(
                                                    o =>
                                                    o.ID ==
                                                    _symbols.Find(oo => oo.SymbolName == busySymbolName).SymbolId);
                                            if(ssmb.TimeFrames.Exists(oo=> oo.TimeFrame == historicalPeriod))
                                            {
                                                symbols.Remove(busySymbolName);
                                                _logger.LogAdd(
                                                "Symbol " + busySymbolName + " is busy",
                                                Category.Warning);
                                            }
                                                
                                        }
                                    }
                                }
                                if (!isBars) historicalPeriod = "tick";
                             if(!calledFromGroup) Task.Factory.StartNew(() => SendLog(symbols,
                                                                    DataAdminMessageFactory.LogMessage.Log.CollectSymbol,
                                                                    "", historicalPeriod, true,
                                                                    false)).Wait();

                                _dataCollector.StartCollectingSymbols(symbols, _cel, isBars,
                                                                      rangeDateStart,
                                                                      rangeDateEnd,
                                                                      sessionFilter,
                                                                      historicalPeriod,
                                                                      continuationType,
                                                                      rangeStart,
                                                                      rangeEnd);
                                if (onlySymbol)
                                {
                                    _semaphoreWaitEndCollecting.WaitOne();

                                    if (ui_checkBoxAuto_CheckForMissedBars.Value)
                                        StartMissingBar(symbols, true);

                                }
                            }
                        });
            thread.Start();
            
        }

        private void StartCollectingGroups(List<string> groups)
        {
         
            var thread = new Thread(()=>
                                                        {
                var symbolsInAllGroups = new List<string>();
                _semaphoreWaitEndCollecting= new Semaphore(0,1);
                for (int i = 0; i < groups.Count(); i++)
                {
                    if (_shouldStop) return;
                    var groupName = groups[i];
                    var group = _groupItems.Find(a => a.GroupModel.GroupName == groupName).GroupModel;
                    if (_shouldStop) return;
                    _logger.LogAdd(" Start collecting group: "+groupName, Category.Information);

                    Task.Factory.StartNew(() => SendLog(new List<string>(), DataAdminMessageFactory.LogMessage.Log.CollectGroup,
                                                        groupName,
                                                        @group.TimeFrame, true, false)).Wait();
                    
                    Invoke((Action) delegate
                                        {
                                            cmbHistoricalPeriod.SelectedItem = group.TimeFrame;
                                            cmbContinuationType.SelectedItem = group.CntType;
                                            dateTimeInputStart.Value = group.Start;
                                            dateTimeInputEnd.Value = group.End;
                                            if(group.TimeFrame == "tick") radioButtonTick.Checked = true;
                                            else radioButBars.Checked = true;
                                        }
                        );

                    if (_shouldStop) return;
                    var symbols = DatabaseManager.GetSymbolsInGroup(group.GroupId).Select(a => a.SymbolName).ToList();

                    symbolsInAllGroups.AddRange(symbols.Where(smb => !symbolsInAllGroups.Exists(a=>a==smb)));

                    if (_shouldStop) return;
                    StartCollectingSymbols(symbols,true);

                    _semaphoreWaitEndCollecting.WaitOne();
                   
                    Task.Factory.StartNew(() => SendLog(new List<string>(), DataAdminMessageFactory.LogMessage.Log.CollectGroup,
                                                        groupName,
                                                        @group.TimeFrame, false, true)).Wait();
                    _logger.LogAdd(" Finished collecting group: " + groupName, Category.Information);
                }
                var isAuto = ui_checkBoxAuto_CheckForMissedBars.Value;
                if (isAuto)
                {
                    if (_shouldStop) return;
                    StartMissingBar(symbolsInAllGroups, true);
                }
                                                        }) {Name = "Groups Thread"};

            thread.Start();
        }

        private void StopCollecting()
        {
            if(_shouldStop) return;

            _shouldStop = true;
            _dataCollector.StopCollecting();

            _logger.LogAdd(@" Collecting stoped!!!", Category.Warning);
            _cel.Shutdown();
            _cel.Startup();
        }

        private void StopMissingBar()
        {
            
        }
        */

        private void DataCollector_MissingBarStart(string symbolName)
        {
            _logger.LogAdd("   Start missing bar for symbol: " + symbolName, Category.Information);
        }

        private void DataCollector_MissingBarEnd(string symbolName, List<ListViewGroup> groups, List<ListViewItem> items)
        {
            _logger.LogAdd("   Finished missing bar for symbol: " + symbolName, Category.Information);

            Invoke((Action) delegate
            {
                ui_buttonX_localConnect.Enabled = true;
                ui_buttonX_shareConnect.Enabled = true;
                ui_metroTileItem_missingBar.Enabled = true;

                listViewResult.Groups.AddRange(groups.ToArray());
                listViewResult.Items.AddRange(items.ToArray());
            });

        }

        private void DataCollector_Finished()
        {

            Invoke((Action) delegate
            {
                ui_buttonX_localConnect.Enabled = true;
                ui_buttonX_shareConnect.Enabled = true;

                ui_metroTileItem_missingBar.Enabled = true;
                _semaphoreWaitEndCollecting.Release();
            });


        }

        #endregion


        private void ui__status_labelItem_status_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }


        #region CQG COLLECTING GROUPS

        private DateTime _timeLastCollecting;

        private void CQGDataCollectorManager_CollectedSymbolCountChanged(int index, string symbol, int count,
            int totalCount, bool isCorrect, int realyInsertedRowsCount, string comments)
        {
            Invoke((Action) (() =>
            {
                if (index == -1)
                {
                    ui__status_labelItem_status.Text = "Collecting:  [" + count + "/" + totalCount + "]";

                    _logger.LogAdd(
                        @"  |  Symbol '" + symbol + "' collected [" + (isCorrect ? "Success" : "Unsuccessful") +
                        "] Inserted:" + realyInsertedRowsCount, isCorrect ? Category.Information : Category.Warning);


                    if (count == totalCount)
                        ui__status_labelItem_status.Text = "Collecting finished.";
                    return;
                }
                if (count != 0)
                {
//                    Task.Factory.StartNew(() => SendLog(new List<string>{symbol}, DataAdminMessageFactory.LogMessage.Log.CollectSymbol, "", _groupItems[index].GroupModel.TimeFrame, true, false)).Wait();
                    Task.Factory.StartNew(
                        () =>
                            SendLog(new List<string> {symbol}, DataAdminMessageFactory.LogMessage.Log.CollectSymbol, "",
                                _groupItems[index].GroupModel.TimeFrame, false, true, !isCorrect,
                                " Inserted:" + realyInsertedRowsCount + ". Time:" +
                                GetStringTime(DateTime.Now - _timeLastCollecting) + ". " + comments)).Wait();
                    _logger.LogAdd(
                        @"  |  Symbol '" + symbol + "' collected [" + (isCorrect ? "Success" : "Unsuccessful") + "] " +
                        comments + "  Inserted: " + realyInsertedRowsCount,
                        isCorrect ? Category.Information : Category.Warning);
                }
                _timeLastCollecting = DateTime.Now;
                //groupList4.ChangeCollectedCount(index, count, totalCount);
                ChangeCollectedItem(index,count,totalCount);
                ui__status_labelItem_status.Text = "Collecting: " + _groupItems[index].GroupModel.GroupName + " [" +
                                                   count + "/" + totalCount + "]";

            }));
        }

        private string GetStringTime(TimeSpan ts)
        {
            return ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
        }

        private void CQGDataCollectorManager_ItemStateChanged(int index, GroupState state)
        {
            Invoke((Action) (() =>
            {
                StoreGroupStatus(index, state);
                _groupItems[index].GroupState = state;
                //todo 
               //groupList4.ChangeState(index, state);
                StateChanged(state,index);

                if (state == GroupState.InProgress)
                {

                    _logger.LogAdd(
                        @"  Collecting start for group: " + _groupItems[index].GroupModel.GroupName + " [" +
                        _groupItems[index].AllSymbols.Count + "]",
                        Category.Information);
                    Task.Factory.StartNew(
                        () =>
                            SendLog(_groupItems[index].AllSymbols, DataAdminMessageFactory.LogMessage.Log.CollectGroup,
                                _groupItems[index].GroupModel.GroupName, _groupItems[index].GroupModel.TimeFrame, true,
                                false)).Wait();
                    if (_groupItems[index].AllSymbols.Count != 0)
                        Task.Factory.StartNew(
                            () =>
                                SendLog(_groupItems[index].AllSymbols,
                                    DataAdminMessageFactory.LogMessage.Log.CollectSymbol, "",
                                    _groupItems[index].GroupModel.TimeFrame, true, false)).Wait();
                }
                if (state == GroupState.Finished)
                {
                    _logger.LogAdd(@"  Collecting finished for group: " + _groupItems[index].GroupModel.GroupName,
                        Category.Information);
                    _groupItems[index].GroupModel.End = DateTime.Now;
                    //groupList4.ChangeDateTime(index, _groupItems[index].GroupModel.End);
                    ChangeDateTime(index, _groupItems[index].GroupModel.End);
                    ClientDatabaseManager.SetGroupEndDatetime(_groupItems[index].GroupModel.GroupId,
                        _groupItems[index].GroupModel.End);
                    ui__status_labelItem_status.Text = "Collecting finished for group: " +
                                                       _groupItems[index].GroupModel.GroupName;

                    // Task.Factory.StartNew(() => SendLog(_groupItems[index].CollectedSymbols, DataAdminMessageFactory.LogMessage.Log.CollectSymbol,"", _groupItems[index].GroupModel.TimeFrame, false, true)).Wait();
                    Task.Factory.StartNew(
                        () =>
                            SendLog(_groupItems[index].AllSymbols, DataAdminMessageFactory.LogMessage.Log.CollectGroup,
                                _groupItems[index].GroupModel.GroupName, _groupItems[index].GroupModel.TimeFrame, false,
                                true)).Wait();
                }

            }));

        }

        private void StoreGroupStatus(int index, GroupState state)
        {
            var strIndex = "[" + index + "]";

            if (state == GroupState.Finished || state == GroupState.NotInQueue || state == GroupState.InProgress)
            {

                if (Settings.Default.InQueueGroups.Contains(strIndex))
                {
                    var ind = Settings.Default.InQueueGroups.IndexOf(strIndex);
                    Settings.Default.InQueueGroups = Settings.Default.InQueueGroups.Remove(ind, strIndex.Length);
                }
            }
            if (state == GroupState.InQueue)
            {
                if (!Settings.Default.InQueueGroups.Contains(strIndex))
                    Settings.Default.InQueueGroups += strIndex;
            }
            if (state == GroupState.Finished)
            {
                Settings.Default.InProgressGroup = "";
            }
            if (state == GroupState.InProgress)
            {
                Settings.Default.InProgressGroup = strIndex;
            }

            //Console.WriteLine("#InQueue:" + Settings.Default.InQueueGroups);
            //Console.WriteLine("#InProgress:" + Settings.Default.InProgressGroup);
            Settings.Default.Save();

        }



        private void CQGDataCollectorManager_RunnedStateChanged(bool state)
        {
            Invoke((Action) (() => ShowDataCollectorStatus(state)));
        }

        private void CQGDataCollectorManager_StartTimeChanged(int index, DateTime dateTime)
        {
            //todo Invoke((Action)(() => styledListControl1.ChangeStartDateTime(index, dateTime)));
        }

        private void ShowDataCollectorStatus(bool status)
        {
            labelItem_collecting.Text = status ? "Runned" : "Finished";
            metroStatusBar1.Refresh();
        }

        private void groupList4_ItemStateChanged(int index, int groupID, GroupState state, bool itemIsSelected, List<string> symbols)
        {
             //todo

            //if (itemIsSelected)
            //{
            //    SymbolItem.AddGroupItem(symbols, groupID, _client.UserID);

            //        foreach (var panel in panelSymbolItem.Controls)
            //        {
            //        var symbolItem = panel as SymbolItem;
            //        if (symbolItem != null) symbolItem.ColorStateChange();
            //        }
            //        slidePanelSymbols.Focus();
            //        slidePanelSymbols.BringToFront();

            //}
            //else
            //{
               
            //    SymbolItem.RemoveGroupItem(groupID);
            //    foreach (var panel in panelSymbolItem.Controls)
            //    {
            //        var symbolItem = panel as SymbolItem;
            //        if (symbolItem != null) symbolItem.ColorStateChange();
            //        //panelSymbolItem.Controls.Add(new SymbolItem(sym.SymbolName));
            //        // listViewSymbols.Items.Add(sym.SymbolName);
            //    }
            //    slidePanelSymbols.Focus();
            //    slidePanelSymbols.BringToFront();
            //}
            //StoreGroupStatus(groupList4.Count-index-1, state);

            //_groupItems[index].GroupState = state;
            //CQGDataCollectorManager.ChangeState(index, state);
        }



        #endregion


        #region COLLECT, COLLECT GROUPS, MISSING BARS

        private void buttonX_StartCollectSymbols_Click(object sender, EventArgs e)
        {
            if (!_client.Privileges.CollectSQGAllowed)
            {
                ui__status_labelItem_status.Text = "You don't have permissions to do this.";
                return;
            }

            /*if (ui_listBox_symbols.SelectedItems.Count == 0)
            {
                ui__status_labelItem_status.Text = "Please, select the instruments.";
                return;
            }

            if (!_isStartedCqg)
            {
                ui__status_labelItem_status.Text = "Start CQG first, please.";
                return;
            }


            var symbols = ui_listBox_symbols.SelectedItems.Cast<string>().ToList();

            _logger.LogAdd(@" Start collecting symbols from list [" + symbols.Count + "]", Category.Information);
            var isTick = radioButtonTick.Checked;
            CQGDataCollectorManager.StartFromList(isTick, symbols, dateTimeInputStart.Value.Date,
                dateTimeInputEnd.Value.Date.AddDays(1).AddMinutes(-1), (rdb1.Checked ? 1 : 31),
                cmbHistoricalPeriod.SelectedItem.ToString(), cmbContinuationType.SelectedItem.ToString(),
                (int) nudStartBar.Value, (int) nudEndBar.Value, _client.UserName);
            */
        }

        private DateTime startCollecting;

        private void buttonX_StartCollectGroups_Click(object sender, EventArgs e)
        {
            if (!_client.Privileges.CollectSQGAllowed)
            {
                ui__status_labelItem_status.Text = "You don't have permissions to do this.";
                return;
            }
            ClientDatabaseManager.isExpirationColumnExist_ADD();
            ClientDatabaseManager.isExpirationColumnExist_Delete();
            Console.WriteLine(_groupItems[0].AllSymbols);
            CQGDataCollectorManager.Start();
            startCollecting = DateTime.Now;

            //dateTimeInputStart.Value.Date, dateTimeInputEnd.Value, (rdb1.Checked ? 1 : 31), (int)nudStartBar.Value, (int)nudEndBar.Value, _client.UserName);
        }

        private void buttonX_stopCollecting_Click(object sender, EventArgs e)
        {
            _logger.LogAdd(" Stoped by user.", Category.Warning);
            CQGDataCollectorManager.Stop();

        }

        private void metroTileItemMissingBar_Click(object sender, EventArgs e)
        {
            if (!_client.Privileges.MissingBarFAllowed)
            {
                ui__status_labelItem_status.Text = "You don't have permissions to do this.";
                return;
            }
            if (!_isStartedCqg)
            {
                ui__status_labelItem_status.Text = "Start CQG first, please.";
                return;
            }
            if (ui_listBox_symbolsForMissing.SelectedItems.Count < 1)
            {
                ui__status_labelItem_status.Text = "Select symbols, please.";
                return;
            }
            _shouldStop = false;
            _missingBarManager.AllowCollectingAndMissingBar();

            var symbols = ui_listBox_symbolsForMissing.SelectedItems.Cast<string>().ToList();

            StartMissingBar(symbols, false);
        }

        #endregion


        #region SORTING SelectAll/None


        private void linkLabel_edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSymbolEditControl();
        }

        private void SelectedAll()
        {
            for (int i = 0; i < superGridControl1.PrimaryGrid.Rows.Count; i++)
            {
                if (superGridControl1.GetCell(i, 5).Value.ToString() != "InProgress")
                    StateChanged(GroupState.InQueue, i);
            }
            //superGridControl1.PrimaryGrid.SelectAll();
        }

        private void SelectedNone()
        {
            for (int i = 0; i < superGridControl1.PrimaryGrid.Rows.Count; i++)
            {
                if (superGridControl1.GetCell(i, 5).Value.ToString() != "InProgress")
                    StateChanged(GroupState.NotInQueue, i);
            }

        }

        private void linkLabel_selectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //groupList4.SelectedAll();
            SelectedAll();
        }


        private void linkLabel_selectNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //groupList4.SelectedNone();
            SelectedNone();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientDatabaseManager.SortingModeIsAsc = !ClientDatabaseManager.SortingModeIsAsc;
            RefreshSymbols();
            RefreshGroups();
        }

        private void linkLabel_sort_name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var newMode = Convert.ToInt32((sender as LinkLabel).Tag);
            if (_sortMode == newMode)
                ClientDatabaseManager.SortingModeIsAsc = !ClientDatabaseManager.SortingModeIsAsc;

            _sortMode = newMode;
            
            RefreshGroups();
        }


        #endregion

        #region TAB:::::::::: DAILY VALUES 


        private void buttonX_daily_getValues_Click(object sender, EventArgs e)
        {
            ClientDatabaseManager.isExpirationColumnExist_ADD();
            ClientDatabaseManager.isExpirationColumnExist_Delete();
            var symbols = listBox_daily_symbols.SelectedItems.Cast<string>().ToList();
            DailyLoadSelectedSYmbolData(symbols);
            NotChanchedLoadSelectedSYmbolData(symbols);
            // DailyValuesManager.DisplayProperties(symbols);
        }





        private void LoadAllDailyListToListView()
        {
            listView1.View = View.Details;
            listView1.Groups.Clear();

            List<DailyValueModel> dailyList = ClientDatabaseManager.GetAllDailyValues();

            var lastGroupName = "";
            foreach (var dailyValueModel in dailyList)
            {
                var gr = new ListViewGroup();

                if (lastGroupName != dailyValueModel.symbol)
                {
                    gr = listView1.Groups.Add(dailyValueModel.symbol, dailyValueModel.symbol);
                    lastGroupName = dailyValueModel.symbol;
                }


                var item = new ListViewItem(dailyValueModel.id.ToString(CultureInfo.InvariantCulture)) {Group = gr};
                item.SubItems.Add(dailyValueModel.symbol);
                item.SubItems.Add(dailyValueModel.Date.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(dailyValueModel.IndicativeOpen.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(dailyValueModel.Settlement.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(dailyValueModel.Marker.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(dailyValueModel.TodayMarker.ToString(CultureInfo.InvariantCulture));
                listView1.Items.Add(item);
            }

        }

        private void NotChanchedLoadSelectedSYmbolData(List<string> symbol)
        {
            //listView1.Clear();
            listView2.View = View.Details;
            listView2.Groups.Clear();
            listView2.Items.Clear();
            foreach (var variable in symbol)
            {

                List<SymbolsNotChangedValuesModel> NotChangedList =
                    ClientDatabaseManager.GetNotChangedValuesModels(variable);
                var lastGroupName = "";
                var gr = new ListViewGroup();
                foreach (var NotChangedValue in NotChangedList)
                {
                    if (lastGroupName != NotChangedValue.Symbol)
                    {
                        gr = listView2.Groups.Add(NotChangedValue.Symbol, NotChangedValue.Symbol);
                        lastGroupName = NotChangedValue.Symbol;
                    }

                    var item = new ListViewItem(NotChangedValue.ID.ToString(CultureInfo.InvariantCulture)) {Group = gr};
                    item.SubItems.Add(NotChangedValue.Symbol);
                    item.SubItems.Add(NotChangedValue.TickSize.ToString());
                    item.SubItems.Add(NotChangedValue.Currency.ToString(CultureInfo.InvariantCulture));
                    //item.SubItems.Add(NotChangedValue.Expiration.ToShortDateString());
                    item.SubItems.Add(NotChangedValue.TickValue.ToString());


                    listView2.Items.Add(item);
                }
            }
        }


        public void DailyLoadSelectedSYmbolData(List<string> symbol)
        {
            //listView1.Clear();
            listView1.View = View.Details;
            listView1.Groups.Clear();
            listView1.Items.Clear();
            foreach (var variable in symbol)
            {

                List<DailyValueModel> dailyList = ClientDatabaseManager.GetDailyValueModels(variable);

                var lastGroupName = "";
                var gr = new ListViewGroup();
                foreach (var dailyValueModel in dailyList)
                {
                    // if (variable != dailyValueModel.symbol) break;////test

                    if (lastGroupName != dailyValueModel.symbol)
                    {
                        gr = listView1.Groups.Add(dailyValueModel.symbol, dailyValueModel.symbol);
                        lastGroupName = dailyValueModel.symbol;
                    }

                    var item = new ListViewItem(dailyValueModel.id.ToString(CultureInfo.InvariantCulture)) {Group = gr};
                    item.SubItems.Add(dailyValueModel.symbol);
                    item.SubItems.Add(dailyValueModel.Date.ToShortDateString());
                    if (dailyValueModel.IndicativeOpen == -1) item.SubItems.Add("N/A");
                    else
                        item.SubItems.Add(dailyValueModel.IndicativeOpen.ToString(CultureInfo.InvariantCulture));

                    if (dailyValueModel.Settlement == -1) item.SubItems.Add("N/A");
                    else
                        item.SubItems.Add(dailyValueModel.Settlement.ToString(CultureInfo.InvariantCulture));

                    if (dailyValueModel.Marker == -1) item.SubItems.Add("N/A");
                    else
                        item.SubItems.Add(dailyValueModel.Marker.ToString(CultureInfo.InvariantCulture));

                    if (dailyValueModel.TodayMarker == -1) item.SubItems.Add("N/A");
                    else
                        item.SubItems.Add(dailyValueModel.TodayMarker.ToString());
                    item.SubItems.Add(dailyValueModel.Expiration.ToString());
                    listView1.Items.Add(item);
                }
            }


        }



        private void buttonX_daily_updateValues_Click(object sender, EventArgs e)
        {
            ClientDatabaseManager.isExpirationColumnExist_ADD();
            ClientDatabaseManager.isExpirationColumnExist_Delete();
            var symbols = listBox_daily_symbols.SelectedItems.Cast<string>().ToList();
            Daily_NotChanchedValuesManager.UpdateDailyValues(symbols);
        }


        #endregion

        #region ProgressChenced 

        private void CQGDataCollectorManager_ProgressBarChanched(int progress)
        {
            Invoke((Action) (() => ProgressChenched(progress)));
        }

        private void ProgressChenched(int progress)
        {
            progressBarItemCollecting.Value = progress;
        }

        #endregion

        private void ui_LabelX_sharedAvaliable_Click(object sender, EventArgs e)
        {
            Convert.ToInt32("Crash");
        }




        #region Expiration Dates BAR DATA

        private void buttonX_ac_update_Click(object sender, EventArgs e)
        {
            var selectedSymbols = new List<string>();
            foreach (string str in listBox_daily_symbols.SelectedItems)
            {
                selectedSymbols.Add(str);
            }
            CQGDataCollectorManager.UpdateMonthAndYearForSymbols(selectedSymbols);

        }

        private void button_ac_add_Click(object sender, EventArgs e)
        {

            var symbol = textBox_ac_symbol.Text;
            var endDate = dateTimePicker_ac_enddate.Value;
            var monthChar = textBox_ac_monthchar.Text;
            var year = numericUpDown_ac_year.Value;

            if (string.IsNullOrEmpty(monthChar))
            {
                ToastNotification.Show(this, "Please type month char!");
                return;
            }

            if (string.IsNullOrEmpty(textBox_ac_symbol.Text))
            {
                ToastNotification.Show(panelEx14, "Please selcet symbol");
                return;
            }
            //todo insert into DB

            ClientDatabaseManager.AddExpirationDatesForSymbol(symbol, endDate, monthChar, year);

            ToastNotification.Show(panelEx14, "Data added for symbol " + symbol);

            LoadExpirationDatesForSymbols();

        }

        private void button_ac_delete_Click(object sender, EventArgs e)
        {
            if (listView_ac_list.SelectedItems.Count == 0)
            {
                ToastNotification.Show(panelEx14, "Please selcet row to delete");
                return;
            }
            foreach (var item in listView_ac_list.SelectedIndices)
            {
                var symbol = listView_ac_list.Items[(int) item].SubItems[1].Text.ToString();
                var monthChar = listView_ac_list.Items[(int) item].SubItems[3].Text.ToString();
                var year = listView_ac_list.Items[(int) item].SubItems[4].Text.ToString();

                ClientDatabaseManager.RemoveExpirationDatesForSymbol(symbol, monthChar, year);

            }

            ToastNotification.Show(panelEx14, "Data removed from table");

            LoadExpirationDatesForSymbols();
        }

        private void LoadExpirationDatesForSymbols()
        {
            listView_ac_list.Items.Clear();
            if (listBox_daily_symbols.SelectedItems.Count == 0)
            {
                return;
            }
            var symbol = listBox_daily_symbols.SelectedItems[0].ToString();

            var res = ClientDatabaseManager.GetExpirationDatesForSymbol(symbol);

            listView_ac_list.Items.Clear();
            for (int i = 0; i < res.Count; i++)
            {
                var rrr = listView_ac_list.Items.Add("" + i);
                rrr.SubItems.Add(res[i].Symbol);
                rrr.SubItems.Add(res[i].EndDate.ToShortDateString());
                rrr.SubItems.Add(res[i].MonthChar);
                rrr.SubItems.Add(res[i].Year.ToString());
            }

            //todo display info 
        }


        private void listBox_daily_symbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_daily_symbols.SelectedIndex != -1)
                textBox_ac_symbol.Text = listBox_daily_symbols.Items[listBox_daily_symbols.SelectedIndex].ToString();
            else
                textBox_ac_symbol.Text = string.Empty;

            LoadExpirationDatesForSymbols();
        }


        #endregion

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var from = new FormAutocollect(_client.UserID);
            from.ShowDialog();

        }

        private void StateChanged(GroupState state,int row)
        {
            
            if (state == GroupState.Finished)
            {
                for (int i = 0; i < superGridControl1.PrimaryGrid.Columns.Count; i++)
                {
                    superGridControl1.GetCell(row, i).CellStyles.Default.Background.Color1 = Color.LightGreen;
                }
                superGridControl1.GetCell(row, 5).Value = state.ToString();
                ChangeLogs(row, (DateTime.Now - startCollecting).Hours + "h:" + (DateTime.Now - startCollecting).Minutes + "m:" + (DateTime.Now - startCollecting).Seconds + "s",totalrows.ToString(),minrows,maxrows);
                totalrows = 0;
                minrows = 9999999;
                maxrows = 0;
            }

            if (state == GroupState.InProgress)
            {
                for (int i = 0; i < superGridControl1.PrimaryGrid.Columns.Count; i++)
                {
                    superGridControl1.GetCell(row, i).CellStyles.Default.Background.Color1 = Color.Yellow;
                }
                superGridControl1.GetCell(row, 5).Value = state.ToString();
            }
            if (state == GroupState.InQueue)
            {
                for (int i = 0; i < superGridControl1.PrimaryGrid.Columns.Count; i++)
                {
                    superGridControl1.GetCell(row, i).CellStyles.Default.Background.Color1 = Color.DodgerBlue;
                }
            superGridControl1.GetCell(row, 5).Value = state.ToString();
            }
            if (state == GroupState.NotInQueue)
            {
                for (int i = 0; i < superGridControl1.PrimaryGrid.Columns.Count; i++)
                {
                    superGridControl1.GetCell(row, i).CellStyles.Default.Background.Color1 = Color.White;
                }
                superGridControl1.GetCell(row, 5).Value = state.ToString();
            }
            int index = _groupItems.FindIndex(oo => oo.GroupModel.GroupName == (string) superGridControl1.GetCell(row, 1).Value);
            CQGDataCollectorManager.ChangeState(index, state);
        }

        //todo
        public struct Autocollect
        {
            private int day;
            private DateTime time;
        }
        public void RefreshAutocollectDaysAndTime(List<GroupModel> groups)
        {
            //todo
            /* for (var rowIndex = 0; rowIndex < superGridControl1.PrimaryGrid.Rows.Count; rowIndex++)
             {
                 var session = ClientDatabaseManager.GetSessionsInGroup(groups[rowIndex].GroupId);
                 if (session.Count == 0) continue;
                 string days="";
                 DateTime times = DateTime.Now;
                 int dayToday = DateTime.Now.Day;
                 bool _found=false;
                 List<Autocollect> autocollects = new List<Autocollect>();
                 foreach (var sessionModel in session)
                 {
                     string s = sessionModel.Days;
                     for (int i = 0; i < 7; i++)
                     {
                         if (s[i].ToString() != "_")
                         {
                             Autocollect a=new Autocollect();
                             a.
                             autocollects.Add(new Autocollect());
                                
                         }
                     }
                

                 if (s.Contains(dayToday.ToString()))
                     {
                         if (sessionModel.TimeStart >= DateTime.Now)
                         {
                             times = sessionModel.TimeStart;
                             days = sessionModel.Days;

                         }
                     }
                    
                     superGridControl1.GetCell(rowIndex, 9).Value = days;
                     superGridControl1.GetCell(rowIndex, 8).Value = times;
                 }


             else
                     {
                         for (int i = dayToday + 1; i < 7; i++)
                         {
                             if (s.Contains(i.ToString()))
                             {
                                 times = sessionModel.TimeStart;
                                 days = sessionModel.Days;
                                 _found = true;
                                 break;
                             }
                         }
                         for (int i = 0; i < dayToday; i++)
                         {
                             if (s.Contains(i.ToString()))
                             {
                                 times = sessionModel.TimeStart;
                                 days = sessionModel.Days;
                                 _found = true;
                                 break;
                             }
                         }
                         if (s.Contains(dayToday.ToString()) && !_found)
                         {
                             if (sessionModel.TimeStart <= DateTime.Now)
                             {
                                 times = sessionModel.TimeStart;
                                 days = sessionModel.Days;
                                 break;
                             }
                         }
                     }
                    
                 }
             }*/

        }

        public void ChangeDateTime(int index, DateTime end)
        {
            //gridGroup.Rows[index].Cells[2].Value = end.ToString();
            superGridControl1.GetCell(index, 3).Value = end.ToString();
        }
        public void ChangeMinandMaxTime(int index, DateTime minTime,DateTime maxTime)
        {
            superGridControl1.GetCell(index, 6).Value = minTime.ToString();
            superGridControl1.GetCell(index, 7).Value = maxTime.ToString();
        }
        public void ChangeLogs(int index, string totaltime, string totalrows, int minrows, int maxrows)
        {
            //gridGroup.Rows[index].Cells[2].Value = end.ToString();
            superGridControl1.GetCell(index, 10).Value = "Total Time:" + totaltime + "  inserted rows:( Min:" + minrows + " / Max:" + maxrows + " / Total:" + totalrows + ")";

        }
        public void ChangeCollectedItem(int index, int colecCount, int allCount)
        {
            //gridGroup.Rows[index].Cells[5].Value = colecCount+"/"+allCount;
            superGridControl1.GetCell(index, 6).Value = colecCount + "/" + allCount;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var from = new FormAddSymbolsGroups(_client.UserID);
            from.ShowDialog();
        }

        private void editSymbolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = superGridControl1.PrimaryGrid.GetCell(superGridControl1.PrimaryGrid.ActiveRow.Index, 1).Value.ToString();
            var groupID = _groupItems.Find(oo => oo.GroupModel.GroupName == name).GroupModel.GroupId;
            var form = new FormAddSymbolsGroups(_client.UserID, groupID);
            form.ShowDialog();
        }

        private void autocollectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var name = superGridControl1.PrimaryGrid.GetCell(superGridControl1.PrimaryGrid.ActiveRow.Index, 1).Value.ToString();
            var groupID = _groupItems.Find(oo => oo.GroupModel.GroupName == name).GroupModel.GroupId;
            var form = new FormAutocollect(_client.UserID, groupID);
            form.ShowDialog();
        }

        private void RefreshGridSymbolsGroups()
        {
            //gridGroup.Rows.Clear();
            RefreshGroups();
            RefreshSymbols();
        }

        private void RefreshGridGroups()
        {
            //gridGroup.Rows.Clear();
            RefreshGroups();
        }

        private void superGridControl1_AfterExpand(object sender, DevComponents.DotNetBar.SuperGrid.GridAfterExpandEventArgs e)
        {
            if (e.GridContainer.Rows[0].GridPanel.Columns["ID"] != null)
            {
                e.GridContainer.Rows[0].GridPanel.ColumnHeader.RowHeight = 30;
                e.GridContainer.Rows[0].GridPanel.Columns["ID"].Visible = false;
                e.GridContainer.Rows[0].GridPanel.AllowEdit = false;

            }
        }

        private void superGridControl1_CellClick(object sender, DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs e)
        {
            if (e.MouseEventArgs.Button == MouseButtons.Left && e.GridCell.IsPrimaryCell)
            {
                superGridControl1.PrimaryGrid.SetSelectedRows(e.GridCell.RowIndex, 1, true);
                
                //superGridControl1.PrimaryGrid.SetSelected()
                if (e.GridCell.RowIndex != -1)
                {
                    //var a = superGridControl1.GetCell(e.GridCell.RowIndex, 4);
                    if (superGridControl1.GetCell(e.GridCell.RowIndex, 5).Value.ToString() == "InQueue")
                        StateChanged(GroupState.NotInQueue, e.GridCell.RowIndex);

                    else if (superGridControl1.GetCell(e.GridCell.RowIndex, 5).Value.ToString() != "InProgress")
                        StateChanged(GroupState.InQueue, e.GridCell.RowIndex);

                }
            }

            if (e.GridCell.ColumnIndex != -1)
                {
                    if (e.MouseEventArgs.Button == MouseButtons.Right)
                    {
                        var relativeMousePosition = superGridControl1.PointToClient(Cursor.Position);
                        contextMenuStripGroupGrid.Show(superGridControl1, relativeMousePosition);
                    }
                }

            
        }

        private void symbolsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            var name = superGridControl1.PrimaryGrid.GetCell(superGridControl1.PrimaryGrid.ActiveRow.Index, 1).Value.ToString();
            var symbols = _groupItems.Find(oo => oo.GroupModel.GroupName == name).AllSymbols;
            symbolsToolStripMenuItem.DropDownItems.Clear();
            foreach (var item in symbols)
            {
                symbolsToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void autocollectToolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
            var groudID = _groupItems.Find(oo => oo.GroupModel.GroupName == 
                superGridControl1.PrimaryGrid.GetCell(superGridControl1.PrimaryGrid.ActiveRow.Index, 1).Value.ToString()).GroupModel.GroupId;
            var sessions = ClientDatabaseManager.GetSessionsInGroup(groudID);
            sessionToolStripMenuItem.DropDownItems.Clear();
            foreach (var item in sessions)
            {
                sessionToolStripMenuItem.DropDownItems.Add(item.Name + "(" + item.Days + ")");
            }
        }

        private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
        {
            e.Cancel=true;
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // superGridControl1.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.None;
            var oldSize = superGridControl1.Font.Size;
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = fontDialog1.Font;
                superGridControl1.ActiveGrid.DefaultVisualStyles.CellStyles.Default.Font = fontDialog1.Font;
                if (oldSize < fontDialog1.Font.Size)
                {
                    superGridControl1.ActiveGrid.DefaultRowHeight = (int)fontDialog1.Font.Size +
                                                                    superGridControl1.PrimaryGrid.DefaultRowHeight;
                    for (int i = 0; i < superGridControl1.ActiveGrid.Columns.Count; i++)
                        superGridControl1.ActiveGrid.Columns[i].Width = superGridControl1.ActiveGrid.Columns[i].Width
                                                                        + (int)fontDialog1.Font.Size;
                    //superGridControl1.PrimaryGrid.SuperGrid.Width = (int)fontDialog1.Font.Size +
                    //                            superGridControl1.PrimaryGrid.SuperGrid.Width + 200;

                }
                if (oldSize > fontDialog1.Font.Size)
                {
                    for (int i = 0; i < superGridControl1.ActiveGrid.Columns.Count; i++)
                        superGridControl1.ActiveGrid.Columns[i].Width = superGridControl1.ActiveGrid.Columns[i].Width
                                                                        - (int)fontDialog1.Font.Size;
                    superGridControl1.ActiveGrid.DefaultRowHeight =
                            superGridControl1.PrimaryGrid.DefaultRowHeight - (int)fontDialog1.Font.Size;

                }
            }
        }


      
    }
}
