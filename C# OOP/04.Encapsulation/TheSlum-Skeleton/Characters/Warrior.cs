using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Warrior : AttackableCharacter
    {
        private const int InitialHealthPoints = 200;
        private const int InitialDefensePoints = 100;

        private const int InitialAttackPoints = 150;

        private const int InitialRange = 2;

        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, InitialHealthPoints, InitialDefensePoints, team, InitialRange)
        {
            this.AttackPoints = InitialAttackPoints;
        }


        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.FirstOrDefault(x => x.IsAlive == true && this.Team != x.Team);
        }
    }
}
