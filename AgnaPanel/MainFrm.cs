using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        private void loadAgnaScene()
        {
            //Parse fields
            for (int row = 0; row < activeScene.Fields.GetLength(0); row++)
            {
                for (int column = 0; column < activeScene.Fields.GetLength(1); column++)
                {
                    if (!activeScene.Fields[row, column].Equals(null))
                    {
                        switch (activeScene.Fields[row, column].name)
                        {
                            case "to": //Tournament Name
                                //textBoxNameGoesHere.Text = activeScene.Fields[row, column].value;
                                //textBoxNameGoesHere.FocusedBorderColor = activeScene.Fields[row, column].htmlColor;
                                break;
                            case "ev": //Event Name
                                break;
                            case "ma": //Match / Round
                                break;
                            case "an": //Announcement
                                break;
                            case "mu": //Music
                                break;
                            case "p1": //Player 1 Name
                                break;
                            case "p2": //Player 2 Name
                                break;
                            case "s1": //Player 1 Score
                                break;
                            case "s2": //Player 2 Score
                                break;
                            case "cam1": //Camera 1
                                break;
                            case "cam2": //Camera 2
                                break;
                            case "co1": //Commentator 1 Name
                                break;
                            case "co2": //Commentator 2 Name
                                break;
                            case "tw1": //Twitter Handle 1
                                break;
                            case "tw2": //Twitter Handle 2
                                break;
                        }
                    }
                }
            }
        }

        #region fileMenu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeScene = new AgnaScene();
            reloadToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAgnaDialog.ShowDialog();
        }
        private void openAgnaScene_FileOk(object sender, CancelEventArgs e)
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
                tabPanel.Text = "Panel - " + activeScene.BaseURI.Split('/')[activeScene.BaseURI.Split('/').Length - 1];
                reloadToolStripMenuItem.Enabled = true;
                loadAgnaScene();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(activeScene.BaseURI))
            {
                saveAgnaDialog.ShowDialog();
            }
            else
            {
                activeScene.Save(activeScene.BaseURI.Substring(8));
                reloadToolStripMenuItem.Enabled = true;
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAgnaDialog.ShowDialog();
        }
        private void saveAgnaScene_FileOk(object sender, CancelEventArgs e)
        {
            activeScene.Save(saveAgnaDialog.FileName);
            reloadToolStripMenuItem.Enabled = true;
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        #region tabPanel
        #endregion

        #region tabIRC
        private void txtSendIRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSendIRC.Text) && e.KeyChar.Equals((char)Keys.Enter))
            {
                txtSendIRC.Text = String.Empty;
            }
        }
        #endregion
    }
}