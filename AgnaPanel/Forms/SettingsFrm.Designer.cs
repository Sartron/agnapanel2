namespace AgnaPanel.Forms
{
    partial class SettingsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsFrm));
            this.cbOnTop = new System.Windows.Forms.CheckBox();
            this.cbTray_close = new System.Windows.Forms.CheckBox();
            this.cbTray_minimize = new System.Windows.Forms.CheckBox();
            this.cbTaskbar = new System.Windows.Forms.CheckBox();
            this.cbTray = new System.Windows.Forms.CheckBox();
            this._lblTray1 = new System.Windows.Forms.Label();
            this._lblTray2 = new System.Windows.Forms.Label();
            this.txtMaxRecent = new System.Windows.Forms.TextBox();
            this.lblMaxRecent = new System.Windows.Forms.Label();
            this.rbNewFile = new System.Windows.Forms.RadioButton();
            this.rbMostRecent = new System.Windows.Forms.RadioButton();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.openImagesDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.cbAcceptCmds = new System.Windows.Forms.CheckBox();
            this.txtOAuthToken = new System.Windows.Forms.TextBox();
            this.lblOAuthToken = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tabBase = new System.Windows.Forms.TabControl();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.txtAddUser = new System.Windows.Forms.TextBox();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panelValidUsers = new System.Windows.Forms.Panel();
            this.listValidUsers = new System.Windows.Forms.ListBox();
            this.lblValidUsers = new System.Windows.Forms.Label();
            this.tabImages = new System.Windows.Forms.TabPage();
            this.tabAutocomplete = new System.Windows.Forms.TabPage();
            this.btnRemoveMatch = new System.Windows.Forms.Button();
            this.txtMatch = new System.Windows.Forms.TextBox();
            this.btnAddMatch = new System.Windows.Forms.Button();
            this.listMatch = new System.Windows.Forms.ListBox();
            this.lblMatches = new System.Windows.Forms.Label();
            this.btnRemovePlayerName = new System.Windows.Forms.Button();
            this.btnChallongeImport = new System.Windows.Forms.PictureBox();
            this.txtAddPlayer = new System.Windows.Forms.TextBox();
            this.btnAddPlayerName = new System.Windows.Forms.Button();
            this.listPlayerNames = new System.Windows.Forms.ListBox();
            this.lblPlayerNames = new System.Windows.Forms.Label();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.lblMiscGroup2 = new System.Windows.Forms.Label();
            this.lblMiscGroup1 = new System.Windows.Forms.Label();
            this.btnClearRecent = new System.Windows.Forms.Button();
            this.tabBase.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.panelValidUsers.SuspendLayout();
            this.tabAutocomplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChallongeImport)).BeginInit();
            this.tabMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbOnTop
            // 
            this.cbOnTop.AutoSize = true;
            this.cbOnTop.Location = new System.Drawing.Point(9, 17);
            this.cbOnTop.Margin = new System.Windows.Forms.Padding(1);
            this.cbOnTop.Name = "cbOnTop";
            this.cbOnTop.Size = new System.Drawing.Size(98, 17);
            this.cbOnTop.TabIndex = 0;
            this.cbOnTop.Text = "Always On Top";
            this.cbOnTop.UseVisualStyleBackColor = true;
            // 
            // cbTray_close
            // 
            this.cbTray_close.AutoSize = true;
            this.cbTray_close.Enabled = false;
            this.cbTray_close.Location = new System.Drawing.Point(28, 93);
            this.cbTray_close.Margin = new System.Windows.Forms.Padding(1);
            this.cbTray_close.Name = "cbTray_close";
            this.cbTray_close.Size = new System.Drawing.Size(88, 17);
            this.cbTray_close.TabIndex = 5;
            this.cbTray_close.Text = "Close to Tray";
            this.cbTray_close.UseVisualStyleBackColor = true;
            // 
            // cbTray_minimize
            // 
            this.cbTray_minimize.AutoSize = true;
            this.cbTray_minimize.Enabled = false;
            this.cbTray_minimize.Location = new System.Drawing.Point(28, 74);
            this.cbTray_minimize.Margin = new System.Windows.Forms.Padding(1);
            this.cbTray_minimize.Name = "cbTray_minimize";
            this.cbTray_minimize.Size = new System.Drawing.Size(102, 17);
            this.cbTray_minimize.TabIndex = 4;
            this.cbTray_minimize.Text = "Minimize to Tray";
            this.cbTray_minimize.UseVisualStyleBackColor = true;
            // 
            // cbTaskbar
            // 
            this.cbTaskbar.AutoSize = true;
            this.cbTaskbar.Checked = true;
            this.cbTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTaskbar.Enabled = false;
            this.cbTaskbar.Location = new System.Drawing.Point(9, 36);
            this.cbTaskbar.Margin = new System.Windows.Forms.Padding(1);
            this.cbTaskbar.Name = "cbTaskbar";
            this.cbTaskbar.Size = new System.Drawing.Size(106, 17);
            this.cbTaskbar.TabIndex = 2;
            this.cbTaskbar.Text = "Show in Taskbar";
            this.cbTaskbar.UseVisualStyleBackColor = true;
            // 
            // cbTray
            // 
            this.cbTray.AutoSize = true;
            this.cbTray.Location = new System.Drawing.Point(9, 55);
            this.cbTray.Margin = new System.Windows.Forms.Padding(1);
            this.cbTray.Name = "cbTray";
            this.cbTray.Size = new System.Drawing.Size(125, 17);
            this.cbTray.TabIndex = 3;
            this.cbTray.Text = "Show in System Tray";
            this.cbTray.UseVisualStyleBackColor = true;
            this.cbTray.CheckedChanged += new System.EventHandler(this.cbTray_CheckedChanged);
            // 
            // _lblTray1
            // 
            this._lblTray1.AutoSize = true;
            this._lblTray1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._lblTray1.Location = new System.Drawing.Point(10, 70);
            this._lblTray1.Name = "_lblTray1";
            this._lblTray1.Size = new System.Drawing.Size(22, 17);
            this._lblTray1.TabIndex = 7;
            this._lblTray1.Text = "∟";
            // 
            // _lblTray2
            // 
            this._lblTray2.AutoSize = true;
            this._lblTray2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._lblTray2.Location = new System.Drawing.Point(10, 89);
            this._lblTray2.Name = "_lblTray2";
            this._lblTray2.Size = new System.Drawing.Size(22, 17);
            this._lblTray2.TabIndex = 8;
            this._lblTray2.Text = "∟";
            // 
            // txtMaxRecent
            // 
            this.txtMaxRecent.Location = new System.Drawing.Point(157, 77);
            this.txtMaxRecent.MaxLength = 2;
            this.txtMaxRecent.Name = "txtMaxRecent";
            this.txtMaxRecent.Size = new System.Drawing.Size(83, 20);
            this.txtMaxRecent.TabIndex = 15;
            this.txtMaxRecent.Text = "10";
            this.txtMaxRecent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaxRecent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxRecent_KeyPress);
            // 
            // lblMaxRecent
            // 
            this.lblMaxRecent.AutoSize = true;
            this.lblMaxRecent.Location = new System.Drawing.Point(154, 61);
            this.lblMaxRecent.Name = "lblMaxRecent";
            this.lblMaxRecent.Size = new System.Drawing.Size(89, 13);
            this.lblMaxRecent.TabIndex = 16;
            this.lblMaxRecent.Text = "Max Recent Files";
            // 
            // rbNewFile
            // 
            this.rbNewFile.AutoSize = true;
            this.rbNewFile.Location = new System.Drawing.Point(157, 36);
            this.rbNewFile.Name = "rbNewFile";
            this.rbNewFile.Size = new System.Drawing.Size(66, 17);
            this.rbNewFile.TabIndex = 1;
            this.rbNewFile.Text = "New File";
            this.rbNewFile.UseVisualStyleBackColor = true;
            // 
            // rbMostRecent
            // 
            this.rbMostRecent.AutoSize = true;
            this.rbMostRecent.Checked = true;
            this.rbMostRecent.Location = new System.Drawing.Point(157, 19);
            this.rbMostRecent.Name = "rbMostRecent";
            this.rbMostRecent.Size = new System.Drawing.Size(86, 17);
            this.rbMostRecent.TabIndex = 0;
            this.rbMostRecent.TabStop = true;
            this.rbMostRecent.Text = "Most Recent";
            this.rbMostRecent.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(12, 232);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(301, 23);
            this.btnSaveSettings.TabIndex = 14;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(9, 97);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(100, 20);
            this.txtChannel.TabIndex = 6;
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(6, 81);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(46, 13);
            this.lblChannel.TabIndex = 5;
            this.lblChannel.Text = "Channel";
            // 
            // cbAcceptCmds
            // 
            this.cbAcceptCmds.AutoSize = true;
            this.cbAcceptCmds.Location = new System.Drawing.Point(189, 3);
            this.cbAcceptCmds.Name = "cbAcceptCmds";
            this.cbAcceptCmds.Size = new System.Drawing.Size(15, 14);
            this.cbAcceptCmds.TabIndex = 4;
            this.cbAcceptCmds.UseVisualStyleBackColor = true;
            // 
            // txtOAuthToken
            // 
            this.txtOAuthToken.Location = new System.Drawing.Point(9, 58);
            this.txtOAuthToken.Name = "txtOAuthToken";
            this.txtOAuthToken.Size = new System.Drawing.Size(100, 20);
            this.txtOAuthToken.TabIndex = 3;
            this.txtOAuthToken.UseSystemPasswordChar = true;
            // 
            // lblOAuthToken
            // 
            this.lblOAuthToken.AutoSize = true;
            this.lblOAuthToken.Location = new System.Drawing.Point(6, 42);
            this.lblOAuthToken.Name = "lblOAuthToken";
            this.lblOAuthToken.Size = new System.Drawing.Size(71, 13);
            this.lblOAuthToken.TabIndex = 2;
            this.lblOAuthToken.Text = "OAuth Token";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(9, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 3);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.tabChat);
            this.tabBase.Controls.Add(this.tabImages);
            this.tabBase.Controls.Add(this.tabAutocomplete);
            this.tabBase.Controls.Add(this.tabMisc);
            this.tabBase.Location = new System.Drawing.Point(12, 12);
            this.tabBase.Name = "tabBase";
            this.tabBase.SelectedIndex = 0;
            this.tabBase.Size = new System.Drawing.Size(301, 214);
            this.tabBase.TabIndex = 16;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.txtAddUser);
            this.tabChat.Controls.Add(this.btnRemoveUser);
            this.tabChat.Controls.Add(this.btnAddUser);
            this.tabChat.Controls.Add(this.panelValidUsers);
            this.tabChat.Controls.Add(this.lblValidUsers);
            this.tabChat.Controls.Add(this.txtChannel);
            this.tabChat.Controls.Add(this.lblChannel);
            this.tabChat.Controls.Add(this.cbAcceptCmds);
            this.tabChat.Controls.Add(this.txtOAuthToken);
            this.tabChat.Controls.Add(this.lblOAuthToken);
            this.tabChat.Controls.Add(this.txtUsername);
            this.tabChat.Controls.Add(this.lblUsername);
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(293, 188);
            this.tabChat.TabIndex = 1;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // txtAddUser
            // 
            this.txtAddUser.Location = new System.Drawing.Point(126, 97);
            this.txtAddUser.Name = "txtAddUser";
            this.txtAddUser.Size = new System.Drawing.Size(161, 20);
            this.txtAddUser.TabIndex = 12;
            this.txtAddUser.TextChanged += new System.EventHandler(this.txtAddUser_TextChanged);
            this.txtAddUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddUser_KeyPress);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Enabled = false;
            this.btnRemoveUser.Location = new System.Drawing.Point(230, 123);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(57, 23);
            this.btnRemoveUser.TabIndex = 11;
            this.btnRemoveUser.Text = "Remove";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Enabled = false;
            this.btnAddUser.Location = new System.Drawing.Point(126, 123);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(57, 23);
            this.btnAddUser.TabIndex = 10;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // panelValidUsers
            // 
            this.panelValidUsers.Controls.Add(this.listValidUsers);
            this.panelValidUsers.Location = new System.Drawing.Point(126, 19);
            this.panelValidUsers.Name = "panelValidUsers";
            this.panelValidUsers.Size = new System.Drawing.Size(161, 75);
            this.panelValidUsers.TabIndex = 9;
            // 
            // listValidUsers
            // 
            this.listValidUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listValidUsers.FormattingEnabled = true;
            this.listValidUsers.Location = new System.Drawing.Point(0, 0);
            this.listValidUsers.Name = "listValidUsers";
            this.listValidUsers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listValidUsers.Size = new System.Drawing.Size(161, 75);
            this.listValidUsers.TabIndex = 8;
            this.listValidUsers.SelectedIndexChanged += new System.EventHandler(this.listValidUsers_SelectedIndexChanged);
            this.listValidUsers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listValidUsers_MouseUp);
            // 
            // lblValidUsers
            // 
            this.lblValidUsers.AutoSize = true;
            this.lblValidUsers.Location = new System.Drawing.Point(123, 3);
            this.lblValidUsers.Name = "lblValidUsers";
            this.lblValidUsers.Size = new System.Drawing.Size(60, 13);
            this.lblValidUsers.TabIndex = 8;
            this.lblValidUsers.Text = "Valid Users";
            // 
            // tabImages
            // 
            this.tabImages.Location = new System.Drawing.Point(4, 22);
            this.tabImages.Name = "tabImages";
            this.tabImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabImages.Size = new System.Drawing.Size(293, 188);
            this.tabImages.TabIndex = 2;
            this.tabImages.Text = "Images";
            this.tabImages.UseVisualStyleBackColor = true;
            // 
            // tabAutocomplete
            // 
            this.tabAutocomplete.Controls.Add(this.btnRemoveMatch);
            this.tabAutocomplete.Controls.Add(this.txtMatch);
            this.tabAutocomplete.Controls.Add(this.btnAddMatch);
            this.tabAutocomplete.Controls.Add(this.listMatch);
            this.tabAutocomplete.Controls.Add(this.lblMatches);
            this.tabAutocomplete.Controls.Add(this.btnRemovePlayerName);
            this.tabAutocomplete.Controls.Add(this.btnChallongeImport);
            this.tabAutocomplete.Controls.Add(this.txtAddPlayer);
            this.tabAutocomplete.Controls.Add(this.btnAddPlayerName);
            this.tabAutocomplete.Controls.Add(this.listPlayerNames);
            this.tabAutocomplete.Controls.Add(this.lblPlayerNames);
            this.tabAutocomplete.Location = new System.Drawing.Point(4, 22);
            this.tabAutocomplete.Name = "tabAutocomplete";
            this.tabAutocomplete.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutocomplete.Size = new System.Drawing.Size(293, 188);
            this.tabAutocomplete.TabIndex = 4;
            this.tabAutocomplete.Text = "Autocomplete";
            this.tabAutocomplete.UseVisualStyleBackColor = true;
            // 
            // btnRemoveMatch
            // 
            this.btnRemoveMatch.Enabled = false;
            this.btnRemoveMatch.Location = new System.Drawing.Point(226, 159);
            this.btnRemoveMatch.Name = "btnRemoveMatch";
            this.btnRemoveMatch.Size = new System.Drawing.Size(61, 23);
            this.btnRemoveMatch.TabIndex = 10;
            this.btnRemoveMatch.Text = "Remove";
            this.btnRemoveMatch.UseVisualStyleBackColor = true;
            this.btnRemoveMatch.Click += new System.EventHandler(this.btnRemoveMatch_Click);
            // 
            // txtMatch
            // 
            this.txtMatch.Location = new System.Drawing.Point(158, 133);
            this.txtMatch.Name = "txtMatch";
            this.txtMatch.Size = new System.Drawing.Size(129, 20);
            this.txtMatch.TabIndex = 9;
            this.txtMatch.TextChanged += new System.EventHandler(this.txtMatch_TextChanged);
            this.txtMatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatch_KeyPress);
            // 
            // btnAddMatch
            // 
            this.btnAddMatch.Enabled = false;
            this.btnAddMatch.Location = new System.Drawing.Point(158, 159);
            this.btnAddMatch.Name = "btnAddMatch";
            this.btnAddMatch.Size = new System.Drawing.Size(62, 23);
            this.btnAddMatch.TabIndex = 8;
            this.btnAddMatch.Text = "Add";
            this.btnAddMatch.UseVisualStyleBackColor = true;
            this.btnAddMatch.Click += new System.EventHandler(this.btnAddMatch_Click);
            // 
            // listMatch
            // 
            this.listMatch.FormattingEnabled = true;
            this.listMatch.Location = new System.Drawing.Point(158, 19);
            this.listMatch.Name = "listMatch";
            this.listMatch.Size = new System.Drawing.Size(129, 108);
            this.listMatch.TabIndex = 7;
            this.listMatch.SelectedIndexChanged += new System.EventHandler(this.listMatch_SelectedIndexChanged);
            this.listMatch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listMatch_MouseUp);
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.Location = new System.Drawing.Point(155, 3);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(80, 13);
            this.lblMatches.TabIndex = 6;
            this.lblMatches.Text = "Match / Round";
            // 
            // btnRemovePlayerName
            // 
            this.btnRemovePlayerName.Enabled = false;
            this.btnRemovePlayerName.Location = new System.Drawing.Point(49, 159);
            this.btnRemovePlayerName.Name = "btnRemovePlayerName";
            this.btnRemovePlayerName.Size = new System.Drawing.Size(59, 23);
            this.btnRemovePlayerName.TabIndex = 5;
            this.btnRemovePlayerName.Text = "Remove";
            this.btnRemovePlayerName.UseVisualStyleBackColor = true;
            this.btnRemovePlayerName.Click += new System.EventHandler(this.btnRemovePlayerName_Click);
            // 
            // btnChallongeImport
            // 
            this.btnChallongeImport.Enabled = false;
            this.btnChallongeImport.Image = ((System.Drawing.Image)(resources.GetObject("btnChallongeImport.Image")));
            this.btnChallongeImport.Location = new System.Drawing.Point(114, 158);
            this.btnChallongeImport.Name = "btnChallongeImport";
            this.btnChallongeImport.Size = new System.Drawing.Size(24, 24);
            this.btnChallongeImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnChallongeImport.TabIndex = 4;
            this.btnChallongeImport.TabStop = false;
            this.btnChallongeImport.Click += new System.EventHandler(this.btnChallongeImport_Click);
            // 
            // txtAddPlayer
            // 
            this.txtAddPlayer.Location = new System.Drawing.Point(9, 133);
            this.txtAddPlayer.Name = "txtAddPlayer";
            this.txtAddPlayer.Size = new System.Drawing.Size(129, 20);
            this.txtAddPlayer.TabIndex = 3;
            this.txtAddPlayer.TextChanged += new System.EventHandler(this.txtAddPlayer_TextChanged);
            this.txtAddPlayer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddPlayer_KeyPress);
            // 
            // btnAddPlayerName
            // 
            this.btnAddPlayerName.Enabled = false;
            this.btnAddPlayerName.Location = new System.Drawing.Point(9, 159);
            this.btnAddPlayerName.Name = "btnAddPlayerName";
            this.btnAddPlayerName.Size = new System.Drawing.Size(34, 23);
            this.btnAddPlayerName.TabIndex = 2;
            this.btnAddPlayerName.Text = "Add";
            this.btnAddPlayerName.UseVisualStyleBackColor = true;
            this.btnAddPlayerName.Click += new System.EventHandler(this.btnAddPlayerName_Click);
            // 
            // listPlayerNames
            // 
            this.listPlayerNames.FormattingEnabled = true;
            this.listPlayerNames.Location = new System.Drawing.Point(9, 19);
            this.listPlayerNames.Name = "listPlayerNames";
            this.listPlayerNames.Size = new System.Drawing.Size(129, 108);
            this.listPlayerNames.TabIndex = 1;
            this.listPlayerNames.SelectedIndexChanged += new System.EventHandler(this.listPlayerNames_SelectedIndexChanged);
            this.listPlayerNames.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listPlayerNames_MouseUp);
            // 
            // lblPlayerNames
            // 
            this.lblPlayerNames.AutoSize = true;
            this.lblPlayerNames.Location = new System.Drawing.Point(6, 3);
            this.lblPlayerNames.Name = "lblPlayerNames";
            this.lblPlayerNames.Size = new System.Drawing.Size(72, 13);
            this.lblPlayerNames.TabIndex = 0;
            this.lblPlayerNames.Text = "Player Names";
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.btnClearRecent);
            this.tabMisc.Controls.Add(this.lblMiscGroup2);
            this.tabMisc.Controls.Add(this.lblMiscGroup1);
            this.tabMisc.Controls.Add(this.cbOnTop);
            this.tabMisc.Controls.Add(this.cbTray_close);
            this.tabMisc.Controls.Add(this.cbTray_minimize);
            this.tabMisc.Controls.Add(this.cbTaskbar);
            this.tabMisc.Controls.Add(this.cbTray);
            this.tabMisc.Controls.Add(this._lblTray1);
            this.tabMisc.Controls.Add(this._lblTray2);
            this.tabMisc.Controls.Add(this.txtMaxRecent);
            this.tabMisc.Controls.Add(this.lblMaxRecent);
            this.tabMisc.Controls.Add(this.rbNewFile);
            this.tabMisc.Controls.Add(this.rbMostRecent);
            this.tabMisc.Location = new System.Drawing.Point(4, 22);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabMisc.Size = new System.Drawing.Size(293, 188);
            this.tabMisc.TabIndex = 3;
            this.tabMisc.Text = "Miscellaneous";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // lblMiscGroup2
            // 
            this.lblMiscGroup2.AutoSize = true;
            this.lblMiscGroup2.Location = new System.Drawing.Point(154, 3);
            this.lblMiscGroup2.Name = "lblMiscGroup2";
            this.lblMiscGroup2.Size = new System.Drawing.Size(86, 13);
            this.lblMiscGroup2.TabIndex = 14;
            this.lblMiscGroup2.Text = "Startup Behavior";
            // 
            // lblMiscGroup1
            // 
            this.lblMiscGroup1.AutoSize = true;
            this.lblMiscGroup1.Location = new System.Drawing.Point(6, 3);
            this.lblMiscGroup1.Name = "lblMiscGroup1";
            this.lblMiscGroup1.Size = new System.Drawing.Size(85, 13);
            this.lblMiscGroup1.TabIndex = 13;
            this.lblMiscGroup1.Text = "Program Visibility";
            // 
            // btnClearRecent
            // 
            this.btnClearRecent.Location = new System.Drawing.Point(157, 103);
            this.btnClearRecent.Name = "btnClearRecent";
            this.btnClearRecent.Size = new System.Drawing.Size(83, 23);
            this.btnClearRecent.TabIndex = 17;
            this.btnClearRecent.Text = "Clear All";
            this.btnClearRecent.UseVisualStyleBackColor = true;
            this.btnClearRecent.Click += new System.EventHandler(this.btnClearRecent_Click);
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 267);
            this.Controls.Add(this.tabBase);
            this.Controls.Add(this.btnSaveSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::AgnaPanel.Properties.Resources.agna_wing;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.tabBase.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabChat.PerformLayout();
            this.panelValidUsers.ResumeLayout(false);
            this.tabAutocomplete.ResumeLayout(false);
            this.tabAutocomplete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChallongeImport)).EndInit();
            this.tabMisc.ResumeLayout(false);
            this.tabMisc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.CheckBox cbOnTop;
        internal System.Windows.Forms.CheckBox cbTray_close;
        internal System.Windows.Forms.CheckBox cbTray_minimize;
        internal System.Windows.Forms.CheckBox cbTaskbar;
        internal System.Windows.Forms.CheckBox cbTray;
        internal System.Windows.Forms.Label _lblTray1;
        internal System.Windows.Forms.Label _lblTray2;
        internal System.Windows.Forms.RadioButton rbNewFile;
        internal System.Windows.Forms.RadioButton rbMostRecent;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.FolderBrowserDialog openImagesDialog;
        private System.Windows.Forms.TextBox txtMaxRecent;
        private System.Windows.Forms.Label lblMaxRecent;
        private System.Windows.Forms.CheckBox cbAcceptCmds;
        private System.Windows.Forms.TextBox txtOAuthToken;
        private System.Windows.Forms.Label lblOAuthToken;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.TabControl tabBase;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.TabPage tabImages;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.Label lblValidUsers;
        private System.Windows.Forms.Panel panelValidUsers;
        private System.Windows.Forms.ListBox listValidUsers;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtAddUser;
        private System.Windows.Forms.Label lblMiscGroup1;
        private System.Windows.Forms.Label lblMiscGroup2;
        private System.Windows.Forms.TabPage tabAutocomplete;
        private System.Windows.Forms.Label lblPlayerNames;
        private System.Windows.Forms.TextBox txtAddPlayer;
        private System.Windows.Forms.Button btnAddPlayerName;
        private System.Windows.Forms.ListBox listPlayerNames;
        private System.Windows.Forms.PictureBox btnChallongeImport;
        private System.Windows.Forms.Button btnRemovePlayerName;
        private System.Windows.Forms.Button btnRemoveMatch;
        private System.Windows.Forms.TextBox txtMatch;
        private System.Windows.Forms.Button btnAddMatch;
        private System.Windows.Forms.ListBox listMatch;
        private System.Windows.Forms.Label lblMatches;
        private System.Windows.Forms.Button btnClearRecent;
    }
}