using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Person
    {
         string name;
         int age;


        public virtual void Show()
        {
            Console.WriteLine("Hello");
        };
        ~Person()
        {

            Console.WriteLine("Exit");
        }
    }
}
