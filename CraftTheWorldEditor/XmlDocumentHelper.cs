using System.Xml;

namespace CraftTheWorldEditor
{
    internal static class XmlDocumentHelper
    {
        #region Methods

        public static XmlElement AppendElement(this XmlDocument doc, XmlNode parent, string name)
        {
            XmlElement ele = doc.CreateElement(name);

            if (parent == null)
            {
                doc.AppendChild(ele);
            }
            else
            {
                parent.AppendChild(ele);
            }

            return ele;
        }
        public static XmlAttribute ChangeOrAddAttribute(this XmlDocument doc, XmlNode parent, string name, string value)
        {
            XmlAttribute attr = parent.Attributes[name];

            if (parent.Attributes[name] == null)
            {
                attr = doc.CreateAttribute(name);
                attr.InnerText = value;

                parent.Attributes.Append(attr);
            }
            else
            {
                attr.InnerText = value;
            }

            return attr;
        }

        #endregion
    }
}