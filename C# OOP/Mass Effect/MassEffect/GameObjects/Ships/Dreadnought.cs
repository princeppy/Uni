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
    public class Dreadnought : Ship, IStarship
    {
        private const int InitialHealth = 200;
        private const int InitialShields = 300;
        private const int InitialDamage = 150;
        private const int InitialFuel = 700;
        public Dreadnought(string name, StarSystem location)
            : base(name, InitialHealth, InitialShields, InitialDamage, InitialFuel, location)
        {
            
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields/2);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            attack.Hit(this);
            this.Shields -= 50;
        }
    }
}
