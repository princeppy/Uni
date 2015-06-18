using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Healer : BasicCharacter, IHeal
    {
        private const int InitialHealthPoints = 75;
        private const int InitialDefensePoints = 50;

        private const int InitialHealingPoints = 60;

        private const int InitialRange = 6;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, InitialHealthPoints, InitialDefensePoints, team, InitialRange)
        {
            this.HealingPoints = InitialHealingPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            
            return targetsList.OrderBy(x => x.HealthPoints).FirstOrDefault(x=>x.Id!=this.Id&&x.IsAlive==true&&x.Team==this.Team);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("-- "+base.ToString());
            return str.Append(String.Format(", Healing: {0}", this.HealingPoints)).ToString();

        }
    }
}




