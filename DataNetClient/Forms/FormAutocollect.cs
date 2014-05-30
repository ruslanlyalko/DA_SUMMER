using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DADataManager;
using DADataManager.Models;
using DevComponents.DotNetBar;

namespace DataNetClient.Forms
{
    public partial class FormAutocollect : DevComponents.DotNetBar.Metro.MetroForm
    {



        #region event
        public delegate void RefreshGroupsHandler();

        public static event RefreshGroupsHandler RefreshGroups;

        private void OnRefreshGroups()
        {
            RefreshGroupsHandler handler = RefreshGroups;
            if (handler != null) handler();
        }



        #endregion


        #region LABEL CLIK

        private void lS_Click(object sender, EventArgs e)
        {
            lS.ForeColor = lS.ForeColor != Color.Red ? Color.Red : Color.Black;
        }

        private void lM_Click(object sender, EventArgs e)
        {
            lM.ForeColor = lM.ForeColor != Color.Red ? Color.Red : Color.Black;
        }

        private void lT_Click(object sender, EventArgs e)
        {
            lT.ForeColor = lT.ForeColor != Color.Red ? Color.Red : Color.Black;
        }

        private void lW_Click(object sender, EventArgs e)
        {
            lW.ForeColor = lW.ForeColor != Color.Red ? Color.Red : Color.Black;
        }

        private void lTu_Click(object sender, EventArgs e)
        {
            lTu.ForeColor = lTu.ForeColor != Color.Red ? Color.Red : Color.Black;
        }

        private void lF_Click(object sender, EventArgs e)
        {
            lF.ForeColor = lF.ForeColor != Color.Red ? Color.Red : Color.Black;
        }

        private void lSu_Click(object sender, EventArgs e)
        {
            lSu.ForeColor = lSu.ForeColor != Color.Red ? Color.Red : Color.Black;
        }

        private void RefreshClik()
        {
            foreach (var control in panelDays.Controls)
            {
                var label = control as LabelX;
                if (label.ForeColor == Color.Red)
                    label.ForeColor = Color.Black;
            }
        }

        #endregion

        private int _userID;
        private List<GroupModel> _groups = null;
        private List<SessionModel> _sessions = null;

        private int _groupID;
        private bool _isSingle = false;


        public FormAutocollect(int userID, int groupID = -1)
        {
            InitializeComponent();
            _userID = userID;
            if (groupID != -1)
            {
                _groupID = groupID;
                _isSingle = true;
            }


        }


        private void InitGroupList()
        {
            _groups = ClientDatabaseManager.GetGroupsForUser(_userID, ApplicationType.DataNet);
            foreach (var item in _groups)
            {
                listBoxGroupName.Items.Add(item.GroupName);
            }
        }



        private void InitComboBoxAuto()
        {
            _sessions = ClientDatabaseManager.GetSessions();
            foreach (var sesion in _sessions)
            {
                comboBoxAutoCollect.Items.Add(sesion.Name + "(" + sesion.Days + ")");
            }

        }

        private void FormAutocollect_Load(object sender, EventArgs e)
        {
            mainPanel.BackColor = Color.White;
            panelDays.BackColor = Color.White;
            if (!_isSingle) InitGroupList();
            else
            {
                SingleInitialize();
            }

            InitComboBoxAuto();
        }

        private void AddSessionToList(SessionModel sess)
        {
            ListViewItem res = new ListViewItem(listViewAutocollects.Items.Count.ToString());
            res.SubItems.Add(sess.Name);
            res.SubItems.Add(sess.TimeStart.ToShortTimeString());
            res.SubItems.Add(sess.Days);
            listViewAutocollects.Items.Add(res);
        }

        private void buttonAddSesion_Click(object sender, EventArgs e)
        {
            if (dateTimeInput.Value == new DateTime())
            {
                ToastNotification.Show(this, @"Ñhoose a time,please");
                return;
            }
            if (GetDaysStr() == "_______")
            {
                ToastNotification.Show(this, @"Ñhoose a day(s),please");
                return;
            }
            var sess = new SessionModel
            {
                Id = -1,
                Name = textBoxSesionName.Text == "" ? "Untitled session" : textBoxSesionName.Text,
                IsStartYesterday = true,
                Days = GetDaysStr(),
                TimeStart = dateTimeInput.Value,
                TimeEnd = new DateTime(),
            };

            //  ClientDatabaseManager.AddSessionForGroup(_groups.Find(oo => oo.GroupName == group).GroupId, sess);
            if (listBoxGroupName.SelectedItems.Count != 0)
            {
                if (listBoxGroupName.SelectedItems.Count == 1)
                {
                    AddSessionToList(sess);
                }
                for (int index = 0; index < listBoxGroupName.SelectedItems.Count; index++)
                {
                    var group = listBoxGroupName.SelectedItems[index];
                    if (index == 0)
                    {
                        ClientDatabaseManager.AddSessionForGroup(_groups.Find(oo => oo.GroupName == group).GroupId, sess);
                        _sessions = ClientDatabaseManager.GetSessions();
                        continue;
                    }
                    var currSes =
                        _sessions.Find(oo => oo.Name == sess.Name && oo.Days == sess.Days);
                    ClientDatabaseManager.AddSessionForGroup(_groups.Find(oo => oo.GroupName == group).GroupId,
                        currSes.Id);

                }
            }
            else
                ClientDatabaseManager.AddSessionForGroup(-1, sess);
            RefreshClik();
            textBoxSesionName.Text = "";
            dateTimeInput.Value = new DateTime();
            comboBoxAutoCollect.Items.Add(sess.Name + "(" + sess.Days + ")");
            _sessions = ClientDatabaseManager.GetSessions();

        }

        private string GetDaysStr()
        {
            string str = "";
            str += lS.ForeColor == Color.Red ? "S" : "_";
            str += lM.ForeColor == Color.Red ? "M" : "_";
            str += lT.ForeColor == Color.Red ? "T" : "_";
            str += lW.ForeColor == Color.Red ? "W" : "_";
            str += lTu.ForeColor == Color.Red ? "T" : "_";
            str += lF.ForeColor == Color.Red ? "F" : "_";
            str += lSu.ForeColor == Color.Red ? "S" : "_";
            return str;
        }

        private void listBoxGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxGroupName.SelectedItems.Count == 0 || listBoxGroupName.SelectedItems.Count > 1)
            {
                listViewAutocollects.Items.Clear();
                return;
            }
            listViewAutocollects.Items.Clear();
            var groupID = _groups.Find(oo => oo.GroupName == listBoxGroupName.SelectedItems[0]).GroupId;
            var sesions = ClientDatabaseManager.GetSessionsInGroup(groupID);
            foreach (var sesion in sesions)
            {
                ListViewItem item = new ListViewItem(listViewAutocollects.Items.Count.ToString());
                item.SubItems.Add(sesion.Name);
                item.SubItems.Add(sesion.TimeStart.ToShortTimeString());
                item.SubItems.Add(sesion.Days);
                listViewAutocollects.Items.Add(item);
            }
        }

        private void buttonAddToGroup_Click(object sender, EventArgs e)
        {
            if (comboBoxAutoCollect.SelectedItem == null)
            {
                ToastNotification.Show(this, "Please, choose session");
                return;
            }

            int sesionID =
                _sessions.Find(
                    sesion => sesion.Name + "(" + sesion.Days + ")" == comboBoxAutoCollect.SelectedItem.ToString()).Id;
            if (!_isSingle)
            {


                if (comboBoxAutoCollect.SelectedItem == "" || comboBoxAutoCollect.SelectedItem == null) return;
                if (listBoxGroupName.SelectedItems.Count == 0 || listBoxGroupName.SelectedItem == null) return;
                for (int index = 0; index < listBoxGroupName.SelectedItems.Count; index++)
                {
                    int groupID = _groups.Find(oo => oo.GroupName == listBoxGroupName.SelectedItems[index]).GroupId;
                    if (ClientDatabaseManager.ReturnSesionIDinGroup(sesionID, groupID) != -1)
                    {
                        ToastNotification.Show(this, @"This session already exists in group");
                        return;
                    }

                    ClientDatabaseManager.AddSessionForGroup(groupID, sesionID);
                    if (listBoxGroupName.SelectedItems.Count == 1)
                    {
                        var currSes = _sessions.Find(oo => oo.Id == sesionID);
                        AddSessionToList(currSes);
                    }
                }
            }
            else
            {
                if (comboBoxAutoCollect.SelectedItem == "" || comboBoxAutoCollect.SelectedItem == null) return;

                int groupID = _groupID;
                if (ClientDatabaseManager.ReturnSesionIDinGroup(sesionID, groupID) != -1)
                {
                    ToastNotification.Show(this, @"This session already exists in group");
                    return;
                }

                ClientDatabaseManager.AddSessionForGroup(groupID, sesionID);
                var currSes = _sessions.Find(oo => oo.Id == sesionID);
                AddSessionToList(currSes);


            }
        }

        private void buttonRemoveIntoGroup_Click(object sender, EventArgs e)
        {
            if (!_isSingle)
            {
                if (listBoxGroupName.SelectedItems.Count == 0)
                {
                    ToastNotification.Show(this, @"Ñhoose a group,please");
                    return;
                }
                if (listViewAutocollects.SelectedItems.Count == 0)
                {
                    ToastNotification.Show(this, @"Ñhoose a autocollect,please");
                    return;
                }
                int GroupID = _groups.Find(oo => oo.GroupName == listBoxGroupName.SelectedItems[0]).GroupId;
                for (int index = 0; index < listViewAutocollects.SelectedItems.Count; )
                {
                    int sesionID =
                        _sessions.Find(oo => oo.Name == listViewAutocollects.SelectedItems[index].SubItems[1].Text).Id;
                    ClientDatabaseManager.RemoveSession(GroupID, sesionID);
                    listViewAutocollects.SelectedItems[index].Remove();
                    //  if(index!=0) index--;//

                }
            }
            else
            {
                if (listViewAutocollects.SelectedItems.Count == 0)
                {
                    ToastNotification.Show(this, @"Ñhoose a autocollect,please");
                    return;
                }
                for (int index = 0; index < listViewAutocollects.SelectedItems.Count; )
                {
                    int sesionID =
                        _sessions.Find(oo => oo.Name == listViewAutocollects.SelectedItems[index].SubItems[1].Text).Id;
                    ClientDatabaseManager.RemoveSession(_groupID, sesionID);
                    listViewAutocollects.SelectedItems[index].Remove();

                }
            }





        }

        private void comboBoxAutoCollect_KeyDown(object sender, KeyEventArgs e)
        {


            if (comboBoxAutoCollect.SelectedItem == null)
            {
                ToastNotification.Show(this, "Please, choose autocollect before delete");
                return;
            }

            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Do you wish to delete " + comboBoxAutoCollect.SelectedItem + " session?",
                    "Deleting sesion", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string deleteSesion = comboBoxAutoCollect.SelectedItem.ToString();
                    int sesId = _sessions.Find(oo => oo.Name + "(" + oo.Days + ")" == (string)comboBoxAutoCollect.SelectedItem).Id;
                    if (ClientDatabaseManager.DeleteSesion(sesId))
                    {
                        _sessions = ClientDatabaseManager.GetSessions();
                        for (int index = 0; index < comboBoxAutoCollect.Items.Count; index++)
                        {
                            if (deleteSesion == (string)comboBoxAutoCollect.Items[index])
                            {
                                comboBoxAutoCollect.Items.Remove(comboBoxAutoCollect.Items[index]);
                                listBoxGroupName.SelectedValue = false;
                                listViewAutocollects.Items.Clear();
                                ToastNotification.Show(this, "Deleted");
                                break;
                            }


                        }
                    }
                    else
                    {
                        ToastNotification.Show(this, "Delete error");
                    }

                }
            }
        }

        private void FormAutocollect_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnRefreshGroups();
        }




        private void SingleInitialize()
        {
            listBoxGroupName.Enabled = false;
            textBoxFilter.Enabled = false;
            labelX1.Enabled = false;

            listBoxGroupName.Visible = false;
            textBoxFilter.Visible = false;
            labelX1.Visible = false;

            Point p = new Point(274, 264);
            Size s = new Size(p);
            listViewAutocollects.Size = s;
            p = new Point(348, 47);
            listViewAutocollects.Location = p;

            labelX21.Text =
                ClientDatabaseManager.GetGroups(_userID, ApplicationType.DataNet)
                    .Find(oo => oo.GroupId == _groupID)
                    .GroupName;

            listViewAutocollects.Items.Clear();
            var groupID = _groupID;
            var sesions = ClientDatabaseManager.GetSessionsInGroup(groupID);
            foreach (var sesion in sesions)
            {
                ListViewItem item = new ListViewItem(listViewAutocollects.Items.Count.ToString());
                item.SubItems.Add(sesion.Name);
                item.SubItems.Add(sesion.TimeStart.ToShortTimeString());
                item.SubItems.Add(sesion.Days);
                listViewAutocollects.Items.Add(item);
            }

        }

    }
}