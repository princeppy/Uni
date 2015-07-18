using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Core.Validator;
using WinterIsComing.Models.Spells;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.CombatHandlers
{
    public class WarriorCombatHandler : ICombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }
        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var pickedTargets = new List<IUnit>();
            var target = candidateTargets.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name).FirstOrDefault();
            if (target == null)
            {
                return new List<IUnit>();
            }
            pickedTargets.Add(target);
            return pickedTargets;
        }

        public ISpell GenerateAttack()
        {
            var damage = this.Unit.HealthPoints <= 80
                ? (this.Unit.AttackPoints + this.Unit.HealthPoints * 2)
                : this.Unit.AttackPoints;

            var spellToUse = new Cleave(damage);

            Validator.ValidateEnergy(this.Unit, spellToUse);

            if (this.Unit.HealthPoints > 50)
            {
                this.Unit.EnergyPoints -= spellToUse.EnergyCost;
            }
            
            
            return new Cleave(damage);
        }
    }
}
