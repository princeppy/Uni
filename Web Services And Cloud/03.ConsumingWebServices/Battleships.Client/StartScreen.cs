using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Client
{
    public partial class StartScreen : Form
    {
        private string server;

        public StartScreen(string server)
        {
            this.server = server;
            InitializeComponent();
            this.CenterToScreen();
            this.ArrangeComponents();
        }

        private void LoginFormStart(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(this.server);
            loginForm.Show();
        }

        private void RegisterFormStart(object sender, EventArgs e)
        {
            var regForm = new RegisterForm(this.server);
            regForm.Show();
            
        }

        private void ArrangeComponents()
        {
// 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoginFormStart);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "REGISTER";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RegisterFormStart);
        }
    }
}
