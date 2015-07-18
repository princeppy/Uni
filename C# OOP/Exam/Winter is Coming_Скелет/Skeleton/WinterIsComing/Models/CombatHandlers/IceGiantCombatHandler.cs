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
    public class IceGiantCombatHandler : ICombatHandler
    {
        public IceGiantCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }
        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var pickedTargets = new List<IUnit>();

            if (this.Unit.HealthPoints <= 150)
            {
                var target = candidateTargets.FirstOrDefault();
                pickedTargets.Add(target);
            }
            else
            {
                pickedTargets.AddRange(candidateTargets);
            }
            return pickedTargets;
        }

        public ISpell GenerateAttack()
        {
            var damage = this.Unit.AttackPoints;
            var spellToUse = new Stomp(damage);

            Validator.ValidateEnergy(this.Unit,spellToUse);
            this.Unit.EnergyPoints -= spellToUse.EnergyCost;
            this.Unit.AttackPoints += spellToUse.AttackIncrease;
            return spellToUse;
        }
    }
}
