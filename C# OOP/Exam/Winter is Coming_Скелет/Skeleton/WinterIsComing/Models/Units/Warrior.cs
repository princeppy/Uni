using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Models.CombatHandlers;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.Units
{
    public class Warrior:Unit
    {
        private const int InitialAttackPoints = 120;
        private const int InitialHealthPoints = 180;
        private const int InitialDefencePoints = 70;
        private const int InitialEnergyPoints = 60;
        private const int InitialRange = 1;

        public Warrior(string name, int x, int y)
            : base(
                name, x, y, InitialAttackPoints, InitialHealthPoints, InitialDefencePoints, InitialEnergyPoints,
                InitialRange)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }


        
    }
}
