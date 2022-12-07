using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Schema;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace WpfConfigTool
{
    public class XmlDocumentHelper
    {
        public static void Save(object document, string filename)
        {
            //XmlWriterSettings s = new XmlWriterSettings();

            //s.Encoding = Encoding.UTF8;
            //using (XmlWriter w = XmlWriter.Create(filename, s))
            //{

            //    document.Save(w);
            //}
            XmlSerializer sr = new XmlSerializer(document.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, document);
            writer.Close();
        }


        public static XmlDocument LoadXML(string xml, string xsd)
        {
            //XmlSchemaValidator validator = new XmlSchemaValidator(xml, xsd);
            //validator.ErrorValidated += StateChanged;

            //if (!validator.Validate())
            //{
            //return null;
            //}

            var document = new XmlDocument();
            document.Load(xml);
            return document;
        }

        internal static XmlSchema LoadSchema(string xsdFile)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", xsdFile);
            //settings.Schemas = schema;
            //settings.ValidationType = ValidationType.Schema;
            schema.Compile();
            foreach (XmlSchema s in schema.Schemas())
            {
                return s;
            }
            return null;
        }
        string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                // Handle and throw if fatal exception here; don't just ignore them
                return xml;
            }
        }
    }
}
