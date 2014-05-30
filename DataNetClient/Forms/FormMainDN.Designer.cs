using DataAdminCommonLib;
using Hik.Communication.ScsServices.Client;

namespace DataNetClient.Forms
{
    partial class FormMainDN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("10/12/2013", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("13/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("14/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("10/12/2013", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("13/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("14/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("10/12/2013", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("13/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("14/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("10/12/2013", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("13/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("14/12/12", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainDN));
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.ui__status_labelItem_status = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_collecting = new DevComponents.DotNetBar.LabelItem();
            this.ui_status_labelItemStatusSB = new DevComponents.DotNetBar.LabelItem();
            this.labelItemStatusCQG = new DevComponents.DotNetBar.LabelItem();
            this.progressBarItemCollecting = new DevComponents.DotNetBar.ProgressBarItem();
            this.labelItemUserName = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_server = new DevComponents.DotNetBar.LabelItem();
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.metroTabPanel2 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonEdit = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_StartCollectGroups = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_stopCollecting = new DevComponents.DotNetBar.ButtonX();
            this.linkLabel_selectNone = new System.Windows.Forms.LinkLabel();
            this.linkLabel_selectAll = new System.Windows.Forms.LinkLabel();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panelEx8 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panelEx15 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel_status = new System.Windows.Forms.LinkLabel();
            this.panelEx16 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel_sort_outcome = new System.Windows.Forms.LinkLabel();
            this.panelEx17 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel_sort_ContType = new System.Windows.Forms.LinkLabel();
            this.panelEx18 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel_sort_time = new System.Windows.Forms.LinkLabel();
            this.panelEx19 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel_sort_tf = new System.Windows.Forms.LinkLabel();
            this.panelEx20 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel_sort_name = new System.Windows.Forms.LinkLabel();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.linkLabel_logs = new System.Windows.Forms.LinkLabel();
            this.metroTabPanel5 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelEx14 = new DevComponents.DotNetBar.PanelEx();
            this.button_ac_delete = new System.Windows.Forms.Button();
            this.textBox_ac_symbol = new System.Windows.Forms.TextBox();
            this.button_ac_add = new System.Windows.Forms.Button();
            this.numericUpDown_ac_year = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker_ac_enddate = new System.Windows.Forms.DateTimePicker();
            this.textBox_ac_monthchar = new System.Windows.Forms.TextBox();
            this.listView_ac_list = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelEx13 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_ac_update = new DevComponents.DotNetBar.ButtonX();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelEx11 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx12 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_daily_updateValues = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_daily_getValues = new DevComponents.DotNetBar.ButtonX();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelEx9 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx10 = new DevComponents.DotNetBar.PanelEx();
            this.listBox_daily_symbols = new System.Windows.Forms.ListBox();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.metroTabPanel3 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.tableLayoutPanel_missingBar = new System.Windows.Forms.TableLayoutPanel();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStartDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEndDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.ui_metroTileItem_missingBar = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ui_missingbar_panelEx_symbolsBack = new DevComponents.DotNetBar.PanelEx();
            this.ui_missingbars_panelEx_list_back = new DevComponents.DotNetBar.PanelEx();
            this.ui_listBox_symbolsForMissing = new System.Windows.Forms.ListBox();
            this.contextMenuStripTables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.metroTabPanel1 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.ui_LabelX_sharedAvaliable = new DevComponents.DotNetBar.LabelX();
            this.ui_buttonX_shareConnect = new DevComponents.DotNetBar.ButtonX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.ui_home_textBoxX_db_historical = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.ui_home_textBoxX_db_bar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ui_LabelX_localAvaliable = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ui_buttonX_localConnect = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.ui_home_textBoxX_pwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.ui_home_textBoxX_uid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.ui_home_textBoxX_db = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ui_home_textBoxX_host = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.metroTabPanel4 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewLogger = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroAppButton1 = new DevComponents.DotNetBar.Metro.MetroAppButton();
            this.metroTabItem1 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem2 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem3 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem5 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem4 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.contextMenuStripSymbols = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.ui_ToolStripMenuItem_EditSymbols = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6_selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_unselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripGroupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSymbolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocollectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.metroShell1.SuspendLayout();
            this.metroTabPanel2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelEx8.SuspendLayout();
            this.panelEx15.SuspendLayout();
            this.panelEx16.SuspendLayout();
            this.panelEx17.SuspendLayout();
            this.panelEx18.SuspendLayout();
            this.panelEx19.SuspendLayout();
            this.panelEx20.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.metroTabPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelEx14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ac_year)).BeginInit();
            this.panelEx13.SuspendLayout();
            this.panelEx11.SuspendLayout();
            this.panelEx12.SuspendLayout();
            this.panelEx9.SuspendLayout();
            this.panelEx10.SuspendLayout();
            this.metroTabPanel3.SuspendLayout();
            this.tableLayoutPanel_missingBar.SuspendLayout();
            this.ui_missingbar_panelEx_symbolsBack.SuspendLayout();
            this.ui_missingbars_panelEx_list_back.SuspendLayout();
            this.contextMenuStripTables.SuspendLayout();
            this.metroTabPanel1.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.metroTabPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.contextMenuStripSymbols.SuspendLayout();
            this.contextMenuStripGroups.SuspendLayout();
            this.contextMenuStripGroupGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ui__status_labelItem_status,
            this.labelItem_collecting,
            this.ui_status_labelItemStatusSB,
            this.labelItemStatusCQG,
            this.progressBarItemCollecting,
            this.labelItemUserName,
            this.labelItem_server});
            this.metroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 478);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(799, 21);
            this.metroStatusBar1.TabIndex = 1;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // ui__status_labelItem_status
            // 
            this.ui__status_labelItem_status.Name = "ui__status_labelItem_status";
            this.ui__status_labelItem_status.Text = "READY";
            this.ui__status_labelItem_status.TextChanged += new System.EventHandler(this.ui__status_labelItem_status_TextChanged);
            // 
            // labelItem_collecting
            // 
            this.labelItem_collecting.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItem_collecting.Name = "labelItem_collecting";
            this.labelItem_collecting.PaddingLeft = 5;
            this.labelItem_collecting.Text = "Stoped";
            this.labelItem_collecting.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelItem_collecting.Tooltip = "Collecting process";
            // 
            // ui_status_labelItemStatusSB
            // 
            this.ui_status_labelItemStatusSB.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.ui_status_labelItemStatusSB.Name = "ui_status_labelItemStatusSB";
            this.ui_status_labelItemStatusSB.PaddingLeft = 5;
            this.ui_status_labelItemStatusSB.Text = "Not connected";
            this.ui_status_labelItemStatusSB.TextAlignment = System.Drawing.StringAlignment.Far;
            this.ui_status_labelItemStatusSB.Tooltip = "DB connection status";
            // 
            // labelItemStatusCQG
            // 
            this.labelItemStatusCQG.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItemStatusCQG.Name = "labelItemStatusCQG";
            this.labelItemStatusCQG.PaddingLeft = 5;
            this.labelItemStatusCQG.PaddingRight = 5;
            this.labelItemStatusCQG.Text = "CQG not started";
            this.labelItemStatusCQG.Tooltip = "CQG status";
            // 
            // progressBarItemCollecting
            // 
            // 
            // 
            // 
            this.progressBarItemCollecting.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarItemCollecting.ChunkGradientAngle = 0F;
            this.progressBarItemCollecting.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.progressBarItemCollecting.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.progressBarItemCollecting.Name = "progressBarItemCollecting";
            this.progressBarItemCollecting.RecentlyUsed = false;
            this.progressBarItemCollecting.Value = 100;
            this.progressBarItemCollecting.ValueChanged += new System.EventHandler(this.progressBarItemCollecting_ValueChanged);
            // 
            // labelItemUserName
            // 
            this.labelItemUserName.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItemUserName.Name = "labelItemUserName";
            this.labelItemUserName.PaddingLeft = 5;
            this.labelItemUserName.PaddingRight = 5;
            this.labelItemUserName.Text = "<user>";
            this.labelItemUserName.Tooltip = "User name";
            // 
            // labelItem_server
            // 
            this.labelItem_server.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItem_server.Name = "labelItem_server";
            this.labelItem_server.PaddingLeft = 5;
            this.labelItem_server.Text = "Master";
            this.labelItem_server.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelItem_server.Tooltip = "Collecting process";
            // 
            // metroShell1
            // 
            this.metroShell1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroShell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell1.CanCustomize = false;
            this.metroShell1.CaptionVisible = true;
            this.metroShell1.Controls.Add(this.metroTabPanel2);
            this.metroShell1.Controls.Add(this.metroTabPanel5);
            this.metroShell1.Controls.Add(this.metroTabPanel3);
            this.metroShell1.Controls.Add(this.metroTabPanel1);
            this.metroShell1.Controls.Add(this.metroTabPanel4);
            this.metroShell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroShell1.ForeColor = System.Drawing.Color.Black;
            this.metroShell1.HelpButtonText = "LOGOUT";
            this.metroShell1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroAppButton1,
            this.metroTabItem1,
            this.metroTabItem2,
            this.metroTabItem3,
            this.metroTabItem5,
            this.metroTabItem4});
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(0, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.Size = new System.Drawing.Size(799, 498);
            this.metroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell1.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell1.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell1.SystemText.QatDialogOkButton = "OK";
            this.metroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell1.TabIndex = 0;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.Text = "Shell";
            this.metroShell1.SettingsButtonClick += new System.EventHandler(this.metroShell1_SettingsButtonClick);
            this.metroShell1.HelpButtonClick += new System.EventHandler(this.metroShell1_LogOutButtonClick);
            // 
            // metroTabPanel2
            // 
            this.metroTabPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel2.Controls.Add(this.panelEx3);
            this.metroTabPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel2.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel2.Name = "metroTabPanel2";
            this.metroTabPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel2.Size = new System.Drawing.Size(799, 447);
            // 
            // 
            // 
            this.metroTabPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel2.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.metroTabPanel2.Style.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel2.TabIndex = 2;
            // 
            // panelEx3
            // 
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.superGridControl1);
            this.panelEx3.Controls.Add(this.buttonX1);
            this.panelEx3.Controls.Add(this.buttonEdit);
            this.panelEx3.Controls.Add(this.buttonX_StartCollectGroups);
            this.panelEx3.Controls.Add(this.buttonX_stopCollecting);
            this.panelEx3.Controls.Add(this.linkLabel_selectNone);
            this.panelEx3.Controls.Add(this.linkLabel_selectAll);
            this.panelEx3.Controls.Add(this.labelX7);
            this.panelEx3.Controls.Add(this.tableLayoutPanel4);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(3, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx3.Size = new System.Drawing.Size(793, 444);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 6;
            // 
            // superGridControl1
            // 
            this.superGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.superGridControl1.BackColor = System.Drawing.Color.White;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.ForeColor = System.Drawing.Color.Black;
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(1, 33);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.superGridControl1.PrimaryGrid.MultiSelect = false;
            this.superGridControl1.PrimaryGrid.RowHeaderWidth = 0;
            this.superGridControl1.Size = new System.Drawing.Size(791, 352);
            this.superGridControl1.TabIndex = 99;
            this.superGridControl1.TabSelection = DevComponents.DotNetBar.SuperGrid.TabSelection.Control;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.superGridControl1_CellClick);
            this.superGridControl1.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_BeginEdit);
            this.superGridControl1.AfterExpand += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridAfterExpandEventArgs>(this.superGridControl1_AfterExpand);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonX1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(611, 391);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(85, 33);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 82;
            this.buttonX1.Text = "AutoCollect";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonEdit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonEdit.Location = new System.Drawing.Point(702, 391);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(85, 33);
            this.buttonEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonEdit.TabIndex = 76;
            this.buttonEdit.Text = "Symbols and Groups Edit";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonX_StartCollectGroups
            // 
            this.buttonX_StartCollectGroups.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_StartCollectGroups.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonX_StartCollectGroups.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_StartCollectGroups.Location = new System.Drawing.Point(84, 392);
            this.buttonX_StartCollectGroups.Name = "buttonX_StartCollectGroups";
            this.buttonX_StartCollectGroups.Size = new System.Drawing.Size(88, 33);
            this.buttonX_StartCollectGroups.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_StartCollectGroups.TabIndex = 53;
            this.buttonX_StartCollectGroups.Text = "Start collecting\r\nGroups";
            this.buttonX_StartCollectGroups.Click += new System.EventHandler(this.buttonX_StartCollectGroups_Click);
            // 
            // buttonX_stopCollecting
            // 
            this.buttonX_stopCollecting.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_stopCollecting.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonX_stopCollecting.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_stopCollecting.Location = new System.Drawing.Point(5, 390);
            this.buttonX_stopCollecting.Name = "buttonX_stopCollecting";
            this.buttonX_stopCollecting.Size = new System.Drawing.Size(73, 35);
            this.buttonX_stopCollecting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_stopCollecting.TabIndex = 3;
            this.buttonX_stopCollecting.Text = "Stop";
            this.buttonX_stopCollecting.Click += new System.EventHandler(this.buttonX_stopCollecting_Click);
            // 
            // linkLabel_selectNone
            // 
            this.linkLabel_selectNone.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_selectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_selectNone.AutoSize = true;
            this.linkLabel_selectNone.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_selectNone.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_selectNone.Location = new System.Drawing.Point(743, 14);
            this.linkLabel_selectNone.Name = "linkLabel_selectNone";
            this.linkLabel_selectNone.Size = new System.Drawing.Size(35, 13);
            this.linkLabel_selectNone.TabIndex = 31;
            this.linkLabel_selectNone.TabStop = true;
            this.linkLabel_selectNone.Text = "None";
            this.toolTip1.SetToolTip(this.linkLabel_selectNone, "Unselect");
            this.linkLabel_selectNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_selectNone_LinkClicked);
            // 
            // linkLabel_selectAll
            // 
            this.linkLabel_selectAll.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_selectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_selectAll.AutoSize = true;
            this.linkLabel_selectAll.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_selectAll.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_selectAll.Location = new System.Drawing.Point(708, 14);
            this.linkLabel_selectAll.Name = "linkLabel_selectAll";
            this.linkLabel_selectAll.Size = new System.Drawing.Size(20, 13);
            this.linkLabel_selectAll.TabIndex = 30;
            this.linkLabel_selectAll.TabStop = true;
            this.linkLabel_selectAll.Text = "All";
            this.toolTip1.SetToolTip(this.linkLabel_selectAll, "Select all");
            this.linkLabel_selectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_selectAll_LinkClicked);
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(1, 1);
            this.labelX7.Name = "labelX7";
            this.labelX7.PaddingLeft = 6;
            this.labelX7.Size = new System.Drawing.Size(791, 32);
            this.labelX7.TabIndex = 20;
            this.labelX7.Text = "GROUP";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 8;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.tableLayoutPanel4.Controls.Add(this.panelEx8, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelEx15, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelEx16, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelEx17, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelEx18, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelEx19, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelEx20, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panelEx2, 7, 0);
            this.tableLayoutPanel4.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(793, 24);
            this.tableLayoutPanel4.TabIndex = 97;
            // 
            // panelEx8
            // 
            this.panelEx8.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx8.Controls.Add(this.linkLabel3);
            this.panelEx8.Controls.Add(this.linkLabel2);
            this.panelEx8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx8.Location = new System.Drawing.Point(594, 0);
            this.panelEx8.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx8.Name = "panelEx8";
            this.panelEx8.Size = new System.Drawing.Size(99, 24);
            this.panelEx8.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx8.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx8.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx8.Style.BorderWidth = 3;
            this.panelEx8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx8.Style.GradientAngle = 90;
            this.panelEx8.TabIndex = 1;
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel3.ForeColor = System.Drawing.Color.Black;
            this.linkLabel3.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel3.Location = new System.Drawing.Point(58, 4);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(38, 17);
            this.linkLabel3.TabIndex = 81;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "3";
            this.linkLabel3.Text = "Days";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.linkLabel3, "Sort by time of last collecting");
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel2.ForeColor = System.Drawing.Color.Black;
            this.linkLabel2.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel2.Location = new System.Drawing.Point(6, 4);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(39, 17);
            this.linkLabel2.TabIndex = 80;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "3";
            this.linkLabel2.Text = "Time";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.linkLabel2, "Sort by time of last collecting");
            // 
            // panelEx15
            // 
            this.panelEx15.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx15.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx15.Controls.Add(this.linkLabel_status);
            this.panelEx15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx15.Location = new System.Drawing.Point(495, 0);
            this.panelEx15.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx15.Name = "panelEx15";
            this.panelEx15.Size = new System.Drawing.Size(99, 24);
            this.panelEx15.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx15.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx15.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx15.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx15.Style.BorderWidth = 3;
            this.panelEx15.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx15.Style.GradientAngle = 90;
            this.panelEx15.TabIndex = 2;
            // 
            // linkLabel_status
            // 
            this.linkLabel_status.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_status.AutoSize = true;
            this.linkLabel_status.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel_status.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_status.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_status.Location = new System.Drawing.Point(22, 5);
            this.linkLabel_status.Name = "linkLabel_status";
            this.linkLabel_status.Size = new System.Drawing.Size(46, 17);
            this.linkLabel_status.TabIndex = 79;
            this.linkLabel_status.TabStop = true;
            this.linkLabel_status.Tag = "3";
            this.linkLabel_status.Text = "Status";
            this.toolTip1.SetToolTip(this.linkLabel_status, "Sort by time of last collecting");
            // 
            // panelEx16
            // 
            this.panelEx16.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx16.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx16.Controls.Add(this.linkLabel_sort_outcome);
            this.panelEx16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx16.Location = new System.Drawing.Point(396, 0);
            this.panelEx16.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx16.Name = "panelEx16";
            this.panelEx16.Size = new System.Drawing.Size(99, 24);
            this.panelEx16.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx16.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx16.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx16.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx16.Style.BorderWidth = 3;
            this.panelEx16.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx16.Style.GradientAngle = 90;
            this.panelEx16.TabIndex = 3;
            // 
            // linkLabel_sort_outcome
            // 
            this.linkLabel_sort_outcome.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_sort_outcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_sort_outcome.AutoSize = true;
            this.linkLabel_sort_outcome.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel_sort_outcome.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_sort_outcome.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_sort_outcome.Location = new System.Drawing.Point(18, 4);
            this.linkLabel_sort_outcome.Name = "linkLabel_sort_outcome";
            this.linkLabel_sort_outcome.Size = new System.Drawing.Size(64, 17);
            this.linkLabel_sort_outcome.TabIndex = 74;
            this.linkLabel_sort_outcome.TabStop = true;
            this.linkLabel_sort_outcome.Tag = "3";
            this.linkLabel_sort_outcome.Text = "Outcome";
            this.linkLabel_sort_outcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.linkLabel_sort_outcome, "Sort by time of last collecting");
            // 
            // panelEx17
            // 
            this.panelEx17.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx17.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx17.Controls.Add(this.linkLabel_sort_ContType);
            this.panelEx17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx17.Location = new System.Drawing.Point(297, 0);
            this.panelEx17.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx17.Name = "panelEx17";
            this.panelEx17.Size = new System.Drawing.Size(99, 24);
            this.panelEx17.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx17.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx17.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx17.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx17.Style.BorderWidth = 3;
            this.panelEx17.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx17.Style.GradientAngle = 90;
            this.panelEx17.TabIndex = 4;
            // 
            // linkLabel_sort_ContType
            // 
            this.linkLabel_sort_ContType.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_sort_ContType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_sort_ContType.AutoSize = true;
            this.linkLabel_sort_ContType.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel_sort_ContType.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_sort_ContType.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_sort_ContType.Location = new System.Drawing.Point(14, 3);
            this.linkLabel_sort_ContType.Name = "linkLabel_sort_ContType";
            this.linkLabel_sort_ContType.Size = new System.Drawing.Size(66, 17);
            this.linkLabel_sort_ContType.TabIndex = 73;
            this.linkLabel_sort_ContType.TabStop = true;
            this.linkLabel_sort_ContType.Tag = "3";
            this.linkLabel_sort_ContType.Text = "ContType";
            this.linkLabel_sort_ContType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.linkLabel_sort_ContType, "Sort by time of last collecting");
            // 
            // panelEx18
            // 
            this.panelEx18.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx18.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx18.Controls.Add(this.linkLabel_sort_time);
            this.panelEx18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx18.Location = new System.Drawing.Point(198, 0);
            this.panelEx18.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx18.Name = "panelEx18";
            this.panelEx18.Size = new System.Drawing.Size(99, 24);
            this.panelEx18.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx18.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx18.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx18.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx18.Style.BorderWidth = 3;
            this.panelEx18.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx18.Style.GradientAngle = 90;
            this.panelEx18.TabIndex = 5;
            // 
            // linkLabel_sort_time
            // 
            this.linkLabel_sort_time.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_sort_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_sort_time.AutoSize = true;
            this.linkLabel_sort_time.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel_sort_time.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_sort_time.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_sort_time.Location = new System.Drawing.Point(26, 4);
            this.linkLabel_sort_time.Name = "linkLabel_sort_time";
            this.linkLabel_sort_time.Size = new System.Drawing.Size(39, 17);
            this.linkLabel_sort_time.TabIndex = 72;
            this.linkLabel_sort_time.TabStop = true;
            this.linkLabel_sort_time.Tag = "3";
            this.linkLabel_sort_time.Text = "Time";
            this.linkLabel_sort_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.linkLabel_sort_time, "Sort by time of last collecting");
            // 
            // panelEx19
            // 
            this.panelEx19.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx19.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx19.Controls.Add(this.linkLabel_sort_tf);
            this.panelEx19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx19.Location = new System.Drawing.Point(99, 0);
            this.panelEx19.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx19.Name = "panelEx19";
            this.panelEx19.Size = new System.Drawing.Size(99, 24);
            this.panelEx19.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx19.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx19.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx19.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx19.Style.BorderWidth = 3;
            this.panelEx19.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx19.Style.GradientAngle = 90;
            this.panelEx19.TabIndex = 6;
            // 
            // linkLabel_sort_tf
            // 
            this.linkLabel_sort_tf.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_sort_tf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_sort_tf.AutoSize = true;
            this.linkLabel_sort_tf.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel_sort_tf.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_sort_tf.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_sort_tf.Location = new System.Drawing.Point(33, 4);
            this.linkLabel_sort_tf.Name = "linkLabel_sort_tf";
            this.linkLabel_sort_tf.Size = new System.Drawing.Size(23, 17);
            this.linkLabel_sort_tf.TabIndex = 71;
            this.linkLabel_sort_tf.TabStop = true;
            this.linkLabel_sort_tf.Tag = "2";
            this.linkLabel_sort_tf.Text = "TF";
            this.linkLabel_sort_tf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.linkLabel_sort_tf, "Sort by time frame");
            // 
            // panelEx20
            // 
            this.panelEx20.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx20.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx20.Controls.Add(this.linkLabel_sort_name);
            this.panelEx20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx20.Location = new System.Drawing.Point(0, 0);
            this.panelEx20.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx20.Name = "panelEx20";
            this.panelEx20.Size = new System.Drawing.Size(99, 24);
            this.panelEx20.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx20.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx20.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx20.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx20.Style.BorderWidth = 3;
            this.panelEx20.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx20.Style.GradientAngle = 90;
            this.panelEx20.TabIndex = 7;
            // 
            // linkLabel_sort_name
            // 
            this.linkLabel_sort_name.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_sort_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_sort_name.AutoSize = true;
            this.linkLabel_sort_name.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel_sort_name.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_sort_name.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_sort_name.Location = new System.Drawing.Point(16, 4);
            this.linkLabel_sort_name.Name = "linkLabel_sort_name";
            this.linkLabel_sort_name.Size = new System.Drawing.Size(44, 17);
            this.linkLabel_sort_name.TabIndex = 70;
            this.linkLabel_sort_name.TabStop = true;
            this.linkLabel_sort_name.Tag = "1";
            this.linkLabel_sort_name.Text = "Name";
            this.linkLabel_sort_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.linkLabel_logs);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(693, 0);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(100, 24);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.BorderWidth = 3;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 8;
            // 
            // linkLabel_logs
            // 
            this.linkLabel_logs.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel_logs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel_logs.AutoSize = true;
            this.linkLabel_logs.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel_logs.ForeColor = System.Drawing.Color.Black;
            this.linkLabel_logs.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_logs.Location = new System.Drawing.Point(29, 4);
            this.linkLabel_logs.Name = "linkLabel_logs";
            this.linkLabel_logs.Size = new System.Drawing.Size(37, 17);
            this.linkLabel_logs.TabIndex = 80;
            this.linkLabel_logs.TabStop = true;
            this.linkLabel_logs.Tag = "3";
            this.linkLabel_logs.Text = "Logs";
            // 
            // metroTabPanel5
            // 
            this.metroTabPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel5.Controls.Add(this.tableLayoutPanel2);
            this.metroTabPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel5.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel5.Name = "metroTabPanel5";
            this.metroTabPanel5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel5.Size = new System.Drawing.Size(799, 447);
            // 
            // 
            // 
            this.metroTabPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel5.TabIndex = 5;
            this.metroTabPanel5.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.45847F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.54153F));
            this.tableLayoutPanel2.Controls.Add(this.panelEx14, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.listView_ac_list, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelEx13, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelEx11, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelEx9, 0, 0);
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(793, 420);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panelEx14
            // 
            this.panelEx14.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx14.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx14.Controls.Add(this.button_ac_delete);
            this.panelEx14.Controls.Add(this.textBox_ac_symbol);
            this.panelEx14.Controls.Add(this.button_ac_add);
            this.panelEx14.Controls.Add(this.numericUpDown_ac_year);
            this.panelEx14.Controls.Add(this.dateTimePicker_ac_enddate);
            this.panelEx14.Controls.Add(this.textBox_ac_monthchar);
            this.panelEx14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx14.Location = new System.Drawing.Point(569, 78);
            this.panelEx14.Name = "panelEx14";
            this.panelEx14.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx14.Size = new System.Drawing.Size(221, 166);
            this.panelEx14.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx14.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx14.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx14.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx14.Style.BorderWidth = 0;
            this.panelEx14.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx14.Style.GradientAngle = 90;
            this.panelEx14.TabIndex = 42;
            // 
            // button_ac_delete
            // 
            this.button_ac_delete.ForeColor = System.Drawing.Color.Black;
            this.button_ac_delete.Location = new System.Drawing.Point(138, 126);
            this.button_ac_delete.Name = "button_ac_delete";
            this.button_ac_delete.Size = new System.Drawing.Size(69, 23);
            this.button_ac_delete.TabIndex = 47;
            this.button_ac_delete.Text = "DELETE";
            this.button_ac_delete.UseVisualStyleBackColor = true;
            this.button_ac_delete.Click += new System.EventHandler(this.button_ac_delete_Click);
            // 
            // textBox_ac_symbol
            // 
            this.textBox_ac_symbol.BackColor = System.Drawing.Color.White;
            this.textBox_ac_symbol.ForeColor = System.Drawing.Color.Black;
            this.textBox_ac_symbol.Location = new System.Drawing.Point(15, 14);
            this.textBox_ac_symbol.MaxLength = 500;
            this.textBox_ac_symbol.Name = "textBox_ac_symbol";
            this.textBox_ac_symbol.ReadOnly = true;
            this.textBox_ac_symbol.Size = new System.Drawing.Size(192, 22);
            this.textBox_ac_symbol.TabIndex = 46;
            this.toolTip1.SetToolTip(this.textBox_ac_symbol, "symbol");
            // 
            // button_ac_add
            // 
            this.button_ac_add.ForeColor = System.Drawing.Color.Black;
            this.button_ac_add.Location = new System.Drawing.Point(15, 126);
            this.button_ac_add.Name = "button_ac_add";
            this.button_ac_add.Size = new System.Drawing.Size(117, 23);
            this.button_ac_add.TabIndex = 45;
            this.button_ac_add.Text = "ADD";
            this.button_ac_add.UseVisualStyleBackColor = true;
            this.button_ac_add.Click += new System.EventHandler(this.button_ac_add_Click);
            // 
            // numericUpDown_ac_year
            // 
            this.numericUpDown_ac_year.BackColor = System.Drawing.Color.White;
            this.numericUpDown_ac_year.ForeColor = System.Drawing.Color.Black;
            this.numericUpDown_ac_year.Location = new System.Drawing.Point(15, 98);
            this.numericUpDown_ac_year.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numericUpDown_ac_year.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown_ac_year.Name = "numericUpDown_ac_year";
            this.numericUpDown_ac_year.Size = new System.Drawing.Size(192, 22);
            this.numericUpDown_ac_year.TabIndex = 44;
            this.numericUpDown_ac_year.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // dateTimePicker_ac_enddate
            // 
            this.dateTimePicker_ac_enddate.BackColor = System.Drawing.Color.White;
            this.dateTimePicker_ac_enddate.ForeColor = System.Drawing.Color.Black;
            this.dateTimePicker_ac_enddate.Location = new System.Drawing.Point(15, 42);
            this.dateTimePicker_ac_enddate.Name = "dateTimePicker_ac_enddate";
            this.dateTimePicker_ac_enddate.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker_ac_enddate.TabIndex = 43;
            this.dateTimePicker_ac_enddate.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // textBox_ac_monthchar
            // 
            this.textBox_ac_monthchar.BackColor = System.Drawing.Color.White;
            this.textBox_ac_monthchar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_ac_monthchar.ForeColor = System.Drawing.Color.Black;
            this.textBox_ac_monthchar.Location = new System.Drawing.Point(15, 70);
            this.textBox_ac_monthchar.MaxLength = 1;
            this.textBox_ac_monthchar.Name = "textBox_ac_monthchar";
            this.textBox_ac_monthchar.Size = new System.Drawing.Size(192, 22);
            this.textBox_ac_monthchar.TabIndex = 42;
            this.toolTip1.SetToolTip(this.textBox_ac_monthchar, "Month char");
            // 
            // listView_ac_list
            // 
            this.listView_ac_list.BackColor = System.Drawing.Color.White;
            this.listView_ac_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.listView_ac_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_ac_list.ForeColor = System.Drawing.Color.Black;
            this.listView_ac_list.FullRowSelect = true;
            listViewGroup1.Header = "10/12/2013";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "13/12/12";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "14/12/12";
            listViewGroup3.Name = "listViewGroup3";
            this.listView_ac_list.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listView_ac_list.Location = new System.Drawing.Point(569, 250);
            this.listView_ac_list.Name = "listView_ac_list";
            this.listView_ac_list.Size = new System.Drawing.Size(221, 167);
            this.listView_ac_list.TabIndex = 41;
            this.listView_ac_list.UseCompatibleStateImageBehavior = false;
            this.listView_ac_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Id";
            this.columnHeader9.Width = 25;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Symbol";
            this.columnHeader17.Width = 65;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "End date";
            this.columnHeader18.Width = 90;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "MonthChar";
            this.columnHeader19.Width = 110;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Year";
            this.columnHeader20.Width = 80;
            // 
            // panelEx13
            // 
            this.panelEx13.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx13.Controls.Add(this.buttonX_ac_update);
            this.panelEx13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx13.Location = new System.Drawing.Point(569, 3);
            this.panelEx13.Name = "panelEx13";
            this.panelEx13.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx13.Size = new System.Drawing.Size(221, 69);
            this.panelEx13.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx13.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx13.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx13.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx13.Style.BorderWidth = 0;
            this.panelEx13.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx13.Style.GradientAngle = 90;
            this.panelEx13.TabIndex = 40;
            // 
            // buttonX_ac_update
            // 
            this.buttonX_ac_update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_ac_update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_ac_update.Location = new System.Drawing.Point(15, 10);
            this.buttonX_ac_update.Name = "buttonX_ac_update";
            this.buttonX_ac_update.Size = new System.Drawing.Size(185, 44);
            this.buttonX_ac_update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_ac_update.TabIndex = 53;
            this.buttonX_ac_update.Text = "UPDATE VALUES ON DB";
            this.buttonX_ac_update.Tooltip = "For selected symbols";
            this.buttonX_ac_update.Click += new System.EventHandler(this.buttonX_ac_update_Click);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.White;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader21});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.ForeColor = System.Drawing.Color.Black;
            this.listView2.FullRowSelect = true;
            listViewGroup4.Header = "10/12/2013";
            listViewGroup4.Name = "listViewGroup1";
            listViewGroup5.Header = "13/12/12";
            listViewGroup5.Name = "listViewGroup2";
            listViewGroup6.Header = "14/12/12";
            listViewGroup6.Name = "listViewGroup3";
            this.listView2.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.listView2.Location = new System.Drawing.Point(194, 250);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(369, 167);
            this.listView2.TabIndex = 36;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Symbol";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tick Size";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Currency";
            this.columnHeader7.Width = 110;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "TickValue";
            // 
            // panelEx11
            // 
            this.panelEx11.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx11.Controls.Add(this.panelEx12);
            this.panelEx11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx11.Location = new System.Drawing.Point(194, 3);
            this.panelEx11.Name = "panelEx11";
            this.panelEx11.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx11.Size = new System.Drawing.Size(369, 69);
            this.panelEx11.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx11.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx11.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx11.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx11.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx11.Style.GradientAngle = 90;
            this.panelEx11.TabIndex = 35;
            // 
            // panelEx12
            // 
            this.panelEx12.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx12.Controls.Add(this.buttonX_daily_updateValues);
            this.panelEx12.Controls.Add(this.buttonX_daily_getValues);
            this.panelEx12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx12.Location = new System.Drawing.Point(1, 1);
            this.panelEx12.Name = "panelEx12";
            this.panelEx12.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx12.Size = new System.Drawing.Size(367, 67);
            this.panelEx12.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx12.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx12.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx12.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx12.Style.BorderWidth = 0;
            this.panelEx12.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx12.Style.GradientAngle = 90;
            this.panelEx12.TabIndex = 39;
            // 
            // buttonX_daily_updateValues
            // 
            this.buttonX_daily_updateValues.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_daily_updateValues.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_daily_updateValues.Location = new System.Drawing.Point(171, 9);
            this.buttonX_daily_updateValues.Name = "buttonX_daily_updateValues";
            this.buttonX_daily_updateValues.Size = new System.Drawing.Size(133, 46);
            this.buttonX_daily_updateValues.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_daily_updateValues.TabIndex = 54;
            this.buttonX_daily_updateValues.Text = "Update values for selected symbols";
            this.toolTip1.SetToolTip(this.buttonX_daily_updateValues, "From CQG");
            this.buttonX_daily_updateValues.Click += new System.EventHandler(this.buttonX_daily_updateValues_Click);
            // 
            // buttonX_daily_getValues
            // 
            this.buttonX_daily_getValues.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_daily_getValues.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_daily_getValues.Location = new System.Drawing.Point(4, 10);
            this.buttonX_daily_getValues.Name = "buttonX_daily_getValues";
            this.buttonX_daily_getValues.Size = new System.Drawing.Size(161, 45);
            this.buttonX_daily_getValues.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_daily_getValues.TabIndex = 53;
            this.buttonX_daily_getValues.Text = "Get values for selected symbols";
            this.toolTip1.SetToolTip(this.buttonX_daily_getValues, "From DB");
            this.buttonX_daily_getValues.Click += new System.EventHandler(this.buttonX_daily_getValues_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader8});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            listViewGroup7.Header = "10/12/2013";
            listViewGroup7.Name = "listViewGroup1";
            listViewGroup8.Header = "13/12/12";
            listViewGroup8.Name = "listViewGroup2";
            listViewGroup9.Header = "14/12/12";
            listViewGroup9.Name = "listViewGroup3";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup7,
            listViewGroup8,
            listViewGroup9});
            this.listView1.Location = new System.Drawing.Point(194, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(369, 166);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Id";
            this.columnHeader10.Width = 25;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Symbol";
            this.columnHeader11.Width = 65;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Date time";
            this.columnHeader12.Width = 90;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Indicative Open";
            this.columnHeader13.Width = 110;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Settlement";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Marker";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Today Marker";
            this.columnHeader16.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Expiration";
            this.columnHeader8.Width = 71;
            // 
            // panelEx9
            // 
            this.panelEx9.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx9.Controls.Add(this.panelEx10);
            this.panelEx9.Controls.Add(this.labelX20);
            this.panelEx9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx9.Location = new System.Drawing.Point(3, 3);
            this.panelEx9.Name = "panelEx9";
            this.panelEx9.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.SetRowSpan(this.panelEx9, 3);
            this.panelEx9.Size = new System.Drawing.Size(185, 414);
            this.panelEx9.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx9.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx9.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx9.Style.GradientAngle = 90;
            this.panelEx9.TabIndex = 34;
            // 
            // panelEx10
            // 
            this.panelEx10.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx10.Controls.Add(this.listBox_daily_symbols);
            this.panelEx10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx10.Location = new System.Drawing.Point(1, 33);
            this.panelEx10.Name = "panelEx10";
            this.panelEx10.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx10.Size = new System.Drawing.Size(183, 380);
            this.panelEx10.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx10.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx10.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx10.Style.BorderWidth = 0;
            this.panelEx10.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx10.Style.GradientAngle = 90;
            this.panelEx10.TabIndex = 39;
            this.panelEx10.Text = "panelEx7";
            // 
            // listBox_daily_symbols
            // 
            this.listBox_daily_symbols.BackColor = System.Drawing.Color.White;
            this.listBox_daily_symbols.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_daily_symbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_daily_symbols.ForeColor = System.Drawing.Color.Black;
            this.listBox_daily_symbols.FormattingEnabled = true;
            this.listBox_daily_symbols.Location = new System.Drawing.Point(1, 1);
            this.listBox_daily_symbols.Name = "listBox_daily_symbols";
            this.listBox_daily_symbols.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_daily_symbols.Size = new System.Drawing.Size(181, 378);
            this.listBox_daily_symbols.TabIndex = 37;
            this.listBox_daily_symbols.SelectedIndexChanged += new System.EventHandler(this.listBox_daily_symbols_SelectedIndexChanged);
            // 
            // labelX20
            // 
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX20.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX20.ForeColor = System.Drawing.Color.Black;
            this.labelX20.Location = new System.Drawing.Point(1, 1);
            this.labelX20.Name = "labelX20";
            this.labelX20.PaddingLeft = 6;
            this.labelX20.Size = new System.Drawing.Size(183, 32);
            this.labelX20.TabIndex = 38;
            this.labelX20.Text = "SYMBOLS";
            // 
            // metroTabPanel3
            // 
            this.metroTabPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel3.Controls.Add(this.tableLayoutPanel_missingBar);
            this.metroTabPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel3.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel3.Name = "metroTabPanel3";
            this.metroTabPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel3.Size = new System.Drawing.Size(799, 447);
            // 
            // 
            // 
            this.metroTabPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel3.TabIndex = 3;
            this.metroTabPanel3.Visible = false;
            // 
            // tableLayoutPanel_missingBar
            // 
            this.tableLayoutPanel_missingBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_missingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tableLayoutPanel_missingBar.ColumnCount = 2;
            this.tableLayoutPanel_missingBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel_missingBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_missingBar.Controls.Add(this.listViewResult, 1, 0);
            this.tableLayoutPanel_missingBar.Controls.Add(this.metroTilePanel1, 0, 1);
            this.tableLayoutPanel_missingBar.Controls.Add(this.ui_missingbar_panelEx_symbolsBack, 0, 0);
            this.tableLayoutPanel_missingBar.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel_missingBar.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_missingBar.Name = "tableLayoutPanel_missingBar";
            this.tableLayoutPanel_missingBar.RowCount = 2;
            this.tableLayoutPanel_missingBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_missingBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel_missingBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_missingBar.Size = new System.Drawing.Size(793, 423);
            this.tableLayoutPanel_missingBar.TabIndex = 0;
            // 
            // listViewResult
            // 
            this.listViewResult.BackColor = System.Drawing.Color.White;
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDate,
            this.columnHeaderState,
            this.columnHeaderStartDay,
            this.columnHeaderStart,
            this.columnHeaderEndDay,
            this.columnHeaderEnd});
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.ForeColor = System.Drawing.Color.Black;
            this.listViewResult.FullRowSelect = true;
            listViewGroup10.Header = "10/12/2013";
            listViewGroup10.Name = "listViewGroup1";
            listViewGroup11.Header = "13/12/12";
            listViewGroup11.Name = "listViewGroup2";
            listViewGroup12.Header = "14/12/12";
            listViewGroup12.Name = "listViewGroup3";
            this.listViewResult.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup10,
            listViewGroup11,
            listViewGroup12});
            this.listViewResult.Location = new System.Drawing.Point(253, 3);
            this.listViewResult.Name = "listViewResult";
            this.tableLayoutPanel_missingBar.SetRowSpan(this.listViewResult, 2);
            this.listViewResult.Size = new System.Drawing.Size(537, 417);
            this.listViewResult.TabIndex = 2;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 96;
            // 
            // columnHeaderState
            // 
            this.columnHeaderState.Text = "State";
            this.columnHeaderState.Width = 95;
            // 
            // columnHeaderStartDay
            // 
            this.columnHeaderStartDay.Text = "Start Day";
            this.columnHeaderStartDay.Width = 85;
            // 
            // columnHeaderStart
            // 
            this.columnHeaderStart.Text = "Start Time";
            this.columnHeaderStart.Width = 88;
            // 
            // columnHeaderEndDay
            // 
            this.columnHeaderEndDay.Text = "End Day";
            this.columnHeaderEndDay.Width = 85;
            // 
            // columnHeaderEnd
            // 
            this.columnHeaderEnd.Text = "End Time";
            this.columnHeaderEnd.Width = 83;
            // 
            // metroTilePanel1
            // 
            this.metroTilePanel1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel1.ContainerControlProcessDialogKey = true;
            this.metroTilePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTilePanel1.ForeColor = System.Drawing.Color.Black;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ui_metroTileItem_missingBar});
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(4, 272);
            this.metroTilePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(242, 147);
            this.metroTilePanel1.TabIndex = 33;
            this.metroTilePanel1.Text = "s";
            // 
            // ui_metroTileItem_missingBar
            // 
            this.ui_metroTileItem_missingBar.Image = global::DataNetClient.Properties.Resources.Charts;
            this.ui_metroTileItem_missingBar.Name = "ui_metroTileItem_missingBar";
            this.ui_metroTileItem_missingBar.SymbolColor = System.Drawing.Color.Empty;
            this.ui_metroTileItem_missingBar.Text = "<font size=\"+4\">Start analyzing<br/>symbol data</font>";
            this.ui_metroTileItem_missingBar.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.ui_metroTileItem_missingBar.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.ui_metroTileItem_missingBar.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.ui_metroTileItem_missingBar.TileStyle.BackColorGradientAngle = 45;
            this.ui_metroTileItem_missingBar.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_metroTileItem_missingBar.TileStyle.PaddingBottom = 4;
            this.ui_metroTileItem_missingBar.TileStyle.PaddingLeft = 4;
            this.ui_metroTileItem_missingBar.TileStyle.PaddingRight = 4;
            this.ui_metroTileItem_missingBar.TileStyle.PaddingTop = 4;
            this.ui_metroTileItem_missingBar.TileStyle.TextColor = System.Drawing.Color.White;
            this.ui_metroTileItem_missingBar.TitleText = "Analyzing";
            this.ui_metroTileItem_missingBar.Click += new System.EventHandler(this.metroTileItemMissingBar_Click);
            // 
            // ui_missingbar_panelEx_symbolsBack
            // 
            this.ui_missingbar_panelEx_symbolsBack.CanvasColor = System.Drawing.SystemColors.Control;
            this.ui_missingbar_panelEx_symbolsBack.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_missingbar_panelEx_symbolsBack.Controls.Add(this.ui_missingbars_panelEx_list_back);
            this.ui_missingbar_panelEx_symbolsBack.Controls.Add(this.labelX17);
            this.ui_missingbar_panelEx_symbolsBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_missingbar_panelEx_symbolsBack.Location = new System.Drawing.Point(3, 3);
            this.ui_missingbar_panelEx_symbolsBack.Name = "ui_missingbar_panelEx_symbolsBack";
            this.ui_missingbar_panelEx_symbolsBack.Padding = new System.Windows.Forms.Padding(1);
            this.ui_missingbar_panelEx_symbolsBack.Size = new System.Drawing.Size(244, 262);
            this.ui_missingbar_panelEx_symbolsBack.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.ui_missingbar_panelEx_symbolsBack.Style.BackColor1.Color = System.Drawing.Color.White;
            this.ui_missingbar_panelEx_symbolsBack.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.ui_missingbar_panelEx_symbolsBack.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ui_missingbar_panelEx_symbolsBack.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.ui_missingbar_panelEx_symbolsBack.Style.GradientAngle = 90;
            this.ui_missingbar_panelEx_symbolsBack.TabIndex = 34;
            // 
            // ui_missingbars_panelEx_list_back
            // 
            this.ui_missingbars_panelEx_list_back.CanvasColor = System.Drawing.SystemColors.Control;
            this.ui_missingbars_panelEx_list_back.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_missingbars_panelEx_list_back.Controls.Add(this.ui_listBox_symbolsForMissing);
            this.ui_missingbars_panelEx_list_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_missingbars_panelEx_list_back.Location = new System.Drawing.Point(1, 33);
            this.ui_missingbars_panelEx_list_back.Name = "ui_missingbars_panelEx_list_back";
            this.ui_missingbars_panelEx_list_back.Padding = new System.Windows.Forms.Padding(1);
            this.ui_missingbars_panelEx_list_back.Size = new System.Drawing.Size(242, 228);
            this.ui_missingbars_panelEx_list_back.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.ui_missingbars_panelEx_list_back.Style.BackColor1.Color = System.Drawing.Color.White;
            this.ui_missingbars_panelEx_list_back.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.ui_missingbars_panelEx_list_back.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.ui_missingbars_panelEx_list_back.Style.BorderWidth = 0;
            this.ui_missingbars_panelEx_list_back.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.ui_missingbars_panelEx_list_back.Style.GradientAngle = 90;
            this.ui_missingbars_panelEx_list_back.TabIndex = 39;
            this.ui_missingbars_panelEx_list_back.Text = "panelEx7";
            // 
            // ui_listBox_symbolsForMissing
            // 
            this.ui_listBox_symbolsForMissing.BackColor = System.Drawing.Color.White;
            this.ui_listBox_symbolsForMissing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ui_listBox_symbolsForMissing.ContextMenuStrip = this.contextMenuStripTables;
            this.ui_listBox_symbolsForMissing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_listBox_symbolsForMissing.ForeColor = System.Drawing.Color.Black;
            this.ui_listBox_symbolsForMissing.FormattingEnabled = true;
            this.ui_listBox_symbolsForMissing.Location = new System.Drawing.Point(1, 1);
            this.ui_listBox_symbolsForMissing.Name = "ui_listBox_symbolsForMissing";
            this.ui_listBox_symbolsForMissing.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ui_listBox_symbolsForMissing.Size = new System.Drawing.Size(240, 226);
            this.ui_listBox_symbolsForMissing.TabIndex = 37;
            // 
            // contextMenuStripTables
            // 
            this.contextMenuStripTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStripTables.Name = "contextMenuStrip1";
            this.contextMenuStripTables.Size = new System.Drawing.Size(135, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem2.Text = "Select all";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem3.Text = "Unselect all";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // labelX17
            // 
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX17.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.ForeColor = System.Drawing.Color.Black;
            this.labelX17.Location = new System.Drawing.Point(1, 1);
            this.labelX17.Name = "labelX17";
            this.labelX17.PaddingLeft = 6;
            this.labelX17.Size = new System.Drawing.Size(242, 32);
            this.labelX17.TabIndex = 38;
            this.labelX17.Text = "SYMBOLS";
            // 
            // metroTabPanel1
            // 
            this.metroTabPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel1.Controls.Add(this.panelEx5);
            this.metroTabPanel1.Controls.Add(this.panelEx1);
            this.metroTabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel1.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel1.Name = "metroTabPanel1";
            this.metroTabPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel1.Size = new System.Drawing.Size(799, 447);
            // 
            // 
            // 
            this.metroTabPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel1.StyleMouseOver.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.metroTabPanel1.TabIndex = 0;
            this.metroTabPanel1.Visible = false;
            // 
            // panelEx5
            // 
            this.panelEx5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.Controls.Add(this.ui_LabelX_sharedAvaliable);
            this.panelEx5.Controls.Add(this.ui_buttonX_shareConnect);
            this.panelEx5.Controls.Add(this.labelX16);
            this.panelEx5.Location = new System.Drawing.Point(113, 33);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(272, 313);
            this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx5.Style.GradientAngle = 90;
            this.panelEx5.TabIndex = 17;
            // 
            // ui_LabelX_sharedAvaliable
            // 
            // 
            // 
            // 
            this.ui_LabelX_sharedAvaliable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_LabelX_sharedAvaliable.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_LabelX_sharedAvaliable.ForeColor = System.Drawing.Color.Black;
            this.ui_LabelX_sharedAvaliable.Location = new System.Drawing.Point(113, 34);
            this.ui_LabelX_sharedAvaliable.Name = "ui_LabelX_sharedAvaliable";
            this.ui_LabelX_sharedAvaliable.PaddingRight = 6;
            this.ui_LabelX_sharedAvaliable.Size = new System.Drawing.Size(156, 32);
            this.ui_LabelX_sharedAvaliable.TabIndex = 23;
            this.ui_LabelX_sharedAvaliable.Text = "avaliable";
            this.ui_LabelX_sharedAvaliable.TextAlignment = System.Drawing.StringAlignment.Far;
            this.ui_LabelX_sharedAvaliable.Click += new System.EventHandler(this.ui_LabelX_sharedAvaliable_Click);
            // 
            // ui_buttonX_shareConnect
            // 
            this.ui_buttonX_shareConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_shareConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_shareConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_buttonX_shareConnect.Location = new System.Drawing.Point(49, 270);
            this.ui_buttonX_shareConnect.Name = "ui_buttonX_shareConnect";
            this.ui_buttonX_shareConnect.Size = new System.Drawing.Size(144, 29);
            this.ui_buttonX_shareConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_shareConnect.TabIndex = 21;
            this.ui_buttonX_shareConnect.Text = "Connect to Share DB";
            this.ui_buttonX_shareConnect.Click += new System.EventHandler(this.Ui_ButtonX_ShareConnect_Click);
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX16.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX16.ForeColor = System.Drawing.Color.Black;
            this.labelX16.Location = new System.Drawing.Point(0, 0);
            this.labelX16.Name = "labelX16";
            this.labelX16.PaddingLeft = 6;
            this.labelX16.Size = new System.Drawing.Size(272, 32);
            this.labelX16.TabIndex = 20;
            this.labelX16.Text = "SHARED DB";
            // 
            // panelEx1
            // 
            this.panelEx1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX19);
            this.panelEx1.Controls.Add(this.ui_home_textBoxX_db_historical);
            this.panelEx1.Controls.Add(this.labelX18);
            this.panelEx1.Controls.Add(this.ui_home_textBoxX_db_bar);
            this.panelEx1.Controls.Add(this.ui_LabelX_localAvaliable);
            this.panelEx1.Controls.Add(this.checkBoxX1);
            this.panelEx1.Controls.Add(this.ui_buttonX_localConnect);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.ui_home_textBoxX_pwd);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.ui_home_textBoxX_uid);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.ui_home_textBoxX_db);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.ui_home_textBoxX_host);
            this.panelEx1.Location = new System.Drawing.Point(391, 33);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(272, 313);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX19
            // 
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.ForeColor = System.Drawing.Color.Black;
            this.labelX19.Location = new System.Drawing.Point(3, 201);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(107, 20);
            this.labelX19.TabIndex = 28;
            this.labelX19.Text = "historical tick DB";
            this.labelX19.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ui_home_textBoxX_db_historical
            // 
            this.ui_home_textBoxX_db_historical.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ui_home_textBoxX_db_historical.Border.BorderLeftColor = System.Drawing.Color.Green;
            this.ui_home_textBoxX_db_historical.Border.BorderLeftWidth = 3;
            this.ui_home_textBoxX_db_historical.Border.Class = "TextBoxBorder";
            this.ui_home_textBoxX_db_historical.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_home_textBoxX_db_historical.ForeColor = System.Drawing.Color.Black;
            this.ui_home_textBoxX_db_historical.Location = new System.Drawing.Point(116, 201);
            this.ui_home_textBoxX_db_historical.Name = "ui_home_textBoxX_db_historical";
            this.ui_home_textBoxX_db_historical.Size = new System.Drawing.Size(128, 22);
            this.ui_home_textBoxX_db_historical.TabIndex = 5;
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.ForeColor = System.Drawing.Color.Black;
            this.labelX18.Location = new System.Drawing.Point(35, 174);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(75, 20);
            this.labelX18.TabIndex = 26;
            this.labelX18.Text = "bar DB";
            this.labelX18.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ui_home_textBoxX_db_bar
            // 
            this.ui_home_textBoxX_db_bar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ui_home_textBoxX_db_bar.Border.BorderLeftColor = System.Drawing.Color.Green;
            this.ui_home_textBoxX_db_bar.Border.BorderLeftWidth = 3;
            this.ui_home_textBoxX_db_bar.Border.Class = "TextBoxBorder";
            this.ui_home_textBoxX_db_bar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_home_textBoxX_db_bar.ForeColor = System.Drawing.Color.Black;
            this.ui_home_textBoxX_db_bar.Location = new System.Drawing.Point(116, 174);
            this.ui_home_textBoxX_db_bar.Name = "ui_home_textBoxX_db_bar";
            this.ui_home_textBoxX_db_bar.Size = new System.Drawing.Size(128, 22);
            this.ui_home_textBoxX_db_bar.TabIndex = 4;
            // 
            // ui_LabelX_localAvaliable
            // 
            // 
            // 
            // 
            this.ui_LabelX_localAvaliable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_LabelX_localAvaliable.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_LabelX_localAvaliable.ForeColor = System.Drawing.Color.Black;
            this.ui_LabelX_localAvaliable.Location = new System.Drawing.Point(116, 34);
            this.ui_LabelX_localAvaliable.Name = "ui_LabelX_localAvaliable";
            this.ui_LabelX_localAvaliable.PaddingRight = 6;
            this.ui_LabelX_localAvaliable.Size = new System.Drawing.Size(153, 32);
            this.ui_LabelX_localAvaliable.TabIndex = 24;
            this.ui_LabelX_localAvaliable.Text = "avaliable";
            this.ui_LabelX_localAvaliable.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Checked = true;
            this.checkBoxX1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX1.CheckValue = "Y";
            this.checkBoxX1.ForeColor = System.Drawing.Color.Black;
            this.checkBoxX1.Location = new System.Drawing.Point(116, 235);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(100, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 6;
            this.checkBoxX1.Text = "Save me";
            // 
            // ui_buttonX_localConnect
            // 
            this.ui_buttonX_localConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_localConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_localConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_buttonX_localConnect.Location = new System.Drawing.Point(60, 270);
            this.ui_buttonX_localConnect.Name = "ui_buttonX_localConnect";
            this.ui_buttonX_localConnect.Size = new System.Drawing.Size(144, 29);
            this.ui_buttonX_localConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_localConnect.TabIndex = 7;
            this.ui_buttonX_localConnect.Text = "Connect to Local DB";
            this.ui_buttonX_localConnect.Click += new System.EventHandler(this.Ui_ButtonX_LocalConnect_Click);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(0, 0);
            this.labelX5.Name = "labelX5";
            this.labelX5.PaddingLeft = 6;
            this.labelX5.Size = new System.Drawing.Size(272, 32);
            this.labelX5.TabIndex = 19;
            this.labelX5.Text = "LOCAL DB SETTINGS";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(35, 96);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 20);
            this.labelX4.TabIndex = 18;
            this.labelX4.Text = "password";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ui_home_textBoxX_pwd
            // 
            this.ui_home_textBoxX_pwd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ui_home_textBoxX_pwd.Border.BorderLeftColor = System.Drawing.Color.Green;
            this.ui_home_textBoxX_pwd.Border.BorderLeftWidth = 3;
            this.ui_home_textBoxX_pwd.Border.Class = "TextBoxBorder";
            this.ui_home_textBoxX_pwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_home_textBoxX_pwd.ForeColor = System.Drawing.Color.Black;
            this.ui_home_textBoxX_pwd.Location = new System.Drawing.Point(116, 96);
            this.ui_home_textBoxX_pwd.Name = "ui_home_textBoxX_pwd";
            this.ui_home_textBoxX_pwd.PasswordChar = '*';
            this.ui_home_textBoxX_pwd.Size = new System.Drawing.Size(128, 22);
            this.ui_home_textBoxX_pwd.TabIndex = 1;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(35, 70);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 20);
            this.labelX3.TabIndex = 16;
            this.labelX3.Text = "user";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ui_home_textBoxX_uid
            // 
            this.ui_home_textBoxX_uid.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ui_home_textBoxX_uid.Border.BorderLeftColor = System.Drawing.Color.Green;
            this.ui_home_textBoxX_uid.Border.BorderLeftWidth = 3;
            this.ui_home_textBoxX_uid.Border.Class = "TextBoxBorder";
            this.ui_home_textBoxX_uid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_home_textBoxX_uid.ForeColor = System.Drawing.Color.Black;
            this.ui_home_textBoxX_uid.Location = new System.Drawing.Point(116, 70);
            this.ui_home_textBoxX_uid.Name = "ui_home_textBoxX_uid";
            this.ui_home_textBoxX_uid.Size = new System.Drawing.Size(128, 22);
            this.ui_home_textBoxX_uid.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(35, 148);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 20);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "system DB";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ui_home_textBoxX_db
            // 
            this.ui_home_textBoxX_db.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ui_home_textBoxX_db.Border.BorderLeftColor = System.Drawing.Color.Green;
            this.ui_home_textBoxX_db.Border.BorderLeftWidth = 3;
            this.ui_home_textBoxX_db.Border.Class = "TextBoxBorder";
            this.ui_home_textBoxX_db.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_home_textBoxX_db.ForeColor = System.Drawing.Color.Black;
            this.ui_home_textBoxX_db.Location = new System.Drawing.Point(116, 148);
            this.ui_home_textBoxX_db.Name = "ui_home_textBoxX_db";
            this.ui_home_textBoxX_db.Size = new System.Drawing.Size(128, 22);
            this.ui_home_textBoxX_db.TabIndex = 3;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(35, 122);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 20);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "host";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ui_home_textBoxX_host
            // 
            this.ui_home_textBoxX_host.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ui_home_textBoxX_host.Border.BorderLeftColor = System.Drawing.Color.Green;
            this.ui_home_textBoxX_host.Border.BorderLeftWidth = 3;
            this.ui_home_textBoxX_host.Border.Class = "TextBoxBorder";
            this.ui_home_textBoxX_host.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_home_textBoxX_host.ForeColor = System.Drawing.Color.Black;
            this.ui_home_textBoxX_host.Location = new System.Drawing.Point(116, 122);
            this.ui_home_textBoxX_host.Name = "ui_home_textBoxX_host";
            this.ui_home_textBoxX_host.Size = new System.Drawing.Size(128, 22);
            this.ui_home_textBoxX_host.TabIndex = 2;
            // 
            // metroTabPanel4
            // 
            this.metroTabPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel4.Controls.Add(this.tableLayoutPanel3);
            this.metroTabPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel4.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel4.Name = "metroTabPanel4";
            this.metroTabPanel4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel4.Size = new System.Drawing.Size(799, 447);
            // 
            // 
            // 
            this.metroTabPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel4.TabIndex = 4;
            this.metroTabPanel4.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 873F));
            this.tableLayoutPanel3.Controls.Add(this.listViewLogger, 0, 0);
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(793, 423);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // listViewLogger
            // 
            this.listViewLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLogger.BackColor = System.Drawing.Color.White;
            this.listViewLogger.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewLogger.ForeColor = System.Drawing.Color.Black;
            this.listViewLogger.Location = new System.Drawing.Point(3, 3);
            this.listViewLogger.Name = "listViewLogger";
            this.listViewLogger.ShowItemToolTips = true;
            this.listViewLogger.Size = new System.Drawing.Size(867, 417);
            this.listViewLogger.TabIndex = 0;
            this.listViewLogger.UseCompatibleStateImageBehavior = false;
            this.listViewLogger.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Message";
            this.columnHeader3.Width = 507;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 146;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Category";
            this.columnHeader5.Width = 127;
            // 
            // metroAppButton1
            // 
            this.metroAppButton1.AutoExpandOnClick = true;
            this.metroAppButton1.CanCustomize = false;
            this.metroAppButton1.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.metroAppButton1.ImagePaddingHorizontal = 0;
            this.metroAppButton1.ImagePaddingVertical = 0;
            this.metroAppButton1.Name = "metroAppButton1";
            this.metroAppButton1.ShowSubItems = false;
            this.metroAppButton1.Text = "&File";
            this.metroAppButton1.Visible = false;
            // 
            // metroTabItem1
            // 
            this.metroTabItem1.Name = "metroTabItem1";
            this.metroTabItem1.Panel = this.metroTabPanel1;
            this.metroTabItem1.Text = "&HOME";
            // 
            // metroTabItem2
            // 
            this.metroTabItem2.Checked = true;
            this.metroTabItem2.Name = "metroTabItem2";
            this.metroTabItem2.Panel = this.metroTabPanel2;
            this.metroTabItem2.Text = "&COLLECT DATA";
            this.metroTabItem2.Visible = false;
            // 
            // metroTabItem3
            // 
            this.metroTabItem3.Name = "metroTabItem3";
            this.metroTabItem3.Panel = this.metroTabPanel3;
            this.metroTabItem3.Text = "&MISSING BARS";
            this.metroTabItem3.Visible = false;
            // 
            // metroTabItem5
            // 
            this.metroTabItem5.Name = "metroTabItem5";
            this.metroTabItem5.Panel = this.metroTabPanel5;
            this.metroTabItem5.Text = "ADDITIONAL INFO";
            this.metroTabItem5.Visible = false;
            // 
            // metroTabItem4
            // 
            this.metroTabItem4.Name = "metroTabItem4";
            this.metroTabItem4.Panel = this.metroTabPanel4;
            this.metroTabItem4.Text = "&LOG";
            // 
            // contextMenuStripSymbols
            // 
            this.contextMenuStripSymbols.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.toolStripMenuItem7,
            this.ui_ToolStripMenuItem_EditSymbols});
            this.contextMenuStripSymbols.Name = "contextMenuStrip1";
            this.contextMenuStripSymbols.Size = new System.Drawing.Size(142, 76);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.unselectAllToolStripMenuItem.Text = "Unselect all";
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(138, 6);
            // 
            // ui_ToolStripMenuItem_EditSymbols
            // 
            this.ui_ToolStripMenuItem_EditSymbols.Name = "ui_ToolStripMenuItem_EditSymbols";
            this.ui_ToolStripMenuItem_EditSymbols.Size = new System.Drawing.Size(141, 22);
            this.ui_ToolStripMenuItem_EditSymbols.Text = "Edit symbols";
            this.ui_ToolStripMenuItem_EditSymbols.Click += new System.EventHandler(this.ui_ToolStripMenuItem_EditSymbols_Click);
            // 
            // contextMenuStripGroups
            // 
            this.contextMenuStripGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6_selectAll,
            this.toolStripMenuItem_unselectAll});
            this.contextMenuStripGroups.Name = "contextMenuStrip1";
            this.contextMenuStripGroups.Size = new System.Drawing.Size(135, 48);
            // 
            // toolStripMenuItem6_selectAll
            // 
            this.toolStripMenuItem6_selectAll.Name = "toolStripMenuItem6_selectAll";
            this.toolStripMenuItem6_selectAll.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem6_selectAll.Text = "Select all";
            // 
            // toolStripMenuItem_unselectAll
            // 
            this.toolStripMenuItem_unselectAll.Name = "toolStripMenuItem_unselectAll";
            this.toolStripMenuItem_unselectAll.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem_unselectAll.Text = "Unselect all";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // editListToolStripMenuItem
            // 
            this.editListToolStripMenuItem.Name = "editListToolStripMenuItem";
            this.editListToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // deleteListToolStripMenuItem
            // 
            this.deleteListToolStripMenuItem.Name = "deleteListToolStripMenuItem";
            this.deleteListToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.SteelBlue);
            // 
            // contextMenuStripGroupGrid
            // 
            this.contextMenuStripGroupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSymbolsToolStripMenuItem,
            this.autocollectToolStripMenuItem,
            this.symbolsToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.textToolStripMenuItem});
            this.contextMenuStripGroupGrid.Name = "contextMenuStripGroupGrid";
            this.contextMenuStripGroupGrid.Size = new System.Drawing.Size(143, 114);
            // 
            // editSymbolsToolStripMenuItem
            // 
            this.editSymbolsToolStripMenuItem.Name = "editSymbolsToolStripMenuItem";
            this.editSymbolsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.editSymbolsToolStripMenuItem.Text = "Edit Symbols";
            this.editSymbolsToolStripMenuItem.Click += new System.EventHandler(this.editSymbolsToolStripMenuItem_Click);
            // 
            // autocollectToolStripMenuItem
            // 
            this.autocollectToolStripMenuItem.Name = "autocollectToolStripMenuItem";
            this.autocollectToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.autocollectToolStripMenuItem.Text = "Autocollect";
            this.autocollectToolStripMenuItem.Click += new System.EventHandler(this.autocollectToolStripMenuItem_Click);
            // 
            // symbolsToolStripMenuItem
            // 
            this.symbolsToolStripMenuItem.Name = "symbolsToolStripMenuItem";
            this.symbolsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.symbolsToolStripMenuItem.Text = "Symbols";
            this.symbolsToolStripMenuItem.MouseEnter += new System.EventHandler(this.symbolsToolStripMenuItem_MouseEnter);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sessionToolStripMenuItem.Text = "Sessions";
            this.sessionToolStripMenuItem.MouseEnter += new System.EventHandler(this.autocollectToolStripMenuItem1_MouseEnter);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // FormMainDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.metroStatusBar1);
            this.Controls.Add(this.metroShell1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormMainDN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.metroShell1.ResumeLayout(false);
            this.metroShell1.PerformLayout();
            this.metroTabPanel2.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panelEx8.ResumeLayout(false);
            this.panelEx8.PerformLayout();
            this.panelEx15.ResumeLayout(false);
            this.panelEx15.PerformLayout();
            this.panelEx16.ResumeLayout(false);
            this.panelEx16.PerformLayout();
            this.panelEx17.ResumeLayout(false);
            this.panelEx17.PerformLayout();
            this.panelEx18.ResumeLayout(false);
            this.panelEx18.PerformLayout();
            this.panelEx19.ResumeLayout(false);
            this.panelEx19.PerformLayout();
            this.panelEx20.ResumeLayout(false);
            this.panelEx20.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.metroTabPanel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelEx14.ResumeLayout(false);
            this.panelEx14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ac_year)).EndInit();
            this.panelEx13.ResumeLayout(false);
            this.panelEx11.ResumeLayout(false);
            this.panelEx12.ResumeLayout(false);
            this.panelEx9.ResumeLayout(false);
            this.panelEx10.ResumeLayout(false);
            this.metroTabPanel3.ResumeLayout(false);
            this.tableLayoutPanel_missingBar.ResumeLayout(false);
            this.ui_missingbar_panelEx_symbolsBack.ResumeLayout(false);
            this.ui_missingbars_panelEx_list_back.ResumeLayout(false);
            this.contextMenuStripTables.ResumeLayout(false);
            this.metroTabPanel1.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.metroTabPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.contextMenuStripSymbols.ResumeLayout(false);
            this.contextMenuStripGroups.ResumeLayout(false);
            this.contextMenuStripGroupGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel2;
        private DevComponents.DotNetBar.Metro.MetroAppButton metroAppButton1;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem1;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem2;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem ui__status_labelItem_status;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel3;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem3;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.ButtonX ui_buttonX_localConnect;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX ui_home_textBoxX_pwd;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX ui_home_textBoxX_uid;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX ui_home_textBoxX_db;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX ui_home_textBoxX_host;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSymbols;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeaderState;
        private System.Windows.Forms.ColumnHeader columnHeaderStart;
        private System.Windows.Forms.ColumnHeader columnHeaderEnd;
        //private System.Windows.Forms.ContextMenuStrip contextMenuStripLists;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteListToolStripMenuItem;
        private DevComponents.DotNetBar.LabelItem labelItemUserName;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editListToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroups;
        private DevComponents.DotNetBar.LabelItem labelItemStatusCQG;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.Metro.MetroTileItem ui_metroTileItem_missingBar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTables;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel4;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem4;
        private System.Windows.Forms.ListView listViewLogger;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private DevComponents.DotNetBar.LabelItem ui_status_labelItemStatusSB;
        private DevComponents.DotNetBar.ProgressBarItem progressBarItemCollecting;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderStartDay;
        private System.Windows.Forms.ColumnHeader columnHeaderEndDay;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem ui_ToolStripMenuItem_EditSymbols;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_missingBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private DevComponents.DotNetBar.ButtonX ui_buttonX_shareConnect;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX ui_LabelX_sharedAvaliable;
        private DevComponents.DotNetBar.LabelX ui_LabelX_localAvaliable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6_selectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_unselectAll;
        private DevComponents.DotNetBar.PanelEx ui_missingbar_panelEx_symbolsBack;
        private System.Windows.Forms.ListBox ui_listBox_symbolsForMissing;
        private DevComponents.DotNetBar.PanelEx ui_missingbars_panelEx_list_back;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.Controls.TextBoxX ui_home_textBoxX_db_bar;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.Controls.TextBoxX ui_home_textBoxX_db_historical;
        private DevComponents.DotNetBar.LabelItem labelItem_collecting;
        private DevComponents.DotNetBar.LabelItem labelItem_server;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel5;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView listView1;
        private DevComponents.DotNetBar.PanelEx panelEx9;
        private DevComponents.DotNetBar.PanelEx panelEx10;
        private System.Windows.Forms.ListBox listBox_daily_symbols;
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.PanelEx panelEx11;
        private DevComponents.DotNetBar.PanelEx panelEx12;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private DevComponents.DotNetBar.ButtonX buttonX_daily_getValues;
        private DevComponents.DotNetBar.ButtonX buttonX_daily_updateValues;
        private DevComponents.DotNetBar.PanelEx panelEx14;
        private System.Windows.Forms.Button button_ac_add;
        private System.Windows.Forms.NumericUpDown numericUpDown_ac_year;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ac_enddate;
        private System.Windows.Forms.TextBox textBox_ac_monthchar;
        private System.Windows.Forms.ListView listView_ac_list;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private DevComponents.DotNetBar.PanelEx panelEx13;
        private DevComponents.DotNetBar.ButtonX buttonX_ac_update;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox textBox_ac_symbol;
        private System.Windows.Forms.Button button_ac_delete;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private Controls.GroupList groupList1;
        private Controls.GroupList groupList2;
        private Controls.GroupList groupList3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroupGrid;
        private System.Windows.Forms.ToolStripMenuItem editSymbolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocollectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem symbolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonEdit;
        private DevComponents.DotNetBar.ButtonX buttonX_StartCollectGroups;
        private DevComponents.DotNetBar.ButtonX buttonX_stopCollecting;
        private System.Windows.Forms.LinkLabel linkLabel_selectNone;
        private System.Windows.Forms.LinkLabel linkLabel_selectAll;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevComponents.DotNetBar.PanelEx panelEx8;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private DevComponents.DotNetBar.PanelEx panelEx15;
        private System.Windows.Forms.LinkLabel linkLabel_status;
        private DevComponents.DotNetBar.PanelEx panelEx16;
        private System.Windows.Forms.LinkLabel linkLabel_sort_outcome;
        private DevComponents.DotNetBar.PanelEx panelEx17;
        private System.Windows.Forms.LinkLabel linkLabel_sort_ContType;
        private DevComponents.DotNetBar.PanelEx panelEx18;
        private System.Windows.Forms.LinkLabel linkLabel_sort_time;
        private DevComponents.DotNetBar.PanelEx panelEx19;
        private System.Windows.Forms.LinkLabel linkLabel_sort_tf;
        private DevComponents.DotNetBar.PanelEx panelEx20;
        private System.Windows.Forms.LinkLabel linkLabel_sort_name;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.LinkLabel linkLabel_logs;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;        
    }
}

