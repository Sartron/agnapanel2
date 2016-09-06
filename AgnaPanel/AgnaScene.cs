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
        public XElement Name { get; set; }
        public List<AgnaField> Fields { get; set; }
        public List<AgnaImage> Images { get; set; }

        public AgnaScene()
        {
            //Load preset XML
            Document = XDocument.Parse(Resources.agnascene_clean);

            //Parse ID
            Name = GetName(Document);

            //Parse Fields
            Fields = ParseFields(GetFields(Document));

            //Parse Images
            Images = ParseImages(GetImages((Document)));
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
            Name = GetName(Document);

            //Parse Fields
            Fields = ParseFields(GetFields(Document));

            //Parse Images
            Images = ParseImages(GetImages((Document)));
        }

        private XElement GetName(XDocument xDocument)
        {
            //Check for either a null 'name' field or duplicate fields
            if (xDocument.Root.Elements("name").Count() != 1)
                return new XElement("name");

            //Get XElement 'name'
            XElement elementName = xDocument.Root.Element("name");

            //Return new XElement with only the name if it has value
            return !String.IsNullOrWhiteSpace(elementName.Value) ? new XElement("name", elementName.Value) : new XElement("name");
        }

        private XElement GetFields(XDocument xDocument)
        {
            //Check for either a null 'fields' field or duplicate fields
            if (xDocument.Root.Elements("fields").Count() != 1)
                return XDocument.Parse(Resources.agnascene_clean).Root.Element("fields");

            //Get XElement 'fields'
            XElement elementFieldsParent = xDocument.Root.Element("fields");

            //Confirm attributes of XElement 'fields', return preset Fields if not
            return elementFieldsParent.Elements("main").Count() == 1 && elementFieldsParent.Element("main").Elements("field").Count() >= 15
                ? elementFieldsParent : XDocument.Parse(Resources.agnascene_clean).Root.Element("fields");
        }

        public List<AgnaField> ParseFields(XElement fieldsParent)
        {
            List<AgnaField> returnFields = new List<AgnaField>();

            //Parse main fields
            for (int i = 0; i < fieldsParent.Element("main").Elements("field").Count(); i++)
            {
                if (AgnaField.isMainAgnaField(fieldsParent.Element("main").Elements("field").ElementAt(i)))
                    returnFields.Add(new AgnaField(fieldsParent.Element("main").Elements("field").ElementAt(i), AgnaField.FieldType.Main));
            }

            //Parse custom images
            if (fieldsParent.Elements("custom").Count() != 1 || fieldsParent.Element("custom").Elements("field").Count() == 0)
                return returnFields;

            for (int i = 0; i < fieldsParent.Element("custom").Elements("field").Count(); i++)
            {
                if (AgnaField.isAgnaField(fieldsParent.Element("custom").Elements("field").ElementAt(i)))
                    returnFields.Add(new AgnaField(fieldsParent.Element("custom").Elements("field").ElementAt(i), AgnaField.FieldType.Custom));
            }

            return returnFields;
        }

        private XElement GetImages(XDocument xDocument)
        {
            //Check for either a null 'images' field or duplicate fields
            if (xDocument.Root.Elements("images").Count() != 1)
                return XDocument.Parse(Resources.agnascene_clean).Root.Element("images");

            //Get XElement 'images'
            XElement elementImagesParent = xDocument.Root.Element("images");

            //Confirm attributes of XElement 'images', return preset Images if not

            return elementImagesParent.Elements("main").Count() == 1 && elementImagesParent.Element("main").Elements("image").Count() >= 2
                ? elementImagesParent : XDocument.Parse(Resources.agnascene_clean).Root.Element("images");
        }

        private List<AgnaImage> ParseImages(XElement imagesParent)
        {
            List<AgnaImage> returnImages = new List<AgnaImage>();

            //Parse main images
            for (int i = 0; i < imagesParent.Element("main").Elements("image").Count(); i++)
            {
                if (AgnaImage.isMainAgnaImage(imagesParent.Element("main").Elements("image").ElementAt(i)))
                    returnImages.Add(new AgnaImage(imagesParent.Element("main").Elements("image").ElementAt(i), AgnaImage.FieldType.Main));
            }

            //Parse custom images
            if (imagesParent.Elements("custom").Count() != 1 || imagesParent.Element("custom").Elements("image").Count() == 0)
                return returnImages;

            for (int i = 0; i < imagesParent.Element("custom").Elements("image").Count(); i++)
            {
                if (AgnaImage.isAgnaImage(imagesParent.Element("custom").Elements("image").ElementAt(i)))
                    returnImages.Add(new AgnaImage(imagesParent.Element("custom").Elements("image").ElementAt(i), AgnaImage.FieldType.Custom));
            }

            return returnImages;
        }

        public XDocument OutputAgnaScene()
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
                (Name),
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
            //Clear all pre-existing nodes/attributes from the base constructor
            RemoveAll();

            //Run checks on the two primary attributes: name, color
            ReplaceAttributes(new XAttribute("name", xElement.Attribute("name") != null ? !String.IsNullOrEmpty(xElement.Attribute("name").Value) ? xElement.Attribute("name").Value : "customField" :
                "customField"),
                new XAttribute("color", xElement.Attribute("color") != null ? xElement.Attribute("color").Value.StartsWith("#") && xElement.Attribute("color").Value.Substring(1).Length == 6 ?
                xElement.Attribute("color").Value : "#000000" : "#000000")
                );

            //Set value & type
            Value = xElement.Value;
            Type = type;
        }

        /// <summary>
        /// Return boolean indicating whether or not the XElement meets the minimum requirements of being an AgnaField
        /// </summary>
        public static bool isAgnaField(XElement xElement)
        {
            //Attribute 'name', 'color' must not be null or empty
            //Attribute 'color must follow the format #XXXXXX
            return xElement.Attribute("name") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("name").Value)
                && xElement.Attribute("color") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("color").Value)
                && xElement.Attribute("color").Value.StartsWith("#") && xElement.Attribute("color").Value.Substring(1).Length == 6;
        }

        /// <summary>
        /// List of officially supported fields, designated as a "main" field
        /// </summary>
        private static string[] validFields = { "to", "ev", "ma", "an", "mu", "p1", "p2", "s1", "s2", "cam1", "cam2", "co1", "co2", "tw1", "tw2" };
        /// <summary>
        /// Return boolean indicating whether or not the XElement meets the minimum requirements of being a "main" AgnaField
        /// </summary>
        public static bool isMainAgnaField(XElement xElement)
        {
            //Check if AgnaField
            if (!isAgnaField(xElement))
                return false;

            //Check if 'name' attribute is a valid "main" variable
            foreach (string label in validFields)
            {
                if (xElement.Attribute("name").Value == label)
                    return true;
            }

            //Failed
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

        public AgnaImage(string name, string path) : base(name: "image")
        {
            ReplaceAttributes(new XAttribute("name", name), new XAttribute("path", path));
            Add(new XElement("x", 0), new XElement("y", 0), new XElement("w", 0), new XElement("h", 0), new XElement("scale", 1.0), new XElement("reverse", false), new XElement("base64"));
        }

        public AgnaImage(XElement xElement, FieldType type = FieldType.Custom) : base(xElement)
        {
            //Clear all pre-existing nodes/attributes from the base constructor
            RemoveAll();

            //Run checks on the two primary attributes: name, path
            ReplaceAttributes(new XAttribute("name", xElement.Attribute("name") != null ? !String.IsNullOrEmpty(xElement.Attribute("name").Value) ? xElement.Attribute("name").Value : "customImage" :
                "customImage"),
                new XAttribute("path", xElement.Attribute("path") != null ? xElement.Attribute("path").Value : String.Empty)
                );

            //Fill with image attributes
            Add(new XElement("x", xElement.Element("x") != null ? xElement.Element("x").Value : "0"),
                new XElement("y", xElement.Element("y") != null ? xElement.Element("y").Value : "0"),
                new XElement("w", xElement.Element("w") != null ? xElement.Element("w").Value : "0"),
                new XElement("h", xElement.Element("h") != null ? xElement.Element("h").Value : "0"),
                new XElement("scale", xElement.Element("scale") != null ? xElement.Element("scale").Value : "1.0"),
                new XElement("reverse", xElement.Element("reverse") != null ? xElement.Element("reverse").Value : "false"),
                new XElement("base64", xElement.Element("base64") != null ? xElement.Element("base64").Value : String.Empty)
                );

            //Set type
            Type = type;
        }

        /// <summary>
        /// Return boolean indicating whether or not the XElement meets the minimum requirements of being an AgnaField
        /// </summary>
        public static bool isAgnaImage(XElement xElement)
        {
            //Make sure there are no duplicate elements
            if (xElement.Elements("x").Count() > 1 || xElement.Elements("y").Count() > 1 || xElement.Elements("w").Count() > 1 || xElement.Elements("h").Count() > 1
                || xElement.Elements("scale").Count() > 1 || xElement.Elements("reverse").Count() > 1 || xElement.Elements("base64").Count() > 1)
                return false;

            //Attribute 'name', 'path' must not be null or empty
            return xElement.Attribute("name") != null && !String.IsNullOrWhiteSpace(xElement.Attribute("name").Value)
                   && xElement.Attribute("path") != null;
        }

        /// <summary>
        /// List of officially supported images, designated as a "main" image
        /// </summary>
        private static string[] validImages = { "p1", "p2" };
        /// <summary>
        /// Return boolean indicating whether or not the XElement meets the minimum requirements of being a "main" AgnaImage
        /// </summary>
        public static bool isMainAgnaImage(XElement xElement)
        {
            //Check if AgnaImage
            if (!isAgnaImage(xElement))
                return false;

            //Check if 'name' attribute is a valid "main" variable
            foreach (string label in validImages)
            {
                if (xElement.Attribute("name").Value.Equals(label))
                    return true;
            }

            //Failed
            return false;
        }
    }
}