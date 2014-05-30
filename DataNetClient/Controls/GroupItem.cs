using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DADataManager.Models;
using DataNetClient.Forms;
using DevComponents.DotNetBar;

namespace DataNetClient.Controls
{
    public sealed partial class GroupItem : UserControl
    {
        public GroupItem()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            _isSelected = false;
            EditListControl.AddSesion += EditListControl_AddSesion;
            EditListControl.RemoveSesion += EditListControl_RemoveSesion;
            expandablePanel1.Size = new Size(29, expandablePanel1.Size.Height);
            //listViewEx3.SuspendLayout();
            //columnHeader_name.Width = listViewEx3.ClientSize.Width * .65;
            //columnHeader2.Width = listView1.ClientSize.Width - columnHeader1.Width;
            //listView1.ResumeLayout();
            
        }

        void EditListControl_RemoveSesion(int index)
        {
            RemoveDay(index);
        }

        void EditListControl_AddSesion(SessionModel sesions)
        {
           AddDay(sesions.TimeStart,sesions.Days);
        }


        private bool _isAutoCollect;
        public bool ItemIsAutoCollect
        {
            get { return _isAutoCollect; }
            set
            {
                _isAutoCollect = value;
                labelX_Autocollect.Text = _isAutoCollect ? "ON" : "OFF";
            }
        }


        public Color ItemColor
        {
            get { return panelEx_Main.Style.BackColor1.Color; }
            set { //panelEx_Main.Style.BackColor1.Color = value;
                panelEx5.Style.BackColor1.Color = value;
                panelEx6.Style.BackColor1.Color = value;
                panelEx7.Style.BackColor1.Color = value;
                panelEx8.Style.BackColor1.Color = value;
                panelEx9.Style.BackColor1.Color = value;
                panelEx10.Style.BackColor1.Color = value;
                panelEx_logs.Style.BackColor1.Color = value;
                expandablePanel1.TitleStyle.BackColor1.Color = value;
                panelEx_Day.Style.BackColor1.Color = value;
                foreach (var item in panelEx_Day.Controls)
                {
                    var i = (Day) item;
                    i.ItemsColor(value);
                }
            }
        }

        public string ItemName
        {
            get { return labelX_Name.Text; }
            set { labelX_Name.Text = value.ToUpper(); grid.Columns[0].HeaderText = value.ToUpper(); }
        }

        public string TimeFrame
        {
            get { return labelX_TimeFrame.Text; }
            set { labelX_TimeFrame.Text = value.ToUpper(); grid.Columns[1].HeaderText = value.ToUpper(); }
        }

        public void SetCount(int col, int all)
        {
            labelX_Status_Count.Text=col+"/"+all;
        }

        private DateTime _time ;
        public DateTime Time
        {
            set { _time = value; UpdateTime(); }
            get { return _time; }
        }

        public string ContType
        {
            get { return labelX_ContType.Text; }
            set { labelX_ContType.Text = value;
                grid.Columns[3].HeaderText = value;
            }
        }
        public int ItemIndex { get; set; }
        public int GroupID { get; set; }
        private bool _isSelected;
        public bool ItemIsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnItemSelectedChanged(ItemIndex,GroupID, ItemState,_isSelected,Symbols);
            }
        }

        public delegate void ItemEditGroupClickHandler(int itemIndex);

        public event ItemEditGroupClickHandler ItemEditGroupClick;

        private void OnItemEditGroupClick(int itemIndex)
        {
            ItemEditGroupClickHandler handler = ItemEditGroupClick;
            if (handler != null) handler(itemIndex);
        }

        public delegate void ItemSelectedChangedHandler(int itemIndex, int groupID, GroupState state, bool itemIsSelected,List<string> symbols);

        public event ItemSelectedChangedHandler ItemSelectedChanged;

        private void OnItemSelectedChanged(int itemIndex, int groupID, GroupState state, bool itemIsSelected, List<string> symbols)
        {
            //panelEx_isSelected.Visible = _isSelected;
            if (ItemState != GroupState.InProgress && _isSelected)
                ItemState = GroupState.InQueue;
             
            if (ItemState != GroupState.InProgress && !_isSelected)
                ItemState = GroupState.NotInQueue;
              
            ItemSelectedChangedHandler handler = ItemSelectedChanged;
            if (handler != null) handler(itemIndex, groupID, ItemState,ItemIsSelected,Symbols);
        }

        public delegate void ItemRefreshHandler();

        public event ItemRefreshHandler ItemRefresh;

        private void panelEx_Main_Click(object sender, EventArgs e)
        {
            ItemIsSelected = !ItemIsSelected;
            
            Focus();
        }
        

        public GroupItemModel SymbolsList
        {
            set;
            get;
        }

        private int _itemHeight;
        private List<string> _symbols;    
        public List<string> Symbols
        {
            get { return _symbols; }
            set
            {
                _symbols = value;
                _itemHeight = _symbols.Count * 17 + 26 + 31;
                if (_itemHeight > 250)
                    _itemHeight = 250; 
                if (expandablePanel1.Expanded)
                    Height = _itemHeight;
                listViewEx2.Controls.Add(new GroupItem());
                listViewEx2.Clear();
                foreach (var symbolModel in _symbols)
                {
                    listViewEx2.Items.Add(symbolModel +"  [ "+ Time+" ]");
                }
            }
        }


        private void expandablePanel1_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (expandablePanel1.Expanded)
            {
                Height = _itemHeight;
                panelEx_Day.Height = _itemHeight;
                
                //listViewEx1.Items.Add("erere");
                //panelEx_Main.BringToFront();
                //expandablePanel1.BringToFront();
                //listViewEx1.BringToFront();

                //line6.Height = _itemHeight;
            }
        }

        private void expandablePanel1_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (expandablePanel1.Expanded)
            {
                Height = 57;
                panelEx_Day.Height = 57;
                expandablePanel1.Size = new Size(29,expandablePanel1.Size.Height);
                //line6.Height = 53;
            }
            
        }

        //public delegate void ItemColorChangedHandler(Status status);

        //public event ItemColorChangedHandler ItemColorChanged;

        private void StatusChanged(GroupState state)
        {
            //if (state == GroupState.Unsuccessful) ItemColor = Color.Red;
            if (state == GroupState.Finished) ItemColor = Color.LightGreen;
            if (state == GroupState.InProgress) ItemColor = Color.Yellow;
            if (state == GroupState.InQueue) ItemColor = Color.DodgerBlue;
            if (state == GroupState.NotInQueue) ItemColor = Color.White;

            //ItemColorChangedHandler handler = ItemColorChanged;
            //if (handler != null) handler(status);
        }

        private GroupState _state;
        public GroupState ItemState
        {
            get { return _state; }
            set
            {
                _state = value;
                labelX_Status_Name.Text = _state.ToString();
                StatusChanged(_state);
            }
        }

        public void AddDay(DateTime time,string days)
        {
            //days.Trim('_');
            //days.Replace('_', '/');
            
            var day = new Day(GroupID, ItemIndex,time,days);
            
            panelEx_Day.Controls.Add(day);
        }

        public void ClearAllDay()
        {
            panelEx_Day.Controls.Clear();
        }

        private List<SessionModel> _sessions;
        public List<SessionModel> Sessions
        {
            get { return _sessions; }
            set
            {
                _sessions = value;
                panelEx_Day.Controls.Clear();

                foreach (var s in _sessions)
                {
                    AddDay(s.TimeStart,s.Days);
                }
            }
        }

        public void RemoveDay(int index)
        {
            if (panelEx_Day.Controls.Count - 1 >= index)
            {
                panelEx_Day.Controls.RemoveAt(index);
            }
        }

        public void RemoveSelectedDay()
        {
            foreach (var day in panelEx_Day.Controls.Cast<object>().OfType<Day>().Where(day => day.ItemIsSelected))
            {
                panelEx_Day.Controls.Remove(day);
            }
        }

        private void UpdateTime()
        {
            if (DateTime.Now.AddMinutes(-2) < Time)
                labelX_Time.Text = "just now";
            else
            {
                int totalLocalMinutes = Convert.ToInt32(Math.Floor((DateTime.Now - Time).TotalMinutes));
                int totalLocalHours = Convert.ToInt32(Math.Floor((DateTime.Now - Time).TotalHours));
                int totalLocalDays = Convert.ToInt32(Math.Floor((DateTime.Now - Time).TotalDays));

                labelX_Time.Text =
                    totalLocalMinutes < 60
                        ? totalLocalMinutes + " minutes ago"
                        : totalLocalHours < 24
                            ? totalLocalHours + " hours ago"
                            : totalLocalDays < 30
                                ? totalLocalDays + " days ago"
                                : totalLocalDays > 365 ? "-" : Time.ToShortDateString();
            }
        }

        private void timer_update_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        public int LocationName
        {
            get
            {
                return labelX_Name.Size.Width;
            }
            set
            {
                /*line1.Location = new Point(value, line1.Location.Y);
                labelX_Name.Size = new Size(value-labelX_Name.Location.X, labelX_Name.Size.Height);
                line2.Location = new Point(value + labelX_TimeFrame.Size.Width+9, line2.Location.Y);
                labelX_TimeFrame.Location = new Point(value, labelX_TimeFrame.Location.Y);
                line3.Location = new Point(value + labelX_TimeFrame.Size.Width+labelX_Time.Size.Width+9, line3.Location.Y);
                labelX_Time.Location = new Point(line2.Location.X, labelX_Time.Location.Y);
                line4.Location = new Point(value + labelX_TimeFrame.Size.Width + labelX_Time.Size.Width+labelX_ContType.Size.Width+9, line4.Location.Y);
                labelX_ContType.Location = new Point(line3.Location.X, labelX_ContType.Location.Y);
                line5.Location = new Point(value + labelX_TimeFrame.Size.Width + labelX_Time.Size.Width + labelX_ContType.Size.Width+labelX_Status_Name.Size.Width+9, line5.Location.Y);
                labelX_Status_Name.Location = new Point(line4.Location.X+2, labelX_Status_Name.Location.Y);
                labelX_Status_Count.Location = new Point(line4.Location.X+2, labelX_Status_Count.Location.Y);
                line6.Location = new Point(value + labelX_TimeFrame.Size.Width + labelX_Time.Size.Width + labelX_ContType.Size.Width + labelX_Status_Name.Size.Width+labelX_Autocollect.Size.Width+9, line6.Location.Y);
                labelX_Autocollect.Location = new Point(line5.Location.X + 2, labelX_Autocollect.Location.Y);
                panelEx_Day.Location = new Point(line6.Location.X + 2, panelEx_Day.Location.Y);*/
                
            }
        }

        

        public int LocationTf
        {
            get
            {
                return labelX_Time.Location.X;
            }
            set
            {
                /*//line1.Location = new Point(value, line1.Location.Y);
                //labelX_Name.Size = new Size(value - labelX_Name.Location.X, labelX_Name.Size.Height);
                line2.Location = new Point(value, line2.Location.Y);
                labelX_TimeFrame.Size = new Size(value - labelX_TimeFrame.Location.X, labelX_TimeFrame.Size.Height);
                line3.Location = new Point(value + labelX_Time.Size.Width+9, line3.Location.Y);
                labelX_Time.Location = new Point(line2.Location.X, labelX_Time.Location.Y);
                line4.Location = new Point(value + labelX_Time.Size.Width + labelX_ContType.Size.Width + 9, line4.Location.Y);
                labelX_ContType.Location = new Point(line3.Location.X, labelX_ContType.Location.Y);
                line5.Location = new Point(value + labelX_Time.Size.Width + labelX_ContType.Size.Width + labelX_Status_Name.Size.Width + 9, line5.Location.Y);
                labelX_Status_Name.Location = new Point(line4.Location.X + 2, labelX_Status_Name.Location.Y);
                labelX_Status_Count.Location = new Point(line4.Location.X + 2, labelX_Status_Count.Location.Y);
                line6.Location = new Point(value + labelX_Time.Size.Width + labelX_ContType.Size.Width + labelX_Status_Name.Size.Width + labelX_Autocollect.Size.Width + 9, line6.Location.Y);
                labelX_Autocollect.Location = new Point(line5.Location.X + 2, labelX_Autocollect.Location.Y);
                panelEx_Day.Location = new Point(line6.Location.X + 2, panelEx_Day.Location.Y);*/
            }
        }
        public int LocationTime
        {
            get
            {
                return labelX_ContType.Location.X;
            }
            set
            {
               /* //line1.Location = new Point(value, line1.Location.Y);
                //labelX_Name.Size = new Size(value - labelX_Name.Location.X, labelX_Name.Size.Height);
                //line2.Location = new Point(value + labelX_TimeFrame.Size.Width, line2.Location.Y);
               // labelX_TimeFrame.Location = new Point(value, labelX_TimeFrame.Location.Y);
                line3.Location = new Point(value, line3.Location.Y);
                labelX_Time.Size = new Size(value - labelX_Time.Location.X, labelX_Name.Size.Height);
                line4.Location = new Point(value + labelX_ContType.Size.Width + 9, line4.Location.Y);
                labelX_ContType.Location = new Point(line3.Location.X, labelX_ContType.Location.Y);
                line5.Location = new Point(value + labelX_ContType.Size.Width + labelX_Status_Name.Size.Width + 9, line5.Location.Y);
                labelX_Status_Name.Location = new Point(line4.Location.X + 2, labelX_Status_Name.Location.Y);
                labelX_Status_Count.Location = new Point(line4.Location.X + 2, labelX_Status_Count.Location.Y);
                line6.Location = new Point(value + labelX_ContType.Size.Width + labelX_Status_Name.Size.Width + labelX_Autocollect.Size.Width + 9, line6.Location.Y);
                labelX_Autocollect.Location = new Point(line5.Location.X + 2, labelX_Autocollect.Location.Y);
                panelEx_Day.Location = new Point(line6.Location.X + 2, panelEx_Day.Location.Y);*/
            }
        }
        public int LocationContType
        {
            get
            {
                return labelX_Status_Name.Location.X;
            }
            set
            {
               /* //line1.Location = new Point(value, line1.Location.Y);
                //labelX_Name.Size = new Size(value - labelX_Name.Location.X, labelX_Name.Size.Height);
                //line2.Location = new Point(value + labelX_TimeFrame.Size.Width, line2.Location.Y);
                //labelX_TimeFrame.Location = new Point(value, labelX_TimeFrame.Location.Y);
                //line3.Location = new Point(value + labelX_TimeFrame.Size.Width + labelX_Time.Size.Width, line3.Location.Y);
                //labelX_Time.Location = new Point(line2.Location.X, labelX_Time.Location.Y);
                line4.Location = new Point(value, line4.Location.Y);
                labelX_ContType.Size = new Size(value - labelX_ContType.Location.X, labelX_Name.Size.Height);
                line5.Location = new Point(value + labelX_Status_Name.Size.Width + 9, line5.Location.Y);
                labelX_Status_Name.Location = new Point(line4.Location.X + 2, labelX_Status_Name.Location.Y);
                labelX_Status_Count.Location = new Point(line4.Location.X + 2, labelX_Status_Count.Location.Y);
                line6.Location = new Point(value + labelX_Status_Name.Size.Width + labelX_Autocollect.Size.Width + 9, line6.Location.Y);
                labelX_Autocollect.Location = new Point(line5.Location.X + 2, labelX_Autocollect.Location.Y);
                panelEx_Day.Location = new Point(line6.Location.X + 2, panelEx_Day.Location.Y);*/
            }
        }
        public int LocationOutcome
        {
            get
            {
                return labelX_Name.Size.Width;
            }
            set
            {
                /*line5.Location = new Point(value , line5.Location.Y);
                labelX_Status_Name.Size = new Size(value - labelX_Status_Name.Location.X, labelX_Status_Name.Location.Y);
                labelX_Status_Count.Size = new Size(value - labelX_Status_Count.Location.X, labelX_Status_Count.Location.Y);
                line6.Location = new Point(value + labelX_Autocollect.Size.Width + 9, line6.Location.Y);
                labelX_Autocollect.Location = new Point(line5.Location.X + 2, labelX_Autocollect.Location.Y);
                panelEx_Day.Location = new Point(line6.Location.X + 2, panelEx_Day.Location.Y);*/
            }
        }

        public int LocationStatus
        {
            get
            {
                return labelX_Name.Size.Width;
            }
            set
            {
                /*line6.Location = new Point(value, line6.Location.Y);
                labelX_Autocollect.Location = new Point(line5.Location.X + 2, labelX_Autocollect.Location.Y);
                panelEx_Day.Location = new Point(line6.Location.X + 2, panelEx_Day.Location.Y);*/

            }
        }
        public int LocationDay
        {
            get
            {
                return labelX_Name.Size.Width;
            }
            set
            {
                /*line1.Location = new Point(value, line1.Location.Y);
                labelX_Name.Size = new Size(value - labelX_Name.Location.X, labelX_Name.Size.Height);
                line2.Location = new Point(value + labelX_TimeFrame.Size.Width, line2.Location.Y);
                labelX_TimeFrame.Location = new Point(value, labelX_TimeFrame.Location.Y);
                line3.Location = new Point(value + labelX_TimeFrame.Size.Width + labelX_Time.Size.Width, line3.Location.Y);
                labelX_Time.Location = new Point(line2.Location.X, labelX_Time.Location.Y);
                line4.Location = new Point(value + labelX_TimeFrame.Size.Width + labelX_Time.Size.Width + labelX_ContType.Size.Width, line4.Location.Y);
                labelX_ContType.Location = new Point(line3.Location.X, labelX_ContType.Location.Y);
                line5.Location = new Point(value + labelX_TimeFrame.Size.Width + labelX_Time.Size.Width + labelX_ContType.Size.Width + labelX_Status_Name.Size.Width, line5.Location.Y);
                labelX_Status_Name.Location = new Point(line4.Location.X + 2, labelX_Status_Name.Location.Y);
                labelX_Status_Count.Location = new Point(line4.Location.X + 2, labelX_Status_Count.Location.Y);*/

            }
        }

        private bool isShow;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (!isShow)
            {
                Height = _itemHeight;
                panelEx_Day.Height = _itemHeight;
            }
            else
            {
                Height = 57;
                panelEx_Day.Height = 57;
            }

        }
    }
}

