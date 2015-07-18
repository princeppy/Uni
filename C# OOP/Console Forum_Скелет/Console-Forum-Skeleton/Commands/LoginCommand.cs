using ConsoleForum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    public class LoginCommand:AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }
        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);


            if (users.Any(u => u.Username == username))
            {
                var currentUser = users.FirstOrDefault(x => x.Username == username);
                if (this.Forum.CurrentUser !=null)
                {
                    Console.WriteLine(Messages.AlreadyLoggedIn);
                }
                else
                {
                    if (currentUser.Password == password)
                    {
                        //"User {0} successfully logged in"
                        Console.WriteLine(Messages.LoginSuccess,currentUser.Username);
                        this.Forum.CurrentUser = currentUser;
                    }
                    else
                    {
                        Console.WriteLine(Messages.InvalidLoginDetails);
                    }
                    
                }
            }
            else
            {
                Console.WriteLine(Messages.InvalidLoginDetails);
            }
        }
    }
}
