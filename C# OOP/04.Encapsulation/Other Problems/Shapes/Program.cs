using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<IShape> shapes = new List<IShape>()
            {
                new Rectangle(5,5),
                new Rectangle(5.5,7),
                new Triangle(1,5,5),
                new Circle(10)
            };

            foreach (var s in shapes)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nAreas and Perimeters\n---------------");
            foreach (var s in shapes)
            {
                Console.WriteLine(s+" Area:"+s.CalculateArea()+"/Perimeter:"+s.CalculatePerimeter());
            }


        }
    }
}
