using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace WpfConfigTool
{
    class XmlNodeData
    {
        public XmlSchemaElement schema;
        public XmlNode xmlNode;
        public List<XmlNodeData> childNodeData = new List<XmlNodeData>();
    }
}
