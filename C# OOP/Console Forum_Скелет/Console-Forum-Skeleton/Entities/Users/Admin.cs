﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Users
{
    public class Admin : User, IAdministrator
    {
        public Admin(int id, string name, string password, string email)
            : base(id, name, password, email)
        {

        }
    }
}
