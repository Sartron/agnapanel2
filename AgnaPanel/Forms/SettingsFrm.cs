using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace AgnaPanel.Forms
{
    public partial class SettingsFrm : Form
    {
        public SettingsFrm()
        {
            InitializeComponent();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            //Debug
            btnChallongeImport.Enabled = false;
            btnChallongeImport.Visible = false;

            //Window settings
            cbOnTop.Checked = Settings.Window.onTop;
            //cbTaskbar.Checked = Settings.Window.taskbar;
            cbTray.Checked = Settings.Window.Tray.Enabled;
            cbTray_minimize.Checked = Settings.Window.Tray.Minimize;
            cbTray_close.Checked = Settings.Window.Tray.Close;

            //Chat
            txtUsername.Text = Settings.Chat.Username;
            txtOAuthToken.Text = Settings.Chat.oAuth;
            txtChannel.Text = Settings.Chat.Channel;
            foreach (string user in Settings.Chat.ValidUsers)
                listValidUsers.Items.Add(user);
            cbAcceptCmds.Checked = Settings.Chat.acceptCommands;

            //Recent File settings
            rbMostRecent.Checked = Settings.RecentFiles.Load ? true : false;
            txtMaxRecent.Text = Settings.RecentFiles.MaxFiles.ToString();

            //Autocomplete
            foreach (string name in Settings.AutoComplete.Names)
                listPlayerNames.Items.Add(name);
            foreach (string match in Settings.AutoComplete.Rounds)
                listMatch.Items.Add(match);

            //Images
            //txtImagePath.Text = Settings.Images.Root;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            //Window Settings
            Settings.Window.onTop = cbOnTop.Checked;
            Settings.Window.Tray.Enabled = cbTray.Checked;
            Settings.Window.Tray.Minimize = cbTray_minimize.Checked;
            Settings.Window.Tray.Close = cbTray_close.Checked;

            //Chat
            Settings.Chat.Username = txtUsername.Text;
            Settings.Chat.oAuth = txtOAuthToken.Text;
            Settings.Chat.Channel = txtChannel.Text;
            Settings.Chat.acceptCommands = cbAcceptCmds.Checked;
            Settings.Chat.ValidUsers = listValidUsers.Items.OfType<String>().ToList();

            //Recent File Settings
            Settings.RecentFiles.Load = rbMostRecent.Checked ? true : false;
            Settings.RecentFiles.MaxFiles = Convert.ToInt16(txtMaxRecent.Text);
            if (!btnClearRecent.Enabled)
                Settings.RecentFiles.Files.Clear();

            //Autocomplete
            Settings.AutoComplete.Names = listPlayerNames.Items.OfType<String>().ToList();
            Settings.AutoComplete.Rounds = listMatch.Items.OfType<String>().ToList();

            //Images
            //Settings.Images.Root = txtImagePath.Text;

            Settings.Save();
            Close();
        }

        #region Chat
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (ListBox.NoMatches == listValidUsers.FindStringExact(txtAddUser.Text))
                listValidUsers.Items.Add(txtAddUser.Text);

            txtAddUser.Text = String.Empty;
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            for (int i = listValidUsers.SelectedIndices.Count - 1; i >= 0; i--)
                listValidUsers.Items.RemoveAt(listValidUsers.SelectedIndices[i]);

            if (listValidUsers.Items.Count == 0)
                btnRemoveUser.Enabled = false;

            if (!btnAddUser.Enabled)
                btnAddUser.Enabled = true;
        }

        private void txtAddUser_TextChanged(object sender, EventArgs e)
        {
            btnAddUser.Enabled = !String.IsNullOrWhiteSpace(txtAddUser.Text) && ListBox.NoMatches == listValidUsers.FindStringExact(txtAddUser.Text);
        }

        private void txtAddUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter && !String.IsNullOrWhiteSpace(txtAddUser.Text))
            {
                if (ListBox.NoMatches == listValidUsers.FindStringExact(txtAddUser.Text))
                    listValidUsers.Items.Add(txtAddUser.Text);

                txtAddUser.Text = String.Empty;
            }
        }

        private void listValidUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveUser.Enabled = listValidUsers.SelectedIndices.Count > 0;
        }

        private void listValidUsers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                listValidUsers.SelectedIndex = -1;
        }
        #endregion
        #region Autocomplete
        private void listPlayerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemovePlayerName.Enabled = listPlayerNames.SelectedIndices.Count > 0;
        }

        private void listMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveMatch.Enabled = listMatch.SelectedIndices.Count > 0;
        }

        private void txtAddPlayer_TextChanged(object sender, EventArgs e)
        {
            btnAddPlayerName.Enabled = !String.IsNullOrWhiteSpace(txtAddPlayer.Text) && ListBox.NoMatches == listPlayerNames.FindStringExact(txtAddPlayer.Text);
        }

        private void txtMatch_TextChanged(object sender, EventArgs e)
        {
            btnAddMatch.Enabled = !String.IsNullOrWhiteSpace(txtMatch.Text) && ListBox.NoMatches == listMatch.FindStringExact(txtMatch.Text);
        }

        private void listPlayerNames_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                listPlayerNames.SelectedIndex = -1;
        }

        private void listMatch_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                listMatch.SelectedIndex = -1;
        }

        private void btnAddPlayerName_Click(object sender, EventArgs e)
        {
            listPlayerNames.Items.Add(txtAddPlayer.Text);
            txtAddPlayer.Text = String.Empty;
        }

        private void btnRemovePlayerName_Click(object sender, EventArgs e)
        {
            for (int i = listPlayerNames.SelectedIndices.Count - 1; i >= 0; i--)
                listPlayerNames.Items.RemoveAt(listPlayerNames.SelectedIndices[i]);

            if (listPlayerNames.Items.Count == 0)
                btnRemovePlayerName.Enabled = false;

            if (!btnAddPlayerName.Enabled)
                btnAddPlayerName.Enabled = true;
        }

        private void btnChallongeImport_Click(object sender, EventArgs e)
        {
            string username = "sartron";
            string apiKey = "UYfqEJRqQTXB1aVAs6XUQ63bxxsPVKv5rxJrWv0n";

            Debug.WriteLine(Net.GetHTML($"https://{username}:{apiKey}@api.challonge.com/v1/tournaments/slamfest_pm_copy/participants.xml"));
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            listMatch.Items.Add(txtMatch.Text);
            txtMatch.Text = String.Empty;
        }

        private void btnRemoveMatch_Click(object sender, EventArgs e)
        {
            for (int i = listMatch.SelectedIndices.Count - 1; i >= 0; i--)
                listMatch.Items.RemoveAt(listMatch.SelectedIndices[i]);

            if (listMatch.Items.Count == 0)
                btnRemoveMatch.Enabled = false;

            if (!btnAddMatch.Enabled)
                btnAddMatch.Enabled = true;
        }

        private void txtAddPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter && !String.IsNullOrWhiteSpace(txtAddPlayer.Text))
            {
                if (ListBox.NoMatches == listPlayerNames.FindStringExact(txtAddPlayer.Text))
                    listPlayerNames.Items.Add(txtAddPlayer.Text);

                txtAddPlayer.Text = String.Empty;
            }
        }

        private void txtMatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter && !String.IsNullOrWhiteSpace(txtMatch.Text))
            {
                if (ListBox.NoMatches == listMatch.FindStringExact(txtMatch.Text))
                    listMatch.Items.Add(txtMatch.Text);

                txtMatch.Text = String.Empty;
            }
        }
        #endregion
        #region Miscellaneous
        private void cbTray_CheckedChanged(object sender, EventArgs e)
        {
            cbTray_minimize.Enabled = !cbTray_minimize.Enabled;
            cbTray_close.Enabled = !cbTray_close.Enabled;
        }

        private void txtMaxRecent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnClearRecent_Click(object sender, EventArgs e)
        {
            btnClearRecent.Enabled = false;
        }
        #endregion
    }
}