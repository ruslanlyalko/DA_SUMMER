using System.Drawing;
using DataNormalizer.Core;
using DataNormalizer.Properties;


namespace DataNormalizer.Forms
{
    public partial class StartControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public StartControl()
        {
            InitializeComponent();                   
        }


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
                ui_buttonX_logon.Command = newValue.StartControlCommands.Logon;
                ui_buttonX_exit.Command = newValue.StartControlCommands.Exit;
            }
            else
            {
                ui_buttonX_logon.Command = null;
                ui_buttonX_exit.Command = null;
            }
        }

        private void StartControl_Load(object sender, System.EventArgs e)
        {
            labelX1.ForeColor = Color.SteelBlue;
            ui_textBoxX_login.Text = Settings.Default.connectionUser;
            ui_textBoxX_password.Text = Settings.Default.connectionPassword;
            ui_textBoxX_host.Text = Settings.Default.connectionHost;
            ui_textBoxX_db.Text = Settings.Default.connectionDB;
            ui_checkBoxX_autoLogin.CheckValue = Settings.Default.AutoLogin;
        }

    }
}
