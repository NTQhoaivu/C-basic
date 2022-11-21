using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Student : Person
    {
        private string name;
        private int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override void Show()
        {
            Console.WriteLine("Hello");

        }
        public void ShowAge(int age)
        {
            Console.WriteLine("My age is : " + age + "year old.");
        }
        
    }
}
