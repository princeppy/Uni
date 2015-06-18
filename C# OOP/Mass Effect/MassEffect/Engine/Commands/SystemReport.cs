using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.Engine.Commands;
using MassEffect.Interfaces;

namespace MassEffect.Engine
{
    class SystemReport : Command
    {
        public SystemReport(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            //            Intact ships:
            //{information about ship_1}
            //{information about ship_2}
            //Destroyed ships:
            //{information about ship_3}
            string starSystem = commandArgs[1];

            StringBuilder str = new StringBuilder();

            var intactShips =
                this.GameEngine.Starships.Where(x => x.Health > 0)
                    .Where(x => x.Location.Name == starSystem)
                    .OrderByDescending(x => x.Health)
                    .ThenByDescending(x => x.Shields);
            str.AppendLine("Intact ships:");
            if (intactShips.Count() == 0)
            {
                str.AppendLine("N/A");
            }
            else
            {
                foreach (var s in intactShips)
                {
                    str.AppendLine(s.ToString());
                }
            }


            str.AppendLine("Destroyed ships:");
            var destroyedShips = this.GameEngine.Starships
                .Where(x => x.Health <= 0)
                .Where(x => x.Location.Name == starSystem)
                .OrderBy(x => x.Name);
            if (destroyedShips.Count() == 0)
            {
                str.AppendLine("N/A");
            }
            else
            {
                foreach (var s in destroyedShips)
                {
                    str.AppendLine(s.ToString());
                }
            }
            Console.WriteLine(str.ToString().Trim());
        }
    }
}
