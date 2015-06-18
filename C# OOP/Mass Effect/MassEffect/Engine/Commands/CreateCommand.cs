using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string name = commandArgs[2];
            string location = commandArgs[3];

            var shipExist = this.GameEngine.Starships.Any(x => x.Name == name);

            if (shipExist)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            var locationSystem = this.GameEngine.Galaxy.GetStarSystemByName(location);


            StarshipType shipType = (StarshipType) Enum.Parse(typeof (StarshipType), type);
            

            var ship = this.GameEngine.ShipFactory.CreateShip(shipType, name, locationSystem);

            this.GameEngine.Starships.Add(ship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                //Console.WriteLine(commandArgs[i]);
                var enhancementType = (EnhancementType)Enum.Parse(typeof (EnhancementType), commandArgs[i]);
                var enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                ship.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip,shipType, name);


        }
    }
}
