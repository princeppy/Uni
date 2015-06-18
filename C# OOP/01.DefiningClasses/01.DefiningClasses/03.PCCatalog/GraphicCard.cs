using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PCCatalog
{
    public class GraphicCard : Component
    {
        public GraphicCard(string name, IDictionary<string, string> details, decimal price)
            : base(name, details, price)
        {

        }
    }
}
