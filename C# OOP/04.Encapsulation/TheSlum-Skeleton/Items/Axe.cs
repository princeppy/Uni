using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    class Axe : Item
    {
        private const int InitialHealthEffect = 0;
        private const int InitialDefenseEffect = 0;
        private const int InitialAttackEffect = 75;

        public Axe(string id)
            : base(id, InitialHealthEffect, InitialDefenseEffect, InitialAttackEffect)
        {

        }
    }
}
