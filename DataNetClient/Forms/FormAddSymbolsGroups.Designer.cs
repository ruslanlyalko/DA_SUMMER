namespace DataNetClient.Forms
{
    partial class FormAddSymbolsGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddSymbolsGroups));
            this.slidePanelSymbols = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxTF = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem_tick = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.comboItem14 = new DevComponents.Editors.ComboItem();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderConType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGroupID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSymbolsForGroup = new System.Windows.Forms.ListView();
            this.textBoxGroupsFilter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxConType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonGroupADD = new DevComponents.DotNetBar.ButtonX();
            this.buttonGroupDelete = new DevComponents.DotNetBar.ButtonX();
            this.buttonDeleteFromGroup = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddToGroup = new DevComponents.DotNetBar.ButtonX();
            this.panelSymbolItems = new System.Windows.Forms.Panel();
            this.listBoxSymbols = new System.Windows.Forms.ListBox();
            this.buttonSymbolADD = new DevComponents.DotNetBar.ButtonX();
            this.buttonSymbolDELETE = new DevComponents.DotNetBar.ButtonX();
            this.textBoxSymbolFilter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonSymbolREPLACE = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.buttonCopy = new DevComponents.DotNetBar.ButtonX();
            this.slidePanelSymbols.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSymbolItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // slidePanelSymbols
            // 
            this.slidePanelSymbols.BackColor = System.Drawing.Color.White;
            this.slidePanelSymbols.Controls.Add(this.labelX21);
            this.slidePanelSymbols.Controls.Add(this.panel1);
            this.slidePanelSymbols.Controls.Add(this.buttonDeleteFromGroup);
            this.slidePanelSymbols.Controls.Add(this.buttonAddToGroup);
            this.slidePanelSymbols.Controls.Add(this.panelSymbolItems);
            this.slidePanelSymbols.Controls.Add(this.labelX6);
            this.slidePanelSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slidePanelSymbols.ForeColor = System.Drawing.Color.Black;
            this.slidePanelSymbols.Location = new System.Drawing.Point(0, 0);
            this.slidePanelSymbols.Name = "slidePanelSymbols";
            this.slidePanelSymbols.Size = new System.Drawing.Size(631, 314);
            this.slidePanelSymbols.SlideOutButtonVisible = false;
            this.slidePanelSymbols.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            this.slidePanelSymbols.TabIndex = 32;
            this.slidePanelSymbols.Text = "slidePanel1";
            this.slidePanelSymbols.UsesBlockingAnimation = false;
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
            this.labelX21.Location = new System.Drawing.Point(272, 6);
            this.labelX21.Name = "labelX21";
            this.labelX21.PaddingLeft = 6;
            this.labelX21.Size = new System.Drawing.Size(334, 29);
            this.labelX21.TabIndex = 87;
            this.labelX21.Text = "GROUPS";
            this.labelX21.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panel1.Controls.Add(this.buttonCopy);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.comboBoxTF);
            this.panel1.Controls.Add(this.listViewGroups);
            this.panel1.Controls.Add(this.listViewSymbolsForGroup);
            this.panel1.Controls.Add(this.textBoxGroupsFilter);
            this.panel1.Controls.Add(this.comboBoxConType);
            this.panel1.Controls.Add(this.buttonGroupADD);
            this.panel1.Controls.Add(this.buttonGroupDelete);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(272, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 276);
            this.panel1.TabIndex = 86;
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
            this.labelX1.Location = new System.Drawing.Point(3, 160);
            this.labelX1.Name = "labelX1";
            this.labelX1.PaddingLeft = 6;
            this.labelX1.Size = new System.Drawing.Size(328, 23);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "SYMBOLS IN GROUP";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboBoxTF
            // 
            this.comboBoxTF.DisplayMember = "Text";
            this.comboBoxTF.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTF.ForeColor = System.Drawing.Color.Black;
            this.comboBoxTF.FormattingEnabled = true;
            this.comboBoxTF.ItemHeight = 16;
            this.comboBoxTF.Items.AddRange(new object[] {
            this.comboItem_tick,
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem10,
            this.comboItem11,
            this.comboItem12,
            this.comboItem13,
            this.comboItem14,
            this.comboItem15});
            this.comboBoxTF.Location = new System.Drawing.Point(108, 0);
            this.comboBoxTF.Name = "comboBoxTF";
            this.comboBoxTF.Size = new System.Drawing.Size(101, 22);
            this.comboBoxTF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxTF.TabIndex = 83;
            this.comboBoxTF.WatermarkText = "TimeFrame";
            // 
            // comboItem_tick
            // 
            this.comboItem_tick.Text = "tick";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "1 minute";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2 minutes";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "3 minutes";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "5 minutes";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "10 minutes";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "15 minutes";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "30 minutes";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "60 minutes";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "240 minutes";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "Daily";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "Weekly";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "Monthly";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "Quarterly";
            // 
            // comboItem14
            // 
            this.comboItem14.Text = "Semiannual";
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "Yearly";
            // 
            // listViewGroups
            // 
            this.listViewGroups.BackColor = System.Drawing.Color.White;
            this.listViewGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderTF,
            this.columnHeaderConType,
            this.columnHeaderGroupID});
            this.listViewGroups.ForeColor = System.Drawing.Color.Black;
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.HideSelection = false;
            this.listViewGroups.Location = new System.Drawing.Point(0, 48);
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(331, 112);
            this.listViewGroups.TabIndex = 22;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            this.listViewGroups.View = System.Windows.Forms.View.Details;
            this.listViewGroups.SelectedIndexChanged += new System.EventHandler(this.listViewGroups_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "GroupName";
            this.columnHeaderName.Width = 98;
            // 
            // columnHeaderTF
            // 
            this.columnHeaderTF.Text = "TimeFrame";
            this.columnHeaderTF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTF.Width = 101;
            // 
            // columnHeaderConType
            // 
            this.columnHeaderConType.Text = "ContinuationType";
            this.columnHeaderConType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderConType.Width = 118;
            // 
            // columnHeaderGroupID
            // 
            this.columnHeaderGroupID.Text = "ID";
            this.columnHeaderGroupID.Width = 0;
            // 
            // listViewSymbolsForGroup
            // 
            this.listViewSymbolsForGroup.BackColor = System.Drawing.Color.White;
            this.listViewSymbolsForGroup.ForeColor = System.Drawing.Color.Black;
            this.listViewSymbolsForGroup.HideSelection = false;
            this.listViewSymbolsForGroup.Location = new System.Drawing.Point(0, 185);
            this.listViewSymbolsForGroup.Name = "listViewSymbolsForGroup";
            this.listViewSymbolsForGroup.Size = new System.Drawing.Size(331, 88);
            this.listViewSymbolsForGroup.TabIndex = 21;
            this.listViewSymbolsForGroup.UseCompatibleStateImageBehavior = false;
            this.listViewSymbolsForGroup.View = System.Windows.Forms.View.List;
            // 
            // textBoxGroupsFilter
            // 
            this.textBoxGroupsFilter.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxGroupsFilter.Border.Class = "TextBoxBorder";
            this.textBoxGroupsFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxGroupsFilter.ForeColor = System.Drawing.Color.Black;
            this.textBoxGroupsFilter.Location = new System.Drawing.Point(0, 23);
            this.textBoxGroupsFilter.Name = "textBoxGroupsFilter";
            this.textBoxGroupsFilter.Size = new System.Drawing.Size(256, 22);
            this.textBoxGroupsFilter.TabIndex = 18;
            this.textBoxGroupsFilter.WatermarkText = "ADD/FILTER";
            this.textBoxGroupsFilter.TextChanged += new System.EventHandler(this.textBoxGroupsFilter_TextChanged);
            // 
            // comboBoxConType
            // 
            this.comboBoxConType.DisplayMember = "Text";
            this.comboBoxConType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxConType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConType.ForeColor = System.Drawing.Color.Black;
            this.comboBoxConType.FormattingEnabled = true;
            this.comboBoxConType.ItemHeight = 16;
            this.comboBoxConType.Location = new System.Drawing.Point(208, 0);
            this.comboBoxConType.Name = "comboBoxConType";
            this.comboBoxConType.Size = new System.Drawing.Size(123, 22);
            this.comboBoxConType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxConType.TabIndex = 17;
            this.comboBoxConType.WatermarkText = "ContinuationType";
            // 
            // buttonGroupADD
            // 
            this.buttonGroupADD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGroupADD.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonGroupADD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGroupADD.Location = new System.Drawing.Point(0, 0);
            this.buttonGroupADD.Name = "buttonGroupADD";
            this.buttonGroupADD.Size = new System.Drawing.Size(53, 22);
            this.buttonGroupADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGroupADD.TabIndex = 15;
            this.buttonGroupADD.Text = "ADD";
            this.buttonGroupADD.Click += new System.EventHandler(this.buttonGroupADD_Click);
            // 
            // buttonGroupDelete
            // 
            this.buttonGroupDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGroupDelete.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonGroupDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGroupDelete.Location = new System.Drawing.Point(52, 0);
            this.buttonGroupDelete.Name = "buttonGroupDelete";
            this.buttonGroupDelete.Size = new System.Drawing.Size(57, 22);
            this.buttonGroupDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonGroupDelete.TabIndex = 14;
            this.buttonGroupDelete.Text = "DELETE";
            this.buttonGroupDelete.Click += new System.EventHandler(this.buttonGroupDelete_Click);
            // 
            // buttonDeleteFromGroup
            // 
            this.buttonDeleteFromGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDeleteFromGroup.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDeleteFromGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDeleteFromGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteFromGroup.Location = new System.Drawing.Point(214, 154);
            this.buttonDeleteFromGroup.Name = "buttonDeleteFromGroup";
            this.buttonDeleteFromGroup.Size = new System.Drawing.Size(56, 41);
            this.buttonDeleteFromGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonDeleteFromGroup.TabIndex = 85;
            this.buttonDeleteFromGroup.Text = "<";
            this.buttonDeleteFromGroup.Click += new System.EventHandler(this.buttonDeleteFromGroup_Click);
            // 
            // buttonAddToGroup
            // 
            this.buttonAddToGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddToGroup.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonAddToGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddToGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddToGroup.Location = new System.Drawing.Point(214, 86);
            this.buttonAddToGroup.Name = "buttonAddToGroup";
            this.buttonAddToGroup.Size = new System.Drawing.Size(56, 41);
            this.buttonAddToGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonAddToGroup.TabIndex = 84;
            this.buttonAddToGroup.Text = ">";
            this.buttonAddToGroup.Click += new System.EventHandler(this.buttonAddToGroup_Click);
            // 
            // panelSymbolItems
            // 
            this.panelSymbolItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panelSymbolItems.Controls.Add(this.listBoxSymbols);
            this.panelSymbolItems.Controls.Add(this.buttonSymbolADD);
            this.panelSymbolItems.Controls.Add(this.buttonSymbolDELETE);
            this.panelSymbolItems.Controls.Add(this.textBoxSymbolFilter);
            this.panelSymbolItems.Controls.Add(this.buttonSymbolREPLACE);
            this.panelSymbolItems.ForeColor = System.Drawing.Color.Black;
            this.panelSymbolItems.Location = new System.Drawing.Point(27, 32);
            this.panelSymbolItems.Name = "panelSymbolItems";
            this.panelSymbolItems.Size = new System.Drawing.Size(185, 279);
            this.panelSymbolItems.TabIndex = 21;
            // 
            // listBoxSymbols
            // 
            this.listBoxSymbols.BackColor = System.Drawing.Color.White;
            this.listBoxSymbols.ForeColor = System.Drawing.Color.Black;
            this.listBoxSymbols.FormattingEnabled = true;
            this.listBoxSymbols.Location = new System.Drawing.Point(0, 51);
            this.listBoxSymbols.Name = "listBoxSymbols";
            this.listBoxSymbols.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSymbols.Size = new System.Drawing.Size(184, 225);
            this.listBoxSymbols.TabIndex = 89;
            // 
            // buttonSymbolADD
            // 
            this.buttonSymbolADD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSymbolADD.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSymbolADD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSymbolADD.Location = new System.Drawing.Point(0, 2);
            this.buttonSymbolADD.Name = "buttonSymbolADD";
            this.buttonSymbolADD.Size = new System.Drawing.Size(66, 23);
            this.buttonSymbolADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSymbolADD.TabIndex = 13;
            this.buttonSymbolADD.Text = "ADD";
            this.buttonSymbolADD.Click += new System.EventHandler(this.buttonSymbolADD_Click);
            // 
            // buttonSymbolDELETE
            // 
            this.buttonSymbolDELETE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSymbolDELETE.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSymbolDELETE.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSymbolDELETE.Location = new System.Drawing.Point(62, 2);
            this.buttonSymbolDELETE.Name = "buttonSymbolDELETE";
            this.buttonSymbolDELETE.Size = new System.Drawing.Size(70, 23);
            this.buttonSymbolDELETE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSymbolDELETE.TabIndex = 11;
            this.buttonSymbolDELETE.Text = "DELETE";
            this.buttonSymbolDELETE.Click += new System.EventHandler(this.buttonSymbolDELETE_Click);
            // 
            // textBoxSymbolFilter
            // 
            this.textBoxSymbolFilter.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxSymbolFilter.Border.Class = "TextBoxBorder";
            this.textBoxSymbolFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxSymbolFilter.ForeColor = System.Drawing.Color.Black;
            this.textBoxSymbolFilter.Location = new System.Drawing.Point(0, 26);
            this.textBoxSymbolFilter.Name = "textBoxSymbolFilter";
            this.textBoxSymbolFilter.Size = new System.Drawing.Size(184, 22);
            this.textBoxSymbolFilter.TabIndex = 10;
            this.textBoxSymbolFilter.WatermarkText = "ADD/FILTER";
            this.textBoxSymbolFilter.TextChanged += new System.EventHandler(this.textBoxSymbolFilter_TextChanged);
            // 
            // buttonSymbolREPLACE
            // 
            this.buttonSymbolREPLACE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSymbolREPLACE.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSymbolREPLACE.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSymbolREPLACE.Location = new System.Drawing.Point(130, 2);
            this.buttonSymbolREPLACE.Name = "buttonSymbolREPLACE";
            this.buttonSymbolREPLACE.Size = new System.Drawing.Size(55, 23);
            this.buttonSymbolREPLACE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSymbolREPLACE.TabIndex = 12;
            this.buttonSymbolREPLACE.Text = "REPLACE";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(27, 3);
            this.labelX6.Name = "labelX6";
            this.labelX6.PaddingLeft = 6;
            this.labelX6.Size = new System.Drawing.Size(185, 32);
            this.labelX6.TabIndex = 20;
            this.labelX6.Text = "SYMBOLS";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonCopy
            // 
            this.buttonCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopy.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopy.Location = new System.Drawing.Point(255, 23);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(76, 22);
            this.buttonCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCopy.TabIndex = 90;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // FormAddSymbolsGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 314);
            this.Controls.Add(this.slidePanelSymbols);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAddSymbolsGroups";
            this.Text = "Add Symbols and Groups";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddSymbolsGroups_FormClosing);
            this.Load += new System.EventHandler(this.FromAddSymbolsGroups_Load);
            this.slidePanelSymbols.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSymbolItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.SlidePanel slidePanelSymbols;
        private DevComponents.DotNetBar.LabelX labelX21;
        private System.Windows.Forms.Panel panel1;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxTF;
        private DevComponents.Editors.ComboItem comboItem_tick;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.Editors.ComboItem comboItem14;
        private DevComponents.Editors.ComboItem comboItem15;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderTF;
        private System.Windows.Forms.ColumnHeader columnHeaderConType;
        private System.Windows.Forms.ColumnHeader columnHeaderGroupID;
        private System.Windows.Forms.ListView listViewSymbolsForGroup;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxGroupsFilter;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxConType;
        private DevComponents.DotNetBar.ButtonX buttonGroupADD;
        private DevComponents.DotNetBar.ButtonX buttonGroupDelete;
        private DevComponents.DotNetBar.ButtonX buttonDeleteFromGroup;
        private DevComponents.DotNetBar.ButtonX buttonAddToGroup;
        private System.Windows.Forms.Panel panelSymbolItems;
        private DevComponents.DotNetBar.ButtonX buttonSymbolADD;
        private DevComponents.DotNetBar.ButtonX buttonSymbolDELETE;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxSymbolFilter;
        private DevComponents.DotNetBar.ButtonX buttonSymbolREPLACE;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ListBox listBoxSymbols;
        private DevComponents.DotNetBar.ButtonX buttonCopy;

    }
}