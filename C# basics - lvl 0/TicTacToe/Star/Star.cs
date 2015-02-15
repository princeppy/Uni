using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Star
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int rows = n * 2 - (n / 2 - 1);
        int cols = 2 * n + 1;
        int indexPlus = n;
        int indexMinus = n / 2 + n;
        int index1 = -n;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (row < n / 2)
                {
                    if (col == indexPlus + row || col == indexPlus - row)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                else if (row == n / 2 || row == rows - 1)
                {
                    if (col < n + n / 2 & col > n - n / 2)
                    {
                        Console.Write('.');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }
                else if (row < n & row > n / 2)
                {

                    
                    if (col == (2 * row - n)/2 || col == cols - 1 - ((2 * row - n)/2))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                
            }
            if (row==n)
                {
                    string str = new string('.', indexMinus);
                    string str1 = new string('.', index1);
                    string str2 = new string('.', n / 2 - 1);
                    Console.Write(str + "*"+str2 + "*" + str2+"*" + str);
                    
                }
            else if (row>=n&row<rows-1)
            {
                
                string str = new string('.', indexMinus);
                string str1 = new string('.', index1);
                string str2 = new string('.', n / 2 - 1);
                Console.Write(str + "*" + str2 + "*" + str1 + "*" + str2 + "*" + str);
                index1++;
            }
            
            
            Console.WriteLine();
            index1++;
            indexMinus--;
        }
        
    }
}
