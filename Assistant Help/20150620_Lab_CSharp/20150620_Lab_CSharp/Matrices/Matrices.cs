using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    internal class Matrices
    {
        private static void Main(string[] args)
        {
            double startValue = double.Parse(Console.ReadLine());
            double step = double.Parse(Console.ReadLine());
            double[,] matrix = new double[4, 4];
            int count = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    matrix[row, col] = startValue + count * step;
                    count++;
                }
            }

            string line = Console.ReadLine();

            while (line != "Game Over!")
            {
                string[] arr = line.Split(' ');
                int row = int.Parse(arr[0]);
                int col = int.Parse(arr[1]);
                string command = arr[2];
                double number = double.Parse(arr[3]);

                if (command == "power")
                {
                    matrix[row, col] = Math.Pow(matrix[row, col], number);
                }
                else if (command == "multiply")
                {
                    matrix[row, col] *= number;
                }
                else if (command == "sum")
                {
                    matrix[row, col] += number;
                }
                line = Console.ReadLine();
            }

            double max = Double.MinValue;
            string typeOfMax = "";
            int numberN = 0;

            for (int row = 0; row < 4; row++)
            {
                double temp = 0;
                for (int col = 0; col < 4; col++)
                {
                    temp += matrix[row, col];
                }

                if (temp > max)
                {
                    numberN = row;
                    typeOfMax = "ROW";
                    max = temp;
                }
            }

            for (int col = 0; col < 4; col++)
            {
                double temp = 0;
                for (int row = 0; row < 4; row++)
                {
                    temp += matrix[row, col];
                }
                if (temp > max)
                {
                    numberN = col;
                    typeOfMax = "COLUMN";
                    max = temp;
                }

            }

            double temp1 = 0;
            for (int i = 0; i < 4; i++)
            {
                temp1 += matrix[i, i];

                if (temp1 > max)
                {
                    max = temp1;
                    typeOfMax = "LEFT-DIAGONAL";
                }
            }

            temp1 = 0;
            for (int row = 0, col = 3; row < 4 || col >= 0; row++,col--)
            {
                temp1 += matrix[row, col];

                if (temp1 > max)
                {
                    max = temp1;
                    typeOfMax = "RIGHT-DIAGONAL";
                }
            }

            if (typeOfMax == "ROW" || typeOfMax == "COLUMN")
            {
                Console.WriteLine("{0}[{1}] = {2:f2}", typeOfMax, numberN, max);
            }
            else
            {
                Console.WriteLine("{0} = {1:f2}", typeOfMax, max);
                
            }
        }
    }
}
