using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Mage : AttackableCharacter
    {
        private const int InitialHealthPoints = 150;
        private const int InitialDefensePoints = 50;

        private const int InitialAttackPoints = 300;

        private const int InitialRange = 5;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, InitialHealthPoints, InitialDefensePoints, team, InitialRange)
        {
            this.AttackPoints = InitialAttackPoints;
        }


        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.LastOrDefault(x => x.IsAlive == true && this.Team != x.Team);
        }
    }
}
