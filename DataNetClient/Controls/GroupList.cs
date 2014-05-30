using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DADataManager.Models;

namespace DataNetClient.Controls
{
    public partial class GroupList : UserControl
    {
        public GroupList()
        {
            InitializeComponent();
        }

        public GroupItemModel ListForGroup
        {
            set;
            get;
        }

        private readonly List<GroupModel> _groupModels=new List<GroupModel>();
        private readonly List<GroupItemModel> _groupItems = new List<GroupItemModel>();

        public GroupItemModel GroupItems
        {
            //get { return _groupItems; }
            set { if (value != null) _groupItems.Add(value); }
        }

        public GroupModel GroupModels
        {
            //get { return _groupModels; }
            set { if (value != null) _groupModels.Add(value); }
        }

        public int Count
        {
            //set { _groupModels.Count = value; }
            get { return _groupModels.Count;}            
        }



        public void AddItem(GroupModel groupModel, GroupItemModel groupItems,List<SessionModel> session)
        {
            _groupModels.Add(groupModel);
            _groupItems.Add(groupItems);
            Redraw(session);
        }

        public void SetItem(int ind, GroupModel groupModel, GroupItemModel groupItems,List<SessionModel> session)
        {
            if (ind < panelEx1.Controls.Count && ind < _groupModels.Count  && ind < _groupItems.Count)
            {
                var item = _groupModels[ind];
                var gi = (GroupItem)(panelEx1.Controls[ind]);
                if (gi != null)
                {
                    gi.ItemName = item.GroupName;
                    gi.TimeFrame = item.TimeFrame;
                    gi.Time = item.End;
                    gi.ContType = item.CntType;
                    gi.Sessions = session;
                    //gi.ItemIsSelected = false;
                    gi.ItemIndex = ind;
                    gi.GroupID = item.GroupId;
                    gi.ItemState = _groupItems[ind].GroupState;
                    gi.Symbols = _groupItems[ind].AllSymbols;
                    gi.SetCount(_groupItems[ind].CollectedSymbols.Count, _groupItems[ind].AllSymbols.Count);
                    //gi.ItemIsAutoCollect = false;
                    //gi.ItemSelectedChanged += gi_ItemSelectedChanged;
                    //gi.ItemEditGroupClick += gi_ItemEditGroupClick;

                }
            }
            else
            {
                AddItem(groupModel, groupItems,session);
            }
        }

        public void ChangeLocationName(int x)
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                g.LocationName = x;

            }
        }
        public void ChangeLocationTf(int x)
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                g.LocationTf = x;

            }
        }
        public void ChangeLocationTime(int x)
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                g.LocationTime = x;

            }
        }
        public void ChangeLocationContType(int x)
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                g.LocationContType = x;

            }
        }

        public void ChangeLocationOutcome(int x)
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                g.LocationOutcome = x;

            }
        }

        public void ChangeLocationStatus(int x)
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                g.LocationStatus = x;

            }
        }

        public void ChangeLocationDay(int x)
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                g.LocationDay = x;

            }
        }

        public void RefreshItem(int index)
        {
            //SetItemsCount(Count);
            //for (int index = 0; index < _groupModels.Count; index++)
            //{
            var item = _groupModels[index];
            var gi = (GroupItem)(panelEx1.Controls[index]);
            if (gi != null)
            {
                gi.ItemName = item.GroupName;
                gi.TimeFrame = item.TimeFrame;
               // gi.Time = item.End;
                gi.ContType = item.CntType;
                gi.ItemIsSelected = false;
                gi.GroupID = item.GroupId;
                gi.ItemState = _groupItems[index].GroupState;
                gi.Symbols = _groupItems[index].AllSymbols;
                gi.SetCount(_groupItems[index].CollectedSymbols.Count, _groupItems[index].AllSymbols.Count);
                gi.ItemIsAutoCollect = false;
                gi.Refresh();
                //gi.ItemSelectedChanged += gi_ItemSelectedChanged;
            }
            // }
        }


        private void Redraw(List<SessionModel> session )
        {
            SetItemsCount(Count);
            //for (int index = 0; index < _groupModels.Count; index++)
            //{
                var item = _groupModels[Count-1];
                var gi = (GroupItem)(panelEx1.Controls[Count - 1]);
                if (gi != null)
                {
                    gi.ItemName = item.GroupName;
                    gi.TimeFrame = item.TimeFrame;
                    gi.Time = item.End;
                    gi.ContType = item.CntType;
                    gi.ItemIsSelected = false;
                    gi.Sessions = session;
                    gi.ItemIndex = Count - 1;
                    gi.GroupID = item.GroupId;
                    gi.ItemState = _groupItems[Count - 1].GroupState;
                    gi.Symbols = _groupItems[Count - 1].AllSymbols;
                    gi.SetCount(_groupItems[Count - 1].CollectedSymbols.Count, _groupItems[Count - 1].AllSymbols.Count);
                    gi.ItemIsAutoCollect = false;
                    gi.ItemSelectedChanged += gi_ItemSelectedChanged;
                    gi.ItemEditGroupClick += gi_ItemEditGroupClick;
                }
           // }
        }

        

        void gi_ItemEditGroupClick(int itemIndex)
        {
            OnItemEditGroupClick(itemIndex);
        }

        void gi_ItemSelectedChanged(int itemIndex, int groupID, GroupState state, bool itemIsSelected, List<string> symbols)
        {
            OnItemStateChanged(itemIndex, groupID, state,itemIsSelected,symbols);
        }
        
        public delegate void ItemEditGroupClickHandler(int itemIndex);

        public event ItemEditGroupClickHandler ItemEditGroupClick;

        protected virtual void OnItemEditGroupClick(int itemIndex)
        {
            ItemEditGroupClickHandler handler = ItemEditGroupClick;
            if (handler != null) handler(itemIndex);
        }

        public void ChangeState(int index, GroupState state)
        {
            var groupItem = panelEx1.Controls[index] as GroupItem;
            if (groupItem != null)
                groupItem.ItemState = state;
        }

        public void ChangeCollectedCount(int index, int count, int totalCount)
        {
            var groupItem = panelEx1.Controls[index] as GroupItem;
            if (groupItem != null)
                groupItem.SetCount(count,totalCount);
        }

        public delegate void ItemStateChangedHandler(int index, int groupID,  GroupState state, bool itemIsSelected,List<string> symbols);

        public event ItemStateChangedHandler ItemStateChanged;

        protected virtual void OnItemStateChanged(int index, int groupID, GroupState state, bool itemIsSelected, List<string> symbols)
        {
            ItemStateChangedHandler handler = ItemStateChanged;
            if (handler != null) handler(index,  groupID, state,itemIsSelected,symbols);
        }
        

        internal void SelectedNone()
        {
            for (int i = 0; i < panelEx1.Controls.Count; i++)
            {
                var groupItem = panelEx1.Controls[i] as GroupItem;
                if (groupItem != null)
                {
                    if (groupItem.ItemState != GroupState.InProgress)
                    {
                        groupItem.ItemState = GroupState.NotInQueue;
                        groupItem.Refresh();
                        OnItemStateChanged(i,groupItem.GroupID, GroupState.NotInQueue,groupItem.ItemIsSelected,groupItem.Symbols);
                    }
                }
            }
        }

        internal void SelectedAll()
        {
            for (int i = 0; i < panelEx1.Controls.Count; i++)
            {
                var groupItem = panelEx1.Controls[i] as GroupItem;
                if (groupItem != null)
                {
                    if (groupItem.ItemState != GroupState.InProgress)
                    {
                        groupItem.ItemState = GroupState.InQueue;
                        groupItem.Refresh();
                        OnItemStateChanged(i, groupItem.GroupID, GroupState.InQueue, groupItem.ItemIsSelected, groupItem.Symbols);
                    }
                }
            }
        }

        public void ChangeDateTime(int index, DateTime end)
        {
            var groupItem = panelEx1.Controls[index] as GroupItem;
            if (groupItem != null)
                groupItem.Time = end;
        }


        public void ClearAllItems()
        {
            panelEx1.Controls.Clear();
        }

        public void RemoveItem(int index)
        {
            if(panelEx1.Controls.Count-1>=index)
            panelEx1.Controls.RemoveAt(index);
        }

        public void AddSession(int groupId, List<SessionModel> sm )
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem) var;
                if (g.GroupID == groupId)
                {
                    foreach (var sessionModel in sm)
                    {
                        g.AddDay(sessionModel.TimeStart,sessionModel.Days);
                    }
                }
            }
        }

        public void ClearAllSession()
        {
            foreach (var var in panelEx1.Controls)
            {
                var g = (GroupItem)var;
                        g.ClearAllDay();
                
            }
        }
        public void RemoveSelectedItems()
        {
            foreach (var groupItem in panelEx1.Controls.Cast<object>().OfType<GroupItem>().Where(groupItem => groupItem.ItemIsSelected))
            {
                panelEx1.Controls.Remove(groupItem);
            }
        }
    
        public void SetItemsCount(int count)
        {
            while (panelEx1.Controls.Count > count)
                panelEx1.Controls.RemoveAt(panelEx1.Controls.Count - 1);

            while (panelEx1.Controls.Count < count)
                 panelEx1.Controls.Add(new GroupItem());

                
        }

        public List<GroupItem> GetSelectedItems()
        {
            var gr = panelEx1.Controls.Cast<object>().OfType<GroupItem>().Where(groupItem => groupItem.ItemIsSelected).ToList();
            return gr;
        }

    }
}
