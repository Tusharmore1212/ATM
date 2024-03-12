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
    public partial class account : Form
    {
       
        public account()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ht\New folder\Login\Login\ATMDb.mdf;Integrated Security=True;User Instance=True");
        private void button1_Click(object sender, EventArgs e)
        {
         
            if (AccNameTb.Text == "" || AccNameTb.Text == "" || FaNameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "" || occupationTb.Text == "" || pinTb.Text == ""||bala.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into AccountTbl values('" + AccNumTb.Text + "','" + AccNameTb.Text + "','" + FaNameTb.Text + "','" + dobdate.Value.Date + "','" + PhoneTb.Text + "','" + AddressTb.Text + "','" + educationtb.SelectedItem.ToString() + "','" + occupationTb.Text + "','" + pinTb.Text + "'," + bala.Text + ")";
                   // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                
                    MessageBox.Show("Account Created Successfully");
                    con.Close();
                    Form1 fb = new Form1();
                    fb.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fb = new Form1();
            fb.Show();
            this.Hide();
        }

        private void account_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
