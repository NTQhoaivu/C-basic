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

namespace WpfConfigTool
{
    public class XmlDocumentHelper
    {
        public static void Save(XmlDocument document, string filename)
        {
            XmlWriterSettings s = new XmlWriterSettings();            
            
            s.Encoding = Encoding.UTF8;
            using (XmlWriter w = XmlWriter.Create(filename, s))
            {
                document.Save(w);
            }
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
    }
}
