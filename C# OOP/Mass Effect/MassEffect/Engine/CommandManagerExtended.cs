namespace MassEffect.Engine
{
    using System;
    using System.Collections.Generic;

    using MassEffect.Engine.Commands;
    using MassEffect.Interfaces;

    public class CommandManagerExtended : CommandManager
    {

        public CommandManagerExtended():base()
        {
            
        }

        public override void SeedCommands()
        {
            this.commandsByName["system-report"] = new SystemReport(this.Engine);
            base.SeedCommands();
        }
    }
}
