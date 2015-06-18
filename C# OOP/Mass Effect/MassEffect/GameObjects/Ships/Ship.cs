using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Engine;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{


    public abstract class Ship : IStarship, IEnhanceable
    {
        private List<Enhancement> enhancements;
        private int health;
        private int shields;
        protected Ship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();

        }
        public string Name { get; set; }

        public int Health
        {
            get
            {
                if (this.health <= 0)
                {
                    this.health = 0;
                }
                return this.health;
            }
            set { this.health = value; }
        }

        public int Shields
        {
            get
            {
                if (this.shields <= 0)
                {
                    this.shields = 0;
                }
                return this.shields;
            }
            set { this.shields = value; }
        }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();


        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public IEnumerable<Enhancements.Enhancement> Enhancements
        {
            get { return this.enhancements; }

        }

        public void AddEnhancement(Enhancements.Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null");
            }

            this.enhancements.Add(enhancement);
            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public virtual bool IsAlive()
        {
            if (this.Health > 0)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(String.Format("--{0} - {1}", this.Name, this.GetType().Name));
            if (this.Health <= 0)
            {
                str.Append("(Destroyed)");

            }
            else
            {
                str.AppendLine(String.Format("-Location: {0}", this.Location.Name));
                str.AppendLine(String.Format("-Health: {0}", this.Health));
                str.AppendLine(String.Format("-Shields: {0}", this.Shields));
                str.AppendLine(String.Format("-Damage: {0}", this.Damage));
                str.AppendLine(String.Format("-Fuel: {0:F1}", this.Fuel));
                str.AppendLine(String.Format("-Enhancements: {0}", this.Enhancements.Count() == 0 ? "N/A" : string.Join(", ", this.Enhancements)).Trim());
                if (this is Frigate)
                {
                    var s = this as Frigate;
                    str.Append(String.Format("-Projectiles fired: {0}", s.ProjectilesCount));
                }
            }

            return str.ToString().Trim();
        }
    }
}
