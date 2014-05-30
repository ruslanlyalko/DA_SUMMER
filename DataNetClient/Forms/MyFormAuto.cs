using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DADataManager.Models;
using DevComponents.DotNetBar;

namespace DataNetClient.Forms
{
    public partial class MyFormAuto : DevComponents.DotNetBar.Metro.MetroForm
    {
        public MyFormAuto()
        {
            InitializeComponent();
        }

        private List<SessionModel> _sessionmodel;
        private List<string> _groupnameList;
        private List<string> _groupnamedays;
        public MyFormAuto(List<SessionModel> sessionmodel, List<string> groupnameList, List<string> groupnamedays)
        {
            InitializeComponent();
            _sessionmodel = sessionmodel;
            _groupnameList = groupnameList;
            _groupnamedays = groupnamedays;
        }

        private void MyFormAuto_Load(object sender, EventArgs e)
        {
            for (int index = 0; index < _sessionmodel.Count; index++)
            {
                var sessionModel = _sessionmodel[index];
                var groupName = _groupnameList[index];
                var days = _groupnamedays[index];
                grid_Info.Rows.Add(groupName, days, sessionModel.TimeStart.ToShortTimeString());
            }
        }

        private void button_No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Yes_Click(object sender, EventArgs e)
        {
            //todo need autocollect selected items
        }

        private void grid_Info_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grid_Info.Rows[e.RowIndex].Frozen = !grid_Info.Rows[e.RowIndex].Frozen;
        }
    }
}