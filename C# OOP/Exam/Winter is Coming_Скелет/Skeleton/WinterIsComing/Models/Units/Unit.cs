using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit:IUnit
    {
        protected Unit(string name, int x, int y, int attackPoints, int healthPoints, int defencePoints, int energyPoints,int range)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defencePoints;
            this.EnergyPoints = energyPoints;
        }
        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; set; }

        public int Range { get; set; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler { get; set; }


        public override string ToString()
        {
            //>{name} - {type} at ({x},{y})
            //-Health points = {..}
            //-Attack points = {..}
            //-Defense points = {..}
            //-Energy points = {..}
            //-Range = {..}

            StringBuilder write = new StringBuilder();
            write.AppendLine(String.Format(">{0} - {1} at ({2},{3})", this.Name, this.GetType().Name, this.X, this.Y));
            if (this.HealthPoints > 0)
            {
                write.AppendLine(String.Format("-Health points = {0}", this.HealthPoints));
                write.AppendLine(String.Format("-Attack points = {0}", this.AttackPoints));
                write.AppendLine(String.Format("-Defense points = {0}", this.DefensePoints));
                write.AppendLine(String.Format("-Energy points = {0}", this.EnergyPoints));
                write.AppendLine(String.Format("-Range = {0}", this.Range));

            }
            else
            {
                write.AppendLine("(Dead)");
            }
            return write.ToString().Trim();
        }
    }
}
