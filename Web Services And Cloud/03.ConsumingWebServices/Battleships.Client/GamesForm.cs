using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleships.WebServices.Models;
using Battleships.WebServices.Models.ViewModels;

namespace Battleships.Client
{
    public partial class GamesForm : Form
    {
        private string server;
        private string loggedUser;

        public List<GameViewModel> games = new List<GameViewModel>();
        public GamesForm(List<GameViewModel> games, string server, string username)
        {
            this.server = server;
            this.games = games;
            this.loggedUser = username;
            InitializeComponent();
            this.Height = this.games.Count * 40 + 40;
            this.Width = 350;
            CreateButtons(this.games.Count, this.games);
            CreateLabels(this.games.Count, this.games);
            this.CenterToScreen();
            this.ArrangeComponents();
        }

        private void CreateButtons(int length, List<GameViewModel> games)
        {
            Button[] buttons = new Button[length];
            for (int i = 0; i < buttons.Length; i++)
            {

                buttons[i] = new Button();
                Point p = new Point(this.Width - buttons[i].Width * 2, (i + 1) * 30);
                buttons[i].Location = p;
                var gameId = games[i].Id.ToString();
                if (games[i].PlayerOneName != this.loggedUser)
                {
                    buttons[i].Text = "Join Game " + i.ToString();
                    buttons[i].Click += (s, e) => this.JoinGame(s, e);
                }
                else
                {
                    buttons[i].Text = "Play Game " + i.ToString();
                    buttons[i].Click += (s, e) =>
                    {
                        var joinedGame = new PlayGameForm(this.server, gameId, this.token.Text);
                        joinedGame.Show();
                        this.Close();
                    };
                }
                buttons[i].Name = games[i].Id.ToString();

                this.Controls.Add(buttons[i]);
            }
        }



        private void CreateLabels(int length, List<GameViewModel> games)
        {
            Label[] labels = new Label[length];
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                Point p1 = new Point(25, (i + 1) * 30);
                labels[i].Location = p1;
                labels[i].Text = "Player One: " + games[i].PlayerOneName;
                labels[i].Name = "Player One";
                labels[i].AutoSize = true;
                this.Controls.Add(labels[i]);
            }
        }

        private async void JoinGame(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var JoinGameEndpoint = this.server + "/api/games/join";

            Button btn = (Button)sender;

            string gameId = btn.Name;
            int btnNum = int.Parse(btn.Text.Split(' ')[2]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Text);

            var body = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("GameId",gameId)
            });

            var response = await client.PostAsync(JoinGameEndpoint, body);

            if (response.IsSuccessStatusCode)
            {
                var joinedGame = new PlayGameForm(this.server, gameId, this.token.Text);
                joinedGame.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("You cannot join to your own game");
            }

        }

        private void ArrangeComponents()
        {
            this.token.Name = "token";
            this.token.Hide();
            this.token.AcceptsTab = false;
        }
    }
}
