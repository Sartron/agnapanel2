using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using AgnaPanel.Controls;
using System.Collections.Generic;
using System.IO;
using AgnaPanel.Properties;

namespace AgnaPanel.Forms
{
    public partial class SettingsFrm : Form
    {
        public bool clickedSave = false;

        /// <summary>
        /// Save all settings processed through form open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //Clear pre-existing AgnaImageCategory(s)
            Settings.Images.Categories.Clear();

            //Creates a deep copy of each new Settings.AgnaImageCategory
            foreach (Settings.AgnaImageCategory category in tempCategories)
                Settings.Images.Categories.Add(category.Clone()); 

            Settings.Save();
            clickedSave = true;
            Close();
        }

        #region Form
        public SettingsFrm()
        {
            InitializeComponent();

            //Transparent imageViewer ToolStrip
            imageTools.Renderer = new WindowToolStripRenderer();

            //Icons for imageViewer
            ImageList imageViewIcons = new ImageList();
            imageViewIcons.Images.Add(Resources.folder);
            imageViewIcons.Images.Add(Resources.image);
            imageViewIcons.Images.Add(Resources.image_error);
            imageViewer.LargeImageList = imageViewIcons;
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
            if (Settings.RecentFiles.Load)
                rbMostRecent.Checked = true;
            else
                rbNewFile.Checked = true;
            txtMaxRecent.Text = Settings.RecentFiles.MaxFiles.ToString();

            //Autocomplete
            foreach (string name in Settings.AutoComplete.Names)
                listPlayerNames.Items.Add(name);
            foreach (string match in Settings.AutoComplete.Rounds)
                listMatch.Items.Add(match);

            //Images
            tempCategories = new List<Settings.AgnaImageCategory>();
            foreach (Settings.AgnaImageCategory category in Settings.Images.Categories)
                tempCategories.Add(category.Clone()); //Creates a deep copy of each Settings.AgnaImageCategory

            //Creates only a shallow copy
            //tempCategories = new List<Settings.AgnaImageCategory>(Settings.Images.Categories);
            foreach (Settings.AgnaImageCategory category in tempCategories)
                imageViewer.Items.Add(category.Name, 0);
        }

        #endregion
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
        #region Images
        private List<Settings.AgnaImageCategory> tempCategories;
        private int selectedCategoryIndex = -1;

        private void imageViewer_DragEnter(object sender, DragEventArgs e)
        {
            if (selectedCategoryIndex != -1 && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void imageViewer_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Cursor.Current = Cursors.WaitCursor;
            foreach (string file in files)
            {
                if (File.GetAttributes(file).HasFlag(FileAttributes.Directory)) //Is Directory
                {
                    foreach (string _file in Directory.GetFiles(file))
                    {
                        tempCategories[selectedCategoryIndex].AddAgnaImage(_file);
                        imageViewer.Items.Add(tempCategories[selectedCategoryIndex].Images.Last().Name, 1);
                    }

                    continue;
                }

                tempCategories[selectedCategoryIndex].AddAgnaImage(file);
                imageViewer.Items.Add(tempCategories[selectedCategoryIndex].Images.Last().Name, 1);
            }

            Cursor.Current = Cursors.Default;
        }

        private void imageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (imageViewer.FocusedItem.Bounds.Contains(e.Location))
                    menuImageItem.Show(Cursor.Position);
            }
        }

        private void imageViewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //If not root
            if (selectedCategoryIndex != -1)
                return;

            selectedCategoryIndex = imageViewer.FocusedItem.Index;

            Settings.AgnaImageCategory selectedCategory = tempCategories[selectedCategoryIndex];
            imageViewer.Items.Clear();
            foreach (Settings.AgnaImage image in selectedCategory.Images)
            {
                if (File.Exists(image.Path))
                    imageViewer.Items.Add(!String.IsNullOrWhiteSpace(image.Name) ? image.Name : Path.GetFileName(image.Path), 1);
                else
                    imageViewer.Items.Add(!String.IsNullOrWhiteSpace(image.Name) ? image.Name : Path.GetFileName(image.Path), 2);
            }

            btnRoot.Enabled = true;
            btnAddCategory.Enabled = false;
            btnDeleteItem.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            selectedCategoryIndex = -1;

            imageViewer.Items.Clear();
            foreach (Settings.AgnaImageCategory category in tempCategories)
                imageViewer.Items.Add(category.Name, 0);

            btnRoot.Enabled = false;
            btnAddCategory.Enabled = true;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            tempCategories.Add(new Settings.AgnaImageCategory($"new{imageViewer.Items.Count + 1}"));
            imageViewer.Items.Add($"new{imageViewer.Items.Count + 1}", 0);
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (selectedCategoryIndex == -1)
                tempCategories.RemoveAt(imageViewer.FocusedItem.Index);
            else
                tempCategories[selectedCategoryIndex].RemoveAgnaImage(imageViewer.FocusedItem.Index);
                
            imageViewer.Items.Remove(imageViewer.FocusedItem);
            btnDeleteItem.Enabled = false;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDeleteItem_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SettingsFrm_Edit editFrm;
            if (selectedCategoryIndex == -1)
                editFrm = new SettingsFrm_Edit(tempCategories[imageViewer.FocusedItem.Index]);
            else
                editFrm = new SettingsFrm_Edit(imageViewer.FocusedItem.Index, tempCategories[selectedCategoryIndex]);
            editFrm.ShowDialog();

            //User actually pressed the save button
            if (editFrm.Saved)
            {
                if (selectedCategoryIndex == -1)
                {
                    //Replace existing category
                    tempCategories[imageViewer.FocusedItem.Index] = editFrm.selectedCategory.Clone();
                    if (imageViewer.FocusedItem.Text != tempCategories[imageViewer.FocusedItem.Index].Name)
                        imageViewer.FocusedItem.Text = tempCategories[imageViewer.FocusedItem.Index].Name;
                }
                else
                {
                    //Replace existing image
                    tempCategories[selectedCategoryIndex].ReplaceAgnaImage(editFrm.selectedImage.Clone(), imageViewer.FocusedItem.Index);
                    if (imageViewer.FocusedItem.Text != tempCategories[selectedCategoryIndex].Images[imageViewer.FocusedItem.Index].Name)
                        imageViewer.FocusedItem.Text = tempCategories[selectedCategoryIndex].Images[imageViewer.FocusedItem.Index].Name;
                }
            }
        }

        private void imageViewer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null) //No changes made
                return;

            if (selectedCategoryIndex == -1) //Editing a category
            {
                if (String.IsNullOrWhiteSpace(e.Label))
                    e.CancelEdit = true;
                else
                    tempCategories[e.Item].Name = e.Label;
            }
            else //Editing an image
            {
                Settings.AgnaImage newName = tempCategories[selectedCategoryIndex].Images[e.Item].Clone();
                newName.Name = e.Label;
                tempCategories[selectedCategoryIndex].ReplaceAgnaImage(newName, e.Item);

                e.CancelEdit = true;
                imageViewer.FocusedItem.Text = tempCategories[selectedCategoryIndex].Images[e.Item].Name;
            }
        }

        private void imageViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteItem.Enabled = imageViewer.SelectedIndices.Count > 0;
            btnEdit.Enabled = imageViewer.SelectedIndices.Count > 0;
        }

        private void imageViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && imageViewer.FocusedItem != null)
                btnEdit_Click(sender, e);
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