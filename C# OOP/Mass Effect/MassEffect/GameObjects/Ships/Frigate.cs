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
    public class Frigate : Ship, IStarship
    {
        private const int InitialHealth = 60;
        private const int InitialShields = 50;
        private const int InitialDamage = 30;
        private const int InitialFuel = 220;
        public Frigate(string name, StarSystem location)
            : base(name, InitialHealth, InitialShields, InitialDamage, InitialFuel, location)
        {
            this.ProjectilesCount = 0;
        }

        public int ProjectilesCount { get; set; }
        public override IProjectile ProduceAttack()
        {
            this.ProjectilesCount++;
            return new ShieldReaver(this.Damage);
        }
    }
}
