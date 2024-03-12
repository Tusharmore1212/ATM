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
    public partial class BALANCE : Form
    {
        public BALANCE()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ht\New folder\Login\Login\ATMDb.mdf;Integrated Security=True;User Instance=True");
       private void getblance()
        {
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='"+AccNum.Text+"'",cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bal.Text  = dt.Rows[0][0].ToString();
            cn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BALANCE_Load(object sender, EventArgs e)
        {
            AccNum.Text = Form1.AccNumber;
            getblance();
        }

        private void AccNum_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HOME h = new HOME();
            this.Hide();
            h.Show();
        }
    }
}
