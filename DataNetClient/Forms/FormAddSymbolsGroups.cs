using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CQG;
using DADataManager;
using DADataManager.Models;
using DevComponents.DotNetBar;

namespace DataNetClient.Forms
{
    public partial class FormAddSymbolsGroups : DevComponents.DotNetBar.Metro.MetroForm
    {


        #region EVENT
        public delegate void RefreshSYmbolsGroupsHandler();

        public static event RefreshSYmbolsGroupsHandler RefreshSYmbolsGroups;

        private void OnRefreshSYmbolsGroups()
        {
            RefreshSYmbolsGroupsHandler handler = RefreshSYmbolsGroups;
            if (handler != null) handler();
        }

        #endregion


        #region VAR

        private int _userID;
        private List<SymbolModel> _symbols = null;
        private List<GroupModel> _groups = null;
        private bool _isSingleGroup = false;
        private GroupModel _group = null;
        private int _groupID;
        private List<string> _symbolsList = new List<string>();
        private bool _isStandart = false;

        #endregion

        public FormAddSymbolsGroups(int userID, int groupID = -1)
        {
            InitializeComponent();
            if (groupID == -1)
            {

                _userID = userID;
                _symbols = ClientDatabaseManager.GetSymbols(_userID, false);
                _groups = ClientDatabaseManager.GetGroupsForUser(_userID, ApplicationType.DataNet);
            }
            else
            {
                _groupID = groupID;
                _userID = userID;
                _group = ClientDatabaseManager.GetGroups(_userID, ApplicationType.DataNet).Find(oo => oo.GroupId == groupID);
                _symbols = ClientDatabaseManager.GetSymbols(_userID, false);
                _isSingleGroup = true;
            }


        }

        private void FromAddSymbolsGroups_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panelSymbolItems.BackColor = Color.White;
            listViewGroups.BackColor = Color.GhostWhite;
            listViewSymbolsForGroup.BackColor = Color.GhostWhite;
            listBoxSymbols.BackColor = Color.GhostWhite;
            textBoxGroupsFilter.BackColor = Color.GhostWhite;
            comboBoxConType.BackColor = Color.GhostWhite;
            comboBoxTF.BackColor = Color.GhostWhite;
            textBoxSymbolFilter.BackColor = Color.GhostWhite;
            InitListViewSymbols();
            if (!_isSingleGroup)
            {
                //AliceBlue
                //Color.GhostWhite

                //   listViewGroups.TopItem.BackColor = Color.Red;
                InitListViewGroups();
            }
            else
            {
                SingleGroupInitialize();
                labelX21.Text = _group.GroupName;

            }

        }




        private void InitListViewSymbols()
        {

            listBoxSymbols.Items.Clear();

            foreach (var sym in _symbols)
            {
                // panelSymbols.Controls.Add(new SymbolItem(sym.SymbolName));
                listBoxSymbols.Items.Add(sym.SymbolName);

            }


        }

        private void InitListViewGroups()
        {
            foreach (var model in _groups)
            {
                ListViewItem item = new ListViewItem(model.GroupName);
                item.SubItems.Add(model.TimeFrame);
                item.SubItems.Add(model.CntType);
                item.SubItems.Add(model.GroupId.ToString());
                listViewGroups.Items.Add(item);
            }
            comboBoxConType.Items.Clear();
            comboBoxConType.Items.Add(eTimeSeriesContinuationType.tsctNoContinuation);
            comboBoxConType.Items.Add(eTimeSeriesContinuationType.tsctStandard);

        }


        private string GetCntTypeOfSymbol(string currSmb)
        {
            var isNoCont = false;
            var lastIndex = currSmb.Length - 1;
            var month = new List<char> { 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'Q', 'U', 'V', 'X', 'Z' };

            if (Char.IsDigit(currSmb[lastIndex]) && char.IsDigit(currSmb[lastIndex - 1]) &&
                month.Contains(currSmb.ToUpper()[lastIndex - 2]))
                isNoCont = true;
            return isNoCont ? "tsctNoContinuation" : "tsctStandard";
        }


        private void buttonAddToGroup_Click(object sender, EventArgs e)
        {
            var message = "";
            var symbCount = listBoxSymbols.SelectedItems.Count;
            var groupCount = listViewGroups.SelectedItems.Count;
            if (!_isSingleGroup)
            {
                if (symbCount == 0)
                {
                    ToastNotification.Show(this, "Please, select symbols");
                    return;
                }
                if (groupCount == 0)
                {
                    ToastNotification.Show(this, "Please, select groups");
                    return;
                }

                for (int i = 0; i < symbCount; i++)
                {
                    var currSmb = listBoxSymbols.SelectedItems[i].ToString();
                    var currSmbId = _symbols.Find(a => a.SymbolName == currSmb).SymbolId;

                    for (int j = 0; j < groupCount; j++)
                    {
                        var currGroupName = listViewGroups.SelectedItems[j].SubItems[0].Text;
                        var currGrp = _groups.Find(a => a.GroupName == currGroupName);
                        var currGroupId = currGrp.GroupId;
                        var currGroupSymbols = ClientDatabaseManager.GetSymbolsInGroup(currGroupId);
                        if (!currGroupSymbols.Exists(a => a.SymbolName == currSmb))
                        {
                            var sModel = new SymbolModel { SymbolId = currSmbId, SymbolName = currSmb };

                            if (GetCntTypeOfSymbol(currSmb) == currGrp.CntType)
                            {
                                ClientDatabaseManager.AddSymbolIntoGroup(currGroupId, sModel);
                                listViewSymbolsForGroup.Items.Add(sModel.SymbolName);
                            }

                            else
                                message += " Symbol: '" + currSmb + "' can't be added to '" + currGroupName + "' group";
                        }
                    }

                }
            }
            else
            {
                if (symbCount == 0)
                {
                    ToastNotification.Show(this, "Please, select symbols");
                    return;
                }
                for (int i = 0; i < symbCount; i++)
                {
                    var currSmb = listBoxSymbols.SelectedItems[i].ToString();
                    var currSmbId = _symbols.Find(a => a.SymbolName == currSmb).SymbolId;
                    var currGroupName = _group.GroupName;
                    var currGrp = _group;
                    var currGroupId = currGrp.GroupId;
                    var currGroupSymbols = ClientDatabaseManager.GetSymbolsInGroup(currGroupId);
                    if (!currGroupSymbols.Exists(a => a.SymbolName == currSmb))
                    {
                        var sModel = new SymbolModel { SymbolId = currSmbId, SymbolName = currSmb };

                        if (GetCntTypeOfSymbol(currSmb) == currGrp.CntType)
                        {
                            ClientDatabaseManager.AddSymbolIntoGroup(currGroupId, sModel);
                            listViewSymbolsForGroup.Items.Add(sModel.SymbolName);
                        }

                        else
                            message += " Symbol: '" + currSmb + "' can't be added to '" + currGroupName + "' group";

                    }
                }
            }
            ToastNotification.Show(this, "Joined.");
            if (!String.IsNullOrEmpty(message))
                ToastNotification.Show(this, message);

        }

        private void listViewGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGroups.SelectedItems.Count == 0 || listViewGroups.SelectedItems.Count > 1)
            {
                listViewSymbolsForGroup.Items.Clear();
                return;
            }
            listViewSymbolsForGroup.Items.Clear();
            var groupID = Convert.ToInt32(listViewGroups.SelectedItems[0].SubItems[3].Text);
            var groupItem = ClientDatabaseManager.GetSymbolsInGroup(groupID);
            foreach (var symbolInGroup in groupItem)
            {
                listViewSymbolsForGroup.Items.Add(symbolInGroup.SymbolName);
            }
        }

        private void textBoxGroupsFilter_TextChanged(object sender, EventArgs e)
        {
            listViewGroups.Items.Clear();
            listViewSymbolsForGroup.Items.Clear();
            foreach (var groupModel in _groups)
            {
                if (groupModel.GroupName.Contains(textBoxGroupsFilter.Text))
                {
                    ListViewItem item = new ListViewItem(groupModel.GroupName);
                    item.SubItems.Add(groupModel.TimeFrame);
                    item.SubItems.Add(groupModel.CntType);
                    item.SubItems.Add(groupModel.GroupId.ToString());
                    listViewGroups.Items.Add(item);
                }
            }
        }

        private void textBoxSymbolFilter_TextChanged(object sender, EventArgs e)
        {
            listBoxSymbols.Items.Clear();
            foreach (var sym in _symbols)
            {
                if (sym.SymbolName.ToUpper().Contains(textBoxSymbolFilter.Text.ToUpper()))
                {
                    listBoxSymbols.Items.Add(sym.SymbolName);
                }
            }
        }

        private void buttonSymbolADD_Click(object sender, EventArgs e)
        {
            if (textBoxSymbolFilter.Text.Contains(" ") | textBoxSymbolFilter.Text == "") return;
            if (_symbols.Any(sym => sym.SymbolName == textBoxSymbolFilter.Text)) return;
            var newSymbol = textBoxSymbolFilter.Text;
            if (!ClientDatabaseManager.CurrentDbIsShared) ClientDatabaseManager.AddNewSymbol(newSymbol);
            if (ClientDatabaseManager.CurrentDbIsShared)
            {
                if (!_symbols.Exists(a => a.SymbolName == newSymbol)) ClientDatabaseManager.AddNewSymbol(newSymbol);
                ClientDatabaseManager.Commit();
                var symbolId = ClientDatabaseManager.GetAllSymbols().Find(a => a.SymbolName == newSymbol).SymbolId;
                ClientDatabaseManager.AddSymbolForUser(_userID, symbolId, ApplicationType.DataNet);
                _symbols = ClientDatabaseManager.GetSymbols(_userID, false);
                listBoxSymbols.Items.Add(newSymbol);
            }
            ToastNotification.Show(this, "Symbol '" + newSymbol + "' added");
            textBoxSymbolFilter.Text = "";
        }

        private void buttonSymbolDELETE_Click(object sender, EventArgs e)
        {
            if (listBoxSymbols.SelectedItems == null) return;
            var listSymbols = new List<string>();
            var list = "";
            foreach (var item in listBoxSymbols.SelectedItems)
            {

                listSymbols.Add(item.ToString());
                list += item + ", ";

            }
            if (list.Count() == 0) return;
            list = list.Substring(0, list.Length - 2);
            if (listSymbols.Count == 0)
            {
                ToastNotification.Show(this, "Please, select symbol");
                return;
            }
            if (MessageBox.Show("Do you wish to delete " + listSymbols.Count + " symbol(s) [" + list + "] ?",
                "Deleting symbols", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                foreach (var item in listSymbols)
                {
                    if (!ClientDatabaseManager.CurrentDbIsShared)
                        ClientDatabaseManager.DeleteSymbol(_symbols.Find(a => a.SymbolName == item).SymbolId);
                    if (ClientDatabaseManager.CurrentDbIsShared)
                    {
                        var symbolId = _symbols.Find(a => a.SymbolName == item).SymbolId;
                        if (ClientDatabaseManager.IsSymbolOnlyForThisUser(symbolId))
                        {
                            ClientDatabaseManager.DeleteSymbol(symbolId);
                        }
                        ClientDatabaseManager.DeleteSymbolForUser(_userID, symbolId, ApplicationType.DataNet);
                        for (int index = 0; index < listBoxSymbols.Items.Count; index++)
                        {
                            string li = (string)listBoxSymbols.Items[index];
                            if (li.ToUpper() == item.ToUpper())
                            {
                                listBoxSymbols.Items.Remove(li);
                                if (index != 0) index--;
                                listBoxSymbols.Refresh();
                            }
                        }
                    }
                }
                _symbols = ClientDatabaseManager.GetSymbols(_userID, false);


            }
        }

        private void buttonGroupADD_Click(object sender, EventArgs e)
        {
            if (_symbolsList.Count == 0)
            {
                if (textBoxGroupsFilter.Text == "" || textBoxGroupsFilter.Text.Contains(" ")) return;
                if (comboBoxConType.SelectedItem == null) return;
                if (comboBoxTF.SelectedItem == null) return;
                var groups = ClientDatabaseManager.GetGroupsForUser(_userID, ApplicationType.DataNet);
                var group = new GroupModel
                {
                    GroupName = textBoxGroupsFilter.Text,
                    TimeFrame = comboBoxTF.SelectedItem.ToString(),
                    Start = new DateTime(),
                    End = new DateTime(),
                    CntType = comboBoxConType.SelectedItem.ToString(),
                    IsAutoModeEnabled = false,

                };
                if (!groups.Exists(oo => oo.GroupName == group.GroupName) &&
                    !ClientDatabaseManager.GetAllGroups(ApplicationType.DataNet)
                        .Exists(a => a.GroupName == group.GroupName))
                {

                    if (ClientDatabaseManager.AddGroupOfSymbols(group))
                    {
                        group.GroupId = ClientDatabaseManager.GetGroupIdByName(group.GroupName);
                        ClientDatabaseManager.AddGroupForUser(_userID, group, ApplicationType.DataNet);
                        _groups = ClientDatabaseManager.GetGroupsForUser(_userID, ApplicationType.DataNet);

                        //todo ClientServiceProxy

                        ListViewItem item = new ListViewItem(group.GroupName);
                        item.SubItems.Add(group.TimeFrame);
                        item.SubItems.Add(group.CntType);
                        item.SubItems.Add(group.GroupId.ToString());
                        listViewGroups.Items.Add(item);
                    }
                }
                else
                {
                    ToastNotification.Show(this, "This group alredy exist");
                }

            }
            else
            {
                if (textBoxGroupsFilter.Text == "" || textBoxGroupsFilter.Text.Contains(" "))
                {
                    ToastNotification.Show(this, @"Please, enter group name");
                    return;
                }
                if (comboBoxTF.SelectedItem == null)
                {
                    ToastNotification.Show(this, @"Please, chose TF");
                    return;
                }
                var groups = ClientDatabaseManager.GetGroupsForUser(_userID, ApplicationType.DataNet);
                var conType = eTimeSeriesContinuationType.tsctNoContinuation.ToString();
                if (_isStandart)
                {
                    conType = eTimeSeriesContinuationType.tsctStandard.ToString();
                }

                var group = new GroupModel
                {
                    GroupName = textBoxGroupsFilter.Text,
                    TimeFrame = comboBoxTF.SelectedItem.ToString(),
                    Start = new DateTime(),
                    End = new DateTime(),
                    CntType = conType,
                    IsAutoModeEnabled = false,

                };
                if (!groups.Exists(oo => oo.GroupName == group.GroupName) &&
                    !ClientDatabaseManager.GetAllGroups(ApplicationType.DataNet)
                        .Exists(a => a.GroupName == group.GroupName))
                {

                    if (ClientDatabaseManager.AddGroupOfSymbols(group))
                    {
                        group.GroupId = ClientDatabaseManager.GetGroupIdByName(group.GroupName);
                        ClientDatabaseManager.AddGroupForUser(_userID, group, ApplicationType.DataNet);
                        _groups = ClientDatabaseManager.GetGroupsForUser(_userID, ApplicationType.DataNet);

                        //todo ClientServiceProxy

                        ListViewItem item = new ListViewItem(group.GroupName);
                        item.SubItems.Add(group.TimeFrame);
                        item.SubItems.Add(group.CntType);
                        item.SubItems.Add(group.GroupId.ToString());
                        listViewGroups.Items.Add(item);
                        for (int i = 0; i < _symbolsList.Count; i++)
                        {
                            var currSmb = _symbolsList[i];
                            var currSmbId = _symbols.Find(a => a.SymbolName == currSmb).SymbolId;
                            //var currGroupName = group.GroupName;
                            var currGrp = group;
                            var currGroupId = currGrp.GroupId;
                            var sModel = new SymbolModel { SymbolId = currSmbId, SymbolName = currSmb };

                            if (GetCntTypeOfSymbol(currSmb) == currGrp.CntType)
                            {
                                ClientDatabaseManager.AddSymbolIntoGroup(currGroupId, sModel);
                            }
                        }
                        _symbolsList.Clear();
                        buttonCopy.Text = "Copy";
                    }
                    else
                    {
                        ToastNotification.Show(this, "This group alredy exist");
                    }
                }
            }
            textBoxGroupsFilter.Text = "";

        }

        private void buttonGroupDelete_Click(object sender, EventArgs e)
        {
            ApplicationType type = ApplicationType.DataNet;
            var groups = ClientDatabaseManager.GetGroupsForUser(_userID, type);

            if (groups.Exists(oo => oo.GroupName == textBoxGroupsFilter.Text))
            {
                if (MessageBox.Show("Do you wish to delete " + textBoxGroupsFilter.Text + " groups ?",
                    "Deleting group", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    var curGroup = groups.Find(oo => oo.GroupName == textBoxGroupsFilter.Text);

                    ClientDatabaseManager.DeleteGroupForUser(_userID, curGroup.GroupId, "DataNet");
                    _groups = ClientDatabaseManager.GetGroupsForUser(_userID, ApplicationType.DataNet);
                    foreach (ListViewItem itemsL in listViewGroups.Items)
                    {
                        if (itemsL.SubItems[0].Text == curGroup.GroupName)
                            itemsL.Remove();

                    }
                }

            }
            else
            {
                ToastNotification.Show(this, "This group alredy exist");
            }
        }

        private void buttonDeleteFromGroup_Click(object sender, EventArgs e)
        {
            if (listViewSymbolsForGroup.SelectedItems.Count == 0)
            {
                ToastNotification.Show(this, @"Pleas, select symbol(s)");
                return;
            }
            if (!_isSingleGroup)
            {
                if (listViewGroups.SelectedItems.Count == 0)
                {
                    ToastNotification.Show(this, @"Pleas, select group");
                    return;
                }
                for (int index = 0; index < listViewSymbolsForGroup.SelectedItems.Count; )
                {
                    string symbolItem = listViewSymbolsForGroup.SelectedItems[index].Text;
                    var cuurSmbID = _symbols.Find(a => a.SymbolName == symbolItem).SymbolId;

                    foreach (ListViewItem groupsItems in listViewGroups.SelectedItems)
                    {
                        var group = _groups.Find(oo => oo.GroupName == groupsItems.SubItems[0].Text);
                        var groupSymbols =
                            ClientDatabaseManager.GetSymbolsInGroup(Convert.ToInt16(groupsItems.SubItems[3].Text));
                        if (groupSymbols.Exists(oo => oo.SymbolName == symbolItem))
                        {
                            var currGroupId = group.GroupId;
                            {
                                ClientDatabaseManager.DeleteSymbolFromGroup(currGroupId, cuurSmbID);
                                ToastNotification.Show(this, "Deleted.");
                                foreach (ListViewItem itemsL in listViewSymbolsForGroup.Items)
                                {
                                    if (itemsL.Text == symbolItem)
                                        itemsL.Remove();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int index = 0; index < listViewSymbolsForGroup.SelectedItems.Count; )
                {
                    string symbolItem = listViewSymbolsForGroup.SelectedItems[index].Text;
                    var cuurSmbID = _symbols.Find(a => a.SymbolName == symbolItem).SymbolId;
                    var group = _group;
                    var groupSymbols =
                        ClientDatabaseManager.GetSymbolsInGroup(_groupID);
                    if (groupSymbols.Exists(oo => oo.SymbolName == symbolItem))
                    {
                        var currGroupId = group.GroupId;
                        {
                            ClientDatabaseManager.DeleteSymbolFromGroup(currGroupId, cuurSmbID);
                            ToastNotification.Show(this, "Deleted.");
                            foreach (ListViewItem itemsL in listViewSymbolsForGroup.Items)
                            {
                                if (itemsL.Text == symbolItem)
                                    itemsL.Remove();
                            }
                        }

                    }
                }
            }

        }

        private void FormAddSymbolsGroups_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnRefreshSYmbolsGroups();
        }



        private void SingleGroupInitialize()
        {
            buttonGroupADD.Enabled = false;
            buttonGroupDelete.Enabled = false;
            comboBoxConType.Enabled = false;
            buttonCopy.Enabled = false;

            comboBoxTF.Enabled = false;
            textBoxGroupsFilter.Enabled = false;
            listViewGroups.Enabled = false;
            labelX1.Enabled = false;


            buttonGroupADD.Visible = false;
            buttonGroupDelete.Visible = false;
            comboBoxConType.Visible = false;
            comboBoxTF.Visible = false;
            buttonCopy.Visible = false;
            textBoxGroupsFilter.Visible = false;
            listViewGroups.Visible = false;
            labelX1.Visible = false;


            Point p = new Point(331, 273);
            Size size = new Size(p);
            p = new Point(0, 0);
            listViewSymbolsForGroup.Size = size;
            listViewSymbolsForGroup.Location = p;
            listViewSymbolsForGroup.Items.Clear();
            var groupItem = ClientDatabaseManager.GetSymbolsInGroup(_groupID);
            foreach (var symbolInGroup in groupItem)
            {
                listViewSymbolsForGroup.Items.Add(symbolInGroup.SymbolName);
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (buttonCopy.Text == "Copy")
            {
                if (listViewGroups.SelectedItems.Count == 0)
                {
                    ToastNotification.Show(this, @"Please, chose group in group list");
                    return;
                }
                _symbolsList.Clear();
                var groupID = Convert.ToInt32(listViewGroups.SelectedItems[0].SubItems[3].Text);
                var groupItem = ClientDatabaseManager.GetSymbolsInGroup(groupID);
                if (groupItem.Count == 0)
                {
                    ToastNotification.Show(this,
                       (listViewGroups.SelectedItems[0].SubItems[0].Text) + @" is empty");
                    return;
                }
                foreach (var symbolInGroup in groupItem)
                {
                    _symbolsList.Add(symbolInGroup.SymbolName);
                }
                if (listViewGroups.SelectedItems[0].SubItems[2].Text ==
                    eTimeSeriesContinuationType.tsctStandard.ToString())
                    _isStandart = true;
                else
                {
                    _isStandart = false;
                }
                buttonCopy.Text = "Clear buffer";
            }
            else
            {
                _symbolsList.Clear();
                buttonCopy.Text = "Copy";
                ToastNotification.Show(this, @" buffer is clear");
            }


        }
    }


}
