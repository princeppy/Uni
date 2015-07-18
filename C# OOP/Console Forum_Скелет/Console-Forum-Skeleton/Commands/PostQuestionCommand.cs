using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostQuestionCommand:AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }
        public override void Execute()
        {
            var title = this.Data[1];
            var body = this.Data[2];
            if (this.Forum.CurrentUser == null)
            {
                Console.WriteLine(Messages.NotLogged);
            }
            else
            {
                var questionToPost = new Question(title,body);
                questionToPost.Id = this.Forum.Questions.Count + 1;
                questionToPost.Author = this.Forum.CurrentUser;
                this.Forum.Questions.Add(questionToPost);
                Console.WriteLine(Messages.PostQuestionSuccess,questionToPost.Id);
            }
        }
    }
}
