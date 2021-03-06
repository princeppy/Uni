﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int InitialTimeout = 3;

        public Injection(string id)
            : base(id, 200, 0, 0)
        {
            this.Timeout = InitialTimeout;
            this.Countdown = this.Timeout;
            this.HasTimedOut = false;
        }
    }
}
