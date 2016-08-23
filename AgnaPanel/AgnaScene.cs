using AgnaPanel.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace AgnaPanel
{
    public class AgnaScene
    {
        public bool Valid { get; } = true;
        public string FilePath { get; set; } = String.Empty;

        public XDocument Document { get; }
        public XElement ID { get; set; }
        public List<AgnaField> Fields { get; set; }
        public List<AgnaImage> Images { get; set; }

        public AgnaScene()
        {
            //Load preset XML
            Document = XDocument.Parse(Resources.agnascene_clean);

            //Parse ID
            ID = getID(Document);

            //Parse Fields
            Fields = parseFields(getFields(Document));

            //Parse Images
            Images = parseImages(getImages((Document)));
        }

        public AgnaScene(string filePath)
        {
            //Attempt to parse XML
            try
            {
                Document = XDocument.Load(filePath);
            }
            catch (Exception)
            {
                Valid = false; return;
            }

            //Save file path
            FilePath = filePath;

            //Parse ID
            ID = getID(Document);

            //Parse Fields
            Fields = parseFields(getFields(Document));

            //Parse Images
            Images = parseImages(getImages((Document)));
        }

        private XElement getID(XDocument xDocument)
        {
            //Check for either a null 'id' field or duplicate fields
            if (xDocument.Root.Elements("id").Count() != 1)
                return new XElement("id", System.IO.Path.GetRandomFileName().Replace(".", String.Empty).Substring(0, 8).ToUpper());

            //Get XElement 'id'
            XElement elementID = xDocument.Root.Element("id");

            //Confirm attributes of XElement 'id', return new ID if not
            return !elementID.HasAttributes && !elementID.HasElements && !String.IsNullOrWhiteSpace(elementID.Value) && elementID.Value.Length == 8
                ? elementID : new XElement("id", System.IO.Path.GetRandomFileName().Replace(".", String.Empty).Substring(0, 8).ToUpper());
        }

        private XElement getFields(XDocument xDocument)
        {
            //Check for either a null 'fields' field or duplicate fields
            if (xDocument.Root.Elements("fields").Count() != 1)
                return XDocument.Parse(Resources.agnascene_clean).Root.Element("fields");

            //Get XElement 'fields'
            XElement elementFieldsParent = xDocument.Root.Element("fields");

            //Confirm attributes of XElement 'fields', return preset Fields if not
            return elementFieldsParent.HasElements && elementFieldsParent.Elements().Count() >= 1
                && elementFieldsParent.Elements("main").Count() == 1 && elementFieldsParent.Element("main").HasElements && elementFieldsParent.Element("main").Elements("field").Count() == 15
                ? elementFieldsParent : XDocument.Parse(Resources.agnascene_clean).Root.Element("fields");
        }

        public List<AgnaField> parseFields(XElement fieldsParent)
        {
            List<AgnaField> returnFields = new List<AgnaField>();

            //Parse main fields
            for (int i = 0; i < fieldsParent.Element("main").Elements("field").Count(); i++)
            {
                if (AgnaField.isMainAgnaField(fieldsParent.Element("main").Elements("field").ElementAt(i)))
                    returnFields.Add(new AgnaField(fieldsParent.Element("main").Elements("field").ElementAt(i), AgnaField.FieldType.Main));
            }

            //Parse custom images
            if (fieldsParent.Elements("custom").Count() != 1 || !fieldsParent.Element("custom").HasElements)
                return returnFields;

            for (int i = 0; i < fieldsParent.Element("custom").Elements("field").Count(); i++)
            {
                if (AgnaField.isAgnaField(fieldsParent.Element("custom").Elements("field").ElementAt(i)))
                    returnFields.Add(new AgnaField(fieldsParent.Element("custom").Elements("field").ElementAt(i), AgnaField.FieldType.Custom));
            }

            return returnFields;
        }

        private XElement getImages(XDocument xDocument)
        {
            //Check for either a null 'images' field or duplicate fields
            if (xDocument.Root.Elements("images").Count() != 1)
                return XDocument.Parse(Resources.agnascene_clean).Root.Element("images");

            //Get XElement 'images'
            XElement elementImagesParent = xDocument.Root.Element("images");

            //Confirm attributes of XElement 'images', return preset Images if not

            return elementImagesParent.HasElements && elementImagesParent.Elements().Count() >= 1
                && elementImagesParent.Elements("main").Count() == 1 && elementImagesParent.Element("main").HasElements && elementImagesParent.Element("main").Elements("image").Count() == 2
                ? elementImagesParent : XDocument.Parse(Resources.agnascene_clean).Root.Element("images");
        }

        private List<AgnaImage> parseImages(XElement imagesParent)
        {
            List<AgnaImage> returnImages = new List<AgnaImage>();

            //Parse main images
            for (int i = 0; i < imagesParent.Element("main").Elements("image").Count(); i++)
            {
                if (AgnaImage.isMainAgnaImage(imagesParent.Element("main").Elements("image").ElementAt(i)))
                    returnImages.Add(new AgnaImage(imagesParent.Element("main").Elements("image").ElementAt(i), AgnaImage.FieldType.Main));
            }

            //Parse custom images
            if (imagesParent.Elements("custom").Count() != 1 || !imagesParent.Element("custom").HasElements)
                return returnImages;

            for (int i = 0; i < imagesParent.Element("custom").Elements("image").Count(); i++)
            {
                if (AgnaImage.isAgnaImage(imagesParent.Element("custom").Elements("image").ElementAt(i)))
                    returnImages.Add(new AgnaImage(imagesParent.Element("custom").Elements("image").ElementAt(i), AgnaImage.FieldType.Custom));
            }

            return returnImages;
        }

        public XDocument outputAgnaScene()
        {
            //Get fields
            XElement mainFields = new XElement("main");
            XElement customFields = new XElement("custom");
            foreach (AgnaField field in Fields)
            {
                if (field.Type == AgnaField.FieldType.Main)
                    mainFields.Add(field);
                else if (field.Type == AgnaField.FieldType.Custom)
                    customFields.Add(field);
            }

            //Get images
            XElement mainImages = new XElement("main");
            XElement customImages = new XElement("custom");
            foreach (AgnaImage image in Images)
            {
                if (image.Type == AgnaImage.FieldType.Main)
                    mainImages.Add(image);
                else if (image.Type == AgnaImage.FieldType.Custom)
                    customImages.Add(image);
            }

            return new XDocument(new XElement("agna-scene",
                (new XElement("id")),
                (new XElement("fields", mainFields, customFields.HasElements ? customFields : null)),
                (new XElement("images", mainImages, customImages.HasElements ? customImages : null))
                ));
        }
    }

    public class AgnaField : XElement
    {
        public new string Name
        {
            get { return Attribute("name").Value; }
            set { Attribute("name").Value = value; }
        }

        public Color Color
        {
            get { return ColorTranslator.FromHtml(Attribute("color").Value); }
            set { Attribute("color").Value = ColorTranslator.ToHtml(value); }
        }

        public enum FieldType { Main, Custom }
        public FieldType Type { get; } = FieldType.Custom;

        public AgnaField(string name, Color color, string value) : base(name: "field")
        {
            ReplaceAttributes(new XAttribute("name", name), new XAttribute("color", ColorTranslator.ToHtml(color)));
            Value = value;
        }
        public AgnaField(XElement xElement, FieldType type = FieldType.Custom) : base(xElement)
        {
            ReplaceAttributes(new XAttribute("name", xElement.Attribute("name").Value), new XAttribute("color", ColorTranslator.ToHtml(Color)));
            Type = type;
        }

        public static bool isAgnaField(XElement xElement)
        {
            //Must have 2 or more attributes, and must not contain elements
            if (!xElement.HasAttributes || xElement.Attributes().Count() < 2 || xElement.HasElements)
                return false;

            //Attribute 'name', 'color' must not be null or empty
            //Attribute 'color must follow the format #XXXXXX
            return xElement.Attribute("name") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("name").Value)
                && xElement.Attribute("color") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("color").Value)
                && xElement.Attribute("color").Value.StartsWith("#") && xElement.Attribute("color").Value.Substring(1).Length == 6;
        }

        private static string[] validLabels = { "to", "ev", "ma", "an", "mu", "p1", "p2", "s1", "s2", "cam1", "cam2", "co1", "co2", "tw1", "tw2" };
        public static bool isMainAgnaField(XElement xElement)
        {
            //Check if AgnaField
            if (!isAgnaField(xElement))
                return false;

            //Check if 'name' attribute is a valid "main" variable
            foreach (string label in validLabels)
            {
                if (xElement.Attribute("name").Value.Equals(label))
                    return true;
            }

            return false;
        }
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

        public Point Location
        {
            get
            {
                return new Point(Convert.ToInt16(Element("x").Value), Convert.ToInt16(Element("y").Value));
            }
            set
            {
                Element("x").Value = value.X.ToString();
                Element("y").Value = value.Y.ToString();
            }
        }

        public Size Size
        {
            get
            {
                return new Size(Convert.ToInt16(Element("w").Value), Convert.ToInt16(Element("h").Value));
            }
            set
            {
                Element("w").Value = value.Width.ToString();
                Element("h").Value = value.Height.ToString();
            }
        }

        public float Scale
        {
            get { return Convert.ToSingle(Element("scale").Value); }
            set { Element("scale").Value = value.ToString(); }
        }

        public bool Reverse
        {
            get { return Convert.ToBoolean(Element("reverse").Value); }
            set { Element("reverse").Value = value.ToString(); }
        }

        public string Base64
        {
            get { return Element("base64").Value; }
            set { Element("base64").Value = "#$#@$@#"; }
        }

        public enum FieldType { Main, Custom }
        public FieldType Type { get; } = FieldType.Custom;

        //Optional Attributes
        public enum _Game { None, Smash64, Melee, Brawl, Smash4 };
        public enum _Character
        {
            None,
            Bayonetta,
            Bowser,
            Bowser_Jr,
            Captain_Falcon,
            Charizard,
            Cloud,
            Corrin,
            Dark_Pit,
            Diddy_Kong,
            Donkey_Kong,
            Dr_Mario,
            Duck_Hunt,
            Falco,
            Fox,
            Ganondorf,
            Greninja,
            Ice_Climbers,
            Ike,
            Ivysaur,
            Jigglypuff,
            King_Dedede,
            Kirby,
            Link,
            Little_Mac,
            Lucario,
            Lucas,
            Lucina,
            Luigi,
            Mario,
            Marth,
            Mega_Man,
            Meta_Knight,
            Mewtwo,
            Mii_Brawler,
            Mii_Gunner,
            Mii_Swordfighter,
            Mr_Game_and_Watch,
            Ness,
            Olimar,
            Pac_Man,
            Palutena,
            Peach,
            Pichu,
            Pikachu,
            Pit,
            Pokémon_Trainer,
            Rob,
            Robin,
            Rosalina,
            Roy,
            Ryu,
            Samus,
            Sheik,
            Shulk,
            Snake,
            Sonic,
            Squirtle,
            Toon_Link,
            Villager,
            Wario,
            Wii_Fit_Trainer,
            Wolf,
            Yoshi,
            Young_Link,
            Zelda,
            Zero_Suit_Samus
        };

        public _Game Game
        {
            get
            {
                if (Type == FieldType.Main)
                    return (_Game)Convert.ToInt16(Attribute("game").Value);
                return _Game.None;
            }
            set
            {
                if (Type == FieldType.Main && Attribute("game") != null)
                    Attribute("game").Value = ((int)value).ToString();
            }
        }

        public _Character Character
        {
            get
            {
                if (Type == FieldType.Main)
                    return (_Character)Convert.ToInt16(Attribute("character").Value);
                return _Character.None;
            }
            set
            {
                if (Type == FieldType.Main && Attribute("character") != null)
                    Attribute("character").Value = ((int)value).ToString();
            }
        }

        public AgnaImage(string name, string path, Point location, Size size, float scale, bool reverse) : base(name: "image")
        {
            ReplaceAttributes(new XAttribute("name", name), new XAttribute("path", path));
            Add(new XElement("x", location.X), new XElement("y", location.Y), new XElement("w", size.Width), new XElement("h", size.Height), new XElement("scale", scale), new XElement("reverse", reverse), new XElement("base64"));
        }

        private string[] validElements = { "x", "y", "w", "h", "scale", "reverse", "base64" };
        public AgnaImage(XElement xElement, FieldType type = FieldType.Custom) : base(xElement)
        {
            if (isCharacterImage(xElement))
            {
                RemoveAll();
                ReplaceAttributes(new XAttribute("name", xElement.Attribute("name").Value),
                    new XAttribute("game", xElement.Attribute("game").Value),
                    new XAttribute("character", xElement.Attribute("character").Value),
                    new XAttribute("path", xElement.Attribute("path").Value));
                foreach (XElement _xElement in xElement.Elements())
                {
                    foreach (string name in validElements)
                    {
                        if (_xElement.Name.ToString().Equals(name))
                            Add(new XElement(_xElement.Name, _xElement.Value));
                    }
                }
                Type = type;
            }
            else
            {
                RemoveAll();
                ReplaceAttributes(new XAttribute("name", xElement.Attribute("name").Value), new XAttribute("path", xElement.Attribute("path").Value));
                foreach (XElement _xElement in xElement.Elements())
                {
                    foreach (string name in validElements)
                    {
                        if (_xElement.Name.ToString().Equals(name))
                            Add(new XElement(_xElement.Name, _xElement.Value));
                    }
                }
            }
        }

        public static bool isAgnaImage(XElement xElement)
        {
            //Must have 2 or more attributes, and must contain elements
            if (!xElement.HasAttributes || xElement.Attributes().Count() < 2 || !xElement.HasElements)
                return false;

            //Make sure there are no duplicate elements
            if (xElement.Elements("x").Count() != 1 || xElement.Elements("y").Count() != 1 || xElement.Elements("w").Count() != 1 || xElement.Elements("h").Count() != 1
                || xElement.Elements("scale").Count() != 1 || xElement.Elements("reverse").Count() != 1 || xElement.Elements("base64").Count() != 1)
                return false;

            //Attribute 'name', 'path' must not be null or empty
            return xElement.Attribute("name") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("name").Value)
                   && xElement.Attribute("path") != null;
        }

        private static string[] validLabels = { "p1", "p2" };
        public static bool isMainAgnaImage(XElement xElement)
        {
            //Check if AgnaField
            if (!isAgnaImage(xElement))
                return false;

            //Check if 'name' attribute is a valid "main" variable
            foreach (string label in validLabels)
            {
                if (xElement.Attribute("name").Value.Equals(label))
                    return true;
            }

            return false;
        }

        public static bool isCharacterImage(XElement xElement)
        {
            //Must have 4 or more attributes, and must contain elements
            if (!xElement.HasAttributes || xElement.Attributes().Count() < 4 || !xElement.HasElements)
                return false;

            //Make sure there are no duplicate elements
            if (xElement.Elements("x").Count() != 1 || xElement.Elements("y").Count() != 1 || xElement.Elements("w").Count() != 1 || xElement.Elements("h").Count() != 1
                || xElement.Elements("scale").Count() != 1 || xElement.Elements("reverse").Count() != 1 || xElement.Elements("base64").Count() != 1)
                return false;

            //Attribute 'name', 'game', 'character' must not be null or empty
            //'path' can be empty, but cannot be null
            //'game' can only be between 0-4, 'character' can only be between 0-66
            return xElement.Attribute("name") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("name").Value)
                   && xElement.Attribute("game") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("game").Value) && (Convert.ToInt16(xElement.Attribute("game").Value) >= 0 && Convert.ToInt16(xElement.Attribute("game").Value) <= 4)
                   && xElement.Attribute("character") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("character").Value) && (Convert.ToInt16(xElement.Attribute("character").Value) >= 0 && Convert.ToInt16(xElement.Attribute("character").Value) <= 66)
                   && xElement.Attribute("path") != null;
        }
    }
}