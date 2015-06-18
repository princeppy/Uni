using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchHTML
{
    public static class HTMLDispatcher
    {
        


        public static ElementBuilder CreateImage(string src, string alt, string title)
        {
            ElementBuilder imgElement = new ElementBuilder("img");
            imgElement.AddAttribute("src",src);
            imgElement.AddAttribute("alt",alt);
            imgElement.AddAttribute("title", title);

            return imgElement;
        }

        public static ElementBuilder CreateURL(string url, string title, string text)
        {
            ElementBuilder urlElement = new ElementBuilder("url");
            urlElement.AddAttribute("url",url);
            urlElement.AddAttribute("title",title);
            urlElement.AddAttribute("text", text);
            return urlElement;
        }

        public static ElementBuilder CreateInput(string type, string name, string value)
        {
            ElementBuilder inputElement = new ElementBuilder("input");
            inputElement.AddAttribute("type", type);
            inputElement.AddAttribute("name",name);
            inputElement.AddAttribute("value", value);
            inputElement.ClosingTag = "";
            return inputElement;
        }
    }
}
