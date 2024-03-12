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
    public partial class ministatement : Form
    {
        public ministatement()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ht\New folder\Login\Login\ATMDb.mdf;Integrated Security=True;User Instance=True");
        string acc = Form1.AccNumber;
        private void populate()
        {
            cn.Open();
            string query = "select * from transactionTbl where ACCNUM ="+acc+"";
            SqlDataAdapter sda = new SqlDataAdapter(query, cn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            mini.DataSource = ds.Tables[0];
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ministatement_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
