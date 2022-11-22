using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{

    internal interface  Animal
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        void  Talk();

    }
}
