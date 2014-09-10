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
        private List<String> qty = new List<string>();
        private List<String> itemName = new List<string>();
        private List<String> units = new List<string>();
        private List<String> unitPrice = new List<string>();
        private string orNumber;
        private string clientName;
        private string address;
        private string action;

        private Classes.Configuration conf;
        public dlgTransactionHistoy()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        public string crit { get; set; }

        private void getViewTransaction()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.orNo, t.qty, u.unitDesc, c.clientName, c.clientAddress, p.productName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId INNER JOIN units as u ON t.unitId = u.unitId WHERE t.orNo = @crit";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].Text);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        qty.Add(reader["qty"].ToString());
                        itemName.Add(reader["productName"].ToString());
                        units.Add(reader["unitDesc"].ToString());
                        unitPrice.Add(reader["productPrice"].ToString());
                        orNumber = reader["orNo"].ToString();
                        clientName = reader["clientName"].ToString();
                        address = reader["clientAddress"].ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchClient(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId  WHERE c.clientName LIKE @criteria ORDER BY clientName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("criteria", "%" + criteria + "%");

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

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstClients.Items.Add(reader["orNo"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
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

        private void populateTransaction()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE transStatus != 'Verified' ORDER BY clientName ASC";

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

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT"); 

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstClients.Items.Add(reader["orNo"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
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
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE DATE_FORMAT(t.transDate,'%Y-%m-%d') BETWEEN @from AND @to ORDER BY clientName ASC";

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
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstClients.Items.Add(reader["orNo"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
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

        private void getTransactionByPayment(string status)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE transStatus != 'Verified' ORDER BY clientName ASC";
                    DateTime dateNow = DateTime.Today;
                    if (status == "Cash")
                    {
                        sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE paymentMethod = 'Cash' AND transStatus != 'Verified' ORDER BY clientName ASC";
                    }
                    else if (status == "Cheque")
                    {
                        sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE paymentMethod = 'Cheque' AND transStatus != 'Verified' ORDER BY clientName ASC";
                    }
                    else if (status == "Balance")
                    {
                        sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE paymentMethod = 'Balance' AND transStatus != 'Verified' ORDER BY clientName ASC";
                    }
                    else if (status == "Verified")
                    {
                        sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE transStatus = 'Verified' ORDER BY clientName ASC";
                    }

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
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstClients.Items.Add(reader["orNo"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
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

        private void verifyTransaction()
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
                {
                    Con.Open();
                    string sqlQuery = "UPDATE transaction SET transStatus = 'Verified' WHERE orNo = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Transaction successfully verified", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database ", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getTransaction(out List<String> qty, out List<String> productName, out List<String> units, out List<String> productPrice, 
                out string orNo, out string clientName, out string clientAddress, out string action)
        {
            // Set the qty
            qty = this.qty;
            // Set the product name
            productName = this.itemName;
            // Set the units
            units = this.units;
            // Set the product price
            productPrice = this.unitPrice;
            // Set the or number
            orNo = orNumber;
            // Set the client name
            clientName = this.clientName;
            // Set the client address
            clientAddress = address;
            // set the action
            action = this.action;
        }

        private void checkTransaction()
        {
            foreach (ListViewItem lvw in lstClients.Items)
            {
                string paymentStatus = lvw.SubItems[4].Text;
                string stat = lvw.SubItems[5].Text;

                // Check for cash
                if (paymentStatus == "Cash")
                {
                    lvw.BackColor = Color.Lime;
                }

                // Check for cheque
                if (paymentStatus == "Cheque")
                {
                    lvw.BackColor = Color.LightSalmon;
                }

                // Check for accounts receivable
                if (paymentStatus == "Balance")
                {
                    lvw.BackColor = Color.Silver;
                }

                // Check for Verified
                if (stat == "Verified")
                {
                    lvw.BackColor = Color.DeepSkyBlue;
                }
            }
        }

        private void dlgTransactionHistoy_Load(object sender, EventArgs e)
        {
            populateTransaction();
            checkTransaction();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchTransaction();
            checkTransaction();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }
            action = "View";
            getViewTransaction();
            DialogResult = DialogResult.OK; 
        }

        private void lstClients_Click(object sender, EventArgs e)
        {
            crit = lstClients.SelectedItems[0].Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            action = "Print";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchClient(txtSearch.Text);
            checkTransaction();
        }

        private void lstClients_DoubleClick(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }
            action = "View";
            getViewTransaction();
            DialogResult = DialogResult.OK; 
        }

        private void lblAll_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("All");
            checkTransaction();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Cash");
            checkTransaction();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Cheque");
            checkTransaction();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Balance");
            checkTransaction();
        }

        private void lblVerify_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Verified");
            checkTransaction();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }

            string id = lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].Text;

            if (MessageBox.Show(this, "Do you want to verify this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                verifyTransaction();
                populateTransaction();
                checkTransaction();
            }
        }
    }
}
