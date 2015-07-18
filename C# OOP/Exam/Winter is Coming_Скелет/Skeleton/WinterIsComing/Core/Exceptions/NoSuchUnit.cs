using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Core.Exceptions
{
    class NoSuchUnit:GameException
    {
        public NoSuchUnit(string msg)
            : base(msg)
        {
        }
    }
}
