﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    class Pill:Bonus
    {
        private const int InitialTimeout=1;
        public Pill(string id)
            : base(id,0,0,100)
        {
            this.Timeout = InitialTimeout;
            this.Countdown = this.Timeout;
            this.HasTimedOut = false;
        }
    }
}
