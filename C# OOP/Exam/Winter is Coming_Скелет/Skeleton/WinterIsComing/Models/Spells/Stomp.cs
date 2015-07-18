using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Stomp:Spell
    {
        private const int InitialEnergyCost = 10;
        private const int AttackIncreaseValue = 5;
        public int AttackIncrease { get; private set; }
        public Stomp(int damage)
            : base(InitialEnergyCost, damage)
        {
            this.AttackIncrease = AttackIncreaseValue;
        }
    }
}
