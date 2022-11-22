using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    internal class Dog : Animal
    {
        private int height;
        private int weight;
        private string color;
        private string name;
        private int id;
       
        public string Name { get; set; }
        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public void Talk()
        {
            Console.WriteLine(" gau gau");
        }
    }
}
