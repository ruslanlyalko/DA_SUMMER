﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TickNetClient.Core;
using System.Linq;
using DADataManager.Models;

namespace TickNetClient.Controls
{
    public partial class StyledListControl : UserControl
    {

        #region EVENTS

        public delegate void ItemStateChangedHandler(int index, GroupState state);

        public event ItemStateChangedHandler ItemStateChanged;

        protected virtual void OnItemStateChanged(int index, GroupState state)
        {
            ItemStateChangedHandler handler = ItemStateChanged;
            if (handler != null) handler(index, state);
        }


        public delegate void ItemEditGroupClickHandler(int itemIndex);

        public event ItemEditGroupClickHandler ItemEditGroupClick;

        protected virtual void OnItemEditGroupClick(int itemIndex)
        {
            ItemEditGroupClickHandler handler = ItemEditGroupClick;
            if (handler != null) handler(itemIndex);
        }

        #endregion


        private int _selectedItem;
        private bool _stateChangingEnabled;

    
        public int SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value < panelEx_container.Controls.Count)
                _selectedItem = value;
                
            }
        }
 


        public StyledListControl()
        {
            InitializeComponent();
            SelectedItem = -1;
        }

    

        void cntrl_ItemSelectedChanged( int itemIndex, GroupState state)
        {                        
            OnItemStateChanged(itemIndex, state);
        }

        public void AddItem(string text, int depth, GroupState state, DateTime datetime, string count, List<string> symbols, List<SessionModel> sessions, bool isAutoCollect)
        {
            var ind = panelEx_container.Controls.Count;
            var cntrl = new StyledListItemControl(text, ind, depth, state, datetime, count,isAutoCollect );
            cntrl.ItemSelectedChanged += cntrl_ItemSelectedChanged;
            cntrl.ItemEditGroupClick += cntrl_ItemEditGroupClick;
            panelEx_container.Controls.Add(cntrl);
            //if(SelectedItem==-1) SelectFirstItem();
            cntrl.Symbols = symbols;
            cntrl.Sessions = sessions;
        }

        void cntrl_ItemEditGroupClick(int itemIndex)
        {
            OnItemEditGroupClick(itemIndex);
        }

        public void RemoveItem(int index)
        {
            SelectedItem = -1;
            bool removed=false;
            for (int i = 0; i < panelEx_container.Controls.Count; i++)
            {
                var item = panelEx_container.Controls[i];
                var styledListItemControl = item as StyledListItemControl;
                if (styledListItemControl != null)
                {
                    if (removed)
                    {
                        styledListItemControl.ItemIndex--;
                    }
                    else if (styledListItemControl.ItemIndex == index)
                    {
                        panelEx_container.Controls.Remove(styledListItemControl);
                        removed = true;
                        i--;
                    }
                }
            }            
        }

        public void RenameSelectedItem(string p)
        {
            var styledListItemControl = panelEx_container.Controls[SelectedItem] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemText = p;
        }

        internal void ClearItems()
        {
            panelEx_container.Controls.Clear();
        }

        internal void ChangeState(int index, GroupState state)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemState = state;
        }

        public void ChangeCollectedCount(int index, int count, int totalCount)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemCount = "["+count+"/"+totalCount+"]";
        }

        public void ChangeDateTime(int index, DateTime end)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemDateTime = end;
        }

        public void SetSymbols(int index, List<string> list)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.Symbols = list;
        }



        public bool StateChangingEnabled
        {
            get { return _stateChangingEnabled; }
            set
            {
                _stateChangingEnabled = value;
                for (int i = 0; i < panelEx_container.Controls.Count; i++)
                {
                    var item = panelEx_container.Controls[i];
                    var styledListItemControl = item as StyledListItemControl;
                    if (styledListItemControl != null)
                    {
                        styledListItemControl.ItemStateChangingEnabled = value;
                    }
                }     
            }
        }

        public void ChangeStartDateTime(int index, DateTime dateTime)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemStartDateTime = dateTime;
        }

        internal void SelectedNone()
        {
            for (int i = 0; i < panelEx_container.Controls.Count; i++)
            {
               
                var styledListItemControl = panelEx_container.Controls[i] as StyledListItemControl;
                if (styledListItemControl != null)
                {
                    if (styledListItemControl.ItemState != GroupState.InProgress)
                    {
                        styledListItemControl.ItemState = GroupState.NotInQueue;
                        styledListItemControl.Refresh();
                        OnItemStateChanged(i, GroupState.NotInQueue);
                    }
                }
            }     
        }

        internal void SelectedAll()
        {
            for (int i = 0; i < panelEx_container.Controls.Count; i++)
            {

                var styledListItemControl = panelEx_container.Controls[i] as StyledListItemControl;
                if (styledListItemControl != null)
                {
                    if (styledListItemControl.ItemState != GroupState.InProgress)
                    {
                        styledListItemControl.ItemState = GroupState.InQueue;
                        styledListItemControl.Refresh();
                        OnItemStateChanged(i, GroupState.InQueue);
                    }
                }
            }     
        }

        public List<string> GetGroups()
        {
            var res = new List<string>();

            foreach (var item in panelEx_container.Controls.OfType<StyledListItemControl>())
            {
                res.Add(item.ItemText);
            }

            return res;
        }


        public void SetItem(int ind, string text, int depth,GroupState groupState, DateTime dateTime, string count, List<string> symbols, List<SessionModel> sessions, bool isAutoCollect)
        {
            if (ind < panelEx_container.Controls.Count)
            {
                var cntrl = panelEx_container.Controls[ind] as StyledListItemControl;

                cntrl.ItemText = text;
                cntrl.ItemState = groupState;
                cntrl.ItemDateTime = dateTime;
                cntrl.Symbols = symbols;
                cntrl.Sessions = sessions;
                cntrl.ItemCount = count;                
                cntrl.ItemIsAutoCollect = isAutoCollect;
                cntrl.ItemDepth = depth;
            }
            else
            {
                AddItem(text, depth, groupState, dateTime, count, symbols, sessions, isAutoCollect);
            }
        }

        internal void SetItemsCount(int count)
        {
            for (int i = count; i < panelEx_container.Controls.Count; i++)
            {
                panelEx_container.Controls.RemoveAt(i);
                i--;
            }
        }
    }
}
