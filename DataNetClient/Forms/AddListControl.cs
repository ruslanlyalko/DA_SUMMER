using System;
using CQG;
using DataNetClient.Core;

namespace DataNetClient.Forms
{
    public partial class AddListControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public AddListControl()
        {
            InitializeComponent();
        }

        public bool OpenSymbolControl;
        private MetroBillCommands _commands;
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
                saveButton.Command = newValue.NewListCommands.Add;
                cancelButton.Command = newValue.NewListCommands.Cancel;                
            }
            else
            {
                saveButton.Command = null;
                cancelButton.Command = null;
            }
        }

        public string GroupName
        {
            get
            {
                return textBoxXListName.Text;
            }
            set
            {
                textBoxXListName.Text = value;
            }
        }
        public string TimeFrame
        {
            get
            {
                return cmbHistoricalPeriod.SelectedItem.ToString();
            }
            set
            {
                cmbHistoricalPeriod.SelectedItem = value;
            }
        }
        public string CntType
        {
            get
            {
                return cmbContinuationType.SelectedItem.ToString();
            }
            set
            {
                cmbContinuationType.SelectedItem = value;
            }
        }

        public delegate void SaveClickHandler(string groupName,string timeFrame,string cntType);

        public event SaveClickHandler SaveClick;

        protected virtual void OnSaveClick(string groupName, string timeFrame, string cntType)
        {
            //todo add function
            SaveClickHandler handler = SaveClick;
            if (handler != null) handler(groupName,timeFrame,cntType);
        }

        public delegate void CanselClickHandler();

        public event CanselClickHandler CanselClick;

        protected virtual void OnCanselClick()
        {
            //todo add function
            CanselClickHandler handler = CanselClick;
            if (handler != null) handler();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cancelButton.Command.Execute();
        }

        private void EditListControl_Load(object sender, EventArgs e)
        {
            cmbHistoricalPeriod.SelectedIndex = 0;
            cmbContinuationType.Items.Clear();
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctNoContinuation);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctStandard);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctStandardByMonth);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctActive);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctActiveByMonth);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctAdjusted);
            //cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctAdjustedByMonth);
            cmbContinuationType.SelectedIndex = 1;
            cmbHistoricalPeriod.SelectedIndex = 1;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            OnSaveClick(GroupName, TimeFrame, CntType);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnCanselClick();
        }

    }
}
