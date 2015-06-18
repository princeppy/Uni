using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Characters
{
    public class BasicCharacter : Character
    {
        public BasicCharacter(string id, int x, int y, int healthPoints, int defensePoints,Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
        }
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            throw new NotImplementedException();
        }

        public override void AddToInventory(Item item)
        {

            
            switch (item.GetType().Name)
            {
                case "Injection":
                    this.Inventory.Add(item);
                    this.HealthPoints += item.HealthEffect;
                    break;
                case "Shield":
                    this.Inventory.Add(item);
                    this.DefensePoints += item.DefenseEffect;
                    break;
            }

        }

        public override void RemoveFromInventory(Item item)
        {
            
            switch (item.GetType().Name)
            {
                case "Injection":
                    this.Inventory.Remove(item);
                    this.HealthPoints -= item.HealthEffect;
                    if (this.HealthPoints < 1)
                    {
                        this.HealthPoints = 1;
                    }
                    break;
                
            }
        }
    }
}
