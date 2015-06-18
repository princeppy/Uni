using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public abstract class AttackableCharacter : BasicCharacter, IAttack
    {
        
        public AttackableCharacter(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            
        }

        public int AttackPoints { get; set; }

        public override void AddToInventory(Item item)
        {

            
            switch (item.GetType().Name)
            {
                case "Axe":
                    this.Inventory.Add(item);
                    this.AttackPoints += item.AttackEffect;
                    break;
                case "Pill":
                    this.Inventory.Add(item);
                    this.AttackPoints += item.AttackEffect;
                    break;
                default:
                    base.AddToInventory(item);
                    break;
            }

        }

        public override void RemoveFromInventory(Item item)
        {
            
            switch (item.GetType().Name)
            {
                case "Pill":
                    this.AttackPoints -= item.AttackEffect;
                    this.Inventory.Remove(item);
                    break;
                default:
                    base.RemoveFromInventory(item);
                    break;

            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("-- "+base.ToString());
            return str.Append(String.Format(", Attack: {0}", this.AttackPoints)).ToString();

        }
    }
}
