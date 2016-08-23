using AgnaPanel.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;

namespace AgnaPanel
{
    public class Settings
    {
        public static XDocument settingsXML;
        public static string Path => Application.StartupPath + @"\settings.xml";
        public static bool Exists => File.Exists(Path);

        /// <summary>
        /// Attempt to load settings from Path, load from internal resources if failed
        /// </summary>
        public static void Open()
        {
            if (Exists)
            {
                try
                {
                    settingsXML = XDocument.Load(Path);
                }
                catch (Exception)
                {
                    settingsXML = XDocument.Parse(Resources.settings_clean);
                    settingsXML.Save(Path);
                }
            }
            else
            {
                settingsXML = XDocument.Parse(Resources.settings_clean);
                settingsXML.Save(Path);
            }

            //Parse window settings
            ParseWindow();

            //Parse chat settings
            ParseChat();

            ////Parse recent files
            ParseRecentFiles();

            //Parse autocomplete entries
            ParseAutocomplete();

            //Parse Image Stuff
            ParseImages();
        }

        /// <summary>
        /// Load settings related to window configuration
        /// </summary>
        private static void ParseWindow()
        {
            //Only 1 'window' element can exist, must contain elements
            if (settingsXML.Root.Elements("window").Count() != 1 || !settingsXML.Root.Element("window").HasElements)
                return;

            //Window.onTop
            if (settingsXML.Root.Element("window").Elements("ontop").Count() == 1 && settingsXML.Root.Element("window").Element("ontop").Attribute("enabled") != null)
                Window.onTop = Convert.ToBoolean(settingsXML.Root.Element("window").Element("ontop").Attribute("enabled").Value);

            //Window.taskbar
            if (settingsXML.Root.Element("window").Elements("taskbar").Count() == 1 && settingsXML.Root.Element("window").Element("taskbar").Attribute("enabled") != null)
                Window.taskbar = Convert.ToBoolean(settingsXML.Root.Element("window").Element("taskbar").Attribute("enabled").Value);

            if (settingsXML.Root.Element("window").Elements("tray").Count() == 1 &&
                settingsXML.Root.Element("window").Element("tray").HasAttributes)
            {
                //Investigate use of Boolean.TryParse method later
                //https://msdn.microsoft.com/en-us/library/system.boolean.tryparse(v=vs.110).aspx

                //Window.Tray.Enabled
                if (settingsXML.Root.Element("window").Element("tray").Attribute("enabled") != null &&
                    !String.IsNullOrWhiteSpace(settingsXML.Root.Element("window").Element("tray").Attribute("enabled").Value))
                    Window.Tray.Enabled = Convert.ToBoolean(settingsXML.Root.Element("window").Element("tray").Attribute("enabled").Value);

                //Window.Tray.Minimize
                if (settingsXML.Root.Element("window").Element("tray").Attribute("minimize") != null &&
                    !String.IsNullOrWhiteSpace(settingsXML.Root.Element("window").Element("tray").Attribute("minimize").Value))
                    Window.Tray.Minimize = Convert.ToBoolean(settingsXML.Root.Element("window").Element("tray").Attribute("minimize").Value);

                //Window.Tray.Close
                if (settingsXML.Root.Element("window").Element("tray").Attribute("close") != null &&
                    !String.IsNullOrWhiteSpace(settingsXML.Root.Element("window").Element("tray").Attribute("close").Value))
                    Window.Tray.Close = Convert.ToBoolean(settingsXML.Root.Element("window").Element("tray").Attribute("close").Value);
            }
        }

        /// <summary>
        /// Load settings related to the chat system
        /// </summary>
        private static void ParseChat()
        {
            //Only 1 'chat' element can exist, must contain elements
            if (settingsXML.Root.Elements("chat").Count() != 1 || !settingsXML.Root.Element("chat").HasElements)
                return;

            if (settingsXML.Root.Element("chat").Elements("username").Count() == 1 && !String.IsNullOrWhiteSpace(settingsXML.Root.Element("chat").Element("username").Value))
                Chat.Username = settingsXML.Root.Element("chat").Element("username").Value;

            if (settingsXML.Root.Element("chat").Elements("oauth").Count() == 1 && !String.IsNullOrWhiteSpace(settingsXML.Root.Element("chat").Element("oauth").Value))
                Chat.oAuth = settingsXML.Root.Element("chat").Element("oauth").Value;

            if (settingsXML.Root.Element("chat").Elements("channel").Count() == 1 && !String.IsNullOrWhiteSpace(settingsXML.Root.Element("chat").Element("channel").Value))
                Chat.Channel = settingsXML.Root.Element("chat").Element("channel").Value;

            if (settingsXML.Root.Element("chat").Elements("acceptCmds").Count() == 1)
            {
                if (settingsXML.Root.Element("chat").Element("acceptCmds").Attribute("enabled") != null &&
                    !String.IsNullOrWhiteSpace(settingsXML.Root.Element("chat").Element("acceptCmds").Attribute("enabled").Value))
                    Chat.acceptCommands = Convert.ToBoolean(settingsXML.Root.Element("chat").Element("acceptCmds").Attribute("enabled").Value);

                //Parse valid Agna users
                if (settingsXML.Root.Element("chat").Element("acceptCmds").Elements("user").Count() > 0)
                {
                    foreach (XElement user in settingsXML.Root.Element("chat").Element("acceptCmds").Elements("user"))
                    {
                        if (!String.IsNullOrWhiteSpace(user.Value))
                            Chat.ValidUsers.Add(user.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Load recently loaded .agna files and related settings
        /// </summary>
        private static void ParseRecentFiles()
        {
            //Only 1 'chat' element can exist
            if (settingsXML.Root.Elements("recent").Count() != 1)
                return;

            if (settingsXML.Root.Element("recent").Attribute("max") != null && !String.IsNullOrWhiteSpace(settingsXML.Root.Element("recent").Attribute("max").Value))
                RecentFiles.MaxFiles = Convert.ToInt16(settingsXML.Root.Element("recent").Attribute("max").Value);

            if (settingsXML.Root.Element("recent").Attribute("load") != null && !String.IsNullOrWhiteSpace(settingsXML.Root.Element("recent").Attribute("load").Value))
                RecentFiles.Load = Convert.ToBoolean(settingsXML.Root.Element("recent").Attribute("load").Value);

            if (settingsXML.Root.Element("recent").Elements("file").Count() > 0)
            {
                foreach (XElement file in settingsXML.Root.Element("recent").Elements("file"))
                {
                    if (!String.IsNullOrWhiteSpace(file.Value))
                        RecentFiles.Files.Add(file.Value);
                }
            }
        }

        /// <summary>
        /// Load entries for auto-filling rounds and names
        /// </summary>
        private static void ParseAutocomplete()
        {
            //Only 1 'autocomplete' element can exist
            if (settingsXML.Root.Elements("autocomplete").Count() != 1)
                return;

            //Only 1 'rounds' element can exist
            if (settingsXML.Root.Element("autocomplete").Elements("rounds").Count() == 1)
            {
                if (settingsXML.Root.Element("autocomplete").Element("rounds").Elements("round").Count() > 0)
                {
                    foreach (XElement round in settingsXML.Root.Element("autocomplete").Element("rounds").Elements("round"))
                    {
                        if (!String.IsNullOrWhiteSpace(round.Value))
                            AutoComplete.Rounds.Add(round.Value);
                    }
                }
            }

            //Only 1 'names' element can exist
            if (settingsXML.Root.Element("autocomplete").Elements("names").Count() == 1)
            {
                if (settingsXML.Root.Element("autocomplete").Element("names").Elements("name").Count() > 0)
                {
                    foreach (XElement name in settingsXML.Root.Element("autocomplete").Element("names").Elements("name"))
                    {
                        if (!String.IsNullOrWhiteSpace(name.Value))
                            AutoComplete.Names.Add(name.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Load image configurations
        /// </summary>
        private static void ParseImages()
        {
            //Only 1 'images' element can exist
            if (settingsXML.Root.Elements("images").Count() != 1)
                return;

            if (settingsXML.Root.Element("images").Attribute("path") != null && !String.IsNullOrWhiteSpace(settingsXML.Root.Element("images").Attribute("path").Value))
                Images.Root = settingsXML.Root.Element("images").Attribute("path").Value;

            if (settingsXML.Root.Element("images").Elements("categories").Count() == 1 && settingsXML.Root.Element("images").Element("categories").Elements("category").Count() > 0)
            {
                foreach (XElement category in settingsXML.Root.Element("images").Element("categories").Elements("category"))
                {
                    if (AgnaImageCategory.isAgnaImageCategory(category))
                        Images.Categories.Add(new AgnaImageCategory(category));
                }
            }
            
            //Chill out
            foreach (AgnaImageCategory category in Images.Categories)
                Debug.WriteLine(category);
        }

        /// <summary>
        /// Creates a clean settings file from internal program settings
        /// </summary>
        public static void Save()
        {
            XDocument newSettingsFile;

            //Window settings
            XElement newWindow = new XElement("window",
                new XElement("ontop", new XAttribute("enabled", Window.onTop)),
                new XElement("taskbar", new XAttribute("enabled", Window.taskbar)),
                new XElement("tray", new XAttribute("enabled", Window.Tray.Enabled), new XAttribute("minimize", Window.Tray.Minimize), new XAttribute("close", Window.Tray.Close))
                );

            //Chat settings
            XElement acceptCmds = new XElement("acceptCmds", new XAttribute("enabled", Chat.acceptCommands));
            foreach (string user in Chat.ValidUsers.Distinct().ToList())
                acceptCmds.Add(new XElement("user", user));

            XElement newChat = new XElement("chat",
                new XElement("username", !String.IsNullOrWhiteSpace(Chat.Username) ? Chat.Username : null),
                new XElement("oauth", !String.IsNullOrWhiteSpace(Chat.oAuth) ? Chat.oAuth : null),
                new XElement("channel", !String.IsNullOrWhiteSpace(Chat.Channel) ? Chat.Channel : null),
                acceptCmds);

            //Recent File settings
            XElement newRecentFiles = new XElement("recent", new XAttribute("max", RecentFiles.MaxFiles), new XAttribute("load", RecentFiles.Load));
            if (RecentFiles.MaxFiles > 0)
            {
                int index = 0;
                foreach (string file in RecentFiles.Files.Distinct().ToList())
                {
                    newRecentFiles.Add(new XElement("file", file));
                    index++;

                    if (index == RecentFiles.MaxFiles)
                        break;
                }
            }

            //Autocomplete settings
            XElement rounds = new XElement("rounds");
            foreach (string round in AutoComplete.Rounds.Distinct().ToList())
                rounds.Add(new XElement("round", round));
            XElement names = new XElement("names");
            foreach (string name in AutoComplete.Names.Distinct().ToList())
                names.Add(new XElement("names", name));
            XElement newAutocomplete = new XElement("autocomplete",
                rounds,
                names);

            //Image settings
            XElement newImages = new XElement("images", new XAttribute("path", Images.Root));
            XElement categories = new XElement("categories");
            foreach (AgnaImageCategory category in Images.Categories)
                categories.Add(category);
            newImages.Add(categories);

            newSettingsFile = new XDocument(new XElement("agna-settings",
                newWindow,
                newChat,
                newRecentFiles,
                newAutocomplete,
                newImages
                ));

            Debug.WriteLine(newSettingsFile);
        }

        public class AgnaImageCategory : XElement
        {
            public new string Name
            {
                get { return Attribute("name").Value; }
                set { Attribute("name").Value = value; }
            }

            private List<AgnaImage> Images = new List<AgnaImage>();

            public AgnaImageCategory(string name) : base(name: "category")
            {
                ReplaceAttributes(new XAttribute("name", name));
            }

            public AgnaImageCategory(XElement xElement) : base(xElement)
            {
                Elements().Remove();
                foreach (XElement image in xElement.Elements("image"))
                {
                    if (AgnaImage.isAgnaImage(image))
                    {
                        Add(new AgnaImage(image));
                        Images.Add(new AgnaImage(image));
                    }
                }
            }

            public void AddAgnaImage(AgnaImage image)
            {
                Add(image);
                Images.Add(image);
            }

            public void RemoveAgnaImage(int index)
            {
                if (index > Images.Count)
                    return;

                AgnaImage findThis = Images[index];
                Images[index].Remove();
                
                //Find way to remove AgnaImage entry from this list :)))))))))))))
            }

            public static bool isAgnaImageCategory(XElement xElement) => xElement.Attribute("name") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("name").Value);
        }
        public class AgnaImage : XElement
        {
            public new string Name
            {
                get { return Attribute("name").Value; }
                set { Attribute("name").Value = value; }
            }

            public string Path
            {
                get { return Attribute("path").Value; }
                set { Attribute("path").Value = value; }
            }
            public AgnaImage(string name, string path) : base(name: "image")
            {
                ReplaceAttributes(new XAttribute("name", name), new XAttribute("path", path));
            }

            public AgnaImage(XElement xElement) : base(xElement)
            {
                RemoveAll();
                ReplaceAttributes(new XAttribute("name", xElement.Attribute("name").Value), new XAttribute("path", xElement.Attribute("path").Value));
            }

            public static bool isAgnaImage(XElement xElement) => (xElement.Attribute("name") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("name").Value)) ||
                (xElement.Attribute("path") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("path").Value));
        }



        #region Internal Program Settings
        public class Window
        {
            public static bool onTop = false;
            public static bool taskbar = true;

            public class Tray
            {
                public static bool Enabled = false;
                public static bool Minimize = false;
                public static bool Close = false;
            }
        }

        public class Chat
        {
            public static string Username = String.Empty;
            public static string oAuth = String.Empty;
            public static string Channel = String.Empty;
            public static bool acceptCommands = true;
            public static List<String> ValidUsers = new List<String>();
        }

        public class RecentFiles
        {
            public static int MaxFiles = 10;
            public static bool Load = true;
            public static List<String> Files = new List<String>();
        }

        public class AutoComplete
        {
            public static List<String> Rounds = new List<String>();
            public static List<String> Names = new List<String>();
        }

        public class Images
        {
            public static string Root = String.Empty;
            public static List<AgnaImageCategory> Categories = new List<AgnaImageCategory>();
        }
        #endregion
    }
}