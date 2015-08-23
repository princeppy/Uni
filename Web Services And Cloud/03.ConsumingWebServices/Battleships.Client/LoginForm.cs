using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleships.WebServices.Models;
using Battleships.WebServices.Models.ViewModels;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Battleships.Client
{
    public partial class LoginForm : Form
    {
        private string server;

        public LoginForm(string server)
        {
            this.server = server;
            InitializeComponent();
            this.CenterToScreen();
            this.ArrangeComponents();
        }

        private void Username(object sender, EventArgs e)
        {

        }

        private void Password(object sender, EventArgs e)
        {

        }



        private async void LoginButton(object sender, EventArgs e)
        {
            string TokenEndpoint = this.server+"/Token";
            HttpClient client = new HttpClient();

            var bodyData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username",this.username.Text),
                new KeyValuePair<string, string>("password", this.password.Text),
                new KeyValuePair<string, string>("grant_type", "password"),
 
            });

            var response = await client.PostAsync(TokenEndpoint, bodyData);

            var result = response.Content.ReadAsAsync<AccessTokenViewModel>();


            if (response.IsSuccessStatusCode)
            {
                var playerForm = new PlayerForm(this.server, this.username.Text);
                this.Close();
                playerForm.token.Text = result.Result.access_token;
                playerForm.Show();
            }
            else
            {
                MessageBox.Show("No such user");
                this.username.Clear();
                this.password.Clear();
            }

        }

        private void ArrangeComponents()
        {
// 
            // username
            // 
            this.username.Location = new System.Drawing.Point(137, 12);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(195, 20);
            this.username.TabIndex = 0;
            this.username.TextChanged += new System.EventHandler(this.Username);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(137, 48);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(195, 20);
            this.password.TabIndex = 1;
            this.password.TextChanged += new System.EventHandler(this.Password);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(188, 87);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(90, 20);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.Click += new System.EventHandler(this.LoginButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
        }
    }
}
