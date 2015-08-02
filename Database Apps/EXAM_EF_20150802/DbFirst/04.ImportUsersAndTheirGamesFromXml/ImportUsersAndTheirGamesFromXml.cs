using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Diablo.Data;

namespace _04.ImportUsersAndTheirGamesFromXml
{
    class ImportUsersAndTheirGamesFromXml
    {
        static void Main(string[] args)
        {
            var ctx = new DiabloEntities();

            var xmlDoc = XDocument.Load("../../users-and-games.xml");

            var users = xmlDoc.Root.Elements();

            var usersInDb = ctx.Users;
            var gamesInDb = ctx.Games;

            foreach (var user in users)
            {
                var firstName = user.Attribute("first-name") != null ? user.Attribute("first-name").Value : null;
                var lastName = user.Attribute("last-name") != null ? user.Attribute("last-name").Value : null;
                var email = user.Attribute("email") != null ? user.Attribute("email").Value : null;
                var username = user.Attribute("username").Value;
                var isDeleted = user.Attribute("is-deleted").Value=="0"?false:true;
                var ipAddress = user.Attribute("ip-address").Value;
                var date = DateTime.Parse(user.Attribute("registration-date").Value);


                // Check if user exist in DB and continue if so
                if (usersInDb.Any(u => u.Username == username))
                {
                    Console.WriteLine("User {0} already exists", username);
                    continue;
                }
                var userToAdd = new User()
                {
                    Username = username,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    RegistrationDate = date,
                    IsDeleted = isDeleted,
                    IpAddress = ipAddress
                   
                };


                ctx.Users.Add(userToAdd);

                var games = user.Element("games").Elements();

                var shouldAddUser = true;
                var gamesList = new List<Game>();
                foreach (var game in games)
                {
                    var isGameExist = true;
                    
                        var gameName = game.Element("game-name").Value;
                        var character = game.Element("character");
                        var characterName = character.Attribute("name").Value;
                        var characterCash = character.Attribute("cash").Value;
                        var characterLevel = character.Attribute("level").Value;
                        var joined = game.Element("joined-on").Value;

                        // If game does not exist in DB break
                        if (!gamesInDb.Any(g => g.Name == gameName))
                        {
                            isGameExist = false;
                            shouldAddUser = false;
                            break;
                        }

                        var gameToAddUserTo = ctx.Games.FirstOrDefault(g => g.Name == gameName);

                        var characterToAdd = ctx.Characters.FirstOrDefault(c=>c.Name == characterName);

                        ctx.UsersGames.Add(new UsersGame()
                        {
                            User = userToAdd,
                            Character = characterToAdd,
                            Cash = decimal.Parse(characterCash),
                            Level = int.Parse(characterLevel),
                            JoinedOn = DateTime.Parse(joined),
                            Game = gameToAddUserTo
                            
                        });

                    gamesList.Add(gameToAddUserTo);
                    
                }

                // Add the user only if all the games are valid
                if (shouldAddUser == true)
                {
                    ctx.SaveChanges();
                    Console.WriteLine("Successfully added user {0}", userToAdd.Username);
                    foreach (var game in gamesList)
                    {
                        Console.WriteLine("User {0} successfully added to game Star of {1}", userToAdd.Username, game.Name);
                    }
                    
                }
            }
        }
    }
}
