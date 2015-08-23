using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleships.WebServices.Models;
using Battleships.WebServices.Models.ViewModels;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Battleships.Models;

namespace Battleships.Client
{
    public partial class PlayerForm : Form
    {
        private string server;
        private string username;

        public PlayerForm(string server, string username)
        {
            this.username = username;
            this.server = server;
            InitializeComponent();
            this.CenterToParent();
            this.ArrangeComponents();
        }

        private void Token(object sender, EventArgs e)
        {
        }

        private async void CreateGameButton(object sender, EventArgs e)
        {
            var token = this.token.Text;
            var CreateGameEndpoint = this.server + "/api/games/create";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var response = await client.PostAsync(CreateGameEndpoint, null);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(response.Content.ReadAsStringAsync().Result);
            }

        }

        private async void GetAvailableGames(object sender, EventArgs e)
        {
            var token = this.token.Text;
            var AvaiilableGamesEndpoint = this.server + "/api/games/available";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var response = await client.GetAsync(AvaiilableGamesEndpoint);


            if (response.IsSuccessStatusCode)
            {

                var games = response.Content.ReadAsAsync<List<GameViewModel>>().Result;
                var gamesForm = new GamesForm(games, this.server, this.username);
                gamesForm.token = this.token;
                gamesForm.Show();
            }
        }


        private void ArrangeComponents()
        {
            //token
            this.token.Name = "token";
            this.token.AcceptsTab = false;
            this.token.Hide();

            // 
            // createGameBtn
            // 
            this.createGameBtn.Location = new System.Drawing.Point(62, 12);
            this.createGameBtn.Name = "createGameBtn";
            this.createGameBtn.Size = new System.Drawing.Size(90, 20);
            this.createGameBtn.TabIndex = 3;
            this.createGameBtn.Text = "Create Game";
            this.createGameBtn.Click += new System.EventHandler(this.CreateGameButton);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Get Available Games";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GetAvailableGames);
        }
    }
}
