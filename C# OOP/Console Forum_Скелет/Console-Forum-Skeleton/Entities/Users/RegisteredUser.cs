using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Entities.Users
{
    public class RegisteredUser : User
    {
        public RegisteredUser(int id, string name, string password, string email)
            : base(id, name, password, email)
        {

        }
    }
}
