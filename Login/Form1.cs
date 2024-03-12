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
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }
        public static string AccNumber;
  
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ht\New folder\Login\Login\ATMDb.mdf;Integrated Security=True;User Instance=True");
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            admin ac = new admin();
            ac.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTbl where AccNum= '" + textBox1.Text + "' and pin=" + textBox2.Text + "", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                AccNumber = textBox1.Text;
                HOME p = new HOME();
                p.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("wrong account number and pin");
                textBox1.Clear();
                textBox2.Clear();
            }
            cn.Close();


        }
        }
            
       

        }
    


