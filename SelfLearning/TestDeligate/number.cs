using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeligate
{
    internal class number
    {
        public double RealInt { get; set; }
        public double ImaInt { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is number number &&
                   RealInt == number.RealInt &&
                   ImaInt == number.ImaInt;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RealInt, ImaInt);
        }
    }
}
