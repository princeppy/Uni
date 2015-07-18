using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostAnswerCommand:AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }
        public override void Execute()
        {
            
            var body = this.Data[1];
            

            if (this.Forum.CurrentQuestion == null)
            {
                Console.WriteLine(Messages.NoQuestionOpened);
            }
            else if (this.Forum.CurrentUser == null)
            {
                Console.WriteLine(Messages.NotLogged);
            }
            else
            {
                var currAnswer = new Answer(body);
                currAnswer.Id = this.Forum.CurrentQuestion.Answers.Count + 1;
                currAnswer.Author = this.Forum.CurrentUser;
                this.Forum.CurrentQuestion.Answers.Add(currAnswer);
                Console.WriteLine(Messages.PostAnswerSuccess,currAnswer.Id);
            }
            
        }
    }
}
