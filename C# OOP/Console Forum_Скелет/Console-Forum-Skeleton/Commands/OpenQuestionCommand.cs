using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class OpenQuestionCommand:AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }
        public override void Execute()
        {
            var id = int.Parse(this.Data[1]);
            var currentQuestion = this.Forum.Questions.FirstOrDefault(x => x.Id == id);

            if (currentQuestion == null)
            {
                Console.WriteLine(Messages.NoQuestion);
            }
            else
            {
                this.Forum.CurrentQuestion = currentQuestion;
                Console.WriteLine(currentQuestion);
            }
        }
    }
}
