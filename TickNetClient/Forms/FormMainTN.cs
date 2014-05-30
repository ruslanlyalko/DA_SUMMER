using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Threading;
using CQG;
using DataAdminCommonLib;
using DevComponents.DotNetBar;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using TickNetClient.Core;
using TickNetClient.Core.ClientManager;
using TickNetClient.Properties;
using Timer = System.Windows.Forms.Timer;
using DADataManager.Models;
using DADataManager;
using DevComponents.DotNetBar.Metro.ColorTables;

namespace TickNetClient.Forms
{
    public partial class FormMainTN : DevComponents.DotNetBar.Metro.MetroAppForm
    {

        #region VARIABLES

        private readonly MetroBillCommands _commands; // All application commands
        private StartControl _startControl;
        private SymbolsEditControl _symbolsEditControl;
        private EditListControl _editListControl;
        private AddListControl _addListControl;

        //private List<GroupModel> _groups = new List<GroupModel>();
        private List<SymbolModel> _symbols = new List<SymbolModel>();
        private Thread _logonThread;
        private readonly List<int> _busySymbolList;        

        private string _connectionToSharedDb;
        private string _connectionToLocalDb;
        private string _connectionToSharedDbLive;
        private string _connectionToLocalDbLive;
        string _lastTip;
        private CQGConnector _connector;
        private bool _logined;
        private Label _lastLabel;
        private bool _normalizerStatus;
        private bool _serverStatusMaster;
        private bool _serverStatusSlave;

        #endregion


        #region CLIENT-SERVER VARIABLES

        private DataClientClass _client;
        private DataNormalizatorClient _dataNormalizatorClient;
        private IScsServiceClient<IDataNormalizatorService> _dnormClientService;
        private IScsServiceClient<IDataAdminService> _clientService;
        private DataNetLogService _logClient;
        private IScsServiceClient<IDataNetLogService> _logClientService;        
        private Timer _pingTimer;
        private object _offlineServerSymbol;
        private object _onlineServerSymbol;
        private string _serverHost;
        //private CQGCEL _cel;

        #endregion


        #region HANDLES

        public FormMainTN()
        {
            SuspendLayout();

            InitializeComponent();

            _commands = new MetroBillCommands
            {
                StartControlCommands = { Logon = new Command(), Exit = new Command() },
                NewSymbolCommands = { NewGroup = new Command(), EditGroup = new Command(), Cancel = new Command() },
                NewListCommands = { Add = new Command(), Cancel = new Command() },
                EditListCommands = { Save = new Command(), Cancel = new Command() }
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


            labelItemUserName.Text = @"ver " + Application.ProductVersion;

            _startControl = new StartControl { Commands = _commands };
            Controls.Add(_startControl);
            _startControl.BringToFront();
            _startControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            ResumeLayout(false);
            _busySymbolList = new List<int>();

            styledListControl_groups.ItemStateChanged += styledListControl_groups_ItemStateChanged;
            styledListControl_groups.ItemEditGroupClick += styledListControl_groups_ItemEditGroupClick;
        }

        void styledListControl_groups_ItemEditGroupClick(int itemIndex)
        {
            var oldGroupInfo = _groupItems[itemIndex].GroupModel;

            _editListControl = new EditListControl(oldGroupInfo.GroupId, oldGroupInfo)
            {
                Commands = _commands,
                textBoxXListName = { Text = oldGroupInfo.GroupName },
                OpenSymbolControl = false
            };

            ShowModalPanel(_editListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);

        }

        void styledListControl_groups_ItemStateChanged(int index, GroupState state)
        {
            _groupItems[index].GroupState = state;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {                
                ClientDatabaseManager.ConnectionStatusChanged += ClientDataManager_ConnectionStatusChanged;

                if (Settings.Default.L.X < 0 || Settings.Default.L.Y < 0) Settings.Default.L = new Point(0, 0);
                if (Settings.Default.S.Width < 0 || Settings.Default.S.Height < 0) Settings.Default.S = new Size(800, 500);

                Size = Settings.Default.S;
                Location = Settings.Default.L;

                UpdateControlsSizeAndLocation();

                ui_home_textBoxX_db.Text = Settings.Default.LocalDbSystem;
                ui_home_textBoxX_db_live.Text = Settings.Default.LocalDbLive;
                ui_home_textBoxX_uid.Text = Settings.Default.LocalUser;
                ui_home_textBoxX_pwd.Text = Settings.Default.LocalPassword;
                ui_home_textBoxX_host.Text = Settings.Default.LoaclHost;
                ui_nudDOMDepth.Value = Settings.Default.Depth;
                ui_SQL_PacketSize.Value = Settings.Default.SqlPacketSize;
                checkBoxX1.Checked = Settings.Default.SavePass;

                metroShell1.SelectedTab = metroTabItem1;

                _pingTimer = new Timer();
                _pingTimer.Tick += TimerTick;
                _pingTimer.Interval = 1000;
                _pingTimer.Enabled = true;
                _onlineServerSymbol = _startControl.uiServerOnlineFakeSymbol.Symbol;
                _offlineServerSymbol = _startControl.uiOfflineFakeSymbol.Symbol;
            }
            catch (COMException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("CQG not installed!");
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Close();
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            metroShell1.TitleText = @"Tick Net v" + Application.ProductVersion;
            //UpdateControlsSizeAndLocation();           
            PingServer();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _pingTimer.Enabled = false;
                Logout(false);
                ClientDatabaseManager.CloseConnectionToDbSystem();
                ClientDatabaseManager.CloseConnectionToDbLive();

                if (checkBoxX1.Checked)
                {
                    Settings.Default.LocalDbLive = ui_home_textBoxX_db_live.Text;
                    Settings.Default.LocalDbSystem = ui_home_textBoxX_db.Text;
                    Settings.Default.LocalUser = ui_home_textBoxX_uid.Text;
                    Settings.Default.LocalPassword = ui_home_textBoxX_pwd.Text;
                    Settings.Default.LoaclHost = ui_home_textBoxX_host.Text;
                }
                else
                {
                    Settings.Default.LocalDbLive = "";
                    Settings.Default.LocalDbSystem = "";
                    Settings.Default.LoaclHost = "";
                    Settings.Default.LocalUser = "";
                    Settings.Default.LocalPassword = "";
                }
                Settings.Default.SavePass = checkBoxX1.Checked;
                Settings.Default.SqlPacketSize = (int)ui_SQL_PacketSize.Value;
                Settings.Default.Depth = (int)ui_nudDOMDepth.Value;

                Settings.Default.S = Size;
                Settings.Default.L = Location;


                Settings.Default.Save();
            }
            finally
            {
                Application.Exit();
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        private Rectangle GetStartControlBounds()
        {
            var captionHeight = metroShell1.MetroTabStrip.GetCaptionHeight() + 2;
            var borderThickness = GetBorderThickness();
            return new Rectangle((int)borderThickness.Left, captionHeight, Width - (int)borderThickness.Horizontal, Height - captionHeight - 1);
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
            tableLayoutPanel1.Size = new Size(Width - 7, Height - 77);
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

                    _startControl.Invoke((Action)delegate
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

                    _startControl.Invoke((Action)delegate
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
                    _startControl.Invoke((Action)delegate
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
                    _startControl.Invoke((Action)delegate
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
                _startControl.Invoke((Action)delegate
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
            _startControl.Invoke((Action)delegate
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
      

       /* private void PingThread()
        {
            var tcpClient = new TcpClient();
            try
            {
                var ip = IPAddress.Parse(_startControl.ui_textBox_ip.Text);
                tcpClient.Connect(ip, 443);
                _serverStatus = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _serverStatus = false;

            }
        }
        
        private void ServerStatusChanged()
        {
            _serverStatusMaster = false;
            Logout();
        }
        */
        private void LoginToServer(string username, string password, string host, bool isMaster)
        {

            _pingTimer.Enabled = false;
            _client = new DataClientClass(username);
            _logClient = new DataNetLogService();

            _serverHost = host;
            _logClientService = ScsServiceClientBuilder.CreateClient<IDataNetLogService>(new ScsTcpEndPoint(host, 443), _logClient);
            _clientService = ScsServiceClientBuilder.CreateClient<IDataAdminService>(new ScsTcpEndPoint(host, 443), _client);

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
               // _client.logoutServer += ServerStatusChanged;
                _client.busySymbolListReceived += BusySymbolChanged;
                _client.symbolPermissionChanged += RefreshSymbols;
                _clientService.Disconnected += OnServerCrashed;

                var logmsg = new DataAdminMessageFactory.LogMessage { Symbol = username, LogType = DataAdminMessageFactory.LogMessage.Log.Login, Group = "" };


                _logClientService.ServiceProxy.SendSimpleLog(logmsg);
                Settings.Default.connectionHost = _startControl.ui_textBox_ip.Text;
                Settings.Default.connectionHostSlave = _startControl.ui_textBox_ip_slave.Text;
                Invoke((Action)(() =>
                {
                    labelItem_server.Text = isMaster ? "Master" : "Slave";
                    styleManager1.MetroColorParameters = new MetroColorGeneratorParameters(Color.White, isMaster ? Color.Green : Color.YellowGreen);

                    metroStatusBar1.Refresh();
                }));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (_startControl != null)
                    _startControl.Invoke((Action)(() =>
                    {
                        ToastNotification.Show(_startControl, "Can't connect. IP is incorrect");
                        _startControl.ui_buttonX_logon.Enabled = true;
                    }
                        ));

                return;
            }
            var loginMsg = new DataAdminMessageFactory.LoginMessage(username, password, 't');
            try
            {
                _clientService.ServiceProxy.Login(loginMsg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private bool LoginToNormalizer(string host)
        {

            var serverStatus = true;
            var succesLogin = true;

            var tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(host, 442);
            }
            catch (Exception ex)
            {
                ToastNotification.Show(this, "The DataNormalizer is not available.");
                Console.Write(ex.Message);
                serverStatus = false;

            }
            if (serverStatus)
            {


                _dataNormalizatorClient = new DataNormalizatorClient();
                _dnormClientService =
                   ScsServiceClientBuilder.CreateClient<IDataNormalizatorService>(new ScsTcpEndPoint(host, 442),
                                                                                  _dataNormalizatorClient);

                try
                {
                    _dnormClientService.Connect();
                    _dnormClientService.ServiceProxy.Login(new DataNormalizatorMessageFactory.LoginMessage()
                                                            {
                                                                Username = _client.UserName,
                                                                IsLoginedToDa = true,
                                                                ServerMessage = ""
                                                            });
                    _normalizerStatus = true;
                }
                catch (Exception)
                {
                    succesLogin = false;
                    _normalizerStatus = false;
                }

                if (succesLogin)
                {
                    _dnormClientService.Disconnected += OnDNormCrashed;
                    _dataNormalizatorClient.OnActivation += CollectActivated;
                    _dataNormalizatorClient.OnDeactivation += CollectDeactivated;
                }
            }
            else succesLogin = false;

            return succesLogin;
        }

        private void OnDNormCrashed(object sender, EventArgs e)
        {
            _normalizerStatus = false;
            Logout();
        }

        private void CollectDeactivated(string symbol)
        {
            LiveTickCollectorManager.DeactivateInserting(symbol);
            //_sdr.DenySymbol(symbol);
            Task.Factory.StartNew(() => _dnormClientService.ServiceProxy.ClientDeactivated(symbol));
        }

        private static object _lockerActivated = new object();
        private void CollectActivated(string symbol)
        {
            lock (_lockerActivated)
            {
                //_sdr.AllowSymbol(symbol);
                LiveTickCollectorManager.ActivateInserting(symbol);
            }
        }

        private void OnServerCrashed(object sender, EventArgs e)
        {

            if (_nowIsMaster)
            {
                _nowIsMaster = false;

                LoginToServer(Settings.Default.connectionUser, Settings.Default.connectionPassword, Settings.Default.connectionHostSlave, _nowIsMaster);
            }
            else
            {
                _nowIsMaster = true;

                LoginToServer(Settings.Default.connectionUser,
                            Settings.Default.connectionPassword,
                            Settings.Default.connectionHost, _nowIsMaster);
            }

        }

        private void BusySymbolChanged(IEnumerable<int> idlist)
        {
            _busySymbolList.Clear();
            foreach (var item in idlist) _busySymbolList.Add(item);
            Thread.Sleep(1000);
            Task.Factory.StartNew(RefreshSymbols);
        }

        private void DeletedClient(object sender, object msg)
        {
            MessageBox.Show(msg.ToString());

            Invoke((Action)Close);
        }

        private void LoginFailed(object sender, DataAdminMessageFactory.LoginMessage msg)
        {
            _startControl.Invoke((Action)(() =>
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


            labelItemUserName.Text = "<" + _client.UserName + ">  " + Settings.Default.connectionHost;

            _logined = true;
            _serverStatusMaster = true;
            _serverStatusSlave = true;
            var xml = new XmlDocument();
            xml.LoadXml(msg.ServerMessage);

            string host = "";
            string dbName = "";
            string usName = "";
            string passw = "";
            string dbNameLive = "";

            var connString = xml.GetElementsByTagName("ConnectionString");
            var attr = connString[0].Attributes;
            if (attr != null)
            {
                host = (attr["Host"].Value);
                dbName = attr["dbName"].Value;
                usName = attr["userName"].Value;
                passw = attr["password"].Value;
                dbNameLive = attr["dbNameLive"].Value;
            }
            _connectionToSharedDb = "SERVER=" + host + "; Port=3306; DATABASE=" + dbName + "; UID=" + usName + "; PASSWORD=" + passw;
            _connectionToSharedDbLive = "SERVER=" + host + "; Port=3306; DATABASE=" + dbNameLive + "; UID=" + usName + "; PASSWORD=" + passw;
            SetPrivilages(msg);

            LiveTickCollectorManager.Init(liveSymbolsList_symbols, _client.UserName);
            LiveTickCollectorManager.SymbolSubscribed += LiveTickCollectorManager_SymbolSubscribed;
            LiveTickCollectorManager.ItemStateChanged += LiveTickCollectorManager_ItemStateChanged;
            LiveTickCollectorManager.SymbolStoped += LiveTickCollectorManager_SymbolStoped;
        }

        void LiveTickCollectorManager_SymbolStoped(string symbol, bool canSendLog)
        {
            CollectStoped(symbol, canSendLog);
        }

        void LiveTickCollectorManager_ItemStateChanged(int index, GroupState state)
        {
            styledListControl_groups.ChangeState(index, state);
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
                    (Action)delegate { ui_buttonX_localConnect.Enabled = _client.Privileges.LocalDBAllowed; });

                ui_buttonX_shareConnect.Invoke((Action)delegate
                {
                    ui_buttonX_shareConnect.Enabled = _client.Privileges.SharedDBAllowed;
                });
                ui_LabelX_localAvaliable.Invoke((MethodInvoker)delegate
                {
                    ui_LabelX_localAvaliable.Text = localDbstring;
                    ui_LabelX_localAvaliable.ForeColor = localDbColor;
                });
                ui_LabelX_sharedAvaliable.Invoke((MethodInvoker)delegate
                {
                    ui_LabelX_sharedAvaliable.Text = sharedDbstring;
                    ui_LabelX_sharedAvaliable.ForeColor = sharedDbColor;
                });

                _startControl.Invoke((Action)(() => _startControl.Hide()));
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
                RefreshGroups();
            }
        }
        #endregion


        #region SYSTEM

        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {
            var form2 = new FormSettings();
            form2.ShowDialog();
        }

        private void StartControl_LogonClick(object sender, EventArgs e)
        {

            Settings.Default.connectionUser = _startControl.ui_textBoxX_login.Text;
            Settings.Default.connectionPassword = _startControl.ui_textBoxX_password.Text;
            Settings.Default.connectionHost = _startControl.ui_textBox_ip.Text;
            Settings.Default.Save();
            _startControl.ui_buttonX_logon.Enabled = false;
            _logonThread = new Thread(
                () => LoginToServer(Settings.Default.connectionUser,
                                                    Settings.Default.connectionPassword,
                                                    Settings.Default.connectionHost, true)

                ) { Name = "LogonThread", IsBackground = true };
            _logonThread.Start();


        }

        private void CqgConnectionStatusChanged(bool isConnectionUp)
        {
            labelItemStatusCQG.Text = isConnectionUp ? @"CQG started" : @"CQG not started";
            Refresh();
        }

        private void ui_buttonX_shareConnect_Click(object sender, EventArgs e)
        {
            if (!LoginToNormalizer(_serverHost))
                return;
            if (ClientDatabaseManager.IsConnected() && ClientDatabaseManager.CurrentDbIsShared) return;

            ClientDatabaseManager.ConnectToShareDb(_connectionToSharedDb, "", "", _connectionToSharedDbLive, _client.UserID);



            _client.ConnectedToSharedDb = true;
            _client.ConnectedToLocalDb = false;

            RefreshGroups();
            RefreshSymbols();
            Refresh();

            UpdateControlsSizeAndLocation();
        }

        private void ui_buttonX_localConnect_Click(object sender, EventArgs e)
        {
            if (ClientDatabaseManager.IsConnected() && !ClientDatabaseManager.CurrentDbIsShared) return;

            var dbName = ui_home_textBoxX_db.Text;
            var host = ui_home_textBoxX_host.Text;
            var dbNameLive = ui_home_textBoxX_db_live.Text;
            var usName = ui_home_textBoxX_uid.Text;
            var passw = ui_home_textBoxX_pwd.Text;

            _connectionToLocalDb = "SERVER=" + host + "; Port=3306; DATABASE=" + dbName + "; UID=" + usName + "; PASSWORD=" + passw;
            _connectionToLocalDbLive = "SERVER=" + host + "; Port=3306; DATABASE=" + dbNameLive + "; UID=" + usName + "; PASSWORD=" + passw;

            ClientDatabaseManager.ConnectToLocalDb(_connectionToLocalDb, "","",_connectionToLocalDbLive, _client.UserID);
            _client.ConnectedToSharedDb = false;
            _client.ConnectedToLocalDb = true;

            RefreshGroups();
            RefreshSymbols();
            Refresh();

            UpdateControlsSizeAndLocation();
        }

        private void ClientDataManager_ConnectionStatusChanged(bool connected, bool isShared)
        {
            var strConn = connected ? @"Connnected to " + (isShared ? @"Shared DB" : @"Local DB") : "Not connected";
            ui_status_labelItemStatusSB.Text = strConn;
            if (connected)
            {
                metroTabItem2.Visible = true;
                metroShell1.SelectedTab = metroTabItem2;
                RefreshSymbols();
                RefreshGroups();
            }
            else
            {
                ToastNotification.Show(metroTabPanel1, @"Can't connect to DB", eToastPosition.TopCenter);
                metroTabItem2.Visible = false;
            }
        }



        private void RefreshGroups()
        {
            
            if (_client == null) return;
            if (!_client.ConnectedToLocalDb && !_client.ConnectedToSharedDb) return;
            if (!ClientDatabaseManager.IsConnected()) return;

            _groupItems = new List<GroupItemModel>();
            //styledListControl_groups.ClearItems();
            var groups = ClientDatabaseManager.GetGroupsForUser(_client.UserID, ApplicationType.TickNet);
            groups = OrderListOfGroups(ClientDatabaseManager.SortingModeIsAsc, groups);
            Invoke((Action)(() => { 
            

            styledListControl_groups.SetItemsCount(groups.Count);

            for (int i = 0; i < groups.Count; i++)
            {
                var groupModel = groups[i];

                var symbols = ClientDatabaseManager.GetSymbolsInGroup(groupModel.GroupId).Select(oo => oo.SymbolName).ToList();

                var sessions = ClientDatabaseManager.GetSessionsInGroup(groupModel.GroupId);

                _groupItems.Add(
                    new GroupItemModel
                    {
                        GroupModel = groupModel,
                        GroupState = GroupState.NotInQueue,
                        AllSymbols = symbols,
                        CollectedSymbols = new List<string>(),
                    });

                styledListControl_groups.SetItem(i, groupModel.GroupName, groupModel.Depth, GroupState.NotInQueue,
                    groupModel.End, "[" + symbols.Count + "]", symbols, sessions, groupModel.IsAutoModeEnabled);
            }
            }));
        }

        private List<GroupModel> OrderListOfGroups(bool asc, List<GroupModel> list)
        {
            List<GroupModel> reslist = list;

            if (_sortMode == 1)
                reslist = list.OrderBy(oo => oo.GroupName).ToList();
            if (_sortMode == 2)
                reslist = list.OrderBy(oo => oo.Depth).ToList();
            if (_sortMode == 3)
                reslist = list.OrderBy(oo => oo.End).ToList();



            if (asc) reslist.Reverse();

            return reslist; ;
        }

        private void RefreshSymbols()
        {
            if (_client == null) return;
            if (!_client.ConnectedToLocalDb && !_client.ConnectedToSharedDb) return;
            if (!ClientDatabaseManager.IsConnected()) return;

            ui_listBox_symbols.Invoke((Action)(() => ui_listBox_symbols.Items.Clear()));
            ui_BufferSymbols_comboBox.Invoke((Action)(() => ui_BufferSymbols_comboBox.Items.Clear()));
            ClientDatabaseManager.Commit();
            _symbols = ClientDatabaseManager.GetSymbols(_client.UserID, true);
            foreach (var item in _symbols)
            {
                SymbolModel item1 = item;
                ui_listBox_symbols.Invoke((Action)delegate { if (!ui_listBox_symbols.Items.Contains(item1.SymbolName)) ui_listBox_symbols.Items.Add(item1.SymbolName); });
                ui_BufferSymbols_comboBox.Invoke((Action)delegate
                    {
                        ui_BufferSymbols_comboBox.Items.Add(item1.SymbolName);
                    });
            }
        }

        private void metroShell1_LogOutButtonClick(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout(bool enableTime = true)
        {
            if (!_logined) return;

            _logined = false;


            StopCollecting();

            if (_serverStatusMaster)
                if (_clientService != null)
                {
                    _clientService.ServiceProxy.Logout("t", _client.UserName);
                }
            if (_dnormClientService != null && _client.ConnectedToSharedDb && _normalizerStatus)
                _dnormClientService.ServiceProxy.Logout();

            if (_logonThread != null) _logonThread.Abort();

            Invoke((Action)delegate
            {
                metroTabItem2.Visible = false;
                metroShell1.SelectedTab = metroTabItem1;
                ClientDatabaseManager.CloseConnectionToDbLive();
                ClientDatabaseManager.CloseConnectionToDbSystem();
                RefreshGroups();
                RefreshSymbols();
                _client = null;
                _startControl.Dispose();
                _startControl = new StartControl { Commands = _commands };
                Controls.Add(_startControl);
                _startControl.BringToFront();
                _startControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
                UpdateControlsSizeAndLocation();
                _startControl.ui_textBox_ip.Text = Settings.Default.connectionHost;
                _startControl.ui_textBox_ip_slave.Text = Settings.Default.connectionHostSlave;
                if (enableTime) _pingTimer.Enabled = true;
            });

        }

        private void StartControl_ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region CEL

        void CEL_DataConnectionStatusChanged(eConnectionStatus eConnectionStatus1)
        {
            CqgConnectionStatusChanged(eConnectionStatus1 == eConnectionStatus.csConnectionUp);
        }

        #endregion


        #region SYMBOLS

        private void ui_ToolStripMenuItem_EditSymbols_Click(object sender, EventArgs e)
        {
            OpenSymbolEditControl();
        }

        void SymbolsEditControl_UpdateSymbolsEvent()
        {
            _clientService.ServiceProxy.onSymbolListRecieved("");
            if(_dnormClientService!=null)
            _dnormClientService.ServiceProxy.RefreshSymbols();
        }

        void SymbolsEditControl_UpdateGroupsEvent()
        {
            _clientService.ServiceProxy.onSymbolGroupListRecieved("");
            if (_dnormClientService != null)
            _dnormClientService.ServiceProxy.RefreshSymbols();
        }

        private void NewGroupNewSymbolExecuted(object sender, EventArgs e)
        {
            CloseAddSymbolControl();

            _addListControl = new AddListControl { Commands = _commands, OpenSymbolControl = true };
            ShowModalPanel(_addListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
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
                ClientDatabaseManager.GetGroupsForUser(_client.UserID, ApplicationType.TickNet).First(oo => oo.GroupName == groupName);
            //_groups.Find(a => a.GroupName == groupName);

            _editListControl = new EditListControl(oldGroupInfo.GroupId,oldGroupInfo)
            {
                Commands = _commands,
                textBoxXListName = { Text = oldGroupInfo.GroupName },
                OpenSymbolControl = true
            };

            var symbols = ClientDatabaseManager.GetSymbolsInGroup(oldGroupInfo.GroupId);

            foreach (var symbol in symbols)
            {
                _editListControl.lbSelList.Items.Add(symbol.SymbolName);
            }

            CloseAddSymbolControl();

            ShowModalPanel(_editListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
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
            //_symbolsEditControl.Dispose();
            _symbolsEditControl = null;
        }

        private void listBoxSymbols_MouseMove(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox == null) return;

            var index = listBox.IndexFromPoint(e.Location);
            if (index <= -1 || index >= listBox.Items.Count) return;

            var tip = listBox.Items[index].ToString();
            if (tip == _lastTip) return;

            toolTip1.SetToolTip(listBox, tip);
            _lastTip = tip;
        }

        private void listBoxSymbols_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var listBox = sender as ListBox;
            if (listBox == null) return;
            listBox.SelectedIndex = listBox.IndexFromPoint(e.X, e.Y);
            listBox.Show();
        }

        private void progressBarItemCollecting_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        #endregion


        #region UI context menus GROUPS

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ui_listBox_symbols.Items.Count; i++)
            {
                ui_listBox_symbols.SetSelected(i, true);
            }
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ui_listBox_symbols.Items.Count; i++)
            {
                ui_listBox_symbols.SetSelected(i, false);
            }
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
                CntType = _addListControl.cmbContinuationType.SelectedItem.ToString(),
                IsAutoModeEnabled = false,
                Depth = 1
            };

            if (!_groupItems.Exists(a => a.GroupModel.GroupName == group.GroupName) && !ClientDatabaseManager.GetAllGroups(ApplicationType.TickNet).Exists(a => a.GroupName == group.GroupName))
            {
                if (ClientDatabaseManager.AddGroupOfSymbols(group))
                {
                    group.GroupId = ClientDatabaseManager.GetGroupIdByName(group.GroupName);

                    ClientDatabaseManager.AddGroupForUser(_client.UserID, group, ApplicationType.TickNet);
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
            var start = (_addListControl.OpenSymbolControl);
            CloseModalPanel(_addListControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
            _addListControl.Dispose();
            _addListControl = null;
            if (start)
            {
                OpenSymbolEditControl();
            }
        }

        private void CancelEditListExecuted(object sender, EventArgs e)
        {
            CloseEditListControl();
        }

        private void EditListControl_SaveClick(object sender, EventArgs e)
        {
  
            var group = new GroupModel
            {
                GroupName = _editListControl.textBoxXListName.Text,
                TimeFrame = "tick",
                Start = new DateTime(),
                End = new DateTime(),
                CntType = eTimeSeriesContinuationType.tsctNoContinuation.ToString(),
                Depth = _editListControl.GetDepth(),
                IsAutoModeEnabled = _editListControl.GetIsAutoModeEnabled(),
            };

            var oldGroupName = _editListControl.OldGroupName;

            if ((!_groupItems.Exists(a => a.GroupModel.GroupName == group.GroupName) && _groupItems.Exists(a => a.GroupModel.GroupName == oldGroupName)) || (group.GroupName == oldGroupName && _groupItems.Exists(a => a.GroupModel.GroupName == oldGroupName)))
            {
                var groupId = _groupItems.Find(a => a.GroupModel.GroupName == oldGroupName).GroupModel.GroupId;
                ClientDatabaseManager.EditGroupOfSymbols(groupId, group);
                var symbolsInGroup = ClientDatabaseManager.GetSymbolsInGroup(groupId);
                foreach (var item in _editListControl.lbSelList.Items)
                {
                    if (!symbolsInGroup.Exists(a => a.SymbolName == item.ToString()) && _symbols.Exists(a => a.SymbolName == item.ToString()))
                    {
                        var symbol = _symbols.Find(a => a.SymbolName == item.ToString());
                        ClientDatabaseManager.AddSymbolIntoGroup(groupId, symbol);


                    }
                }

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

        private void OpenSymbolEditControl()
        {
            _symbolsEditControl = new SymbolsEditControl(_client.UserID) { Commands = _commands };
            _symbolsEditControl.UpdateSymbolsEvent += SymbolsEditControl_UpdateSymbolsEvent;
            _symbolsEditControl.UpdateGroupsEvent += SymbolsEditControl_UpdateGroupsEvent;
            ShowModalPanel(_symbolsEditControl, DevComponents.DotNetBar.Controls.eSlideSide.Right);
        }

        #endregion


        #region COLECT UI AND LOGIC

        private void ui_collect_buttonX_stop_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Stop data collection?", @"STOP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StopCollecting();
            }
        }
        private void StopCollecting()
        {
            var symbols = new List<string>();
            bool canSendlog = false;
            //if (_connector != null)
            //    _connector.CQG_Stop();
            //if (_sdr != null)
            //{
            //    symbols = _sdr.GetSymbols();
            //    canSendlog = true;
            //    _sdr.SymbolSubscribed -= CollectRequest;
            //    _sdr = null;
            //}


            if (ClientDatabaseManager.CurrentDbIsShared && symbols.Count > 0 && canSendlog && _normalizerStatus)
            {
                Task.Factory.StartNew(() => _dnormClientService.ServiceProxy.AllCollectFinished());
            }
        }


        private void ui_collect_buttonX_start_Click(object sender, EventArgs e)
        {
            if (ui_listBox_symbols.SelectedItems.Count == 0)
            {
                ui__status_labelItem_status.Text = @"Please, select the instruments.";
                return;
            }
            ClientDatabaseManager.MaxQueueSize = (int)ui_SQL_PacketSize.Value;
            ClientDatabaseManager.MaxBufferSize = (int)ui_BufferSizeValue.Value;

            var symbols = ui_listBox_symbols.SelectedItems.Cast<object>().Cast<string>().ToList();


            LiveTickCollectorManager.StartFromLists( symbols, (int)ui_nudDOMDepth.Value);
           
        }

        void LiveTickCollectorManager_SymbolSubscribed(string symbols, int depth)
        {
            CollectRequest(new List<string> { symbols }, depth);
        }

        private void ui_collect_buttonX_startGroup_Click(object sender, EventArgs e)
        {
            LiveTickCollectorManager.LoadGroups(_groupItems);
            LiveTickCollectorManager.StartFromGroups();

        }
        private void ui_collect_buttonX_removeSymbols_Click(object sender, EventArgs e)
        {
            LiveTickCollectorManager.RemoveStopedSymbols();
        }

        //private void StartCollect(List<string> symbols, bool isGroup, int groupID)
        //{
        //    if (symbols.Count == 0) return;

        //    ui_buttonX_localConnect.Enabled = false;
        //    ui_buttonX_shareConnect.Enabled = false;

        //    DatabaseManager.MaxQueueSize = (int)ui_SQL_PacketSize.Value;
        //    DatabaseManager.MaxBufferSize = (int)ui_BufferSizeValue.Value;

        //    //ui_componentList.ColumnCount = 1;
        //    //ui_componentList.AutoSize = true;
        //    //ui_componentList.AutoSizeMode = AutoSizeMode.GrowOnly;


        //    _connector = new CQGConnector();

        //    _connector.addDataConnectionStatusChangedListener(CEL_DataConnectionStatusChanged);
        
        //    for (var i = 0; i < symbols.Count; i++)
        //    {
        //        var container = new Panel
        //        {
        //            BorderStyle = BorderStyle.FixedSingle,
        //            Size = new Size(370, 45),
        //            Dock = DockStyle.Top,
        //            AutoSize = false
        //        };

        //        var symbolDescription = new Label
        //        {
        //            Text = symbols[i],
        //            Location = new Point(20, 4),
        //            Size = new Size(100, 20),
        //            Dock = DockStyle.None
        //        };
        //        container.Controls.Add(symbolDescription);

        //        var btnCancel = new ButtonX
        //        {
        //            Text = @"cancel",
        //            Location = new Point(180, 4),
        //            Size = new Size(70, 20),
        //            Dock = DockStyle.None,
        //            AutoSize = false,
        //            Style = ui_collect_buttonX_start.Style
        //        };
        //        btnCancel.Click += btnCommandExec;
        //        container.Controls.Add(btnCancel);

        //        var btnStop = new ButtonX
        //        {
        //            Text = @"stop",
        //            Location = new Point(270, 4),
        //            Size = new Size(70, 20),
        //            Dock = DockStyle.None,
        //            AutoSize = false,
        //            Style = ui_collect_buttonX_start.Style
        //        };
        //        btnStop.Click += btnCommandExec;
        //        container.Controls.Add(btnStop);


        //        var mDesc = new Label
        //        {
        //            Text = @"Status: ",
        //            Location = new Point(5, 24),
        //            Size = new Size(50, 20),
        //            Dock = DockStyle.None
        //        };
        //        container.Controls.Add(mDesc);

        //        var message = new LabelX
        //        {
        //            Text = @"Waiting for processing...",
        //            Size = new Size(295, 17),
        //            Location = new Point(55, 24),
        //            AutoSize = false,
        //            Dock = DockStyle.None,
        //            PaddingLeft = 5
        //        };
        //        message.BackgroundStyle.BorderLeft = eStyleBorderType.Solid;
        //        message.BackgroundStyle.BorderLeftColor = Color.Gray;
        //        message.BackgroundStyle.BorderLeftWidth = 3;

        //        message.MouseMove += labelMessage_MouseMove;

        //        container.Controls.Add(message);

                

        //        //ui_componentList.RowCount = i;
        //       // ui_componentList.Controls.Add(container);

        //        _sdr.AddSymbol(symbols[i], message);
        //    }
        //    if (DatabaseManager.CurrentDbIsShared)
        //    {
        //        _sdr.SymbolSubscribed += CollectRequest;
        //    }
        //    _connector.ICEL.Startup();

        //    ui_collect_buttonX_start.Enabled =
        //        ui_collect_buttonX_startGroup.Enabled =
        //        ui_listBox_symbols.Enabled =
        //        styledListControl_groups.Enabled = false;            
        //}

        private void CollectStoped(string symbol, bool canSendLog)
        {
            if (ClientDatabaseManager.CurrentDbIsShared && canSendLog)
            {
                Task.Factory.StartNew(() => _dnormClientService.ServiceProxy.CollectFinished(symbol));
            }
        }

        private void CollectRequest(List<string> symbols, int depth)
        {
            foreach (var symbol in symbols)
            {
                if(ClientDatabaseManager.CurrentDbIsShared)
                Task.Factory.StartNew(() => _dnormClientService.ServiceProxy.TickNetCollectRequest(
                     new DataNormalizatorMessageFactory
                         .TickNetCollectRequest
                         {
                             DepthValue = depth,
                             IsGroup = false,
                             OperationStatus = DataNormalizatorMessageFactory.TickNetCollectRequest.Status.Started,
                             Symbol = symbol,
                             UserName = _client.UserName,
                             Time = DateTime.Now

                         }));
            }
        }

        private void labelMessage_MouseMove(object sender, MouseEventArgs e)
        {
            var lbl = (sender as Label);
            if (lbl != null)
            {
                if (lbl != _lastLabel)
                {
                    toolTip1.SetToolTip(lbl, lbl.Text);
                    _lastLabel = lbl;
                }
            }

        }

        //private void btnCommandExec(object sender, EventArgs e)
        //{
        //    var control = sender as Control;
        //    var canSendLog = false;
        //    var symbol = "";
        //    if (control != null && control.Text == @"cancel")
        //    {
        //        symbol = control.Parent.Controls[0].Text;
        //        _sdr.Cancel(symbol);
        //        control.Parent.Parent.Controls.Remove(control.Parent);
        //        //ui_componentList.RowCount = ui_componentList.Controls.Count;

        //        canSendLog = true;
        //    }
        //    if (control != null && control.Text == @"stop")
        //    {
        //        symbol = control.Parent.Controls[0].Text;
        //        _sdr.Stop(symbol);
        //        control.Parent.Parent.Controls.Remove(control.Parent);
        //        //ui_componentList.RowCount = ui_componentList.Controls.Count;
        //        canSendLog = true;

        //    }
        //    if (control != null && control.Text == @"remove")
        //    {
        //        symbol = control.Parent.Controls[0].Text;
        //        _sdr.Rm(symbol);
        //        control.Parent.Parent.Controls.Remove(control.Parent);
        //        //ui_componentList.RowCount = ui_componentList.Controls.Count;
        //        canSendLog = false;
        //    }
         
        //    if (DatabaseManager.CurrentDbIsShared && canSendLog)
        //    {
        //        Task.Factory.StartNew(() => _dnormClientService.ServiceProxy.CollectFinished(symbol));
        //    }
        //}

        #endregion

        private void ui__status_labelItem_status_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (ui_BufferSymbols_comboBox.SelectedIndex < 0) return;
            var domBuffer = ClientDatabaseManager.GetBufferForSymbol(ui_BufferSymbols_comboBox.SelectedItem.ToString(), true).OrderBy(item=>item.Date).ToList();
            var tickBuffer = ClientDatabaseManager.GetBufferForSymbol(ui_BufferSymbols_comboBox.SelectedItem.ToString(), false).OrderBy(item=>item.Date).ToList();

            ui_DomTable_dataGridView.Rows.Clear();
            ui_TickTable_dataGridView.Rows.Clear();

            for (var i = domBuffer.Count - 1; i >= 0; i--)
            {
                ui_DomTable_dataGridView.Rows.Add(
                    domBuffer[i].Date.ToString("yyyy/MM/dd H:mm:ss.fff", CultureInfo.InvariantCulture),
                    domBuffer[i].AskPrice.ToString("G", CultureInfo.InvariantCulture),
                    domBuffer[i].BidPrice.ToString("G", CultureInfo.InvariantCulture),
                    domBuffer[i].AskVol.ToString("G", CultureInfo.InvariantCulture),
                    domBuffer[i].BidVol.ToString("G", CultureInfo.InvariantCulture),
                    domBuffer[i].GroupId.ToString("G", CultureInfo.InvariantCulture));
            }
            for (var i = tickBuffer.Count - 1; i >= 0; i--)
            {
                ui_TickTable_dataGridView.Rows.Add(
                    tickBuffer[i].Date.ToString("yyyy/MM/dd H:mm:ss.fff", CultureInfo.InvariantCulture),
                    tickBuffer[i].TickType,
                    tickBuffer[i].AskPrice.ToString("G", CultureInfo.InvariantCulture),
                    tickBuffer[i].BidPrice.ToString("G", CultureInfo.InvariantCulture),
                    tickBuffer[i].AskVol.ToString("G", CultureInfo.InvariantCulture),
                    tickBuffer[i].BidVol.ToString("G", CultureInfo.InvariantCulture),
                    tickBuffer[i].GroupId.ToString("G", CultureInfo.InvariantCulture));
                
            }
        }

        #region OTHERS

        private void switchButton_scheduler_ValueChanged(object sender, EventArgs e)
        {
            var isAuto =switchButton_scheduler.Value;

            styledListControl_groups.StateChangingEnabled = 
            ui_collect_buttonX_start.Enabled =
                ui_collect_buttonX_startGroup.Enabled = !isAuto;
            
            LiveTickCollectorManager.LoadGroups(_groupItems);
            
            LiveTickCollectorManager.ChangeMode(switchButton_scheduler.Value);
            
        }
        private void timer_scheduler_Tick(object sender, EventArgs e)
        {
           
        }

        private List<string> _schAllSymbolsList = new List<string>();

        private List<GroupModel> _schAllGroupsList = new List<GroupModel>();
        private List<GroupModel> _schAllowedGroupsList = new List<GroupModel>();
        private List<string> _allowedSymbols = new List<string>();
        private List<GroupItemModel> _groupItems;
        private int _sortMode=1;
        private bool _nowIsMaster=true;

        //private void StartScheduler()
        //{
        //    ui_nudDOMDepth.Value = 1;
        //    _schAllGroupsList = DatabaseManager.GetGroupsForUser(_client.UserID, ApplicationType.TickNet).Where(oo=>oo.IsAutoModeEnabled).ToList();

        //    _schAllowedGroupsList = new List<GroupModel>();
        //    _schAllSymbolsList = new List<string>();

        //    foreach (var item in _schAllGroupsList)
        //    {
        //        var listSymb = DatabaseManager.GetSymbolsInGroup(item.GroupId);
        //        foreach (var symbolModel in listSymb)
        //        {
        //            if (!_schAllSymbolsList.Contains(symbolModel.SymbolName))
        //            {
        //                _schAllSymbolsList.Add(symbolModel.SymbolName);
        //            }
        //        }


        //    }
        //    StartCollect(_schAllSymbolsList, false, 0);

        //    TickScheduler();
        //    //
        //    timer_scheduler.Start();

        //}

        //private void StopScheduler()
        //{
        //    timer_scheduler.Enabled = false;
        //    StopCollecting();
        //}

        //private void TickScheduler()
        //{
        //    var now = DateTime.Now;
        //    _allowedSymbols = new List<string>();

        //    foreach (var groupModel in _schAllGroupsList)
        //    {
        //        var sess=DatabaseManager.GetSessionsInGroup(groupModel.GroupId);
        //        if (groupModel.IsAutoModeEnabled && (
        //            sess.Any(oo => oo.TimeStart.TimeOfDay < DateTime.Now.TimeOfDay && oo.TimeEnd.TimeOfDay > DateTime.Now.TimeOfDay 
        //                && IsNowDay(oo.Days, oo.IsStartYesterday))//startToday
        //            || (sess.Any(oo => oo.TimeStart.TimeOfDay < DateTime.Now.TimeOfDay
        //                && IsNowGoodDayYesterday(oo.Days, oo.IsStartYesterday)))))//startYesterday
        //        {
        //            var err = DatabaseManager.GetSymbolsInGroup(groupModel.GroupId);

        //            foreach (var symbolModel in err)
        //            {
        //                if (!_allowedSymbols.Contains(symbolModel.SymbolName))
        //                {
        //                    _allowedSymbols.Add(symbolModel.SymbolName);                            
        //                }
        //                if (_sdr.GetDepthForSymbol(symbolModel.SymbolName) < groupModel.Depth)
        //                {
        //                    _sdr.SetDepthForSymbol(symbolModel.SymbolName, groupModel.Depth);
        //                }
                        
        //            }
        //        }
        //    }

        //    var disallowedList = _schAllSymbolsList.Where(symbol => !_allowedSymbols.Contains(symbol)).ToList();

        //    StopCollectingThisSymbols(disallowedList);
        //    StartCollectingThisSymbols(_allowedSymbols,-1);

        //}

        private bool IsNowGoodDayYesterday(string days, bool isStartYesterday)
        {
            if (!isStartYesterday) return false;

            var daysof = new List<DayOfWeek>();

            if (days[0] != '_') daysof.Add(DayOfWeek.Sunday);
            if (days[1] != '_') daysof.Add(DayOfWeek.Monday);
            if (days[2] != '_') daysof.Add(DayOfWeek.Tuesday);
            if (days[3] != '_') daysof.Add(DayOfWeek.Wednesday);
            if (days[4] != '_') daysof.Add(DayOfWeek.Thursday);
            if (days[5] != '_') daysof.Add(DayOfWeek.Friday);
            if (days[6] != '_') daysof.Add(DayOfWeek.Saturday);


            var res= (daysof.Contains(DateTime.Today.AddDays((isStartYesterday?1:0)).DayOfWeek));                
            return res;
        }

        private bool IsNowDay(string days, bool isStartYesterday)
        {
            var daysof = new List<DayOfWeek>();

            if (days[0] != '_') daysof.Add(DayOfWeek.Sunday);
            if (days[1] != '_') daysof.Add(DayOfWeek.Monday);
            if (days[2] != '_') daysof.Add(DayOfWeek.Tuesday);
            if (days[3] != '_') daysof.Add(DayOfWeek.Wednesday);
            if (days[4] != '_') daysof.Add(DayOfWeek.Thursday);
            if (days[5] != '_') daysof.Add(DayOfWeek.Friday);
            if (days[6] != '_') daysof.Add(DayOfWeek.Saturday);


            return (daysof.Contains(DateTime.Today.AddDays((isStartYesterday?1:0)).DayOfWeek) &&
                daysof.Contains(DateTime.Today.DayOfWeek));        
        }

        private bool IsTodayWeNeedToCollect(bool isDaily, DateTime now, string weekDays,
             string monthDays)
        {
            return isDaily ?
                weekDays.Contains(now.DayOfWeek.ToString()) :
                monthDays.Length < 3 || monthDays.Contains(now.ToShortDateString());
        }

        private bool IsNowWeNeedToCollect(bool isPart, DateTime now, string timePeriods)
        {
            if (!isPart) return true;

            var list = timePeriods.Split(',');
            foreach (var s in list)
            {
                var seTime = s.Split('-');
                if (!string.IsNullOrEmpty(seTime[0]))
                {
                    var sTime = DateTime.Today.Date.Add(Convert.ToDateTime(seTime[0]).TimeOfDay);
                    var eTime = DateTime.Today.Date.Add(Convert.ToDateTime(seTime[1]).TimeOfDay);

                    if (now > sTime && now < eTime) return true;

                }
            }
            return false;
        }


        //private void StopCollectingThisSymbols(List<string> symbols)
        //{
        //    foreach (var symbol in symbols)
        //    {
        //        Console.WriteLine("- " + symbol);

        //        _sdr.SchSymbolOff(symbol);
        //    }
        //}

        //private void StartCollectingThisSymbols(List<string> symbols, int depth)
        //{
        //    foreach (var symbol in symbols)
        //    {
        //        Console.WriteLine("+ " + symbol);
        //        _sdr.SchSymbolOn(symbol);
        //        if(depth!=-1)
        //            _sdr.SetDepthForSymbol(symbol, depth);
        //    }

        //}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            styledListControl_groups.SelectedAll();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            styledListControl_groups.SelectedNone();
        } 
        #endregion

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

    

     
    }

}