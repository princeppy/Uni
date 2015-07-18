using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Core.Validator
{
    public static class Validator
    {

        public static void ValidateEnergy(IUnit unit, ISpell spell)
        {
            if (unit.EnergyPoints < spell.EnergyCost)
            {
                string msg = String.Format(GlobalMessages.NotEnoughEnergy, unit.Name,
                    spell.GetType().Name);
                throw new NotEnoughEnergyException(msg);
            }
        }
    }
}
