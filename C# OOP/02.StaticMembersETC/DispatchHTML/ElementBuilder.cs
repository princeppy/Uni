using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchHTML
{
    public class ElementBuilder
    {
        private string elementName;
        private IList<string> components;
        private string openTag;
        private List<string> attributes; 
        private string openTagEnd;
        private string content;
        private string closingTag;

 

        public ElementBuilder(string elementName)
        {
            this.ElementName = elementName;

            this.OpenTag = "<" + this.ElementName;
            this.Attributes = new List<string>();
            this.OpenTagEnd = ">";
            this.Content = "";
            this.ClosingTag = "</" + this.ElementName + ">";

        }
        public string ElementName
        {
            get { return elementName; }
            set { elementName = value; }
        }


        public string OpenTag
        {
            get { return openTag; }
            set { openTag = value; }
        }

        public string OpenTagEnd
        {
            get { return openTagEnd; }
            set { openTagEnd = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string ClosingTag
        {
            get { return closingTag; }
            set { closingTag = value; }
        }

        public List<string> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        public void AddContent(string content)
        {
            this.Content = content;
        }

        public void AddAttribute(string attribute, string value)
        {
            this.Attributes.Add(attribute+"=\""+value+"\"");
        }
        public override string ToString()
        {
            return this.OpenTag + (this.Attributes.Count==0?"":" "+String.Join(", ",this.Attributes))+ this.OpenTagEnd + this.Content + this.ClosingTag;
        }

        public static string operator *(ElementBuilder eb1, int num)
        {
            List<ElementBuilder> list = new List<ElementBuilder>();
            for (int i = 0; i < num; i++)
            {
                list.Add(eb1);
            }
            return String.Join("",list);
        }
    }
}
