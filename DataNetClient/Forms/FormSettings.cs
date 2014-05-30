using DADataManager;
using DataNetClient.Properties;
using System;
using System.Windows.Forms;

namespace DataNetClient.Forms
{
    public partial class FormSettings : DevComponents.DotNetBar.Metro.MetroForm
    {

        #region VARS

        private int _userID;
        private bool _isChanged = false;

        #endregion
        public FormSettings(int userID)
        {
            _userID = userID;
            InitializeComponent();
        }
        #region EVENT

        public delegate void EmeilAfterFinishingHendler(bool flag);

        public static event EmeilAfterFinishingHendler EmeilAfterFinishing;

        private void OnEmeilAfterFinishing(bool flag)
        {
            EmeilAfterFinishingHendler handler = EmeilAfterFinishing;
            if (handler != null) handler(flag);
        }

        public delegate void IsAutocollectHendler(bool flag);

        public static event IsAutocollectHendler IsAutocollect;

        private static void OnIsAutocollect(bool flag)
        {
            IsAutocollectHendler handler = IsAutocollect;
            if (handler != null) handler(flag);
        }


        public delegate void BarEndChangeHendler(int barEnd);

        public static event BarEndChangeHendler BarEnd;

        private static void OnBarEnd(int barend)
        {
            BarEndChangeHendler handler = BarEnd;
            if (handler != null) handler(barend);
        }

        #endregion

        private void FormSettings_Load(object sender, EventArgs e)
        {
            bool isAutocollect, emeilFinish;
            int barEnd, barStart;
            ClientDatabaseManager.GetUSerInfo(_userID, out isAutocollect, out emeilFinish, out barStart, out barEnd);
            numericUpDown_maxTick.Value = Properties.Settings.Default.MaxTickDays;
            nudEndBar.Value = Properties.Settings.Default.valFinish;
            numericUpDown1.Value = Properties.Settings.Default.MaxTimeOutMinutes;
            numericUpDown2.Value = Properties.Settings.Default.MaxTimeOutMinutesStandard;
            textBox_emails.Text = Properties.Settings.Default.Emails;
            numericUpDown_days.Value = Properties.Settings.Default.DaysToExpiration;
            textBox1.Text = Settings.Default.AdditionalText;
            checkBox_add_text.Checked = Settings.Default.IsAdditionalTextReuired;
            checkBox_makeBigger.Checked = Settings.Default.MakeBigger;
            integerInputEnd.Value = barEnd;
            checkBoxAutocollect.Checked = isAutocollect;
            checkBox_emailMe.Checked = emeilFinish;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.valFinish = (int)(nudEndBar.Value);
            Properties.Settings.Default.MaxTickDays = (int)numericUpDown_maxTick.Value;

            Properties.Settings.Default.MaxTimeOutMinutes = (int)numericUpDown1.Value;
            Properties.Settings.Default.MaxTimeOutMinutesStandard = (int)numericUpDown2.Value;
            Properties.Settings.Default.Emails = textBox_emails.Text;
            Properties.Settings.Default.DaysToExpiration = (int)numericUpDown_days.Value;
            Settings.Default.AdditionalText = textBox1.Text;
            Settings.Default.IsAdditionalTextReuired = checkBox_add_text.Checked;
            Settings.Default.MakeBigger = checkBox_makeBigger.Checked;
            Properties.Settings.Default.Save();

            if (_isChanged)
                ClientDatabaseManager.SetUserDetails(_userID, checkBoxAutocollect.Checked, checkBox_emailMe.Checked, 0,
                    integerInputEnd.Value);

        }



        private void checkBox_emailMe_CheckedChanged(object sender, EventArgs e)
        {
            OnEmeilAfterFinishing(checkBox_emailMe.Checked);
            _isChanged = true;
        }

        private void checkBoxAutocollect_CheckedChanged(object sender, EventArgs e)
        {
            OnIsAutocollect(checkBoxAutocollect.Checked);
            _isChanged = true;
        }



        private void integerInputEnd_ValueChanged(object sender, EventArgs e)
        {
            OnBarEnd(integerInputEnd.Value);
            _isChanged = true;
        }

        private void buttonX_stopCollecting_Click(object sender, EventArgs e)
        {
            nudEndBar.Value = Properties.Settings.Default.valFinish = -3000;
            numericUpDown_maxTick.Value = Properties.Settings.Default.MaxTickDays = 2;

            numericUpDown1.Value = Properties.Settings.Default.MaxTimeOutMinutes = 2;
            numericUpDown2.Value = Properties.Settings.Default.MaxTimeOutMinutesStandard = 2;
            Properties.Settings.Default.Emails = textBox_emails.Text = "";
            numericUpDown_days.Value = Properties.Settings.Default.DaysToExpiration = 2;
            Settings.Default.AdditionalText = textBox1.Text = "";
            Settings.Default.IsAdditionalTextReuired = checkBox_add_text.Checked = false;
            Settings.Default.MakeBigger = checkBox_makeBigger.Checked = false;
            integerInputEnd.Value = -3000;
            checkBox_emailMe.Checked = false;
            checkBoxAutocollect.Checked = true;
            ClientDatabaseManager.SetUserDetails(_userID, checkBoxAutocollect.Checked, checkBox_emailMe.Checked, 0,
    integerInputEnd.Value);
            OnBarEnd(integerInputEnd.Value);
            OnIsAutocollect(checkBoxAutocollect.Checked);
            Properties.Settings.Default.Save();
        }

    }
}