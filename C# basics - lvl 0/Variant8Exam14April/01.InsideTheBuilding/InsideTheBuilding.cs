using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InsideTheBuilding
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        List<int> pointList = new List<int>();
        string check = "";

        for (int i = 0; i < 10; i++)
        {
            pointList.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 0; i < 10; i += 2)
        {
            if ((pointList[i] >= 0 & pointList[i] <= 3 * h) && (pointList[i + 1] <= h & pointList[i + 1] >= 0))
            {
                check = "inside";
                
            }
            else if (((pointList[i] >= h & pointList[i] <= 2 * h) && (pointList[i + 1] <= 4 * h & pointList[i + 1] >= 0)))
            {
                check = "inside";
                
            }
            else
            {
                check = "outside";
            }
            Console.WriteLine(check);
        }
    }
}

