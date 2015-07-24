using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BunkerBuster
{
    class Program
    {
        //private static void Main(string[] args)
        //{
        //    var rowsCols =
        //        Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        //    int[,] matrix = new int[rowsCols[0],rowsCols[1]];

        //    for (int row = 0; row < rowsCols[0]; row++)
        //    {
        //        var line = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        //        for (int col = 0; col < rowsCols[1]; col++)
        //        {

        //            matrix[row, col] = line[col];
        //        }
        //    }

        //    var counter = 0;

        //    var currLine = Console.ReadLine();
        //    while (currLine != "cease fire!")
        //    {

        //        var dataArray = currLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //        var row = int.Parse(dataArray[0]);
        //        var col = int.Parse(dataArray[1]);
        //        var power = Convert.ToInt32(dataArray[2].ToCharArray()[0]);



        //        matrix[row, col] -= power;

        //        //if (matrix[row, col] <= 0)
        //        //{
        //        //    counter++;
        //        //}


        //        //Dictionary<int,int> adjecentCells = new Dictionary<int, int>();

        //        for (int i = row-1; i <= row+1; i++)
        //        {
        //            for (int j = col-1; j <= col+1; j++)
        //            {
        //                if (i >= 0 && i < matrix.GetLength(0) &&
        //                    j >= 0 && j < matrix.GetLength(1))
        //                {
        //                    if (i != row || j != col)
        //                    {
        //                        matrix[i, j] -= power/2+power%2;
        //                    }

        //                }
        //            }
        //        }

        //        //foreach (var adjecentCell in adjecentCells)
        //        //{
        //        //    Console.WriteLine(adjecentCell.Key+" "+adjecentCell.Value);
        //        //}

        //        currLine = Console.ReadLine();
        //    }


        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            if (matrix[i, j] <= 0)
        //            {
        //                counter++;
        //            }
        //        }
        //    }

        //    int total = matrix.GetLength(0)*matrix.GetLength(1);

        //    decimal percent = (decimal)counter/total;

        //    //Console.WriteLine(total);
        //    Console.WriteLine("Destroyed bunkers: {0}", counter );
        //    Console.WriteLine("Damage done: {0:F1} %", percent*100);
        //    //PrintMatrix(matrix);
        //}

        //private static void PrintMatrix(int[,] matrix)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            Console.WriteLine(matrix[i, j]);
        //        }
        //    }
        //}

        public static void Main(string[] args)
        {
            Console.WriteLine(-20 % 1);
        }
    }
}
