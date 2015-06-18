using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Characters;
using TheSlum.Interfaces;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    public class ExtendedGameEngine : Engine
    {
        
       

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;

            }

        }


        protected override void CreateCharacter(string[] inputParams)
        {
            switch (inputParams[1])
            {
                case "mage":
                    string id = inputParams[2];
                    int x = int.Parse(inputParams[3]);
                    int y = int.Parse(inputParams[4]);
                    Team team = inputParams[5] == "Blue" ? Team.Blue : Team.Red;
                    Mage mageChar = new Mage(id, x, y, team);
                    this.characterList.Add(mageChar);
                    break;
                case "warrior":
                    id = inputParams[2];
                    x = int.Parse(inputParams[3]);
                    y = int.Parse(inputParams[4]);
                    team = inputParams[5] == "Blue" ? Team.Blue : Team.Red;
                    Warrior warriorChar = new Warrior(id, x, y, team);
                    this.characterList.Add(warriorChar);
                    break;
                case "healer":
                    id = inputParams[2];
                    x = int.Parse(inputParams[3]);
                    y = int.Parse(inputParams[4]);
                    team = inputParams[5] == "Blue" ? Team.Blue : Team.Red;
                    Healer healChar = new Healer(id, x, y, team);
                    this.characterList.Add(healChar);
                    break;
            }
        }

        protected override void AddItem(string[] inputParams)
        {

            var characterName = inputParams[1];
            var character = this.characterList.Find(x => x.Id == characterName);

            switch (inputParams[2])
            {
                case "axe":
                    character.AddToInventory(new Axe(inputParams[3]));
                    break;
                case "shield":
                    character.AddToInventory(new Shield(inputParams[3]));
                    break;
                case "injection":
                    character.AddToInventory(new Injection(inputParams[3]));
                    break;
                case "pill":
                    character.AddToInventory(new Pill(inputParams[3]));
                    break;
            }
        }
    }
}
