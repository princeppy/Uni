using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GalacticGPS
{
    class Galaxy
    {
        static void Main(string[] args)
        {
            Location p1 = new Location(18.037986, 28.870097, Planet.Earth);

            Console.WriteLine(p1);
        }
    }
}
