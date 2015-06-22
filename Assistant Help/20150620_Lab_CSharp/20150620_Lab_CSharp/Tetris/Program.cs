using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                char[] chars = line.ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            int i = 0, l = 0, j = 0, o = 0, z = 0, s = 0, t = 0;

            for (int row = 0; row < rows-4; row+=4)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] && matrix[row + 2, col] == matrix[row + 3, col] &&
                        matrix[row, col] == 'o' && matrix[row + 3, col] == 'o')
                    {
                        i++;
                    }
                }
            }

            for (int row = 0; row < rows - 3; row += 3)
            {
                for (int col = 0; col < cols-1; col+=2)
                {
                    if (matrix[row, col] == matrix[row + 1, col] && matrix[row + 2, col] == matrix[row + 3, col] &&
                        matrix[row, col] == 'o' && matrix[row + 3, col] == 'o')
                    {
                        i++;
                    }
                }
            }

            Console.WriteLine(i);
        }
    }
}
