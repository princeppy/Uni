using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TicTacToe
{
    static void Main()
    {
        int col = int.Parse(Console.ReadLine());
        int row = int.Parse(Console.ReadLine());
        int startValue = int.Parse(Console.ReadLine());
        int powerValue=1;

        int[,] array = new int[3, 3];
        int[,] power = new int[3,3];
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                array[x, y] = startValue;
                startValue++;
                power[x,y]=powerValue;
                powerValue++;
            }
        }
        
        //Console.WriteLine(Math.Pow((double)array[row,col],(double)power[row,col]));
        long result = 1;
        for (int i = 0; i < power[row,col]; i++)
        {
            result *= (long)array[row,col];
        }
        Console.WriteLine(result);
    }
}
