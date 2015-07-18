using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class IceGiant:Unit
    {
        private const int InitialAttackPoints = 150;
        private const int InitialHealthPoints = 300;
        private const int InitialDefencePoints = 60;
        private const int InitialEnergyPoints = 50;
        private const int InitialRange = 1;

        public IceGiant(string name, int x, int y)
            : base(
                name, x, y, InitialAttackPoints, InitialHealthPoints, InitialDefencePoints, InitialEnergyPoints,
                InitialRange)
        {
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}
