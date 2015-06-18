using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Computers
{
    class LaptopProgram
    {
        static void Main(string[] args)
        {
            Battery bat = new Battery(19.2);

            Laptop laptop = new Laptop(
                "Lenovo Yoga 2 Pro",
                "Lenovo",
                "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",
                2259.0m)
            {
                
                Cpu = "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
                BatteryType = bat,
                Gpu = "Intel HD Graphics 4400",
                Ram = "8 GB",
                Hdd = "128GB SSD"
            };

            Laptop laptop1 = new Laptop(
                "Inspiron 5510",
                "Dell",
                "15.6\" – 3200 x 1800 (QHD+), IPS sensor display",
                1659.00m);

            Console.WriteLine(laptop);

        }
    }
}
