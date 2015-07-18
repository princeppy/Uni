using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Mage:Unit
    {
        private const int InitialAttackPoints = 80;
        private const int InitialHealthPoints = 80;
        private const int InitialDefencePoints = 40;
        private const int InitialEnergyPoints = 120;
        private const int InitialRange = 2;

        public Mage(string name, int x, int y)
            : base(
                name, x, y, InitialAttackPoints, InitialHealthPoints, InitialDefencePoints, InitialEnergyPoints,
                InitialRange)
        {
            this.CombatHandler = new MageCombatHandler(this);
        }

        
    }
}
