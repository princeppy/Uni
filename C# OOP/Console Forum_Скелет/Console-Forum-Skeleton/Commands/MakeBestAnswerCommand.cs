using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;
using ConsoleForum.Entities.Users;

namespace ConsoleForum.Commands
{
    class MakeBestAnswerCommand:AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }
        public override void Execute()
        {
            var id = int.Parse(this.Data[1]);
             if (this.Forum.CurrentQuestion == null)
            {
                Console.WriteLine(Messages.NoQuestionOpened);
                 return;
            }
            var currentAnswer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(x => x.Id == id);
            if (this.Forum.CurrentUser == null)
            {
                Console.WriteLine(Messages.NotLogged);
                return;
            }

            
            else if (currentAnswer == null)
            {
                Console.WriteLine(Messages.NoAnswer);
                return;
            }
            else if (!(this.Forum.CurrentUser is Admin)&&this.Forum.CurrentQuestion.Author!=this.Forum.CurrentUser)
            {
                Console.WriteLine(Messages.NoPermission);
            }
            else
            {
                if (!(currentAnswer is BestAnswer))
                {
                    BestAnswer best = new BestAnswer(currentAnswer.Body);
                    best.Id = currentAnswer.Id;
                    best.Author = currentAnswer.Author;

                    this.Forum.CurrentQuestion.Answers.Remove(currentAnswer);
                    this.Forum.CurrentQuestion.Answers.Add(best);
                    Console.WriteLine(Messages.BestAnswerSuccess, best.Id);
                }
            }
        }
    }
}
