using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class FireBreath:Spell
    {
        private const int InitialEnergyCost = 30;
        public FireBreath(int damage)
            : base(InitialEnergyCost, damage)
        {
        }
    }
}
