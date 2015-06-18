namespace Generics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VersionAttribute;

    [VersionAttribute("1", "05b")]
    public class GenericsProgram
    {
        public static void Main(string[] args)
        {
            // Version attribute
            Type type = typeof(GenericsProgram);
            object[] allAttributes = type.GetCustomAttributes(false);

            foreach (object att in allAttributes)
            {
                VersionAttribute v = (VersionAttribute)att;
                Console.WriteLine("Current Version: {0}.{1}", v.Major, v.Minor);
            }

            GenericList<int> list = new GenericList<int>();

            // Just to test the generic type. Point class not implemented.
            Point p1 = new Point();
            Point p2 = new Point();
            GenericList<Point> pointsList = new GenericList<Point>();
            pointsList.Add(p1);
            pointsList.Add(p2);
            Console.WriteLine(pointsList[1]);
            // Just to test the generic type. Point class not implemented.

            // Test functionality
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);

            list.Add(1);
            list.InsertAt(1, -50);

            Console.WriteLine(string.Join(", ", list));

            list.RemoveAt(list.Count - 1);

            Console.WriteLine(string.Join(", ", list));

            // Console.WriteLine(list.ToString());

            // Console.WriteLine(list.IndexOf(5));

            // Console.WriteLine(pList.ToString());

            // Console.WriteLine(list.Max());
            // Console.WriteLine(list.Min());
            //// Console.WriteLine(pList.Max());
            // Console.WriteLine(list.Count);
            // Console.WriteLine(list.Capacity);
        }
    }
}
