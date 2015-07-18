using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class Spell:ISpell
    {
        protected Spell(int energyCost, int damage)
        {
            this.EnergyCost = energyCost;
            this.Damage = damage;
        }
        public int Damage { get; set; }

        public int EnergyCost { get; set; }
    }
}
