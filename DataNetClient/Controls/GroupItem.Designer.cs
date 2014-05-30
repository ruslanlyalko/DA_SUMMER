namespace DataNetClient.Controls
{
    sealed partial class GroupItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx_Main = new DevComponents.DotNetBar.PanelEx();
            this.labelX_Status_Count = new DevComponents.DotNetBar.LabelX();
            this.labelX_Autocollect = new DevComponents.DotNetBar.LabelX();
            this.labelX_Name = new DevComponents.DotNetBar.LabelX();
            this.labelX_TimeFrame = new DevComponents.DotNetBar.LabelX();
            this.labelX_ContType = new DevComponents.DotNetBar.LabelX();
            this.labelX_Time = new DevComponents.DotNetBar.LabelX();
            this.labelX_Status_Name = new DevComponents.DotNetBar.LabelX();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelEx_Day = new DevComponents.DotNetBar.PanelEx();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx7 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx8 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx9 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx10 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx_logs = new DevComponents.DotNetBar.PanelEx();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.panelEx_isSelected = new DevComponents.DotNetBar.PanelEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.listViewEx2 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.grid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_logColumn_MsgType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_logColumn_Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_logColumn_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_logColumn_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_logColumn_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx_Main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.panelEx6.SuspendLayout();
            this.panelEx7.SuspendLayout();
            this.panelEx8.SuspendLayout();
            this.panelEx9.SuspendLayout();
            this.panelEx10.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx_Main
            // 
            this.panelEx_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx_Main.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Main.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Main.Controls.Add(this.listViewEx2);
            this.panelEx_Main.Controls.Add(this.tableLayoutPanel1);
            this.panelEx_Main.Controls.Add(this.panelEx_isSelected);
            this.panelEx_Main.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Main.Name = "panelEx_Main";
            this.panelEx_Main.Size = new System.Drawing.Size(754, 106);
            this.panelEx_Main.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Main.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx_Main.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.panelEx_Main.Style.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.panelEx_Main.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.panelEx_Main.Style.BorderWidth = 3;
            this.panelEx_Main.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Main.Style.GradientAngle = 90;
            this.panelEx_Main.Style.MarginBottom = 3;
            this.panelEx_Main.Style.MarginLeft = 3;
            this.panelEx_Main.Style.MarginRight = 3;
            this.panelEx_Main.Style.MarginTop = 3;
            this.panelEx_Main.TabIndex = 0;
            this.panelEx_Main.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // labelX_Status_Count
            // 
            this.labelX_Status_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_Status_Count.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_Status_Count.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelX_Status_Count.Location = new System.Drawing.Point(3, 29);
            this.labelX_Status_Count.Name = "labelX_Status_Count";
            this.labelX_Status_Count.Size = new System.Drawing.Size(88, 23);
            this.labelX_Status_Count.TabIndex = 11;
            this.labelX_Status_Count.Text = "8/9";
            this.labelX_Status_Count.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX_Status_Count.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // labelX_Autocollect
            // 
            this.labelX_Autocollect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_Autocollect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_Autocollect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelX_Autocollect.Location = new System.Drawing.Point(3, 16);
            this.labelX_Autocollect.Name = "labelX_Autocollect";
            this.labelX_Autocollect.Size = new System.Drawing.Size(88, 23);
            this.labelX_Autocollect.TabIndex = 90;
            this.labelX_Autocollect.Text = "ON";
            this.labelX_Autocollect.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX_Name
            // 
            this.labelX_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_Name.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelX_Name.Location = new System.Drawing.Point(3, 15);
            this.labelX_Name.Name = "labelX_Name";
            this.labelX_Name.Size = new System.Drawing.Size(88, 23);
            this.labelX_Name.TabIndex = 4;
            this.labelX_Name.Text = "Name";
            this.labelX_Name.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX_Name.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // labelX_TimeFrame
            // 
            this.labelX_TimeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_TimeFrame.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_TimeFrame.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_TimeFrame.Location = new System.Drawing.Point(3, 16);
            this.labelX_TimeFrame.Name = "labelX_TimeFrame";
            this.labelX_TimeFrame.Size = new System.Drawing.Size(88, 23);
            this.labelX_TimeFrame.TabIndex = 5;
            this.labelX_TimeFrame.Text = "TF";
            this.labelX_TimeFrame.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX_TimeFrame.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // labelX_ContType
            // 
            this.labelX_ContType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_ContType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_ContType.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_ContType.Location = new System.Drawing.Point(3, 16);
            this.labelX_ContType.Name = "labelX_ContType";
            this.labelX_ContType.Size = new System.Drawing.Size(88, 23);
            this.labelX_ContType.TabIndex = 7;
            this.labelX_ContType.Text = "ContType";
            this.labelX_ContType.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX_ContType.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // labelX_Time
            // 
            this.labelX_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_Time.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_Time.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_Time.Location = new System.Drawing.Point(3, 16);
            this.labelX_Time.Name = "labelX_Time";
            this.labelX_Time.Size = new System.Drawing.Size(88, 23);
            this.labelX_Time.TabIndex = 6;
            this.labelX_Time.Text = "Time";
            this.labelX_Time.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX_Time.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // labelX_Status_Name
            // 
            this.labelX_Status_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_Status_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_Status_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelX_Status_Name.Location = new System.Drawing.Point(3, 3);
            this.labelX_Status_Name.Name = "labelX_Status_Name";
            this.labelX_Status_Name.Size = new System.Drawing.Size(91, 20);
            this.labelX_Status_Name.TabIndex = 10;
            this.labelX_Status_Name.Text = "   In Progress";
            this.labelX_Status_Name.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Interval = 10000;
            this.timer_update.Tick += new System.EventHandler(this.timer_update_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.50357F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49871F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.499F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.499F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.499F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.499F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.499F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.50275F));
            this.tableLayoutPanel1.Controls.Add(this.panelEx_Day, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx7, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEx_logs, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 57);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panelEx_Day
            // 
            this.panelEx_Day.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Day.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Day.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Day.Location = new System.Drawing.Point(564, 0);
            this.panelEx_Day.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx_Day.Name = "panelEx_Day";
            this.panelEx_Day.Size = new System.Drawing.Size(94, 57);
            this.panelEx_Day.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Day.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx_Day.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Day.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Day.Style.BorderWidth = 3;
            this.panelEx_Day.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Day.Style.GradientAngle = 90;
            this.panelEx_Day.TabIndex = 0;
            // 
            // panelEx5
            // 
            this.panelEx5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.Controls.Add(this.labelX_Autocollect);
            this.panelEx5.Location = new System.Drawing.Point(470, 0);
            this.panelEx5.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(94, 57);
            this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx5.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx5.Style.BorderWidth = 3;
            this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx5.Style.GradientAngle = 90;
            this.panelEx5.TabIndex = 1;
            // 
            // panelEx6
            // 
            this.panelEx6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx6.Controls.Add(this.labelX_Status_Name);
            this.panelEx6.Controls.Add(this.labelX_Status_Count);
            this.panelEx6.Location = new System.Drawing.Point(376, 0);
            this.panelEx6.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(94, 57);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.BorderWidth = 3;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 2;
            // 
            // panelEx7
            // 
            this.panelEx7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx7.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx7.Controls.Add(this.labelX_ContType);
            this.panelEx7.Location = new System.Drawing.Point(282, 0);
            this.panelEx7.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx7.Name = "panelEx7";
            this.panelEx7.Size = new System.Drawing.Size(94, 57);
            this.panelEx7.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx7.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx7.Style.BorderWidth = 3;
            this.panelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx7.Style.GradientAngle = 90;
            this.panelEx7.TabIndex = 3;
            // 
            // panelEx8
            // 
            this.panelEx8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx8.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx8.Controls.Add(this.labelX_TimeFrame);
            this.panelEx8.Location = new System.Drawing.Point(94, 0);
            this.panelEx8.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx8.Name = "panelEx8";
            this.panelEx8.Size = new System.Drawing.Size(94, 57);
            this.panelEx8.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx8.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx8.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx8.Style.BorderWidth = 3;
            this.panelEx8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx8.Style.GradientAngle = 90;
            this.panelEx8.TabIndex = 4;
            // 
            // panelEx9
            // 
            this.panelEx9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx9.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx9.Controls.Add(this.labelX_Time);
            this.panelEx9.Location = new System.Drawing.Point(188, 0);
            this.panelEx9.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx9.Name = "panelEx9";
            this.panelEx9.Size = new System.Drawing.Size(94, 57);
            this.panelEx9.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx9.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx9.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx9.Style.BorderWidth = 3;
            this.panelEx9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx9.Style.GradientAngle = 90;
            this.panelEx9.TabIndex = 5;
            // 
            // panelEx10
            // 
            this.panelEx10.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx10.Controls.Add(this.buttonX1);
            this.panelEx10.Controls.Add(this.labelX_Name);
            this.panelEx10.Controls.Add(this.expandablePanel1);
            this.panelEx10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx10.Location = new System.Drawing.Point(0, 0);
            this.panelEx10.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx10.Name = "panelEx10";
            this.panelEx10.Size = new System.Drawing.Size(94, 57);
            this.panelEx10.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx10.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx10.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx10.Style.BorderWidth = 3;
            this.panelEx10.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx10.Style.GradientAngle = 90;
            this.panelEx10.TabIndex = 6;
            // 
            // panelEx_logs
            // 
            this.panelEx_logs.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_logs.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_logs.Location = new System.Drawing.Point(658, 0);
            this.panelEx_logs.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx_logs.Name = "panelEx_logs";
            this.panelEx_logs.Size = new System.Drawing.Size(96, 57);
            this.panelEx_logs.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_logs.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx_logs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_logs.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_logs.Style.BorderWidth = 3;
            this.panelEx_logs.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_logs.Style.GradientAngle = 90;
            this.panelEx_logs.TabIndex = 7;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.expandablePanel1.AutoSize = true;
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.listViewEx1);
            this.expandablePanel1.ExpandButtonAlignment = DevComponents.DotNetBar.eTitleButtonAlignment.Left;
            this.expandablePanel1.Expanded = false;
            this.expandablePanel1.ExpandedBounds = new System.Drawing.Rectangle(3, 29, 464, 136);
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(3, 29);
            this.expandablePanel1.Margin = new System.Windows.Forms.Padding(0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(67, 26);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.expandablePanel1.Style.BorderColor.Alpha = ((byte)(0));
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 10;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.Color = System.Drawing.Color.White;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.expandablePanel1.TitleStyle.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.expandablePanel1.TitleStyle.BorderWidth = 3;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = " ";
            this.expandablePanel1.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel1_ExpandedChanging);
            this.expandablePanel1.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel1_ExpandedChanged);
            this.expandablePanel1.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // listViewEx1
            // 
            this.listViewEx1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listViewEx1.ForeColor = System.Drawing.Color.Black;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.Location = new System.Drawing.Point(0, 26);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(464, 0);
            this.listViewEx1.TabIndex = 1;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.List;
            // 
            // panelEx_isSelected
            // 
            this.panelEx_isSelected.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_isSelected.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_isSelected.Location = new System.Drawing.Point(0, 1);
            this.panelEx_isSelected.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx_isSelected.Name = "panelEx_isSelected";
            this.panelEx_isSelected.Size = new System.Drawing.Size(10, 53);
            this.panelEx_isSelected.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_isSelected.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panelEx_isSelected.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_isSelected.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_isSelected.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_isSelected.Style.GradientAngle = 90;
            this.panelEx_isSelected.TabIndex = 12;
            this.panelEx_isSelected.Visible = false;
            this.panelEx_isSelected.Click += new System.EventHandler(this.panelEx_Main_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(5, 33);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(30, 19);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = ">>";
            this.buttonX1.Visible = false;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // listViewEx2
            // 
            this.listViewEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx2.Border.Class = "ListViewBorder";
            this.listViewEx2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx2.ForeColor = System.Drawing.Color.Black;
            this.listViewEx2.Location = new System.Drawing.Point(3, 56);
            this.listViewEx2.Name = "listViewEx2";
            this.listViewEx2.Size = new System.Drawing.Size(465, 14);
            this.listViewEx2.TabIndex = 18;
            this.listViewEx2.UseCompatibleStateImageBehavior = false;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 30;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Name,
            this.Column_tf,
            this.ui_logColumn_MsgType,
            this.ui_logColumn_Symbol,
            this.ui_logColumn_group,
            this.ui_logColumn_Description,
            this.ui_logColumn_Status,
            this.Column6,
            this.Comm});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.Color.White;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(754, 34);
            this.grid.TabIndex = 1;
            // 
            // Column_Name
            // 
            this.Column_Name.HeaderText = "Name";
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            this.Column_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column_tf
            // 
            this.Column_tf.FillWeight = 70F;
            this.Column_tf.HeaderText = "TimeFrame";
            this.Column_tf.Name = "Column_tf";
            this.Column_tf.ReadOnly = true;
            // 
            // ui_logColumn_MsgType
            // 
            this.ui_logColumn_MsgType.FillWeight = 48.44585F;
            this.ui_logColumn_MsgType.HeaderText = "Event";
            this.ui_logColumn_MsgType.Name = "ui_logColumn_MsgType";
            this.ui_logColumn_MsgType.ReadOnly = true;
            // 
            // ui_logColumn_Symbol
            // 
            this.ui_logColumn_Symbol.FillWeight = 62.19339F;
            this.ui_logColumn_Symbol.HeaderText = "Symbol";
            this.ui_logColumn_Symbol.Name = "ui_logColumn_Symbol";
            this.ui_logColumn_Symbol.ReadOnly = true;
            // 
            // ui_logColumn_group
            // 
            this.ui_logColumn_group.FillWeight = 75.87428F;
            this.ui_logColumn_group.HeaderText = "Group";
            this.ui_logColumn_group.Name = "ui_logColumn_group";
            this.ui_logColumn_group.ReadOnly = true;
            // 
            // ui_logColumn_Description
            // 
            this.ui_logColumn_Description.FillWeight = 80F;
            this.ui_logColumn_Description.HeaderText = "Time frame";
            this.ui_logColumn_Description.Name = "ui_logColumn_Description";
            this.ui_logColumn_Description.ReadOnly = true;
            // 
            // ui_logColumn_Status
            // 
            this.ui_logColumn_Status.FillWeight = 60F;
            this.ui_logColumn_Status.HeaderText = "Status";
            this.ui_logColumn_Status.Name = "ui_logColumn_Status";
            this.ui_logColumn_Status.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 60F;
            this.Column6.HeaderText = "App";
            this.Column6.Name = "Column6";
            // 
            // Comm
            // 
            this.Comm.HeaderText = "Comments";
            this.Comm.Name = "Comm";
            // 
            // GroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelEx_Main);
            this.Name = "GroupItem";
            this.Size = new System.Drawing.Size(754, 34);
            this.panelEx_Main.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            this.panelEx6.ResumeLayout(false);
            this.panelEx7.ResumeLayout(false);
            this.panelEx8.ResumeLayout(false);
            this.panelEx9.ResumeLayout(false);
            this.panelEx10.ResumeLayout(false);
            this.panelEx10.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_Main;
        private DevComponents.DotNetBar.LabelX labelX_ContType;
        private DevComponents.DotNetBar.LabelX labelX_Time;
        private DevComponents.DotNetBar.LabelX labelX_TimeFrame;
        private DevComponents.DotNetBar.LabelX labelX_Name;
        private DevComponents.DotNetBar.LabelX labelX_Status_Count;
        private DevComponents.DotNetBar.LabelX labelX_Status_Name;
        private System.Windows.Forms.Timer timer_update;
        private DevComponents.DotNetBar.LabelX labelX_Autocollect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.PanelEx panelEx_Day;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private DevComponents.DotNetBar.PanelEx panelEx6;
        private DevComponents.DotNetBar.PanelEx panelEx7;
        private DevComponents.DotNetBar.PanelEx panelEx8;
        private DevComponents.DotNetBar.PanelEx panelEx9;
        private DevComponents.DotNetBar.PanelEx panelEx10;
        private DevComponents.DotNetBar.PanelEx panelEx_logs;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private DevComponents.DotNetBar.PanelEx panelEx_isSelected;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx2;
        private DevComponents.DotNetBar.Controls.DataGridViewX grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_logColumn_MsgType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_logColumn_Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_logColumn_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_logColumn_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_logColumn_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comm;

    }
}
