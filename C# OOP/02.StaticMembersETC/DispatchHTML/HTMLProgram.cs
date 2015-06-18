using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchHTML
{
    class HTMLProgram
    {
        public static void Main(string[] args)
        {

            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div);
            Console.WriteLine("------------------------------");
            Console.WriteLine(div*5);

            Console.WriteLine("------------------------------");
            ElementBuilder img = HTMLDispatcher.CreateImage("www.www.www/img.png", "The Image Loaded", "This is the image Title");
            Console.WriteLine(img);
            Console.WriteLine("------------------------------");
            Console.WriteLine("This is not a valid html tag!!! It is only for test purposes!!!");
            ElementBuilder url = HTMLDispatcher.CreateURL("www.www.www", "URL adress", "Hello World!");
            Console.WriteLine(url);
            Console.WriteLine("------------------------------");
            ElementBuilder input = HTMLDispatcher.CreateInput("text", "The Input", "Hello World!");
            Console.WriteLine(input);
            Console.WriteLine("------------------------------");
        }
    }
}
