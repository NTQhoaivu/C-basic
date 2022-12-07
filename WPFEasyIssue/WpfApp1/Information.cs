using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Information
    {
        private string textbox1;
        private string textbox2;
        private string textbox3;
        public string StudenID { get { return textbox1; } set { textbox1 = value; } }
        public string StudenName { get { return textbox2; } set { textbox2 = value; } }
        public string StudenPassword { get { return textbox3; } set { textbox3 = value; } }
    }
}
