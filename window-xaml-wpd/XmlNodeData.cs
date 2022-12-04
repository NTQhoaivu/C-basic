using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;

namespace window_xaml_wpd
{
    class XmlNodeData
    {
        public XmlSchemaElement schema;
        public XmlNode xmlNode;
        public List<XmlNodeData> childNodeData = new List<XmlNodeData>();
    }
}
