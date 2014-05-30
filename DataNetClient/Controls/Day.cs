using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace DataNetClient.Controls
{
    public partial class Day : UserControl
    {
        private int _groupId;
        private int _index;
        public Day()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            _isSelected = false;
        }

        public void ItemsColor(Color color)
        {
            labelX1.BackColor = color;
            dateTimeInput1.BackgroundStyle.BackColor = color;
        }

        public Day(int groupID, int index,DateTime time, string days)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            _isSelected = false;
            _groupId = groupID;
            _index = index;
            Time = time;
            Days = ConvertDay(days);
        }

        public string Days
        {
            get
            {
                return labelX1.Text;
            }
            set
            {
                labelX1.Text = value;
            }
        }

        public DateTime Time
        {
            get { return dateTimeInput1.Value; }
            set
            {
                dateTimeInput1.Value = value;
            }
        }

        public delegate void ItemSelectedChangedHandler(bool isSelected, int itemIndex);

        public event ItemSelectedChangedHandler ItemSelectedChanged;

        protected virtual void OnItemSelectedChanged(bool isSelected, int itemIndex)
        {
            //panelEx_isSelected.Visible = isSelected;

            ItemSelectedChangedHandler handler = ItemSelectedChanged;
            if (handler != null) handler(isSelected, itemIndex);
        }

        private int ItemIndex { get; set; }
        private bool _isSelected;
        public bool ItemIsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnItemSelectedChanged(value, ItemIndex);
            }
        }


        private string ConvertDay(string str)
        {
            string str2 = "";
            foreach (var s in str)
            {
                if (s != '_') str2 += s;
            }
            string str3 = "";
            for (int index = 0; index < str2.Length-1; index++)
            {
                str3 += str2[index]+"/";
            }
            if (str2.Length != 0)
                str3 += str2[str2.Length - 1];
            else str3 = "";
            return str3;
        }

        private void Day_Click(object sender, EventArgs e)
        {
            ItemIsSelected = !ItemIsSelected;
            Focus();
        }

        /*private string GetDaysStr()
        {
            string str = "";
            str += labelX1.ForeColor == Color.Black ? "S" : "_";
            str += labelX2.ForeColor == Color.Black ? "M" : "_";
            str += labelX3.ForeColor == Color.Black ? "T" : "_";
            str += labelX4.ForeColor == Color.Black ? "W" : "_";
            str += labelX5.ForeColor == Color.Black ? "T" : "_";
            str += labelX6.ForeColor == Color.Black ? "F" : "_";
            str += labelX7.ForeColor == Color.Black ? "S" : "_";
            return str;
        }*/
        
        /*public void AddSession()
        {
            var sess = new SessionModel
            {
                Id = Index,
                //Name = textBoxX_sessionsName.Text == "" ? "Untitled session" : textBoxX_sessionsName.Text,
                //IsStartYesterday = checkBox_sy.Checked,
                Days = GetDaysStr(),
                TimeStart = dateTimeInput1.Value,
                TimeEnd = dateTimeInput2.Value,
            };
            //todo
            //AddSessionToList(sess);
            ClientDatabaseManager.AddSessionForGroup(GroupId, sess);
            
        }

        public void RemoveSession(int index)
        {
            //var id = ClientDatabaseManager.GetSessionsInGroup(GroupId).Find(oo => oo.Name.ToUpper() == name.ToUpper()).Id;

            ClientDatabaseManager.RemoveSession(GroupId, index);
        }

        private bool IsCanAdd()
        {
            if (dateTimeInput1.Text == "" || dateTimeInput2.Text == "")
            {
                ToastNotification.Show(this, "Please, input time!",eToastPosition.MiddleCenter);
                return false;
            }
            if (GetDaysStr() != "_______") return true;
            ToastNotification.Show(this, "Please, select days!", eToastPosition.MiddleCenter);
            return false;
        }*/


    }
}
