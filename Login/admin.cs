using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = usertext.Text;
            string password = PasswordText.Text;

            if (username == "admin" && password == "123")
            {
                MessageBox.Show("Login Success");

                account m = new account();
                m.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Login Failed");
                usertext.Clear();
                PasswordText.Clear();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            F.Show();
            this.Hide();
        }
    }
}
