using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using AgnaPanel.Chat;
using AgnaPanel.Forms;

//Project began 7/12/2016
//Based off of AgnaPanel 1.6.3.0

namespace AgnaPanel
{
    public partial class MainFrm : Form
    {
        private Size compactSize = new Size(299, 325);
        private Size expandedSize = new Size(515, 325);
        /// <summary>
        /// Currently active AgnaScene file
        /// </summary>
        private AgnaScene activeScene;
        /// <summary>
        /// List of uncategorized AgnaImages caught by loadAgnaScene()
        /// </summary>
        private List<AgnaImage> uncategorizedAgnaImages = new List<AgnaImage>();
        /*************
        Form Size: 515, 325
        tabsBase
         - Location: 0, 25
         - Size: 501, 262
        ************/

        #region Form Methods
        public MainFrm()
        {
            InitializeComponent();

            //Check settings
            Settings.Open();

            //Update Check
            Updater.UpdateStatus status = Updater.Status;
            if (status == Updater.UpdateStatus.UP_TO_DATE)
                Text += " 2.0";
            else if (status == Updater.UpdateStatus.DEV_BUILD)
                Text += " - Developer's Build";
            else if (status == Updater.UpdateStatus.ERROR)
                Text += " - Error";
            else
                Text += " - Update Available!";
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            //Load settings
            loadSettings();
            
            //Load most recent file
            if (Settings.RecentFiles.Load && Settings.RecentFiles.MaxFiles > 0 && Settings.RecentFiles.Files.Count > 0 && File.Exists(Settings.RecentFiles.Files[0]) && openAgnaScene(Settings.RecentFiles.Files[0]))
            {
                loadAgnaScene();
                tabPanel.Text = !String.IsNullOrWhiteSpace(activeScene.Name.Value) ? activeScene.Name.Value : $"Panel - {Path.GetFileName(activeScene.FilePath)}";
                reloadToolStripMenuItem.Enabled = true;
            }
            else
            {
                //Default, no recent file
                activeScene = new AgnaScene();
                loadAgnaScene();
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Window.Tray.Enabled && Settings.Window.Tray.Close)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (Settings.Window.Tray.Enabled && Settings.Window.Tray.Minimize)
                Visible = false;
        }

        private void MainFrm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((string[])e.Data.GetData(DataFormats.FileDrop)).Length == 1)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainFrm_DragDrop(object sender, DragEventArgs e)
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            if (!File.GetAttributes(file).HasFlag(FileAttributes.Directory) && openAgnaScene(file))
            {
                loadAgnaScene();
                tabPanel.Text = !String.IsNullOrWhiteSpace(activeScene.Name.Value) ? activeScene.Name.Value : $"Panel - {Path.GetFileName(activeScene.FilePath)}";
                reloadToolStripMenuItem.Enabled = true;

                AddRecentFileMenuItem(activeScene.FilePath);
            }
        }
        #endregion
        #region Load Methods
        /// <summary>
        /// Load settings from settings.xml
        /// </summary>
        private void loadSettings()
        {
            //Window settings
            TopMost = Settings.Window.onTop;
            //ShowInTaskbar = Settings.Window.taskbar;
            if (Settings.Window.Tray.Enabled)
                trayIcon.Visible = true;

            //Recent files
            openRecentToolStripMenuItem.DropDownItems.Clear();
            if (Settings.RecentFiles.MaxFiles > 0 && Settings.RecentFiles.Files.Count > 0)
            {
                foreach (string file in Settings.RecentFiles.Files)
                {
                    ToolStripMenuItem newRecentFile = new ToolStripMenuItem()
                    {
                        Name = $"recentFileEntry",
                        Text = file
                    };
                    newRecentFile.Click += new EventHandler(RecentFileToolStripMenuItem_Click);

                    openRecentToolStripMenuItem.DropDownItems.Add(newRecentFile);
                }
            }

            //Load Autocomplete entries
            AutoCompleteStringCollection roundSource = new AutoCompleteStringCollection();
            roundSource.AddRange(Settings.AutoComplete.Rounds.ToArray());
            txtMatch.AutoCompleteCustomSource = roundSource;

            AutoCompleteStringCollection nameSource = new AutoCompleteStringCollection();
            nameSource.AddRange(Settings.AutoComplete.Names.ToArray());
            txtP1Name.AutoCompleteCustomSource = nameSource;
            txtP2Name.AutoCompleteCustomSource = nameSource;

            //Images
            comboP1Category.Items.Clear();
            comboP2Category.Items.Clear();
            comboP1Category.Items.Add("None");
            comboP2Category.Items.Add("None");
            comboP1Category.SelectedIndex = 0;
            comboP2Category.SelectedIndex = 0;
            foreach (Settings.AgnaImageCategory category in Settings.Images.Categories)
            {
                comboP1Category.Items.Add(category.Name);
                comboP2Category.Items.Add(category.Name);
            }
        }

        /// <summary>
        /// Attempt to open AgnaScene, returns success/failure
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool openAgnaScene(string filePath)
        {
            Cursor.Current = Cursors.WaitCursor;
            AgnaScene newScene = new AgnaScene(filePath);

            if (newScene.Valid)
                activeScene = newScene;
            else
            { /*MessageBox.Show("Invalid AgnaScene!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);*/ }

            Cursor.Current = Cursors.Default;
            return newScene.Valid;
        }

        /// <summary>
        /// Load AgnaScene inputs into form
        /// </summary>
        private void loadAgnaScene()
        {
            foreach (AgnaField field in activeScene.Fields)
            {
                if (field.Type == AgnaField.FieldType.Main)
                {
                    switch (field.Name)
                    {
                        case "to": //Tournament Name
                            txtTournamentName.Text = field.Value;
                            txtTournamentName.FocusedBorderColor = field.Color;
                            break;
                        case "ev": //Event
                            txtEvent.Text = field.Value;
                            txtEvent.FocusedBorderColor = field.Color;
                            break;
                        case "ma": //Match / Round
                            txtMatch.Text = field.Value;
                            txtMatch.FocusedBorderColor = field.Color;
                            break;
                        case "an": //Announcement
                            txtAnnouncement.Text = field.Value;
                            txtAnnouncement.FocusedBorderColor = field.Color;
                            break;
                        case "mu": //Music
                            txtMusic.Text = field.Value;
                            txtMusic.FocusedBorderColor = field.Color;
                            break;
                        case "p1": //Player 1 Name
                            txtP1Name.Text = field.Value;
                            txtP1Name.FocusedBorderColor = field.Color;
                            break;
                        case "p2": //Player 2 Name
                            txtP2Name.Text = field.Value;
                            txtP2Name.FocusedBorderColor = field.Color;
                            break;
                        case "s1": //Player 1 Score
                            txtP1Score.Text = field.Value;
                            txtP1Score.FocusedBorderColor = field.Color;
                            break;
                        case "s2": //Player 2 Score
                            txtP2Score.Text = field.Value;
                            txtP2Score.FocusedBorderColor = field.Color;
                            break;
                        case "cam1": //Camera 1
                            txtCamera1.Text = field.Value;
                            txtCamera1.FocusedBorderColor = field.Color;
                            break;
                        case "cam2": //Camera 2
                            txtCamera2.Text = field.Value;
                            txtCamera2.FocusedBorderColor = field.Color;
                            break;
                        case "co1": //Commentator 1
                            txtComm1.Text = field.Value;
                            txtComm1.FocusedBorderColor = field.Color;
                            break;
                        case "co2": //Commentator 2
                            txtComm2.Text = field.Value;
                            txtComm2.FocusedBorderColor = field.Color;
                            break;
                        case "tw1": //Twitter Handle 1
                            txtComm1Twitter.Text = field.Value;
                            txtComm1Twitter.FocusedBorderColor = field.Color;
                            break;
                        case "tw2": //Twitter Handle 2
                            txtComm2Twitter.Text = field.Value;
                            txtComm2Twitter.FocusedBorderColor = field.Color;
                            break;
                    }
                }
                else if (field.Type == AgnaField.FieldType.Custom)
                {
                    //Custom field parsing goes here!!!
                }
            }

            //Clear existing uncategorized images
            uncategorizedAgnaImages.Clear();
            foreach (AgnaImage image in activeScene.Images)
            {
                //Path must not be blank
                if (!String.IsNullOrWhiteSpace(image.Path))
                {
                    //Use this variable later to check if the image needs to be categorized under 'None', since it doesn't have a pre-existing category
                    bool imageExists = false;

                    //Iterate through each pre-existing category of AgnaImages
                    for (int category = 0; category < Settings.Images.Categories.Count; category++)
                    {
                        for (int imagesIndex = 0; imagesIndex < Settings.Images.Categories[category].Images.Count; imagesIndex++)
                        {
                            //Image matched
                            if (Settings.Images.Categories[category].Images[imagesIndex].Path.Contains(image.Path) || image.Path == Settings.Images.Categories[category].Images[imagesIndex].Path)
                            {
                                //It exists!
                                imageExists = true;

                                //Attempt to select the image for either Player 1 or 2
                                if (image.Name == "p1" && image.Type == AgnaImage.FieldType.Main)
                                {
                                    comboP1Category.SelectedIndex = category;
                                    comboP1Image.SelectedIndex = imagesIndex;
                                }
                                else if (image.Name == "p2" && image.Type == AgnaImage.FieldType.Main)
                                {
                                    comboP2Category.SelectedIndex = category;
                                    comboP2Image.SelectedIndex = imagesIndex;
                                }
                            }
                        }
                    }

                    //Add to list for extraction by comboP2Category
                    if (!imageExists)
                        uncategorizedAgnaImages.Add(image);
                }
            }
        }
        #endregion
        #region Tray Icon
        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            if (!Visible)
                Visible = true;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            if (!Visible)
                Visible = true;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Other
        private int P1Index = -1;
        private void comboP1Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If selected index is already selected
            if (P1Index == comboP1Category.SelectedIndex)
                return;

            P1Index = comboP1Category.SelectedIndex;
            comboP1Image.Items.Clear();

            //If selected category 'None'
            if (comboP1Category.SelectedIndex == 0)
            {
                //If no uncategorized images exist
                if (uncategorizedAgnaImages.Count == 0)
                {
                    comboP1Image.Enabled = false;
                    return;
                }

                comboP1Image.Items.Add("None");

                if (!comboP1Image.Enabled)
                    comboP1Image.Enabled = true;

                //If uncategorized images exist
                foreach (AgnaImage image in uncategorizedAgnaImages)
                    comboP1Image.Items.Add(image.Path);
            }
            else
            {
                if (!comboP1Image.Enabled)
                    comboP1Image.Enabled = true;

                //Parse
                Settings.AgnaImageCategory curSelection = Settings.Images.Categories[comboP1Category.SelectedIndex - 1];
                foreach (Settings.AgnaImage image in curSelection.Images)
                    comboP1Image.Items.Add(!String.IsNullOrWhiteSpace(image.Name) ? image.Name : Path.GetFileName(image.Path));
            }

            comboP1Image.SelectedIndex = 0;
        }

        private int P2Index = -1;
        private void comboP2Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If selected index is already selected
            if (P2Index == comboP2Category.SelectedIndex)
                return;

            P2Index = comboP2Category.SelectedIndex;
            comboP2Image.Items.Clear();

            //If selected category 'None'
            if (comboP2Category.SelectedIndex == 0)
            {
                //If no uncategorized images exist
                if (uncategorizedAgnaImages.Count == 0)
                {
                    comboP2Image.Enabled = false;
                    return;
                }

                comboP2Image.Items.Add("None");

                if (!comboP2Image.Enabled)
                    comboP2Image.Enabled = true;

                //If uncategorized images exist
                foreach (AgnaImage image in uncategorizedAgnaImages)
                    comboP2Image.Items.Add(image.Path);
            }
            else
            {
                if (!comboP2Image.Enabled)
                    comboP2Image.Enabled = true;

                //Parse
                Settings.AgnaImageCategory curSelection = Settings.Images.Categories[comboP2Category.SelectedIndex - 1];
                foreach (Settings.AgnaImage image in curSelection.Images)
                    comboP2Image.Items.Add(!String.IsNullOrWhiteSpace(image.Name) ? image.Name : Path.GetFileName(image.Path));
            }

            comboP2Image.SelectedIndex = 0;
        }
        #endregion
        #region fileMenu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene = new AgnaScene();
            loadAgnaScene();
            tabPanel.Text = "Panel";
            reloadToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAgnaDialog.ShowDialog();
        }

        private void openAgnaDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (openAgnaScene(openAgnaDialog.FileName))
            {
                loadAgnaScene();
                tabPanel.Text = !String.IsNullOrWhiteSpace(activeScene.Name.Value) ? activeScene.Name.Value : $"Panel - {Path.GetFileName(activeScene.FilePath)}";
                reloadToolStripMenuItem.Enabled = true;

                AddRecentFileMenuItem(activeScene.FilePath);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(activeScene.FilePath))
            {
                saveAgnaDialog.ShowDialog();
            }
            else
            {
                activeScene.OutputAgnaScene().Save(activeScene.FilePath);
                reloadToolStripMenuItem.Enabled = true;

                AddRecentFileMenuItem(activeScene.FilePath);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAgnaDialog.ShowDialog();
        }
        private void saveAgnaDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(activeScene.FilePath) || !activeScene.FilePath.Equals(saveAgnaDialog.FileName))
                activeScene.FilePath = saveAgnaDialog.FileName;

            activeScene.OutputAgnaScene().Save(activeScene.FilePath);
            tabPanel.Text = !String.IsNullOrWhiteSpace(activeScene.Name.Value) ? activeScene.Name.Value : $"Panel - {Path.GetFileName(activeScene.FilePath)}";
            reloadToolStripMenuItem.Enabled = true;

            AddRecentFileMenuItem(activeScene.FilePath);
        }

        private void AddRecentFileMenuItem(string filePath)
        {
            if (Settings.RecentFiles.MaxFiles > 0 && !Settings.RecentFiles.Files.Contains(filePath))
            {
                if (Settings.RecentFiles.Files.Count == Settings.RecentFiles.MaxFiles) //Max allowed recent file entries reached
                {
                    for (int i = 0; i < openRecentToolStripMenuItem.DropDownItems.Count; i++)
                    {
                        if (openRecentToolStripMenuItem.DropDownItems[i].Text == Settings.RecentFiles.Files.Last()) //Delete last entry from menu
                            openRecentToolStripMenuItem.DropDownItems.RemoveAt(i);
                    }
                    Settings.RecentFiles.Files.Remove(Settings.RecentFiles.Files.Last()); //Delete last entry from internal list
                }

                ToolStripMenuItem newRecentFile = new ToolStripMenuItem()
                {
                    Name = $"recentFileEntry",
                    Text = filePath,
                };
                newRecentFile.Click += new EventHandler(RecentFileToolStripMenuItem_Click);

                Settings.RecentFiles.Files.Insert(0, filePath); //Add to beginning of internal list
                openRecentToolStripMenuItem.DropDownItems.Insert(0, newRecentFile);
            }
            else
            {
                //Bump file to the front of the list, as it is most recent
                for (int i = 0; i < openRecentToolStripMenuItem.DropDownItems.Count; i++)
                {
                    if (openRecentToolStripMenuItem.DropDownItems[i].Text == filePath)
                    {
                        ToolStripItem RemakeThis = openRecentToolStripMenuItem.DropDownItems[i]; //Store existing menu item
                        openRecentToolStripMenuItem.DropDownItems.RemoveAt(i); //Remove existing menu item
                        openRecentToolStripMenuItem.DropDownItems.Insert(0, RemakeThis); //Re-insert menu item at beginning of menu
                    }
                }
            }

            Settings.SaveRecentFiles();
        }

        private void RecentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem owner = (ToolStripMenuItem)sender;

            string fileName = owner.Text;
            if (!File.Exists(fileName))
                return;

            if (openAgnaScene(fileName))
            {
                loadAgnaScene();
                tabPanel.Text = !String.IsNullOrWhiteSpace(activeScene.Name.Value) ? activeScene.Name.Value : $"Panel - {Path.GetFileName(activeScene.FilePath)}";
                reloadToolStripMenuItem.Enabled = true;
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadAgnaScene();
        }

        private void openAgnaDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region toolsMenu
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TopMost)
                TopMost = false;

            SettingsFrm settingsFrm = new SettingsFrm();
            settingsFrm.ShowDialog();

            //Triggers once settingsFrm is closed and if user clicked 'Save' during runtime
            if (settingsFrm.clickedSave)
                loadSettings();
        }
        #endregion
        #region tabPanel
        #endregion
        #region tabIRC
        private ChatClient.Twitch twitchChat;

        private void txtSendIRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSendIRC.Text) && e.KeyChar.Equals((char)Keys.Enter))
            {

            }
        }

        private void timerChat_Tick(object sender, EventArgs e)
        {
            ChatMessage chatMessage = twitchChat.ReaderMessage();
            if (chatMessage.MessageType != ChatMessage.MsgType.NULL)
            {
                txtIRC.AppendText($"\n{chatMessage.ToString()}");
            }
        }
        #endregion
    }
}