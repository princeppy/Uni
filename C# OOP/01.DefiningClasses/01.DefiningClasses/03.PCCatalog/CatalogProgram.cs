using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PCCatalog
{
    class CatalogProgram
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {
                    "Asus Sabertooth X99",
                    "Powerful TUF X99 motherboard compatible with all NVM Express storage options with built-in USB 3.1 for extreme toughness."
                }
            };
            Component mb = new Motherboard("Motherboard", dict, 886m);


            Dictionary<string, string> dict1 = new Dictionary<string, string>
            {
                {
                    "GeForce GTX 980 Ti",
                    "GeForce GTX 980, it enables new levels of performance and capabilities. Accelerated by the groundbreaking NVIDIA Maxwell™ architecture, GTX 980 Ti delivers an unbeatable 4K and virtual reality experience."
                }
            };
            Component gpu = new Motherboard("Graphics Crad", dict1, 1000m);

            Dictionary<string, string> dict2 = new Dictionary<string, string>
            {
                {
                    "Intel® Core™ i7-5550U",
                    "4M Cache, up to 3.00 GHz"
                }
            };
            Component cpu = new Processor("Processor", dict2, 900m);



            Computer pc = new Computer("Extreme PC",new List<Component>(){cpu,gpu,mb} );

            Console.WriteLine(pc);
            

        }
    }
}
