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
using Battleships.Data;

namespace Battleships.Client
{
    public partial class PlayGameForm : Form
    {
        private string server;
        private string gameId;
        private string playerToken;
        public PlayGameForm(string server, string gameId, string playerToken)
        {
            this.gameId = gameId;
            this.server = server;
            this.playerToken = playerToken;
            InitializeComponent();
            this.CenterToParent();
        }

        private async void PlayButton(object sender, EventArgs e)
        {
            var PlayGameEndpoint = this.server + "/api/games/play";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.playerToken);

            var body = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("GameId", this.gameId),
                new KeyValuePair<string, string>("PositionX",this.x.Text), 
                new KeyValuePair<string, string>("PositionY",this.y.Text)
            });

            var response = await client.PostAsync(PlayGameEndpoint, body);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Success :)");
            }
            else
            {
                MessageBox.Show(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
