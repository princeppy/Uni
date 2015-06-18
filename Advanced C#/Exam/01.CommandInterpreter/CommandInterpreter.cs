using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.CommandInterpreter
{
    internal class CommandInterpreter
    {
        private static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Regex reg = new Regex("\\s+");

            string[] arrStr = reg.Split(input).Where(s => s != String.Empty).ToArray();
            string line = Console.ReadLine();


            string[] arrOriginal = new string[arrStr.Count()];


            for (int i = 0; i < arrStr.Count(); i++)
            {
                arrOriginal[i] = arrStr[i];
            }

            bool isValid = true;



            while (line != "end")
            {
                isValid = true;
                string[] commands = reg.Split(line).Where(s => s != String.Empty).ToArray();


                if (commands[0] == "reverse")
                {

                    string[] tempStr = Reverse(arrStr, true, commands);
                    if (tempStr.Length == 0)
                    {
                        isValid = false;
                    }
                    else
                    {
                        arrStr = tempStr;
                    }

                }
                else if (commands[0] == "sort")
                {
                    string[] tempStr = Sort(arrStr, true, commands);
                    if (tempStr.Length == 0)
                    {

                        isValid = false;
                    }
                    else
                    {
                        arrStr = tempStr;
                    }
                }
                else if (commands[0] == "rollLeft")
                {
                    arrStr = RollLeft(arrStr, commands);
                }
                else if (commands[0] == "rollRight")
                {
                    arrStr = RollRight(arrStr, commands);
                }
                line = Console.ReadLine();


                if (!isValid)
                {
                    Console.WriteLine("Invalid input parameters.");

                }
            }

            if (!isValid)
            {
                Console.WriteLine("[" + String.Join(", ", arrOriginal) + "]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", arrStr) + "]");
            }


        }


        static string[] Reverse(string[] arr, bool isValid, string[] commands)
        {
            long start = long.Parse(commands[2]);
            long count = long.Parse(commands[4]);
            if ((start >= arr.Length || start < 0) || ((start + count) >= arr.Length || ((start + count) < 0)) || count < 0)
            {
                return new string[0];
            }
            else
            {
                long j = 0;
                for (long i = start; i <= (start + count / 2 - 1); i++)
                {

                    string temp = arr[i];
                    arr[i] = arr[start + count - 1 - j];
                    arr[start + count - 1 - j] = temp;
                    j++;
                }
            }

            return arr;
        }

        static string[] Sort(string[] arr, bool isValid, string[] commands)
        {
            long start = long.Parse(commands[2]);
            long count = long.Parse(commands[4]);
            if ((start >= arr.Length || start < 0) || ((start + count) >= arr.Length || (start + count < 0)) || count < 0)
            {
                return new string[0];
            }
            else
            {
                List<string> list = new List<string>();
                for (long i = start; i <= (start + count - 1); i++)
                {

                    list.Add(arr[i]);
                }

                list.Sort(StringComparer.InvariantCulture);

                for (long i = start, j = 0; i <= (start + count - 1) && j < list.Count; i++, j++)
                {

                    arr[i] = list[(int)j];
                }

            }

            return arr;
        }

        static string[] RollLeft(string[] arr, string[] commands)
        {
            long times = long.Parse(commands[1]);


            for (long i = 0; i < times; i++)
            {
                string temp = arr[0];
                for (long j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = temp;
            }

            return arr;
        }

        static string[] RollRight(string[] arr, string[] commands)
        {

            long times = long.Parse(commands[1]) % arr.Length;


            for (long i = 0; i < times; i++)
            {
                string temp = arr[arr.Length - 1];
                for (long j = arr.Length - 1; j >= 1; j--)
                {
                    arr[j] = arr[j - 1];
                }
                arr[0] = temp;
            }

            return arr;

        }
    }
}
