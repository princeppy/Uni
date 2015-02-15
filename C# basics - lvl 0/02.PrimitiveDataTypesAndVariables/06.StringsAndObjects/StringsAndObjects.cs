using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringsAndObjects
{
    static void Main(string[] args)
    {
        string salute = "Hello";
        string who = "World";
        object saluteWho = salute + " " + who;
        string saluteWhoString = (string)saluteWho;

        Console.WriteLine(saluteWhoString);
    }
}

