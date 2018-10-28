using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace LED_Planer
{
    static class XmlProcessor
    {
        public static string SaveGradients(List<Data.Gradient> gradients)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlGradients = doc.CreateElement("Gradients");
            doc.AppendChild(xmlGradients);

            foreach (Data.Gradient gradient in gradients)
            {

                XmlElement elem = gradient.ToXml(doc);

                xmlGradients.AppendChild(elem);
            }
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.Indentation = 4;
            doc.WriteTo(xmlTextWriter);

            string text = stringWriter.ToString();
            File.WriteAllText(@"data.xml", text);

            return text;
        }

        public static List<Data.Gradient> LoadGradients()
        {
            List<Data.Gradient> gradients = new List<Data.Gradient>();

            string text = File.ReadAllText(@"data.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(text));


            XmlElement xmlGradients = doc.DocumentElement;
            foreach (XmlNode c in xmlGradients.ChildNodes)
            {
                gradients.Add(Data.Gradient.FromXML((XmlElement)c));
            }
            return gradients;
        }
    }
}
