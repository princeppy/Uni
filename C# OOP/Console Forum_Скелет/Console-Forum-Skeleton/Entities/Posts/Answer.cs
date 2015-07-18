using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Answer : IAnswer
    {
        public Answer(string body)
        {
            this.Body = body;
        }
        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            

            str.AppendLine(String.Format("[ Answer ID: {0} ]", this.Id));
            str.AppendLine(String.Format("Posted by: {0}", this.Author.Username));
            str.AppendLine(String.Format("Answer Body: {0}", this.Body));
            str.AppendLine(new string('-', 20));
            
            return str.ToString().Trim();
        }
    }
}
