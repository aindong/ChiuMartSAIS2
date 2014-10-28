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
        private double cashCount, 
            chequeCount, 
            accountsReceivableCount, 
            transparentBasyo;

        public dlgSalesEndofDay()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        // get the total number of transaction for transaction method
        private Double getTransactionCount(DateTime start, DateTime end, string paymentType)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT qty, unitPrice FROM transaction WHERE transDate BETWEEN @start AND @end AND paymentMethod = @paymentType";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("start", dtpStart.Value.Date);
                    sqlCmd.Parameters.AddWithValue("end", dtpEnd.Value.AddDays(1).Date);
                    sqlCmd.Parameters.AddWithValue("paymentType", paymentType);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    double count = 0;
                    while (reader.Read())
                    {
                        count += Double.Parse(reader["qty"].ToString()) * Double.Parse(reader["unitPrice"].ToString());
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

        private double getLogCount(string paymentMethod)
        {
            double count = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT `price` as totalCount FROM logs WHERE `created_date` BETWEEN @start AND @end AND `log_type` = 'Balance' AND `paymentMethod` = @paymentMethod";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("start", dtpStart.Value.Date);
                    sqlCmd.Parameters.AddWithValue("end", dtpEnd.Value.AddDays(1).Date);
                    sqlCmd.Parameters.AddWithValue("paymentMethod", paymentMethod);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        count += Double.Parse(reader["totalCount"].ToString());
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
                    string basyo = "";
                    con.Open();
                    string sqlQuery = "SELECT SUM(basyo_returned) as total FROM basyo WHERE date_created BETWEEN @start AND @end ";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("start", dtpStart.Value.Date);
                    sqlCmd.Parameters.AddWithValue("end", dtpEnd.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        basyo = reader["total"].ToString();
                    }

                    if (basyo == "")
                    {
                        transparentBasyo = 0;
                    }
                    else
                    {
                        transparentBasyo = Int32.Parse(basyo);
                    }
                    transparentBasyo = transparentBasyo * 110;
                    lblTransparentBasyo.Text = (transparentBasyo).ToString();
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

            lblCash.Text = string.Format("{0:C}", (getTransactionCount(dtpStart.Value.AddDays(-1), dtpEnd.Value, "Cash") + getLogCount("Cash")));
            lblCheque.Text = string.Format("{0:C}", (getTransactionCount(dtpStart.Value.AddDays(-1), dtpEnd.Value, "Cheque") + getLogCount("Cheque")));
            lblAccountsReceivables.Text = string.Format("{0:C}", getTransactionCount(dtpStart.Value.AddDays(-1), dtpEnd.Value, "Balance"));

            getBasyo(dtpStart.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpStart.Value.AddDays(1).ToString("yyyy-MM-dd"));
            lblTransparentBasyo.Text = string.Format("{0:C}", transparentBasyo);

            cashCount = double.Parse(lblCash.Text, System.Globalization.NumberStyles.Currency);
            chequeCount = double.Parse(lblCheque.Text, System.Globalization.NumberStyles.Currency);
            accountsReceivableCount = double.Parse(lblAccountsReceivables.Text, System.Globalization.NumberStyles.Currency);
            transparentBasyo = double.Parse(lblTransparentBasyo.Text, System.Globalization.NumberStyles.Currency);


            //MessageBox.Show(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + " : " + DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));

            lblTotalSales.Text = string.Format("{0:C}", (cashCount + chequeCount + accountsReceivableCount - transparentBasyo));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCash.Text = string.Format("{0:C}", (getTransactionCount(dtpStart.Value.AddDays(-1), dtpEnd.Value, "Cash") + getLogCount("Cash")));
            lblCheque.Text = string.Format("{0:C}", (getTransactionCount(dtpStart.Value.AddDays(-1), dtpEnd.Value, "Cheque")  + getLogCount("Cheque")));
            lblAccountsReceivables.Text = string.Format("{0:C}", getTransactionCount(dtpStart.Value.AddDays(-1), dtpEnd.Value, "Balance"));
            
            getBasyo(dtpStart.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpStart.Value.AddDays(1).ToString("yyyy-MM-dd"));
            lblTransparentBasyo.Text = string.Format("{0:C}",transparentBasyo);

            cashCount = double.Parse(lblCash.Text, System.Globalization.NumberStyles.Currency);
            chequeCount = double.Parse(lblCheque.Text, System.Globalization.NumberStyles.Currency);
            accountsReceivableCount = double.Parse(lblAccountsReceivables.Text, System.Globalization.NumberStyles.Currency);
            transparentBasyo = double.Parse(lblTransparentBasyo.Text, System.Globalization.NumberStyles.Currency);


            //MessageBox.Show(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + " : " + DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));

            lblTotalSales.Text = string.Format("{0:C}", (cashCount + chequeCount + accountsReceivableCount - transparentBasyo));
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
