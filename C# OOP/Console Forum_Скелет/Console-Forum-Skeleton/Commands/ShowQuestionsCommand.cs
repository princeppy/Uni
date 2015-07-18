using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class ShowQuestionsCommand:AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }
        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;
            var questionsOpened = this.Forum.Questions.OrderBy(x=>x.Id);
            if (questionsOpened.Any())
            {
                foreach (var question in this.Forum.Questions)
                {
                    Console.WriteLine(question);
                    
                }
            }
            else
            {
                Console.WriteLine(Messages.NoQuestions);
            }
            
        }
    }
}
