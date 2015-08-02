using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Diablo.Data;

namespace _03.ExportFinishedGamesAsXml
{
    class ExportFinishedGamesAsXml
    {
        static void Main(string[] args)
        {

            var ctx = new DiabloEntities();

            var games = ctx.Games
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Where(g=>g.IsFinished==true)
                .Select(g => new
                {
                    g.Name,
                    g.Duration,
                    users = g.UsersGames.Select(ug => new
                    {
                        ug.User.Username,
                        ug.User.IpAddress
                    })
                });

            XDocument xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            var root = new XElement("games");
            xmlDoc.Add(root);

            foreach (var game in games)
            {
                var gameNode = new XElement("game");
                var gameNameAttr = new XAttribute("name", game.Name);
                gameNode.Add(gameNameAttr);
                var gameDuration = game.Duration;

                if (gameDuration != null)
                {
                    var gameDurationAttr = new XAttribute("duration", gameDuration);
                    gameNode.Add(gameDurationAttr);
                }

                var users = game.users;
                var usersNode = new XElement("users");

                foreach (var user in users)
                {
                    var singleUserNode = new XElement("user");
                    var usernameAttr = new XAttribute("username", user.Username);
                    var ipAddressAttr = new XAttribute("ip-address", user.IpAddress);

                    singleUserNode.Add(usernameAttr);
                    singleUserNode.Add(ipAddressAttr);
                    usersNode.Add(singleUserNode);
                }
                
                gameNode.Add(usersNode);
                root.Add(gameNode);
            }

            Console.WriteLine(xmlDoc);
            xmlDoc.Save("../../finished-games.xml");
        }
    }
}
