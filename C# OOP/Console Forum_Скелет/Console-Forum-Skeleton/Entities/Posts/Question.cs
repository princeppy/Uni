using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Question:IQuestion
    {
        public Question(string title, string body)
        {
            this.Title = title;
            this.Body = body;
            this.Answers = new List<IAnswer>();
            
        }
        public string Title{get; set; }

        public IList<IAnswer> Answers { get; set; }
        

        public int Id{ get; set; }

        public string Body{get; set; }

        public IUser Author { get;set;}

        public override string ToString()
        {
            //[ Question ID: 1 ]
            //Posted by: pesho
            //Question Title: helloooooo
            //Question Body: i'mpeshoooo

            StringBuilder str = new StringBuilder();
            str.AppendLine(String.Format("[ Question ID: {0} ]", this.Id));
            str.AppendLine(String.Format("Posted by: {0}", this.Author.Username));
            str.AppendLine(String.Format("Question Title: {0}", this.Title));
            str.AppendLine(String.Format("Question Body: {0}", this.Body));
            str.AppendLine(new string('=', 20));
            if (this.Answers.Any())
            {
                str.AppendLine(String.Format("Answers:"));
                foreach (var answer in this.Answers)
                {
                    if (answer is BestAnswer)
                    {
                        str.AppendLine(new string('*', 20));
                        str.AppendLine(answer.ToString());
                        str.AppendLine(new string('*', 20));

                    }
                }

                foreach (var answer in this.Answers)
                {
                    if (answer is Answer)
                    {
                        str.AppendLine(answer.ToString());
                    }
                }
            }
            else
            {
                str.AppendLine("No answers");
            }
            return str.ToString().Trim();

        }
    }
}
