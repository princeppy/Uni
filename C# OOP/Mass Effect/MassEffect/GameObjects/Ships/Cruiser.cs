using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : Ship, IStarship
    {
        private const int InitialHealth = 100;
        private const int InitialShields = 100;
        private const int InitialDamage = 50;
        private const int InitialFuel = 300;
        public Cruiser(string name, StarSystem location)
            : base(name, InitialHealth, InitialShields, InitialDamage, InitialFuel, location)
        {
            
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
