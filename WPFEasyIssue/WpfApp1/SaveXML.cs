using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace WpfApp1
{
    internal class SaveXML
    {
        public static void SaveData(object obj, string fileName)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(fileName);
            sr.Serialize(writer, obj);
            writer.Close();
            //git check out other branch 
            // commit 1 
            //commit 2 
        }
    }
}
