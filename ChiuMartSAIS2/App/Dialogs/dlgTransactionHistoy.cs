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

namespace ChiuMartSAIS2.App.Dialogs
{
    public partial class dlgTransactionHistoy : Form
    {
        private Classes.Configuration conf;
        public dlgTransactionHistoy()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateTransaction()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t INNER JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstClients.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstClients.Items.Count > 0)
                        {
                            if (reader["orNo"].ToString() == lstClients.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstClients.Items[ctr].SubItems[3].Text);
                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstClients.Items[ctr].SubItems[3].Text = (lstAmount + totalAmount).ToString();
                            }
                            else
                            {
                                lstClients.Items.Add(reader["orNo"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString()); 

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstClients.Items.Add(reader["orNo"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            ctr++;
                        }
                        
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchTransaction()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t INNER JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE DATE_FORMAT(t.transDate,'%Y-%m-%d') BETWEEN @from AND @to";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.ToString("yyyy-MM-dd"));
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.ToString("yyyy-MM-dd"));

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstClients.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstClients.Items.Count > 0)
                        {
                            if (reader["orNo"].ToString() == lstClients.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstClients.Items[ctr].SubItems[3].Text);
                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstClients.Items[ctr].SubItems[3].Text = (lstAmount + totalAmount).ToString();
                            }
                            else
                            {
                                lstClients.Items.Add(reader["orNo"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstClients.Items.Add(reader["orNo"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            ctr++;
                        }

                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this, errorCode+"Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dlgTransactionHistoy_Load(object sender, EventArgs e)
        {
            populateTransaction();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchTransaction();
        }
    }
}
