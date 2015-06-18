using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }


        public override void Execute(string[] commandArgs)
        {
            string attackerShipName = commandArgs[1];
            string targetShipName = commandArgs[2];

            Ship attackerShip = this.GameEngine.Starships.FirstOrDefault(x => x.Name == attackerShipName) as Ship;
            Ship targetShip = this.GameEngine.Starships.FirstOrDefault(x => x.Name == targetShipName) as Ship;

            ProcessShipInteraction(attackerShip, targetShip);
        }

        private static void ProcessShipInteraction(Ship attackerShip, Ship targetShip)
        {
            if (attackerShip.Location != targetShip.Location)
            {
                throw new LocationOutOfRangeException(Messages.NoSuchShipInStarSystem);
            }

            
            if (!attackerShip.IsAlive())
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
            if (!targetShip.IsAlive())
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }

            IProjectile projectile = attackerShip.ProduceAttack();
            targetShip.RespondToAttack(projectile);

            Console.WriteLine(Messages.ShipAttacked,attackerShip.Name,targetShip.Name);
            if (!targetShip.IsAlive())
            {
                Console.WriteLine(Messages.ShipDestroyed,targetShip.Name);
            }
            
        }
    }
}
