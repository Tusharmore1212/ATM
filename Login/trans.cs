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
    public partial class trans : Form
    {
        public trans()
        {
            InitializeComponent();
        }
        
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ht\New folder\Login\Login\ATMDb.mdf;Integrated Security=True;User Instance=True");
        string acc = Form1.AccNumber;
        int bal,trbal;
        int newbalance,trnewbalance;
         string tracc;
          
        private void getblance()
        {
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + acc+ "'", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SqlDataAdapter sfa = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + tracn.Text+ "'", cn); 
            DataTable dd = new DataTable(); 
            sfa.Fill(dd);
            try
            {
                trbal = Convert.ToInt32(dd.Rows[0][0].ToString());
                tracc = tracn.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid account number");
            }
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            
            cn.Close();
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            getblance();
            if (textBox2.Text == "")
            {
                MessageBox.Show("Missing Transaction");
            }
            else if (Convert.ToInt32(textBox2.Text) <= 0)
            {
                MessageBox.Show("Invalid Amount");
            }
            else if (Convert.ToInt32(textBox2.Text) > bal)
            {
                MessageBox.Show("Low Balance");
            }
            else
            {
                try
                {
                  
                    newbalance = bal - Convert.ToInt32(textBox2.Text);
                    trnewbalance = trbal + Convert.ToInt32(textBox2.Text);
                   
                    try
                    {
                        cn.Open();
                       string que = "update AccountTbl set  Balance = "+trnewbalance+" where AccNum = "+tracc+"";
                        string Query = "update AccountTbl set balance=" + newbalance + "where AccNum =" +acc+ "";
                        SqlCommand cjd = new SqlCommand(que, cn);
                        SqlCommand cmd = new SqlCommand(Query, cn);

                       cjd.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Transaction Successfull");
                        cn.Close();
                        HOME h = new HOME();
                        h.Show();
                       this.Hide();
                        
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                       
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    tracn.Clear();
                    textBox2.Clear();
                }
            }

        }

        private void transaction_Load(object sender, EventArgs e)
        {
            
         
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOME h = new HOME();
            h.Show();
            this.Hide();
        }

        private void tracn_TextChanged(object sender, EventArgs e)
        {

        }

        private void rac_Click(object sender, EventArgs e)
        {
           
        }
    }
}
