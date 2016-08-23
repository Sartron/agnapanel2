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
        private AgnaScene activeScene = new AgnaScene();

        /*************
        Form Size: 515, 325
        tabsBase
         - Location: 0, 25
         - Size: 501, 262
        ************/

        public MainFrm()
        {
            InitializeComponent();
            loadAgnaScene();

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
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (Settings.Window.Tray.Enabled && Settings.Window.Tray.Minimize)
                Visible = false;
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Window.Tray.Enabled && Settings.Window.Tray.Close)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void loadSettings()
        {
            //Window settings
            TopMost = Settings.Window.onTop;
            //ShowInTaskbar = Settings.Window.taskbar;
            if (Settings.Window.Tray.Enabled)
                trayIcon.Visible = true;

            //Recent files
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

            //Load Autocomplete entries
            AutoCompleteStringCollection roundSource = new AutoCompleteStringCollection();
            roundSource.AddRange(Settings.AutoComplete.Rounds.ToArray());
            txtMatch.AutoCompleteCustomSource = roundSource;

            AutoCompleteStringCollection nameSource = new AutoCompleteStringCollection();
            nameSource.AddRange(Settings.AutoComplete.Names.ToArray());
            txtP1Name.AutoCompleteCustomSource = nameSource;
            txtP2Name.AutoCompleteCustomSource = nameSource;
        }

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
        }

        #region fileMenu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene = new AgnaScene();
            loadAgnaScene();
            reloadToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAgnaDialog.ShowDialog();
        }

        private void openAgnaDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openAgnaDialog.FileName;
            activeScene = new AgnaScene(fileName);

            if (!activeScene.Valid)
            {
                activeScene = null;
                tabPanel.Text = "Panel - error!";
                reloadToolStripMenuItem.Enabled = false;
            }
            else
            {
                tabPanel.Text = $"Panel - {Path.GetFileName(activeScene.FilePath)}";
                reloadToolStripMenuItem.Enabled = true;
                loadAgnaScene();
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
                activeScene.outputAgnaScene().Save(activeScene.FilePath);
                reloadToolStripMenuItem.Enabled = true;
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

            activeScene.outputAgnaScene().Save(activeScene.FilePath);
            tabPanel.Text = $"Panel - {Path.GetFileName(activeScene.FilePath)}";
            reloadToolStripMenuItem.Enabled = true;


            if (Settings.RecentFiles.MaxFiles > 0 && !Settings.RecentFiles.Files.Contains(activeScene.FilePath))
            {
                Debug.WriteLine($"{activeScene.FilePath} is not inside the list, adding");
                AddRecentFileMenuItem(activeScene.FilePath);
            }
            else
            {
                //Bump file to the front of the list, as it is most recent
                Debug.WriteLine($"{activeScene.FilePath} is already inside the list, do nothing");
            }
        }

        private void AddRecentFileMenuItem(string filePath)
        {
            if (Settings.RecentFiles.Files.Count == Settings.RecentFiles.MaxFiles)
            {
                Debug.WriteLine("Max count reached!");
                Settings.RecentFiles.Files.Remove(Settings.RecentFiles.Files.Last());
            }

            ToolStripMenuItem newRecentFile = new ToolStripMenuItem()
            {
                Name = $"recentFileEntry",
                Text = filePath,
            };
            newRecentFile.Click += new EventHandler(RecentFileToolStripMenuItem_Click);

            Settings.RecentFiles.Files.Insert(0, filePath);
            openRecentToolStripMenuItem.DropDownItems.Add(newRecentFile);
        }

        private void RecentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem owner = (ToolStripMenuItem)sender;

            string fileName = owner.Text;
            if (!File.Exists(fileName))
                return;

            activeScene = new AgnaScene(fileName);

            if (!activeScene.Valid)
            {
                activeScene = null;
                tabPanel.Text = "Panel - error!";
                reloadToolStripMenuItem.Enabled = false;
            }
            else
            {
                tabPanel.Text = $"Panel - {Path.GetFileName(activeScene.FilePath)}";
                reloadToolStripMenuItem.Enabled = true;
                loadAgnaScene();
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

            //Triggers once settingsFrm is closed
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
    }
}