using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArraySlider
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex("\\s+");
            var array1 = Console.ReadLine();
            array1 = regex.Replace(array1, " ");
            var array = array1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();

            var line = Console.ReadLine();
            var currentIndex = 0;
            while (line != "stop")
            {
                var data1 = regex.Replace(line, " ");
                var data = data1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var offset = int.Parse(data[0]);
                var operation = data[1];
                var operand = BigInteger.Parse(data[2]);



                if (currentIndex + offset < 0)
                {

                    currentIndex = array.Length - 1 - (currentIndex + offset + 1) % array.Length * (-1);



                }
                else if (currentIndex + offset >= array.Length)
                {
                    currentIndex = (currentIndex + offset) % array.Length;
                }
                else
                {
                    currentIndex += offset;
                }


                switch (operation)
                {
                    case "&":
                        if ((array[currentIndex] & operand) >= 0)
                            array[currentIndex] &= operand;
                        else array[currentIndex] = 0;

                        break;
                    case "|":
                        if ((array[currentIndex] | operand) >= 0)
                            array[currentIndex] |= operand;
                        else array[currentIndex] = 0;
                        break;
                    case "^":
                        if ((array[currentIndex] ^ operand) >= 0)
                            array[currentIndex] ^= operand;
                        else array[currentIndex] = 0;
                        break;
                    case "+":
                        if ((array[currentIndex] + operand) >= 0)
                            array[currentIndex] += operand;
                        else array[currentIndex] = 0;
                        break;
                    case "-":
                        if ((array[currentIndex] - operand) >= 0)
                            array[currentIndex] -= operand;
                        else array[currentIndex] = 0;
                        break;
                    case "*":
                        if ((array[currentIndex] * operand) >= 0)
                            array[currentIndex] *= operand;
                        else array[currentIndex] = 0;
                        break;
                    case "/":
                        if ((array[currentIndex] / operand) >= 0)
                            array[currentIndex] /= operand;
                        else array[currentIndex] = 0;
                        break;

                }



                //Console.WriteLine(currentIndex);



                line = Console.ReadLine();
            }

            Console.WriteLine("{0}{1}{2}", "[", string.Join(", ", array), "]");

            //Console.WriteLine(string.Join(", ", array));
        }
    }
}
