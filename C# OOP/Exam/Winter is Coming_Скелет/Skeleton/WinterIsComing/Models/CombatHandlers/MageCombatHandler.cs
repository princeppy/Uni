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
    public class MageCombatHandler : ICombatHandler
    {
        private int spellCounter = 0;
        public MageCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }
        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var pickedTargets = candidateTargets.OrderByDescending(x => x.HealthPoints).ThenBy(x => x.Name).Take(3);
            return pickedTargets;
        }

        public ISpell GenerateAttack()
        {
            var fireBreathDamage = this.Unit.AttackPoints;
            var fireBreathSpell = new FireBreath(fireBreathDamage);
            var blizzardDamage = this.Unit.AttackPoints * 2;
            var blizzardSpell = new Blizzard(blizzardDamage);

            //Create list of spells
            var spellsList = new List<ISpell>() { fireBreathSpell, blizzardSpell };

            //Pick the spell to use accordingly the turn
            var spellToUse = spellsList[spellCounter % spellsList.Count];

            Validator.ValidateEnergy(this.Unit, spellToUse);
            this.Unit.EnergyPoints -= spellToUse.EnergyCost;
            spellCounter++;
            return spellToUse;
        }
    }
}
