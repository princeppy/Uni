using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    class Shield : Item
    {
        private const int InitialHealthEffect = 0;
        private const int InitialDefenseEffect = 50;
        private const int InitialAttackEffect = 0;

        public Shield(string id)
            : base(id, InitialHealthEffect, InitialDefenseEffect, InitialAttackEffect)
        {

        }
    }
}
