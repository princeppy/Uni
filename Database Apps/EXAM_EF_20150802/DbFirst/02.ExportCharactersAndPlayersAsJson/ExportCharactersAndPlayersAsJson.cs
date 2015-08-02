using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diablo.Data;
using Newtonsoft.Json;
using System.IO;

namespace _02.ExportCharactersAndPlayersAsJson
{
    class ExportCharactersAndPlayersAsJson
    {
        static void Main(string[] args)
        {
            var ctx = new DiabloEntities();

            var charactersAndPlayers = ctx.Characters.OrderBy(c => c.Name).Select(c => new
            {
                name = c.Name,
                playedBy = c.UsersGames.Select(ug => ug.User.Username)
            });

            var json = JsonConvert.SerializeObject(charactersAndPlayers, Formatting.Indented);

            Console.WriteLine(json);

            File.WriteAllText(@"..\..\characters.json", json);
        }
    }
}
