using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PCCatalog
{
    class Motherboard:Component
    {
         public Motherboard(string name, IDictionary<string, string> details, decimal price)
            : base(name, details, price)
        {

        }
    }
}
