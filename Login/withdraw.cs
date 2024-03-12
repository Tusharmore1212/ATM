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
    public partial class withdraw : Form
    {
        public withdraw()
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
        private void addtransaction()
        {
            string TrType = "withdraw";
            try
            {
                cn.Open();
                string query = "insert into transactionTbl values('"+ acc + "','" + TrType + "','" + wid.Text + "','" + DateTime.Today.Date.ToString() + "' )";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Account Created Successfully");
                cn.Close();
               

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }


        }
                
        private void withdraw_Load(object sender, EventArgs e)
        {
            getblance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (wid.Text == "")
            {
                MessageBox.Show("Missing Transaction");
            }
            else if (Convert.ToInt32(wid.Text) <= 0)
            {
                MessageBox.Show("Invalid Amount");
                wid.Clear();
            }
            else if (Convert.ToInt32(wid.Text) > bal)
            {
                MessageBox.Show("Low Balance");
                wid.Clear();
            }
            else
            {
                try
                {
                    newbalance = bal - Convert.ToInt32(wid.Text);
                    try
                    {
                        cn.Open();
                        string Query = "update AccountTbl set balance=" + newbalance + "where AccNum =" + Form1.AccNumber + "";
                        SqlCommand cmd = new SqlCommand(Query, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Transaction Successfull");
                        cn.Close();
                        addtransaction();
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
                    wid.Clear();
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
