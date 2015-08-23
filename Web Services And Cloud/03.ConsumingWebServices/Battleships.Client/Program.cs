using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleships.Data;

namespace Battleships.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var ctx = new ApplicationDbContext();
            var games = ctx.Games;
            ctx.SaveChanges();
            //Change the server with your own :)
            string server = "http://localhost:62858";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartScreen(server));
        }
    }
}
