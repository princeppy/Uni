using ConsoleForum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    public class LogoutCommand:AbstractCommand
    {
        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }
        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;
            if (this.Forum.IsLogged)
            {
                this.Forum.CurrentUser = null;
                Console.WriteLine(Messages.LogoutSuccess);
            }
            else
            {
                Console.WriteLine(Messages.NotLogged);
            }
            
        }
    }
}
