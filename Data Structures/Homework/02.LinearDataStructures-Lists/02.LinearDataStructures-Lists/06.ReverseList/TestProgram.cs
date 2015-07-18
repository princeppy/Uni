namespace _06.ReverseList
{
    using System;
  
    public class TestProgram
    {
        public static void Main(string[] args)
        {
            ReverseList<int> list = new ReverseList<int>();

            // Adding elements
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);

            // Remove element
            list.Remove(0);

            // list.Remove(-1); //Exception
            // list.Remove(10); //Exception
            // Console.WriteLine(list[10]); //Excepion
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
