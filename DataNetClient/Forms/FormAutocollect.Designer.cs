namespace DataNetClient.Forms
{
    partial class FormAutocollect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutocollect));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.listViewAutocollects = new System.Windows.Forms.ListView();
            this.columnHeaderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRemoveIntoGroup = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddToGroup = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxAutoCollect = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonAddSesion = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panelDays = new System.Windows.Forms.Panel();
            this.lM = new DevComponents.DotNetBar.LabelX();
            this.lSu = new DevComponents.DotNetBar.LabelX();
            this.lS = new DevComponents.DotNetBar.LabelX();
            this.lF = new DevComponents.DotNetBar.LabelX();
            this.lT = new DevComponents.DotNetBar.LabelX();
            this.lTu = new DevComponents.DotNetBar.LabelX();
            this.lW = new DevComponents.DotNetBar.LabelX();
            this.textBoxSesionName = new System.Windows.Forms.TextBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxFilter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.listBoxGroupName = new System.Windows.Forms.ListBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput)).BeginInit();
            this.panelDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.mainPanel.Controls.Add(this.listViewAutocollects);
            this.mainPanel.Controls.Add(this.buttonRemoveIntoGroup);
            this.mainPanel.Controls.Add(this.buttonAddToGroup);
            this.mainPanel.Controls.Add(this.comboBoxAutoCollect);
            this.mainPanel.Controls.Add(this.labelX3);
            this.mainPanel.Controls.Add(this.buttonAddSesion);
            this.mainPanel.Controls.Add(this.dateTimeInput);
            this.mainPanel.Controls.Add(this.panelDays);
            this.mainPanel.Controls.Add(this.textBoxSesionName);
            this.mainPanel.Controls.Add(this.labelX2);
            this.mainPanel.Controls.Add(this.labelX1);
            this.mainPanel.Controls.Add(this.textBoxFilter);
            this.mainPanel.Controls.Add(this.labelX21);
            this.mainPanel.Controls.Add(this.listBoxGroupName);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(625, 314);
            this.mainPanel.TabIndex = 0;
            // 
            // listViewAutocollects
            // 
            this.listViewAutocollects.BackColor = System.Drawing.Color.White;
            this.listViewAutocollects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNo,
            this.columnHeaderName,
            this.columnHeaderTS,
            this.columnHeaderDays});
            this.listViewAutocollects.ForeColor = System.Drawing.Color.Black;
            this.listViewAutocollects.FullRowSelect = true;
            this.listViewAutocollects.HideSelection = false;
            this.listViewAutocollects.Location = new System.Drawing.Point(348, 170);
            this.listViewAutocollects.Name = "listViewAutocollects";
            this.listViewAutocollects.Size = new System.Drawing.Size(274, 141);
            this.listViewAutocollects.TabIndex = 91;
            this.listViewAutocollects.UseCompatibleStateImageBehavior = false;
            this.listViewAutocollects.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNo
            // 
            this.columnHeaderNo.Text = "No";
            this.columnHeaderNo.Width = 34;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderName.Width = 62;
            // 
            // columnHeaderTS
            // 
            this.columnHeaderTS.Text = "Time Start";
            this.columnHeaderTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTS.Width = 82;
            // 
            // columnHeaderDays
            // 
            this.columnHeaderDays.Text = "Days";
            this.columnHeaderDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderDays.Width = 93;
            // 
            // buttonRemoveIntoGroup
            // 
            this.buttonRemoveIntoGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRemoveIntoGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonRemoveIntoGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveIntoGroup.Location = new System.Drawing.Point(271, 241);
            this.buttonRemoveIntoGroup.Name = "buttonRemoveIntoGroup";
            this.buttonRemoveIntoGroup.Size = new System.Drawing.Size(60, 50);
            this.buttonRemoveIntoGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonRemoveIntoGroup.TabIndex = 114;
            this.buttonRemoveIntoGroup.Text = "<";
            this.buttonRemoveIntoGroup.Click += new System.EventHandler(this.buttonRemoveIntoGroup_Click);
            // 
            // buttonAddToGroup
            // 
            this.buttonAddToGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddToGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddToGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddToGroup.Location = new System.Drawing.Point(271, 170);
            this.buttonAddToGroup.Name = "buttonAddToGroup";
            this.buttonAddToGroup.Size = new System.Drawing.Size(60, 50);
            this.buttonAddToGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddToGroup.TabIndex = 113;
            this.buttonAddToGroup.Text = ">";
            this.buttonAddToGroup.Click += new System.EventHandler(this.buttonAddToGroup_Click);
            // 
            // comboBoxAutoCollect
            // 
            this.comboBoxAutoCollect.DisplayMember = "Text";
            this.comboBoxAutoCollect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxAutoCollect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutoCollect.ForeColor = System.Drawing.Color.Black;
            this.comboBoxAutoCollect.FormattingEnabled = true;
            this.comboBoxAutoCollect.ItemHeight = 16;
            this.comboBoxAutoCollect.Location = new System.Drawing.Point(49, 241);
            this.comboBoxAutoCollect.Name = "comboBoxAutoCollect";
            this.comboBoxAutoCollect.Size = new System.Drawing.Size(187, 22);
            this.comboBoxAutoCollect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxAutoCollect.TabIndex = 112;
            this.comboBoxAutoCollect.WatermarkText = "list of saved autocollect";
            this.comboBoxAutoCollect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxAutoCollect_KeyDown);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(0, 206);
            this.labelX3.Name = "labelX3";
            this.labelX3.PaddingLeft = 6;
            this.labelX3.Size = new System.Drawing.Size(259, 29);
            this.labelX3.TabIndex = 111;
            this.labelX3.Text = "Add new autocollect";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonAddSesion
            // 
            this.buttonAddSesion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddSesion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddSesion.Location = new System.Drawing.Point(193, 78);
            this.buttonAddSesion.Name = "buttonAddSesion";
            this.buttonAddSesion.Size = new System.Drawing.Size(69, 51);
            this.buttonAddSesion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddSesion.TabIndex = 110;
            this.buttonAddSesion.Text = "Add";
            this.buttonAddSesion.Click += new System.EventHandler(this.buttonAddSesion_Click);
            // 
            // dateTimeInput
            // 
            this.dateTimeInput.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput.ButtonDropDown.Visible = true;
            this.dateTimeInput.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector;
            this.dateTimeInput.ForeColor = System.Drawing.Color.Black;
            this.dateTimeInput.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dateTimeInput.IsPopupCalendarOpen = false;
            this.dateTimeInput.Location = new System.Drawing.Point(3, 107);
            // 
            // 
            // 
            this.dateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2014, 5, 1, 0, 0, 0, 0);
            this.dateTimeInput.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput.MonthCalendar.Visible = false;
            this.dateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput.Name = "dateTimeInput";
            this.dateTimeInput.Size = new System.Drawing.Size(100, 22);
            this.dateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput.TabIndex = 109;
            // 
            // panelDays
            // 
            this.panelDays.AutoSize = true;
            this.panelDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panelDays.Controls.Add(this.lM);
            this.panelDays.Controls.Add(this.lSu);
            this.panelDays.Controls.Add(this.lS);
            this.panelDays.Controls.Add(this.lF);
            this.panelDays.Controls.Add(this.lT);
            this.panelDays.Controls.Add(this.lTu);
            this.panelDays.Controls.Add(this.lW);
            this.panelDays.ForeColor = System.Drawing.Color.Black;
            this.panelDays.Location = new System.Drawing.Point(109, 78);
            this.panelDays.Name = "panelDays";
            this.panelDays.Size = new System.Drawing.Size(81, 45);
            this.panelDays.TabIndex = 108;
            // 
            // lM
            // 
            this.lM.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lM.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lM.ForeColor = System.Drawing.Color.Black;
            this.lM.Location = new System.Drawing.Point(13, 19);
            this.lM.Name = "lM";
            this.lM.Size = new System.Drawing.Size(12, 23);
            this.lM.TabIndex = 102;
            this.lM.Text = "M";
            this.lM.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lM.Click += new System.EventHandler(this.lM_Click);
            // 
            // lSu
            // 
            this.lSu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lSu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lSu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSu.ForeColor = System.Drawing.Color.Black;
            this.lSu.Location = new System.Drawing.Point(68, 19);
            this.lSu.Name = "lSu";
            this.lSu.Size = new System.Drawing.Size(10, 23);
            this.lSu.TabIndex = 107;
            this.lSu.Text = "S";
            this.lSu.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lSu.Click += new System.EventHandler(this.lSu_Click);
            // 
            // lS
            // 
            this.lS.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lS.ForeColor = System.Drawing.Color.Black;
            this.lS.Location = new System.Drawing.Point(3, 19);
            this.lS.Name = "lS";
            this.lS.Size = new System.Drawing.Size(10, 23);
            this.lS.TabIndex = 101;
            this.lS.Text = "S";
            this.lS.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lS.Click += new System.EventHandler(this.lS_Click);
            // 
            // lF
            // 
            this.lF.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lF.ForeColor = System.Drawing.Color.Black;
            this.lF.Location = new System.Drawing.Point(58, 19);
            this.lF.Name = "lF";
            this.lF.Size = new System.Drawing.Size(10, 23);
            this.lF.TabIndex = 106;
            this.lF.Text = "F";
            this.lF.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lF.Click += new System.EventHandler(this.lF_Click);
            // 
            // lT
            // 
            this.lT.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lT.ForeColor = System.Drawing.Color.Black;
            this.lT.Location = new System.Drawing.Point(25, 19);
            this.lT.Name = "lT";
            this.lT.Size = new System.Drawing.Size(10, 23);
            this.lT.TabIndex = 103;
            this.lT.Text = "T";
            this.lT.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lT.Click += new System.EventHandler(this.lT_Click);
            // 
            // lTu
            // 
            this.lTu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lTu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lTu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTu.ForeColor = System.Drawing.Color.Black;
            this.lTu.Location = new System.Drawing.Point(48, 19);
            this.lTu.Name = "lTu";
            this.lTu.Size = new System.Drawing.Size(10, 23);
            this.lTu.TabIndex = 105;
            this.lTu.Text = "T";
            this.lTu.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lTu.Click += new System.EventHandler(this.lTu_Click);
            // 
            // lW
            // 
            this.lW.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lW.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lW.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lW.ForeColor = System.Drawing.Color.Black;
            this.lW.Location = new System.Drawing.Point(35, 19);
            this.lW.Name = "lW";
            this.lW.Size = new System.Drawing.Size(13, 23);
            this.lW.TabIndex = 104;
            this.lW.Text = "W";
            this.lW.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lW.Click += new System.EventHandler(this.lW_Click);
            // 
            // textBoxSesionName
            // 
            this.textBoxSesionName.BackColor = System.Drawing.Color.White;
            this.textBoxSesionName.ForeColor = System.Drawing.Color.Black;
            this.textBoxSesionName.Location = new System.Drawing.Point(3, 82);
            this.textBoxSesionName.Name = "textBoxSesionName";
            this.textBoxSesionName.Size = new System.Drawing.Size(100, 22);
            this.textBoxSesionName.TabIndex = 93;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(12, 36);
            this.labelX2.Name = "labelX2";
            this.labelX2.PaddingLeft = 6;
            this.labelX2.Size = new System.Drawing.Size(259, 29);
            this.labelX2.TabIndex = 92;
            this.labelX2.Text = "Add new autocollect";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(348, 143);
            this.labelX1.Name = "labelX1";
            this.labelX1.PaddingLeft = 6;
            this.labelX1.Size = new System.Drawing.Size(274, 29);
            this.labelX1.TabIndex = 90;
            this.labelX1.Text = "Auto Collects in Group";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxFilter.Border.Class = "TextBoxBorder";
            this.textBoxFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxFilter.ForeColor = System.Drawing.Color.Black;
            this.textBoxFilter.Location = new System.Drawing.Point(348, 47);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(274, 22);
            this.textBoxFilter.TabIndex = 89;
            this.textBoxFilter.WatermarkText = "Filter";
            // 
            // labelX21
            // 
            this.labelX21.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX21.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX21.ForeColor = System.Drawing.Color.Black;
            this.labelX21.Location = new System.Drawing.Point(348, 12);
            this.labelX21.Name = "labelX21";
            this.labelX21.PaddingLeft = 6;
            this.labelX21.Size = new System.Drawing.Size(274, 29);
            this.labelX21.TabIndex = 88;
            this.labelX21.Text = "GROUPS";
            this.labelX21.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // listBoxGroupName
            // 
            this.listBoxGroupName.BackColor = System.Drawing.Color.White;
            this.listBoxGroupName.ForeColor = System.Drawing.Color.Black;
            this.listBoxGroupName.FormattingEnabled = true;
            this.listBoxGroupName.Location = new System.Drawing.Point(348, 68);
            this.listBoxGroupName.Name = "listBoxGroupName";
            this.listBoxGroupName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxGroupName.Size = new System.Drawing.Size(274, 69);
            this.listBoxGroupName.TabIndex = 0;
            this.listBoxGroupName.SelectedIndexChanged += new System.EventHandler(this.listBoxGroupName_SelectedIndexChanged);
            // 
            // FormAutocollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 314);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAutocollect";
            this.Tag = "";
            this.Text = "Auto Collect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAutocollect_FormClosed);
            this.Load += new System.EventHandler(this.FormAutocollect_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput)).EndInit();
            this.panelDays.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ListBox listBoxGroupName;
        private System.Windows.Forms.TextBox textBoxSesionName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ListView listViewAutocollects;
        private System.Windows.Forms.ColumnHeader columnHeaderNo;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderTS;
        private System.Windows.Forms.ColumnHeader columnHeaderDays;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxFilter;
        private DevComponents.DotNetBar.LabelX labelX21;
        private DevComponents.DotNetBar.LabelX lSu;
        private DevComponents.DotNetBar.LabelX lF;
        private DevComponents.DotNetBar.LabelX lTu;
        private DevComponents.DotNetBar.LabelX lW;
        private DevComponents.DotNetBar.LabelX lT;
        private DevComponents.DotNetBar.LabelX lM;
        private DevComponents.DotNetBar.LabelX lS;
        private System.Windows.Forms.Panel panelDays;
        private DevComponents.DotNetBar.ButtonX buttonAddSesion;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput;
        private DevComponents.DotNetBar.ButtonX buttonRemoveIntoGroup;
        private DevComponents.DotNetBar.ButtonX buttonAddToGroup;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxAutoCollect;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}