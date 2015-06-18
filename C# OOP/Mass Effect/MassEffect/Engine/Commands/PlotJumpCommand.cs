using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string starSystem = commandArgs[2];


            Ship ship = this.GameEngine.Starships.FirstOrDefault(x => x.Name == shipName) as Ship;

            var oldLocation = ship.Location.Name;
            if (!ship.IsAlive())
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
            if (ship.Location.Name == starSystem)
            {
                throw new LocationOutOfRangeException(String.Format(Messages.ShipAlreadyInStarSystem,oldLocation));
            }
            this.GameEngine.Galaxy.TravelTo(ship,this.GameEngine.Galaxy.GetStarSystemByName(starSystem));


            Console.WriteLine(Messages.ShipTraveled,ship.Name, oldLocation,ship.Location.Name);
            
        }
    }
}
