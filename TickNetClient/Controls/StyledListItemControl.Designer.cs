﻿namespace TickNetClient.Controls
{
    partial class StyledListItemControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelEx_back = new DevComponents.DotNetBar.PanelEx();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.symbolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX_time1 = new DevComponents.DotNetBar.LabelX();
            this.labelX_isAutoCollectEnabled = new DevComponents.DotNetBar.LabelX();
            this.labelX_settings = new DevComponents.DotNetBar.LabelX();
            this.labelX_depth = new DevComponents.DotNetBar.LabelX();
            this.labelX_title = new DevComponents.DotNetBar.LabelX();
            this.labelX_count = new DevComponents.DotNetBar.LabelX();
            this.panelEx_left = new DevComponents.DotNetBar.PanelEx();
            this.labelX_state = new DevComponents.DotNetBar.LabelX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelEx_back.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx_back
            // 
            this.panelEx_back.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_back.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_back.ContextMenuStrip = this.contextMenuStrip1;
            this.panelEx_back.Controls.Add(this.labelX_time1);
            this.panelEx_back.Controls.Add(this.labelX_isAutoCollectEnabled);
            this.panelEx_back.Controls.Add(this.labelX_settings);
            this.panelEx_back.Controls.Add(this.labelX_depth);
            this.panelEx_back.Controls.Add(this.labelX_title);
            this.panelEx_back.Controls.Add(this.labelX_count);
            this.panelEx_back.Controls.Add(this.panelEx_left);
            this.panelEx_back.Controls.Add(this.labelX_state);
            this.panelEx_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_back.Location = new System.Drawing.Point(0, 0);
            this.panelEx_back.Name = "panelEx_back";
            this.panelEx_back.Size = new System.Drawing.Size(302, 41);
            this.panelEx_back.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_back.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx_back.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_back.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_back.Style.GradientAngle = 90;
            this.panelEx_back.TabIndex = 1;
            this.panelEx_back.Click += new System.EventHandler(this.panelEx_back_Click);
            this.panelEx_back.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.panelEx_back.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.symbolsToolStripMenuItem,
            this.sessionsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editGroupToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 76);
            // 
            // symbolsToolStripMenuItem
            // 
            this.symbolsToolStripMenuItem.Name = "symbolsToolStripMenuItem";
            this.symbolsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.symbolsToolStripMenuItem.Text = "Symbols";
            // 
            // sessionsToolStripMenuItem
            // 
            this.sessionsToolStripMenuItem.Name = "sessionsToolStripMenuItem";
            this.sessionsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sessionsToolStripMenuItem.Text = "Sessions";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.editGroupToolStripMenuItem.Text = "Edit group";
            this.editGroupToolStripMenuItem.Click += new System.EventHandler(this.editGroupToolStripMenuItem_Click);
            // 
            // labelX_time1
            // 
            this.labelX_time1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_time1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_time1.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_time1.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_time1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_time1.Location = new System.Drawing.Point(150, 20);
            this.labelX_time1.Name = "labelX_time1";
            this.labelX_time1.Size = new System.Drawing.Size(123, 20);
            this.labelX_time1.TabIndex = 9;
            this.labelX_time1.Text = "12:00";
            this.labelX_time1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.toolTip1.SetToolTip(this.labelX_time1, "Scheduled date/time");
            this.labelX_time1.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_time1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // labelX_isAutoCollectEnabled
            // 
            this.labelX_isAutoCollectEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_isAutoCollectEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_isAutoCollectEnabled.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_isAutoCollectEnabled.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_isAutoCollectEnabled.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_isAutoCollectEnabled.Location = new System.Drawing.Point(279, 20);
            this.labelX_isAutoCollectEnabled.Name = "labelX_isAutoCollectEnabled";
            this.labelX_isAutoCollectEnabled.Size = new System.Drawing.Size(20, 20);
            this.labelX_isAutoCollectEnabled.Symbol = "";
            this.labelX_isAutoCollectEnabled.SymbolColor = System.Drawing.Color.Green;
            this.labelX_isAutoCollectEnabled.SymbolSize = 12F;
            this.labelX_isAutoCollectEnabled.TabIndex = 12;
            this.toolTip1.SetToolTip(this.labelX_isAutoCollectEnabled, "Auto Collect enabled");
            this.labelX_isAutoCollectEnabled.Visible = false;
            this.labelX_isAutoCollectEnabled.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_isAutoCollectEnabled.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // labelX_settings
            // 
            this.labelX_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_settings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_settings.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_settings.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_settings.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_settings.Location = new System.Drawing.Point(279, 3);
            this.labelX_settings.Name = "labelX_settings";
            this.labelX_settings.Size = new System.Drawing.Size(20, 20);
            this.labelX_settings.Symbol = "";
            this.labelX_settings.SymbolColor = System.Drawing.Color.LightGreen;
            this.labelX_settings.SymbolSize = 15F;
            this.labelX_settings.TabIndex = 11;
            this.labelX_settings.Click += new System.EventHandler(this.editGroupToolStripMenuItem_Click);
            this.labelX_settings.MouseLeave += new System.EventHandler(this.labelX_settings_MouseLeave);
            this.labelX_settings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelX_settings_MouseMove);
            // 
            // labelX_depth
            // 
            // 
            // 
            // 
            this.labelX_depth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_depth.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_depth.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_depth.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_depth.Location = new System.Drawing.Point(117, 22);
            this.labelX_depth.Name = "labelX_depth";
            this.labelX_depth.Size = new System.Drawing.Size(27, 16);
            this.labelX_depth.TabIndex = 10;
            this.labelX_depth.Text = "5";
            this.labelX_depth.TextAlignment = System.Drawing.StringAlignment.Center;
            this.toolTip1.SetToolTip(this.labelX_depth, "Depth");
            this.labelX_depth.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_depth.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // labelX_title
            // 
            this.labelX_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_title.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_title.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX_title.Location = new System.Drawing.Point(7, 3);
            this.labelX_title.Name = "labelX_title";
            this.labelX_title.Size = new System.Drawing.Size(266, 20);
            this.labelX_title.TabIndex = 4;
            this.labelX_title.Text = "КСМ - 1";
            this.labelX_title.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelX_title.Click += new System.EventHandler(this.panelEx_back_Click);
            this.labelX_title.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // labelX_count
            // 
            // 
            // 
            // 
            this.labelX_count.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_count.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_count.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelX_count.ForeColor = System.Drawing.Color.Black;
            this.labelX_count.Location = new System.Drawing.Point(70, 21);
            this.labelX_count.Name = "labelX_count";
            this.labelX_count.PaddingRight = 5;
            this.labelX_count.Size = new System.Drawing.Size(48, 17);
            this.labelX_count.SymbolColor = System.Drawing.Color.Black;
            this.labelX_count.SymbolSize = 15F;
            this.labelX_count.TabIndex = 3;
            this.labelX_count.Text = "[15]";
            this.labelX_count.TextAlignment = System.Drawing.StringAlignment.Center;
            this.toolTip1.SetToolTip(this.labelX_count, "Total symbol count");
            this.labelX_count.Click += new System.EventHandler(this.panelEx_back_Click);
            this.labelX_count.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_count.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // panelEx_left
            // 
            this.panelEx_left.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_left.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx_left.Location = new System.Drawing.Point(0, 0);
            this.panelEx_left.MaximumSize = new System.Drawing.Size(3, 0);
            this.panelEx_left.Name = "panelEx_left";
            this.panelEx_left.Size = new System.Drawing.Size(3, 41);
            this.panelEx_left.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_left.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_left.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_left.Style.GradientAngle = 90;
            this.panelEx_left.TabIndex = 6;
            // 
            // labelX_state
            // 
            // 
            // 
            // 
            this.labelX_state.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_state.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_state.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_state.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_state.Location = new System.Drawing.Point(7, 22);
            this.labelX_state.Name = "labelX_state";
            this.labelX_state.Size = new System.Drawing.Size(69, 16);
            this.labelX_state.TabIndex = 7;
            this.labelX_state.Text = "In progress";
            this.toolTip1.SetToolTip(this.labelX_state, "State");
            this.labelX_state.Click += new System.EventHandler(this.panelEx_back_Click);
            this.labelX_state.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_state.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // StyledListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelEx_back);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "StyledListItemControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Size = new System.Drawing.Size(302, 43);
            this.panelEx_back.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_back;
        private DevComponents.DotNetBar.LabelX labelX_count;
        private DevComponents.DotNetBar.LabelX labelX_title;
        private DevComponents.DotNetBar.PanelEx panelEx_left;
        private DevComponents.DotNetBar.LabelX labelX_state;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.LabelX labelX_time1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem symbolsToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX_depth;
        private System.Windows.Forms.ToolStripMenuItem sessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX_settings;
        private DevComponents.DotNetBar.LabelX labelX_isAutoCollectEnabled;
    }
}
