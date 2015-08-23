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
    public partial class RegisterForm : Form
    {
        private string server;

        public RegisterForm(string server)
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

        private void PasswordConfirm(object sender, EventArgs e)
        {

        }

        private async void RegisterButton(object sender, EventArgs e)
        {
            string RegisterEndpoint = this.server + "/api/Account/Register";
            HttpClient client = new HttpClient();

            var bodyData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email",this.username.Text),
                new KeyValuePair<string, string>("password", this.password.Text), 
                new KeyValuePair<string, string>("confirmPassword", this.passwordConfirm.Text), 
            });

            var response = await client.PostAsync(RegisterEndpoint, bodyData);

            var result = response.Content.ReadAsAsync<ResponseResultViewModel>();


            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Register completed");
                this.Close();
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, result.Result.ModelState.Select(m => m.Value)).Replace("]", "").Replace("[", ""));
                this.password.Clear();
                this.passwordConfirm.Clear();
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void ArrangeComponents()
        {
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(131, 12);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(195, 20);
            this.username.TabIndex = 0;
            this.username.TextChanged += new System.EventHandler(this.Username);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(131, 47);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(195, 20);
            this.password.TabIndex = 1;
            this.password.TextChanged += new System.EventHandler(this.Password);
            // 
            // passwordConfirm
            // 
            this.passwordConfirm.Location = new System.Drawing.Point(131, 83);
            this.passwordConfirm.Name = "passwordConfirm";
            this.passwordConfirm.PasswordChar = '*';
            this.passwordConfirm.Size = new System.Drawing.Size(195, 20);
            this.passwordConfirm.TabIndex = 2;
            this.passwordConfirm.TextChanged += new System.EventHandler(this.PasswordConfirm);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(178, 119);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(90, 20);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Register";
            this.registerButton.Click += new System.EventHandler(this.RegisterButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confrim password";
        }
    }
}
