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
    public partial class mr : Form
    {
        public mr()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ht\New folder\Login\Login\ATMDb.mdf;Integrated Security=True;User Instance=True");
        string acc = Form1.AccNumber;
        int bal;
        int newbalance;
        private void getblance()
        {
         cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + acc + "'", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            cn.Close();
        }
        private void am_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (am.Text == ""||mb.Text=="")
            {
                MessageBox.Show("Missing Transaction");
            }
            else if (mb.Text.Length != 10)
            {
                MessageBox.Show("Invalid mobile number");
            }
            else if (Convert.ToInt32(am.Text) <= 0)
            {
                MessageBox.Show("Invalid Amount");
            }
            else if (Convert.ToInt32(am.Text) > bal)
            {
                MessageBox.Show("Low Balance");
            }
            else
            {
                try
                {
                    newbalance = bal - Convert.ToInt32(am.Text);
                    try
                    {
                        cn.Open();
                        string Query = "update AccountTbl set balance=" + newbalance + "where AccNum =" + Form1.AccNumber + "";
                        SqlCommand cmd = new SqlCommand(Query, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Recharge of Rs: " + am.Text + "   successful for your number:  " + mb.Text);

                        HOME h = new HOME();
                        h.Show();
                        this.Hide();
                        cn.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                        mb.Clear();
                        am.Clear();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void mr_Load(object sender, EventArgs e)
        {
            getblance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }
    }
}
