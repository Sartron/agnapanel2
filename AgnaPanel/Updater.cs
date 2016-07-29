using System;
using System.Windows.Forms;

namespace AgnaPanel
{
    public class Updater
    {
        private static bool GitHubConnection => Net.Ping("www.github.com");

        public enum UpdateStatus { UP_TO_DATE, NEW_PROGRAM, MAJOR_UPDATE, MINOR_UPDATE, BUG_FIX, DEV_BUILD, ERROR }
        public static UpdateStatus Status
        {
            get
            {
                if (GitHubConnection)
                {
                    string webVersion = Net.GetHTML("https://raw.githubusercontent.com/Taerk/Agna/master/VERSION");
                    string programVersion = Application.ProductVersion;

                    if (String.IsNullOrWhiteSpace(webVersion))
                        return UpdateStatus.ERROR;

                    if (programVersion.Equals(webVersion))
                        return UpdateStatus.UP_TO_DATE;

                    string[] split_webVersion = webVersion.Split('.');
                    string[] split_programVersion = programVersion.Split('.');

                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (Convert.ToInt32(split_programVersion[i]) < Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.NEW_PROGRAM;
                                else if (Convert.ToInt32(split_programVersion[i]) > Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.DEV_BUILD;
                                break;
                            case 1:
                                if (Convert.ToInt32(split_programVersion[i]) < Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.MAJOR_UPDATE;
                                else if (Convert.ToInt32(split_programVersion[i]) > Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.DEV_BUILD;
                                break;
                            case 2:
                                if (Convert.ToInt32(split_programVersion[i]) < Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.MINOR_UPDATE;
                                else if (Convert.ToInt32(split_programVersion[i]) > Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.DEV_BUILD;
                                break;
                            case 3:
                                if (Convert.ToInt32(split_programVersion[i]) < Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.BUG_FIX;
                                else if (Convert.ToInt32(split_programVersion[i]) > Convert.ToInt32(split_webVersion[i]))
                                    return UpdateStatus.DEV_BUILD;
                                break;
                        }
                    }

                    //Should never execute
                    return UpdateStatus.ERROR;
                }
                else
                {
                    return UpdateStatus.ERROR;
                }
            }
        }
    }
}