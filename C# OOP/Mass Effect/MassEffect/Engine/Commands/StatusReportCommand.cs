using System;
using System.Linq;
using System.Text;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            StringBuilder str = new StringBuilder();
            var name = commandArgs[1];

            var ship = this.GameEngine.Starships.FirstOrDefault(x => x.Name == name) as Ship;

            
            
                str.Append(ship.ToString());

            
            Console.WriteLine(str.ToString());
        }
    }
}
