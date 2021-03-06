﻿using System.Windows.Forms;

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
            this.panelFields = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTournament = new System.Windows.Forms.TableLayoutPanel();
            this.lblMatch = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblTournamentName = new System.Windows.Forms.Label();
            this.panelPlayers = new System.Windows.Forms.Panel();
            this.comboP1Char = new System.Windows.Forms.ComboBox();
            this.comboP2Char = new System.Windows.Forms.ComboBox();
            this.comboP2Game = new System.Windows.Forms.ComboBox();
            this.lblP2 = new System.Windows.Forms.Label();
            this.comboP1Game = new System.Windows.Forms.ComboBox();
            this.btnSwapNames = new System.Windows.Forms.Button();
            this.btnSwapChars = new System.Windows.Forms.Button();
            this.lblP1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabsFields = new System.Windows.Forms.TabControl();
            this.tabSpecial = new System.Windows.Forms.TabPage();
            this.lblMusic = new System.Windows.Forms.Label();
            this.pictureMusicNote = new System.Windows.Forms.PictureBox();
            this.lblCamera2 = new System.Windows.Forms.Label();
            this.btnSwapCameras = new System.Windows.Forms.Button();
            this.lblCamera1 = new System.Windows.Forms.Label();
            this.tabCommentary = new System.Windows.Forms.TabPage();
            this.tabCustom = new System.Windows.Forms.TabPage();
            this.tabIRC = new System.Windows.Forms.TabPage();
            this.txtSendIRC = new System.Windows.Forms.RichTextBox();
            this.txtIRC = new System.Windows.Forms.RichTextBox();
            this.lblAnnouncement = new System.Windows.Forms.Label();
            this.lblComm2 = new System.Windows.Forms.Label();
            this.btnSwapComms = new System.Windows.Forms.Button();
            this.lblComm1 = new System.Windows.Forms.Label();
            this.lblComm2Twitter = new System.Windows.Forms.Label();
            this.lblComm1Twitter = new System.Windows.Forms.Label();
            this.txtMatch = new AgnaPanel.BorderedTextBox();
            this.txtEvent = new AgnaPanel.BorderedTextBox();
            this.txtTournamentName = new AgnaPanel.BorderedTextBox();
            this.txtP1Score = new AgnaPanel.BorderedTextBox();
            this.txtP2Score = new AgnaPanel.BorderedTextBox();
            this.txtP2Name = new AgnaPanel.BorderedTextBox();
            this.txtP1Name = new AgnaPanel.BorderedTextBox();
            this.txtAnnouncement = new AgnaPanel.BorderedTextBox();
            this.txtMusic = new AgnaPanel.BorderedTextBox();
            this.txtCamera2 = new AgnaPanel.BorderedTextBox();
            this.txtCamera1 = new AgnaPanel.BorderedTextBox();
            this.txtComm2Twitter = new AgnaPanel.BorderedTextBox();
            this.txtComm1Twitter = new AgnaPanel.BorderedTextBox();
            this.txtComm2 = new AgnaPanel.BorderedTextBox();
            this.txtComm1 = new AgnaPanel.BorderedTextBox();
            this.mainMenu.SuspendLayout();
            this.tabsBase.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.panelFields.SuspendLayout();
            this.panelTournament.SuspendLayout();
            this.panelPlayers.SuspendLayout();
            this.tabsFields.SuspendLayout();
            this.tabSpecial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMusicNote)).BeginInit();
            this.tabCommentary.SuspendLayout();
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
            this.openAgnaDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openAgnaDialog_FileOk);
            // 
            // saveAgnaDialog
            // 
            this.saveAgnaDialog.Filter = "Agna Scene Files|*.agna|XML Files|*.xml|All files|*.*";
            this.saveAgnaDialog.Title = "Save Agna Scene";
            this.saveAgnaDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveAgnaDialog_FileOk);
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
            this.tabPanel.Controls.Add(this.panelFields);
            this.tabPanel.Location = new System.Drawing.Point(4, 22);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPanel.Size = new System.Drawing.Size(493, 236);
            this.tabPanel.TabIndex = 0;
            this.tabPanel.Text = "Panel";
            this.tabPanel.UseVisualStyleBackColor = true;
            // 
            // panelFields
            // 
            this.panelFields.Controls.Add(this.panelTournament);
            this.panelFields.Controls.Add(this.panelPlayers);
            this.panelFields.Controls.Add(this.panel1);
            this.panelFields.Controls.Add(this.tabsFields);
            this.panelFields.Location = new System.Drawing.Point(0, 0);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(279, 236);
            this.panelFields.TabIndex = 0;
            // 
            // panelTournament
            // 
            this.panelTournament.ColumnCount = 3;
            this.panelTournament.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelTournament.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelTournament.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelTournament.Controls.Add(this.txtMatch, 2, 1);
            this.panelTournament.Controls.Add(this.txtEvent, 1, 1);
            this.panelTournament.Controls.Add(this.lblMatch, 2, 0);
            this.panelTournament.Controls.Add(this.lblEvent, 1, 0);
            this.panelTournament.Controls.Add(this.lblTournamentName, 0, 0);
            this.panelTournament.Controls.Add(this.txtTournamentName, 0, 1);
            this.panelTournament.Location = new System.Drawing.Point(0, 0);
            this.panelTournament.Margin = new System.Windows.Forms.Padding(0);
            this.panelTournament.Name = "panelTournament";
            this.panelTournament.RowCount = 2;
            this.panelTournament.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTournament.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelTournament.Size = new System.Drawing.Size(279, 28);
            this.panelTournament.TabIndex = 0;
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(189, 0);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(37, 13);
            this.lblMatch.TabIndex = 2;
            this.lblMatch.Text = "Match";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(96, 0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(35, 13);
            this.lblEvent.TabIndex = 1;
            this.lblEvent.Text = "Event";
            // 
            // lblTournamentName
            // 
            this.lblTournamentName.AutoSize = true;
            this.lblTournamentName.Location = new System.Drawing.Point(0, 0);
            this.lblTournamentName.Margin = new System.Windows.Forms.Padding(0);
            this.lblTournamentName.Name = "lblTournamentName";
            this.lblTournamentName.Size = new System.Drawing.Size(64, 13);
            this.lblTournamentName.TabIndex = 0;
            this.lblTournamentName.Text = "Tournament";
            // 
            // panelPlayers
            // 
            this.panelPlayers.Controls.Add(this.comboP1Char);
            this.panelPlayers.Controls.Add(this.txtP1Score);
            this.panelPlayers.Controls.Add(this.comboP2Char);
            this.panelPlayers.Controls.Add(this.comboP2Game);
            this.panelPlayers.Controls.Add(this.txtP2Score);
            this.panelPlayers.Controls.Add(this.txtP2Name);
            this.panelPlayers.Controls.Add(this.lblP2);
            this.panelPlayers.Controls.Add(this.comboP1Game);
            this.panelPlayers.Controls.Add(this.btnSwapNames);
            this.panelPlayers.Controls.Add(this.btnSwapChars);
            this.panelPlayers.Controls.Add(this.txtP1Name);
            this.panelPlayers.Controls.Add(this.lblP1);
            this.panelPlayers.Location = new System.Drawing.Point(0, 28);
            this.panelPlayers.Margin = new System.Windows.Forms.Padding(0);
            this.panelPlayers.Name = "panelPlayers";
            this.panelPlayers.Size = new System.Drawing.Size(279, 86);
            this.panelPlayers.TabIndex = 1;
            // 
            // comboP1Char
            // 
            this.comboP1Char.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboP1Char.FormattingEnabled = true;
            this.comboP1Char.Location = new System.Drawing.Point(137, 21);
            this.comboP1Char.Name = "comboP1Char";
            this.comboP1Char.Size = new System.Drawing.Size(93, 21);
            this.comboP1Char.TabIndex = 13;
            // 
            // comboP2Char
            // 
            this.comboP2Char.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboP2Char.FormattingEnabled = true;
            this.comboP2Char.Location = new System.Drawing.Point(137, 65);
            this.comboP2Char.Name = "comboP2Char";
            this.comboP2Char.Size = new System.Drawing.Size(93, 21);
            this.comboP2Char.TabIndex = 17;
            // 
            // comboP2Game
            // 
            this.comboP2Game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboP2Game.FormattingEnabled = true;
            this.comboP2Game.Items.AddRange(new object[] {
            "None",
            "Smash 64",
            "Melee",
            "Brawl",
            "Smash 4"});
            this.comboP2Game.Location = new System.Drawing.Point(47, 65);
            this.comboP2Game.Name = "comboP2Game";
            this.comboP2Game.Size = new System.Drawing.Size(84, 21);
            this.comboP2Game.TabIndex = 16;
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.Location = new System.Drawing.Point(0, 49);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(45, 13);
            this.lblP2.TabIndex = 14;
            this.lblP2.Text = "Player 2";
            // 
            // comboP1Game
            // 
            this.comboP1Game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboP1Game.FormattingEnabled = true;
            this.comboP1Game.Items.AddRange(new object[] {
            "None",
            "Smash 64",
            "Melee",
            "Brawl",
            "Smash 4"});
            this.comboP1Game.Location = new System.Drawing.Point(47, 21);
            this.comboP1Game.Name = "comboP1Game";
            this.comboP1Game.Size = new System.Drawing.Size(84, 21);
            this.comboP1Game.TabIndex = 12;
            // 
            // btnSwapNames
            // 
            this.btnSwapNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwapNames.AutoSize = true;
            this.btnSwapNames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwapNames.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSwapNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapNames.Image = global::AgnaPanel.Properties.Resources.swap_players;
            this.btnSwapNames.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSwapNames.Location = new System.Drawing.Point(235, 5);
            this.btnSwapNames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSwapNames.Name = "btnSwapNames";
            this.btnSwapNames.Size = new System.Drawing.Size(19, 81);
            this.btnSwapNames.TabIndex = 10;
            this.btnSwapNames.UseVisualStyleBackColor = true;
            // 
            // btnSwapChars
            // 
            this.btnSwapChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwapChars.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwapChars.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSwapChars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapChars.Image = global::AgnaPanel.Properties.Resources.swap_characters;
            this.btnSwapChars.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSwapChars.Location = new System.Drawing.Point(258, 5);
            this.btnSwapChars.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSwapChars.Name = "btnSwapChars";
            this.btnSwapChars.Size = new System.Drawing.Size(19, 81);
            this.btnSwapChars.TabIndex = 11;
            this.btnSwapChars.UseVisualStyleBackColor = true;
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Location = new System.Drawing.Point(0, 5);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(45, 13);
            this.lblP1.TabIndex = 2;
            this.lblP1.Text = "Player 1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 0);
            this.panel1.TabIndex = 2;
            // 
            // tabsFields
            // 
            this.tabsFields.Controls.Add(this.tabSpecial);
            this.tabsFields.Controls.Add(this.tabCommentary);
            this.tabsFields.Controls.Add(this.tabCustom);
            this.tabsFields.Location = new System.Drawing.Point(3, 117);
            this.tabsFields.Name = "tabsFields";
            this.tabsFields.SelectedIndex = 0;
            this.tabsFields.Size = new System.Drawing.Size(276, 115);
            this.tabsFields.TabIndex = 3;
            // 
            // tabSpecial
            // 
            this.tabSpecial.Controls.Add(this.txtAnnouncement);
            this.tabSpecial.Controls.Add(this.lblAnnouncement);
            this.tabSpecial.Controls.Add(this.txtMusic);
            this.tabSpecial.Controls.Add(this.lblMusic);
            this.tabSpecial.Controls.Add(this.pictureMusicNote);
            this.tabSpecial.Controls.Add(this.txtCamera2);
            this.tabSpecial.Controls.Add(this.lblCamera2);
            this.tabSpecial.Controls.Add(this.txtCamera1);
            this.tabSpecial.Controls.Add(this.btnSwapCameras);
            this.tabSpecial.Controls.Add(this.lblCamera1);
            this.tabSpecial.Location = new System.Drawing.Point(4, 22);
            this.tabSpecial.Name = "tabSpecial";
            this.tabSpecial.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpecial.Size = new System.Drawing.Size(268, 89);
            this.tabSpecial.TabIndex = 0;
            this.tabSpecial.Text = "Special";
            this.tabSpecial.UseVisualStyleBackColor = true;
            // 
            // lblMusic
            // 
            this.lblMusic.AutoSize = true;
            this.lblMusic.Location = new System.Drawing.Point(15, 61);
            this.lblMusic.Name = "lblMusic";
            this.lblMusic.Size = new System.Drawing.Size(35, 13);
            this.lblMusic.TabIndex = 8;
            this.lblMusic.Text = "Music";
            // 
            // pictureMusicNote
            // 
            this.pictureMusicNote.Image = global::AgnaPanel.Properties.Resources.music_note;
            this.pictureMusicNote.Location = new System.Drawing.Point(0, 74);
            this.pictureMusicNote.Name = "pictureMusicNote";
            this.pictureMusicNote.Size = new System.Drawing.Size(13, 13);
            this.pictureMusicNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureMusicNote.TabIndex = 7;
            this.pictureMusicNote.TabStop = false;
            // 
            // lblCamera2
            // 
            this.lblCamera2.AutoSize = true;
            this.lblCamera2.Location = new System.Drawing.Point(15, 32);
            this.lblCamera2.Name = "lblCamera2";
            this.lblCamera2.Size = new System.Drawing.Size(52, 13);
            this.lblCamera2.TabIndex = 5;
            this.lblCamera2.Text = "Camera 2";
            // 
            // btnSwapCameras
            // 
            this.btnSwapCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSwapCameras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwapCameras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapCameras.Image = global::AgnaPanel.Properties.Resources.swap_camera;
            this.btnSwapCameras.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSwapCameras.Location = new System.Drawing.Point(0, 16);
            this.btnSwapCameras.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.btnSwapCameras.Name = "btnSwapCameras";
            this.btnSwapCameras.Size = new System.Drawing.Size(14, 44);
            this.btnSwapCameras.TabIndex = 2;
            this.btnSwapCameras.UseVisualStyleBackColor = true;
            // 
            // lblCamera1
            // 
            this.lblCamera1.AutoSize = true;
            this.lblCamera1.Location = new System.Drawing.Point(15, 3);
            this.lblCamera1.Name = "lblCamera1";
            this.lblCamera1.Size = new System.Drawing.Size(52, 13);
            this.lblCamera1.TabIndex = 0;
            this.lblCamera1.Text = "Camera 1";
            // 
            // tabCommentary
            // 
            this.tabCommentary.Controls.Add(this.txtComm2Twitter);
            this.tabCommentary.Controls.Add(this.lblComm2Twitter);
            this.tabCommentary.Controls.Add(this.txtComm1Twitter);
            this.tabCommentary.Controls.Add(this.lblComm1Twitter);
            this.tabCommentary.Controls.Add(this.txtComm2);
            this.tabCommentary.Controls.Add(this.lblComm2);
            this.tabCommentary.Controls.Add(this.txtComm1);
            this.tabCommentary.Controls.Add(this.btnSwapComms);
            this.tabCommentary.Controls.Add(this.lblComm1);
            this.tabCommentary.Location = new System.Drawing.Point(4, 22);
            this.tabCommentary.Name = "tabCommentary";
            this.tabCommentary.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommentary.Size = new System.Drawing.Size(268, 89);
            this.tabCommentary.TabIndex = 1;
            this.tabCommentary.Text = "Commentators";
            this.tabCommentary.UseVisualStyleBackColor = true;
            // 
            // tabCustom
            // 
            this.tabCustom.Location = new System.Drawing.Point(4, 22);
            this.tabCustom.Name = "tabCustom";
            this.tabCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustom.Size = new System.Drawing.Size(268, 89);
            this.tabCustom.TabIndex = 2;
            this.tabCustom.Text = "Custom";
            this.tabCustom.UseVisualStyleBackColor = true;
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
            // lblAnnouncement
            // 
            this.lblAnnouncement.AutoSize = true;
            this.lblAnnouncement.Location = new System.Drawing.Point(103, 61);
            this.lblAnnouncement.Name = "lblAnnouncement";
            this.lblAnnouncement.Size = new System.Drawing.Size(79, 13);
            this.lblAnnouncement.TabIndex = 10;
            this.lblAnnouncement.Text = "Announcement";
            // 
            // lblComm2
            // 
            this.lblComm2.AutoSize = true;
            this.lblComm2.Location = new System.Drawing.Point(15, 32);
            this.lblComm2.Name = "lblComm2";
            this.lblComm2.Size = new System.Drawing.Size(78, 13);
            this.lblComm2.TabIndex = 10;
            this.lblComm2.Text = "Commentator 2";
            // 
            // btnSwapComms
            // 
            this.btnSwapComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSwapComms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwapComms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapComms.Image = global::AgnaPanel.Properties.Resources.swap_camera;
            this.btnSwapComms.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSwapComms.Location = new System.Drawing.Point(0, 16);
            this.btnSwapComms.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.btnSwapComms.Name = "btnSwapComms";
            this.btnSwapComms.Size = new System.Drawing.Size(14, 44);
            this.btnSwapComms.TabIndex = 8;
            this.btnSwapComms.UseVisualStyleBackColor = true;
            // 
            // lblComm1
            // 
            this.lblComm1.AutoSize = true;
            this.lblComm1.Location = new System.Drawing.Point(15, 3);
            this.lblComm1.Name = "lblComm1";
            this.lblComm1.Size = new System.Drawing.Size(78, 13);
            this.lblComm1.TabIndex = 7;
            this.lblComm1.Text = "Commentator 1";
            // 
            // lblComm2Twitter
            // 
            this.lblComm2Twitter.AutoSize = true;
            this.lblComm2Twitter.Location = new System.Drawing.Point(137, 32);
            this.lblComm2Twitter.Name = "lblComm2Twitter";
            this.lblComm2Twitter.Size = new System.Drawing.Size(76, 13);
            this.lblComm2Twitter.TabIndex = 14;
            this.lblComm2Twitter.Text = "Twitter Handle";
            // 
            // lblComm1Twitter
            // 
            this.lblComm1Twitter.AutoSize = true;
            this.lblComm1Twitter.Location = new System.Drawing.Point(137, 3);
            this.lblComm1Twitter.Name = "lblComm1Twitter";
            this.lblComm1Twitter.Size = new System.Drawing.Size(76, 13);
            this.lblComm1Twitter.TabIndex = 12;
            this.lblComm1Twitter.Text = "Twitter Handle";
            // 
            // txtMatch
            // 
            this.txtMatch.AcceptsReturn = false;
            this.txtMatch.AcceptsTab = false;
            this.txtMatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtMatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtMatch.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtMatch.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtMatch.Lines = new string[0];
            this.txtMatch.Location = new System.Drawing.Point(189, 13);
            this.txtMatch.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.txtMatch.MaxLength = 32767;
            this.txtMatch.Multiline = false;
            this.txtMatch.Name = "txtMatch";
            this.txtMatch.Size = new System.Drawing.Size(90, 20);
            this.txtMatch.TabIndex = 5;
            this.txtMatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtEvent
            // 
            this.txtEvent.AcceptsReturn = false;
            this.txtEvent.AcceptsTab = false;
            this.txtEvent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEvent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEvent.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtEvent.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtEvent.Lines = new string[0];
            this.txtEvent.Location = new System.Drawing.Point(96, 13);
            this.txtEvent.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.txtEvent.MaxLength = 32767;
            this.txtEvent.Multiline = false;
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(90, 20);
            this.txtEvent.TabIndex = 4;
            this.txtEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTournamentName
            // 
            this.txtTournamentName.AcceptsReturn = false;
            this.txtTournamentName.AcceptsTab = false;
            this.txtTournamentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTournamentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTournamentName.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtTournamentName.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtTournamentName.Lines = new string[0];
            this.txtTournamentName.Location = new System.Drawing.Point(3, 13);
            this.txtTournamentName.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.txtTournamentName.MaxLength = 32767;
            this.txtTournamentName.Multiline = false;
            this.txtTournamentName.Name = "txtTournamentName";
            this.txtTournamentName.Size = new System.Drawing.Size(90, 20);
            this.txtTournamentName.TabIndex = 3;
            this.txtTournamentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtP1Score
            // 
            this.txtP1Score.AcceptsReturn = false;
            this.txtP1Score.AcceptsTab = false;
            this.txtP1Score.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtP1Score.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtP1Score.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtP1Score.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtP1Score.Lines = new string[0];
            this.txtP1Score.Location = new System.Drawing.Point(202, 5);
            this.txtP1Score.MaxLength = 32767;
            this.txtP1Score.Multiline = false;
            this.txtP1Score.Name = "txtP1Score";
            this.txtP1Score.Size = new System.Drawing.Size(28, 20);
            this.txtP1Score.TabIndex = 16;
            this.txtP1Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtP2Score
            // 
            this.txtP2Score.AcceptsReturn = false;
            this.txtP2Score.AcceptsTab = false;
            this.txtP2Score.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtP2Score.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtP2Score.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtP2Score.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtP2Score.Lines = new string[0];
            this.txtP2Score.Location = new System.Drawing.Point(202, 49);
            this.txtP2Score.MaxLength = 32767;
            this.txtP2Score.Multiline = false;
            this.txtP2Score.Name = "txtP2Score";
            this.txtP2Score.Size = new System.Drawing.Size(28, 20);
            this.txtP2Score.TabIndex = 16;
            this.txtP2Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtP2Name
            // 
            this.txtP2Name.AcceptsReturn = false;
            this.txtP2Name.AcceptsTab = false;
            this.txtP2Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtP2Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtP2Name.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtP2Name.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtP2Name.Lines = new string[0];
            this.txtP2Name.Location = new System.Drawing.Point(47, 49);
            this.txtP2Name.MaxLength = 32767;
            this.txtP2Name.Multiline = false;
            this.txtP2Name.Name = "txtP2Name";
            this.txtP2Name.Size = new System.Drawing.Size(153, 20);
            this.txtP2Name.TabIndex = 15;
            this.txtP2Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtP1Name
            // 
            this.txtP1Name.AcceptsReturn = false;
            this.txtP1Name.AcceptsTab = false;
            this.txtP1Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtP1Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtP1Name.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtP1Name.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtP1Name.Lines = new string[0];
            this.txtP1Name.Location = new System.Drawing.Point(47, 5);
            this.txtP1Name.MaxLength = 32767;
            this.txtP1Name.Multiline = false;
            this.txtP1Name.Name = "txtP1Name";
            this.txtP1Name.Size = new System.Drawing.Size(153, 20);
            this.txtP1Name.TabIndex = 3;
            this.txtP1Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtAnnouncement
            // 
            this.txtAnnouncement.AcceptsReturn = false;
            this.txtAnnouncement.AcceptsTab = false;
            this.txtAnnouncement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtAnnouncement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtAnnouncement.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtAnnouncement.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtAnnouncement.Lines = new string[0];
            this.txtAnnouncement.Location = new System.Drawing.Point(106, 74);
            this.txtAnnouncement.MaxLength = 32767;
            this.txtAnnouncement.Multiline = false;
            this.txtAnnouncement.Name = "txtAnnouncement";
            this.txtAnnouncement.Size = new System.Drawing.Size(156, 20);
            this.txtAnnouncement.TabIndex = 11;
            this.txtAnnouncement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtMusic
            // 
            this.txtMusic.AcceptsReturn = false;
            this.txtMusic.AcceptsTab = false;
            this.txtMusic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtMusic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtMusic.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtMusic.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtMusic.Lines = new string[0];
            this.txtMusic.Location = new System.Drawing.Point(18, 74);
            this.txtMusic.MaxLength = 32767;
            this.txtMusic.Multiline = false;
            this.txtMusic.Name = "txtMusic";
            this.txtMusic.Size = new System.Drawing.Size(79, 20);
            this.txtMusic.TabIndex = 9;
            this.txtMusic.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtCamera2
            // 
            this.txtCamera2.AcceptsReturn = false;
            this.txtCamera2.AcceptsTab = false;
            this.txtCamera2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCamera2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCamera2.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtCamera2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtCamera2.Lines = new string[0];
            this.txtCamera2.Location = new System.Drawing.Point(18, 45);
            this.txtCamera2.MaxLength = 32767;
            this.txtCamera2.Multiline = false;
            this.txtCamera2.Name = "txtCamera2";
            this.txtCamera2.Size = new System.Drawing.Size(79, 20);
            this.txtCamera2.TabIndex = 6;
            this.txtCamera2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtCamera1
            // 
            this.txtCamera1.AcceptsReturn = false;
            this.txtCamera1.AcceptsTab = false;
            this.txtCamera1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCamera1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCamera1.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtCamera1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtCamera1.Lines = new string[0];
            this.txtCamera1.Location = new System.Drawing.Point(18, 16);
            this.txtCamera1.MaxLength = 32767;
            this.txtCamera1.Multiline = false;
            this.txtCamera1.Name = "txtCamera1";
            this.txtCamera1.Size = new System.Drawing.Size(79, 20);
            this.txtCamera1.TabIndex = 4;
            this.txtCamera1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtComm2Twitter
            // 
            this.txtComm2Twitter.AcceptsReturn = false;
            this.txtComm2Twitter.AcceptsTab = false;
            this.txtComm2Twitter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtComm2Twitter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtComm2Twitter.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtComm2Twitter.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtComm2Twitter.Lines = new string[0];
            this.txtComm2Twitter.Location = new System.Drawing.Point(140, 45);
            this.txtComm2Twitter.MaxLength = 32767;
            this.txtComm2Twitter.Multiline = false;
            this.txtComm2Twitter.Name = "txtComm2Twitter";
            this.txtComm2Twitter.Size = new System.Drawing.Size(113, 20);
            this.txtComm2Twitter.TabIndex = 15;
            this.txtComm2Twitter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtComm1Twitter
            // 
            this.txtComm1Twitter.AcceptsReturn = false;
            this.txtComm1Twitter.AcceptsTab = false;
            this.txtComm1Twitter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtComm1Twitter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtComm1Twitter.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtComm1Twitter.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtComm1Twitter.Lines = new string[0];
            this.txtComm1Twitter.Location = new System.Drawing.Point(140, 16);
            this.txtComm1Twitter.MaxLength = 32767;
            this.txtComm1Twitter.Multiline = false;
            this.txtComm1Twitter.Name = "txtComm1Twitter";
            this.txtComm1Twitter.Size = new System.Drawing.Size(113, 20);
            this.txtComm1Twitter.TabIndex = 13;
            this.txtComm1Twitter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtComm2
            // 
            this.txtComm2.AcceptsReturn = false;
            this.txtComm2.AcceptsTab = false;
            this.txtComm2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtComm2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtComm2.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtComm2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtComm2.Lines = new string[0];
            this.txtComm2.Location = new System.Drawing.Point(18, 45);
            this.txtComm2.MaxLength = 32767;
            this.txtComm2.Multiline = false;
            this.txtComm2.Name = "txtComm2";
            this.txtComm2.Size = new System.Drawing.Size(113, 20);
            this.txtComm2.TabIndex = 11;
            this.txtComm2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtComm1
            // 
            this.txtComm1.AcceptsReturn = false;
            this.txtComm1.AcceptsTab = false;
            this.txtComm1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtComm1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtComm1.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.txtComm1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.txtComm1.Lines = new string[0];
            this.txtComm1.Location = new System.Drawing.Point(18, 16);
            this.txtComm1.MaxLength = 32767;
            this.txtComm1.Multiline = false;
            this.txtComm1.Name = "txtComm1";
            this.txtComm1.Size = new System.Drawing.Size(113, 20);
            this.txtComm1.TabIndex = 9;
            this.txtComm1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.tabPanel.ResumeLayout(false);
            this.panelFields.ResumeLayout(false);
            this.panelTournament.ResumeLayout(false);
            this.panelTournament.PerformLayout();
            this.panelPlayers.ResumeLayout(false);
            this.panelPlayers.PerformLayout();
            this.tabsFields.ResumeLayout(false);
            this.tabSpecial.ResumeLayout(false);
            this.tabSpecial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMusicNote)).EndInit();
            this.tabCommentary.ResumeLayout(false);
            this.tabCommentary.PerformLayout();
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
        private FlowLayoutPanel panelFields;
        private TableLayoutPanel panelTournament;
        private Label lblMatch;
        private Label lblEvent;
        private Label lblTournamentName;
        private BorderedTextBox txtTournamentName;
        private BorderedTextBox txtMatch;
        private BorderedTextBox txtEvent;
        private Panel panelPlayers;
        private ComboBox comboP2Char;
        private ComboBox comboP2Game;
        private BorderedTextBox txtP2Score;
        private BorderedTextBox txtP2Name;
        private Label lblP2;
        private ComboBox comboP1Char;
        private ComboBox comboP1Game;
        internal Button btnSwapNames;
        internal Button btnSwapChars;
        private BorderedTextBox txtP1Name;
        private Label lblP1;
        private Panel panel1;
        private TabControl tabsFields;
        private TabPage tabSpecial;
        private TabPage tabCommentary;
        private TabPage tabCustom;
        internal Button btnSwapCameras;
        private Label lblCamera1;
        private BorderedTextBox txtCamera1;
        private BorderedTextBox txtCamera2;
        private Label lblCamera2;
        private BorderedTextBox txtMusic;
        private Label lblMusic;
        private PictureBox pictureMusicNote;
        private BorderedTextBox txtP1Score;
        private BorderedTextBox txtAnnouncement;
        private Label lblAnnouncement;
        private BorderedTextBox txtComm2;
        private Label lblComm2;
        private BorderedTextBox txtComm1;
        internal Button btnSwapComms;
        private Label lblComm1;
        private BorderedTextBox txtComm2Twitter;
        private Label lblComm2Twitter;
        private BorderedTextBox txtComm1Twitter;
        private Label lblComm1Twitter;
    }
}