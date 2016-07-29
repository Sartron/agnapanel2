using System.Windows.Forms;

namespace AgnaPanel
{
    partial class MainFrm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAgnaDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAgnaDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveAgnaDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabsBase = new System.Windows.Forms.TabControl();
            this.tabPanel = new System.Windows.Forms.TabPage();
            this.tabIRC = new System.Windows.Forms.TabPage();
            this.txtSendIRC = new System.Windows.Forms.RichTextBox();
            this.txtIRC = new System.Windows.Forms.RichTextBox();
            this.mainMenu.SuspendLayout();
            this.tabsBase.SuspendLayout();
            this.tabIRC.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(499, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.toolStripSeparator1,
            this.openRecentToolStripMenuItem,
            this.openAgnaDirectoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Enabled = false;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.clearHistoryToolStripMenuItem});
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(139, 6);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            // 
            // openAgnaDirectoryToolStripMenuItem
            // 
            this.openAgnaDirectoryToolStripMenuItem.Name = "openAgnaDirectoryToolStripMenuItem";
            this.openAgnaDirectoryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openAgnaDirectoryToolStripMenuItem.Text = "Open Agna Directory";
            this.openAgnaDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openAgnaDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(47, 20);
            this.toolsMenu.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // openAgnaDialog
            // 
            this.openAgnaDialog.Filter = "Agna Scene Files|*.agna|XML Files|*.xml|All files|*.*";
            this.openAgnaDialog.Title = "Open Agna Scene";
            this.openAgnaDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openAgnaScene_FileOk);
            // 
            // saveAgnaDialog
            // 
            this.saveAgnaDialog.Filter = "Agna Scene Files|*.agna|XML Files|*.xml|All files|*.*";
            this.saveAgnaDialog.Title = "Save Agna Scene";
            this.saveAgnaDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveAgnaScene_FileOk);
            // 
            // tabsBase
            // 
            this.tabsBase.Controls.Add(this.tabPanel);
            this.tabsBase.Controls.Add(this.tabIRC);
            this.tabsBase.Location = new System.Drawing.Point(0, 25);
            this.tabsBase.Name = "tabsBase";
            this.tabsBase.SelectedIndex = 0;
            this.tabsBase.Size = new System.Drawing.Size(501, 262);
            this.tabsBase.TabIndex = 1;
            // 
            // tabPanel
            // 
            this.tabPanel.Location = new System.Drawing.Point(4, 22);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPanel.Size = new System.Drawing.Size(493, 236);
            this.tabPanel.TabIndex = 0;
            this.tabPanel.Text = "Panel";
            this.tabPanel.UseVisualStyleBackColor = true;
            // 
            // tabIRC
            // 
            this.tabIRC.Controls.Add(this.txtSendIRC);
            this.tabIRC.Controls.Add(this.txtIRC);
            this.tabIRC.Location = new System.Drawing.Point(4, 22);
            this.tabIRC.Name = "tabIRC";
            this.tabIRC.Padding = new System.Windows.Forms.Padding(3);
            this.tabIRC.Size = new System.Drawing.Size(493, 236);
            this.tabIRC.TabIndex = 1;
            this.tabIRC.Text = "Chat";
            this.tabIRC.UseVisualStyleBackColor = true;
            // 
            // txtSendIRC
            // 
            this.txtSendIRC.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendIRC.Location = new System.Drawing.Point(6, 206);
            this.txtSendIRC.Name = "txtSendIRC";
            this.txtSendIRC.Size = new System.Drawing.Size(481, 24);
            this.txtSendIRC.TabIndex = 1;
            this.txtSendIRC.Text = "";
            this.txtSendIRC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSendIRC_KeyPress);
            // 
            // txtIRC
            // 
            this.txtIRC.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIRC.Location = new System.Drawing.Point(6, 6);
            this.txtIRC.Name = "txtIRC";
            this.txtIRC.ReadOnly = true;
            this.txtIRC.Size = new System.Drawing.Size(481, 194);
            this.txtIRC.TabIndex = 0;
            this.txtIRC.Text = "";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 286);
            this.Controls.Add(this.tabsBase);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::AgnaPanel.Properties.Resources.agna_wing;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Text = "AgnaPanel";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tabsBase.ResumeLayout(false);
            this.tabIRC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAgnaDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private OpenFileDialog openAgnaDialog;
        private SaveFileDialog saveAgnaDialog;
        private TabControl tabsBase;
        private TabPage tabPanel;
        private TabPage tabIRC;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private RichTextBox txtIRC;
        private RichTextBox txtSendIRC;
    }
}