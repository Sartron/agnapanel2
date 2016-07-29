using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AgnaPanel.Properties;

namespace AgnaPanel
{
    public class AgnaScene : XmlDocument
    {
        public bool Valid { get; set; }

        //'New' Inner XML
        public string ID { get; set; } = System.IO.Path.GetRandomFileName().Replace(".", String.Empty).Substring(0, 8).ToUpper();
        public AgnaField[,] Fields { get; set; }
        public AgnaCharacter[] Characters { get; set; }
        public AgnaImage[] Images { get; set; }

        public AgnaScene()
        {
            LoadXml(Resources.agnascene_clean);
            GetID();
            GetFields();
            GetImages();
        }

        public AgnaScene(string filePath)
        {
            try
            {
                Load(filePath);
                Valid = true; //Valid XML

                //Populate variables
                GetID();
                GetFields();
                GetImages();
            }
            catch (XmlException e)
            {
                Valid = false;
            }
        }

        private void GetID()
        {
            for (int i = 0; i < ChildNodes[1].ChildNodes.Count; i++)
            {
                if (ChildNodes[1].ChildNodes[i].Name.ToLower().Equals("id") && ChildNodes[1].ChildNodes[i].ChildNodes.Count == 1)
                {
                    ID = ChildNodes[1].ChildNodes[i].InnerText;
                    break;
                }
            }
        }

        private void GetFields()
        {
            for (int i = 0; i < ChildNodes[1].ChildNodes.Count; i++)
            {
                if (ChildNodes[1].ChildNodes[i].Name.ToLower().Equals("fields"))
                {
                    //Determine size of Fields[,]
                    int fieldsLength = 0;
                    for (int _i = 0; _i < ChildNodes[1].ChildNodes[i].ChildNodes.Count; _i++)
                    {
                        if (ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count > fieldsLength)
                            fieldsLength = ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count;
                    }
                    Fields = new AgnaField[2, fieldsLength];

                    //Fill up Fields[,]
                    for (int _i = 0; _i < ChildNodes[1].ChildNodes[i].ChildNodes.Count; _i++)
                    {
                        if (ChildNodes[1].ChildNodes[i].ChildNodes[_i].Name.ToLower().Equals("main"))
                        {
                            for (int __i = 0; __i < ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count; __i++)
                                Fields[0, __i] = new AgnaField(ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes[__i]);
                        }
                        else if (ChildNodes[1].ChildNodes[i].ChildNodes[_i].Name.ToLower().Equals("custom"))
                        {
                            for (int __i = 0; __i < ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count; __i++)
                                Fields[1, __i] = new AgnaField(ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes[__i]);
                        }
                    }
                }
            }
        }

        private void GetImages()
        {
            for (int i = 0; i < ChildNodes[1].ChildNodes.Count; i++)
            {
                if (ChildNodes[1].ChildNodes[i].Name.ToLower().Equals("images"))
                {
                    for (int _i = 0; _i < ChildNodes[1].ChildNodes[i].ChildNodes.Count; _i++)
                    {
                        if (ChildNodes[1].ChildNodes[i].ChildNodes[_i].Name.ToLower().Equals("main") && ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count == 2)
                        {
                            Characters = new AgnaCharacter[ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count];
                            for (int __i = 0; __i < ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count; __i++)
                                Characters[__i] = new AgnaCharacter(ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes[__i]);
                        }
                        else if (ChildNodes[1].ChildNodes[i].ChildNodes[_i].Name.ToLower().Equals("custom") && ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count > 0)
                        {
                            Images = new AgnaImage[ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count];
                            for (int __i = 0; __i < ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes.Count; __i++)
                                Images[__i] = new AgnaImage(ChildNodes[1].ChildNodes[i].ChildNodes[_i].ChildNodes[__i]);
                        }
                    }
                }
            }
        }
    }


    public class AgnaField
    {
        public string name { get; set; } = String.Empty;
        public string value { get; set; } = String.Empty;
        public Color htmlColor { get; set; } = Color.Black;

        public AgnaField() { }

        public AgnaField(XmlNode node)
        {
            //Scan attributes
            for (int i = 0; i < node.Attributes.Count; i++)
            {
                if (node.Attributes[i].Name.ToLower().Equals("name"))
                    name = node.Attributes[i].InnerText;
                else if (node.Attributes[i].Name.ToLower().Equals("color") && node.Attributes[i].InnerText.StartsWith("#") && node.Attributes[i].InnerText.Substring(1).Length == 6)
                    htmlColor = ColorTranslator.FromHtml(node.Attributes[i].InnerText);
            }

            //Scan value
            if (!String.IsNullOrWhiteSpace(node.InnerText))
                value = node.InnerText;
        }
    }

    public class AgnaImage
    {
        public string name { get; set; } = String.Empty;
        public string path { get; set; } = String.Empty;
        public Size size { get; set; } = new Size();
        public Point location { get; set; } = new Point();
        public double scale { get; set; } = 1.0;
        public bool reverse { get; set; } = false;
        public string base64 { get; set; } = String.Empty;

        public AgnaImage() { }

        public AgnaImage(XmlNode node)
        {
            //Scan attributes
            for (int i = 0; i < node.Attributes.Count; i++)
            {
                if (node.Attributes[i].Name.ToLower().Equals("name"))
                    name = node.Attributes[i].InnerText;
                else if (node.Attributes[i].Name.ToLower().Equals("path"))
                    path = node.Attributes[i].InnerText;
            }

            //Scan properties
            int x = 0, y = 0, w = 0, h = 0;
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {

                switch (node.ChildNodes[i].Name.ToLower())
                {
                    case "x":
                        x = Convert.ToInt32(node.ChildNodes[i].InnerText);
                        break;
                    case "y":
                        y = Convert.ToInt32(node.ChildNodes[i].InnerText);
                        break;
                    case "w":
                        w = Convert.ToInt32(node.ChildNodes[i].InnerText);
                        break;
                    case "h":
                        h = Convert.ToInt32(node.ChildNodes[i].InnerText);
                        break;
                    case "scale":
                        scale = Convert.ToDouble(node.ChildNodes[i].InnerText);
                        break;
                    case "reverse":
                        reverse = Convert.ToBoolean(node.ChildNodes[i].InnerText);
                        break;
                    case "base64":
                        base64 = node.ChildNodes[i].InnerText;
                        break;
                }
            }
            location = new Point(x, y);
            size = new Size(w, h);
        }
    }

    public class AgnaCharacter : AgnaImage
    {
        public enum Game { SMASH64, MELEE, BRAWL, SMASH4 };
        public enum Character
        {
            BAYONETTA,
            BOWSER,
            BOWSER_JR,
            CAPTAIN_FALCON,
            CHARIZARD,
            CLOUD,
            CORRIN,
            DARK_PIT,
            DIDDY_KONG,
            DONKEY_KONG,
            DR_MARIO,
            DUCK_HUNT,
            FALCO,
            FOX,
            GANONDORF,
            GRENINJA,
            ICE_CLIMBERS,
            IKE,
            IVYSAUR,
            JIGGLYPUFF,
            KING_DEDEDE,
            KIRBY,
            LINK,
            LITTLE_MAC,
            LUCARIO,
            LUCAS,
            LUCINA,
            LUIGI,
            MARIO,
            MARTH,
            MEGA_MAN,
            META_KNIGHT,
            MEWTWO,
            MII_BRAWLER,
            MII_GUNNER,
            MII_SWORDFIGHTER,
            MR_GAME_AND_WATCH,
            NESS,
            OLIMAR,
            PAC_MAN,
            PALUTENA,
            PEACH,
            PICHU,
            PIKACHU,
            PIT,
            POKÉMON_TRAINER,
            ROB,
            ROBIN,
            ROSALINA,
            ROY,
            RYU,
            SAMUS,
            SHEIK,
            SHULK,
            SNAKE,
            SONIC,
            SQUIRTLE,
            TOON_LINK,
            VILLAGER,
            WARIO,
            WII_FIT_TRAINER,
            WOLF,
            YOSHI,
            YOUNG_LINK,
            ZELDA,
            ZERO_SUIT_SAMUS
        };

        public Game game { get; set; } = Game.MELEE;
        public Character character { get; set; } = Character.FOX;

        public AgnaCharacter() : base() { }

        public AgnaCharacter(XmlNode node) : base(node)
        {
            //Scan attributes
            for (int i = 0; i < node.Attributes.Count; i++)
            {
                if (node.Attributes[i].Name.ToLower().Equals("game"))
                    game = (Game)Convert.ToInt32(node.Attributes[i].InnerText);
                else if (node.Attributes[i].Name.ToLower().Equals("character"))
                    character = (Character)Convert.ToInt32(node.Attributes[i].InnerText);
            }
        }
    }
}