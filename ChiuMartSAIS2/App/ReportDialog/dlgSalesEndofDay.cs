using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace ChiuMartSAIS2.App.ReportDialog
{
    public partial class dlgSalesEndofDay : Form
    {
        private Classes.Configuration conf;
        private int cashCount, 
            chequeCount, 
            accountsReceivableCount, 
            transparentBasyo, 
            yellowBasyo;

        public dlgSalesEndofDay()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        // get the total number of transaction for transaction method
        private int getTransactionCount(string start, string end, string paymentType)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT orNo FROM transaction WHERE transDate BETWEEN @start AND @end AND paymentMethod = @paymentType GROUP BY orNo";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("start", start);
                    sqlCmd.Parameters.AddWithValue("end", end);
                    sqlCmd.Parameters.AddWithValue("paymentType", paymentType);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }

                    return count;
                }
            }
            catch(MySqlException ex) 
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int getLogCount(string paymentMethod)
        {
            int count = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT COUNT(`id`) as totalCount FROM logs WHERE `created_date` BETWEEN @start AND @end AND `log_type` = 'Balance' AND `paymentMethod` = @paymentMethod";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("start", dtpStart.Value.AddDays(-1));
                    sqlCmd.Parameters.AddWithValue("end", dtpEnd.Value.AddDays(1));
                    sqlCmd.Parameters.AddWithValue("paymentMethod", paymentMethod);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        count = Int32.Parse(reader["totalCount"].ToString());
                    }

                    return count;
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void getBasyo(string start, string end)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT basyo.basyoTransCount, basyo.basyoYellowCount FROM basyo INNER JOIN transaction ON basyo.transId = transaction.orNo WHERE transaction.transDate BETWEEN @start AND @end GROUP BY orNo";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("start", start);
                    sqlCmd.Parameters.AddWithValue("end", end);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        yellowBasyo = yellowBasyo + (int)reader["basyoYellowCount"];
                        transparentBasyo = transparentBasyo + (int)reader["basyoTransCount"];
                    }

                    lblTransparentBasyo.Text = transparentBasyo.ToString();
                    lblYellowBasyo.Text = yellowBasyo.ToString();

                    yellowBasyo = 0;
                    transparentBasyo = 0;

                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgSalesEndofDay_Load(object sender, EventArgs e)
        {

            lblCash.Text = (getTransactionCount(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"), "Cash") + getLogCount("Cash")).ToString();
            lblCheque.Text = (getTransactionCount(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"), "Cheque") +  + getLogCount("Cheque")).ToString();
            lblAccountsReceivables.Text = getTransactionCount(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"), "Balance").ToString();

            cashCount = Int32.Parse(lblCash.Text);
            chequeCount = Int32.Parse(lblCheque.Text);
            accountsReceivableCount = Int32.Parse(lblAccountsReceivables.Text);

            getBasyo(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));

            //MessageBox.Show(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + " : " + DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));

            lblTotalSales.Text = (cashCount + chequeCount + accountsReceivableCount).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCash.Text = (getTransactionCount(dtpStart.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd"), "Cash") + getLogCount("Cash")).ToString();
            lblCheque.Text = (getTransactionCount(dtpStart.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd"), "Cheque")  + getLogCount("Cheque")).ToString();
            lblAccountsReceivables.Text = getTransactionCount(dtpStart.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd"), "Balance").ToString();

            cashCount = Int32.Parse(lblCash.Text);
            chequeCount = Int32.Parse(lblCheque.Text);
            accountsReceivableCount = Int32.Parse(lblAccountsReceivables.Text);

            getBasyo(dtpStart.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpStart.Value.AddDays(1).ToString("yyyy-MM-dd"));
            lblTransparentBasyo.Text = transparentBasyo.ToString();
            lblYellowBasyo.Text = yellowBasyo.ToString();


            //MessageBox.Show(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + " : " + DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));

            lblTotalSales.Text = (cashCount + chequeCount + accountsReceivableCount).ToString();
        }

        private void btnChequeView_Click(object sender, EventArgs e)
        {
            App.frmChequeMonitoring frm = new App.frmChequeMonitoring();
            frm.ShowDialog();
        }

        private void btnAccountsReceivables_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgTransactionHistoy frm = new App.Dialogs.dlgTransactionHistoy();
            frm.ShowDialog();
        }
    }
}
