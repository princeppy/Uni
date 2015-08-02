using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diablo.Data;

namespace _01.ListAllCharacterNames
{
    class ListAllCharacterNames
    {
        static void Main(string[] args)
        {
            var ctx = new DiabloEntities();

            var characterNames = ctx.Characters.Select(c=>c.Name);

            foreach (var characterName in characterNames)
            {
                Console.WriteLine(characterName);

            }

        }
    }
}
