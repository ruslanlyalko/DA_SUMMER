using CQG;
using DADataManager;
using DADataManager.Models;
using DataNetClient.Controls;
using DataNetClient.Core;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;

namespace DataNetClient.Forms
{
    public partial class EditListControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        #region HANDLERS
        public EditListControl(int groupId, GroupModel groupModel)
        {
            GroupId = groupId;
            AGroupModel = groupModel;

            InitializeComponent();

            cmbContinuationType.Items.Clear();
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctNoContinuation);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctStandard);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctStandardByMonth);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctActive);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctActiveByMonth);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctAdjusted);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctAdjustedByMonth);           

        }

        /// <summary>
        /// Gets or sets the commands associated with the control.
        /// </summary>
        public MetroBillCommands Commands
        {
            get { return _commands; }
            set
            {
                if (value != _commands)
                {
                    MetroBillCommands oldValue = _commands;
                    _commands = value;
                    OnCommandsChanged(oldValue, value);
                }
            }
        }
        /// <summary>
        /// Called when Commands property has changed.
        /// </summary>
        /// <param name="oldValue">Old property value</param>
        /// <param name="newValue">New property value</param>
        protected virtual void OnCommandsChanged(MetroBillCommands oldValue, MetroBillCommands newValue)
        {
            if (newValue != null)
            {
                saveButton.Command = newValue.EditListCommands.Save;
                cancelButton.Command = newValue.EditListCommands.Cancel;
            }
            else
            {
                saveButton.Command = null;
                cancelButton.Command = null;
            }
        }
        
        #endregion

        #region VARS
        public bool OpenSymbolControl;
        private MetroBillCommands _commands;
        public int GroupId
        {
            get;
            set;
        }
        public string OldGroupName { get; private set; }

        public GroupModel AGroupModel { get; set; }
        public List<SessionModel> addedSessions { get; set; }

        #endregion


        #region EVENTS

        public delegate void AddSesionHandler(SessionModel sesions);
        public static event AddSesionHandler AddSesion;

        private void OnAddSesion(SessionModel sesions)
        {
            AddSesionHandler handler = AddSesion;
            if (handler != null) handler(sesions);
        }

        public delegate void RemoveSesionHandler(int index);
        public static event RemoveSesionHandler RemoveSesion;

        private void OnRemoveSesion(int index)
        {
            RemoveSesionHandler handler = RemoveSesion;
            if (handler != null) handler(index);
        }

        #endregion

        private void EditListControl_Load(object sender, EventArgs e)
        {
            OldGroupName = textBoxXListName.Text;
            checkBox_AutoCollec.Checked = AGroupModel.IsAutoModeEnabled;

            LoadSymbols();

            LoadSessions();

            LoadExistingSessions();
        }

        private void LoadSessions()
        {
            var sessionsList = ClientDatabaseManager.GetSessionsInGroup(GroupId);
            foreach (var sessions in sessionsList)
            {
                var res = listViewEx_times.Items.Add(listViewEx_times.Items.Count.ToString());
                res.SubItems.Add(sessions.Name);
                res.SubItems.Add(sessions.TimeStart.ToShortTimeString());
                
                res.SubItems.Add(sessions.Days);
            }
        }

        private void LoadSymbols()
        {

            var symbolsList = ClientDatabaseManager.GetSymbolsInGroup(GroupId);
            foreach (var symbol in symbolsList)
            {
                var exist = false;
                foreach (var item in lbSelList.Items)
                {
                    if (item.ToString() == symbol.SymbolName) exist = true;
                }
                if (!exist) lbSelList.Items.Add(symbol.SymbolName);
            }

        }

        private void LoadExistingSessions()
        {
            comboBoxEx_existigsSessions.Items.Clear();
            var sessionsList = ClientDatabaseManager.GetSessions();
            addedSessions = new List<SessionModel>();
            foreach (var sessions in sessionsList)
            {
                if (!addedSessions.Exists(oo => oo.Name == sessions.Name))
                {
                    comboBoxEx_existigsSessions.Items.Add(" [" + sessions.TimeStart.ToShortTimeString() + " - " + sessions.TimeEnd.ToShortTimeString() + "]" + (sessions.IsStartYesterday ? "SY" : "  ") + " (" + sessions.Days + ")   " + sessions.Name);
                    addedSessions.Add(sessions);
                }
            }
        }
        private void btnRemov_Click(object sender, EventArgs e)
        {
            var asd = lbSelList.SelectedItems;
            for (int index = 0; index < asd.Count; index++)
            {
                var item = asd[index];
                lbSelList.Items.Remove(item);
            }

            if (lbSelList.Items.Count > 0)
            {
                btnRemov.Enabled = true;
                lbSelList.SetSelected(0, true);
            }
            else
            {
                btnRemov.Enabled = false;
            }
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cancelButton.Command.Execute();
           // OnAddSesion(addedSessions);
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listViewEx_times.SelectedItems.Count <= 0) return;
            var index = listViewEx_times.SelectedIndices[0];
            var name = listViewEx_times.Items[index].SubItems[1].Text;
            listViewEx_times.Items.RemoveAt(index);


            var id = ClientDatabaseManager.GetSessionsInGroup(GroupId).Find(oo => oo.Name.ToUpper() == name.ToUpper()).Id;
            //todo remove session
            //OnRemoveSesion(index);
            ClientDatabaseManager.RemoveSession(GroupId, id);

        }


        private void checkBox_AutoCollec_CheckedChanged(object sender, EventArgs e)
        {
            panelEx1.Enabled = panelEx4.Enabled = panelEx3.Enabled = checkBox_AutoCollec.Checked;
        }

        private void buttonX_add_Click_1(object sender, EventArgs e)
        {
            var sess = new SessionModel
            {
                Id = -1,
                Name = textBoxX_sessionsName.Text==""?"Untitled session":textBoxX_sessionsName.Text,
                IsStartYesterday = checkBox_sy.Checked,
                Days = GetDaysStr(),
                TimeStart = dateTimeInput1.Value,
                TimeEnd = dateTimeInput2.Value,
            };
            //OnAddSesion(sess);
            AddSessionToList(sess);
            ClientDatabaseManager.AddSessionForGroup(AGroupModel.GroupId, sess);
        }

        private string GetDaysStr()
        {
            string str = "";
            str += checkBox_sun.Checked ? "S" : "_";
            str += checkBox_mon.Checked ? "M" : "_";
            str += checkBox_tue.Checked ? "T" : "_";
            str += checkBox_wed.Checked ? "W" : "_";
            str += checkBox_thu.Checked ? "T" : "_";
            str += checkBox_fri.Checked ? "F" : "_";
            str += checkBox_sat.Checked ? "S" : "_";
            return str;
        }

        private void AddSessionToList(SessionModel sess)
        {
            var res = listViewEx_times.Items.Add(listViewEx_times.Items.Count.ToString());
            res.SubItems.Add(sess.Name);
            res.SubItems.Add(sess.TimeStart.ToShortTimeString());                        
            res.SubItems.Add(sess.Days);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var ind = comboBoxEx_existigsSessions.SelectedIndex;
            if (ind == -1)
            {
                ToastNotification.Show(panelEx4, "Please, choose any session.");
                return;
            }


            var sess = new SessionModel
            {
                Id = -1,
                Name = addedSessions[ind].Name,
                IsStartYesterday = addedSessions[ind].IsStartYesterday,
                Days = addedSessions[ind].Days,
                TimeStart = addedSessions[ind].TimeStart,
                TimeEnd = addedSessions[ind].TimeEnd,
            };
            //OnAddSesion(sess);
            AddSessionToList(sess);
            ClientDatabaseManager.AddSessionForGroup(AGroupModel.GroupId, sess);
        }

    }
}
