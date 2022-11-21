using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    internal class Chicken : Animal
    {


        private int height;
        private int weight;
        private string color;

        public int Height { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public void Talk()
        {
            Console.WriteLine("quaoc quoac");
        }
    }
}
