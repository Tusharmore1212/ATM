using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ht\New folder\Login\Login\ATMDb.mdf;Integrated Security=True;User Instance=True");

        private void ChangePin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pin1.Text == "" || pin2.Text == "")
            {
                MessageBox.Show("Enter and confirm new pin");
            }
            else if (pin2.Text != pin1.Text)
            {
                MessageBox.Show("Pin1 and confirm pin are different");
            }
            else
            {
                try
                {
                    cn.Open();
                    string Query = "update AccountTbl set pin=" + pin1.Text + "where AccNum ="+Form1.AccNumber+"";
                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.ExecuteNonQuery();
                    HOME h = new HOME();
                    h.Show();
                    this.Hide();
                    cn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }
    }
}
