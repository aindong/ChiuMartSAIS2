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
        private string bank = "";
        private string branch = "";
        private string chequeNo = "";
        private string chequeName = "";
        private string chequeDate = "";
        private string total = "";
        private string balance = "";
        private string yellowBasyoReturned;
        private string transparentBasyoReturned;

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
                    string sqlQuery = "SELECT t.unitPrice, t.orNo, t.qty, t.yellowBasyoReturned, t.transparentBasyoReturned, u.unitDesc, c.clientName, c.clientAddress, p.productName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId INNER JOIN units as u ON t.unitId = u.unitId WHERE t.orNo = @crit";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].Text);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        qty.Add(reader["qty"].ToString());
                        itemName.Add(reader["productName"].ToString());
                        units.Add(reader["unitDesc"].ToString());
                        unitPrice.Add(reader["unitPrice"].ToString());
                        orNumber = reader["orNo"].ToString();
                        clientName = reader["clientName"].ToString();
                        address = reader["clientAddress"].ToString();
                        yellowBasyoReturned = reader["yellowBasyoReturned"].ToString();
                        transparentBasyoReturned = reader["transparentBasyoReturned"].ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private double getClientID(string crit)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT clientId FROM client WHERE clientName = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();



                    double tmp = 0;
                    while (reader.Read())
                    {
                        tmp = Convert.ToDouble(reader["clientId"]);
                    }

                    return tmp;
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Message);
                    MessageBox.Show(this, "Error Retrieving client id", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
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
                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                                }
                                else
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                }
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
                            double balancePayment = double.Parse(reader["paidBalance"].ToString());
                            string method = (reader["paymentMethod"].ToString());

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                            }
                            else
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                            }
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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE transStatus != 'Verified' ORDER BY clientName ASC";

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
                                double price = double.Parse(reader["unitPrice"].ToString());
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

                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                                }
                                else
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                }
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

                            double price = double.Parse(reader["unitPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);
                            double balancePayment = double.Parse(reader["paidBalance"].ToString());
                            string method = (reader["paymentMethod"].ToString());

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                            }
                            else
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                            }
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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE DATE_FORMAT(t.transDate,'%Y-%m-%d') BETWEEN @from AND @to ORDER BY clientName ASC";

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
                                double price = double.Parse(reader["unitPrice"].ToString());
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

                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                                }
                                else
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                }
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

                            double price = double.Parse(reader["unitPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);
                            double balancePayment = double.Parse(reader["paidBalance"].ToString());
                            string method = (reader["paymentMethod"].ToString());

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                            }
                            else
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                            }
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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE transStatus != 'Verified' ORDER BY clientName ASC";
                    DateTime dateNow = DateTime.Today;
                    if (status == "Cash")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE paymentMethod = 'Cash' AND transStatus != 'Verified' ORDER BY clientName ASC";
                    }
                    else if (status == "Cheque")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE paymentMethod = 'Cheque' AND transStatus != 'Verified' ORDER BY clientName ASC";
                    }
                    else if (status == "Balance")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE paymentMethod = 'Balance' AND transStatus != 'Verified' ORDER BY clientName ASC";
                    }
                    else if (status == "Verified")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE transStatus = 'Verified' ORDER BY clientName ASC";
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
                                double price = double.Parse(reader["unitPrice"].ToString());
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

                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                                }
                                else
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                                }
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

                            double price = double.Parse(reader["unitPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);
                            double balancePayment = double.Parse(reader["paidBalance"].ToString());
                            string method = (reader["paymentMethod"].ToString());

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(totalAmount.ToString());
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add((totalAmount - balancePayment).ToString());
                            }
                            else
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transStatus"].ToString());
                            }
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

        private void insertCheque(string bank, string branch, string chequeName, string chequeDate, string chequeNo, string amount)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    DateTime chequeDateFinal;
                    DateTime.TryParse(chequeDate, out chequeDateFinal);

                    Con.Open();
                    string sqlQuery = "INSERT INTO cheque (chequeNo, chequeName, chequeBank, chequeBranch, chequeAmount, chequeDate, status) VALUES (@chequeNo, @chequeName, @chequeBank, @chequeBranch, @chequeAmount, @chequeDate, 'active')";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("chequeNo", chequeNo);
                    sqlCmd.Parameters.AddWithValue("chequeName", chequeName);
                    sqlCmd.Parameters.AddWithValue("chequeBank", bank);
                    sqlCmd.Parameters.AddWithValue("chequeBranch", branch);
                    sqlCmd.Parameters.AddWithValue("chequeAmount", amount);
                    sqlCmd.Parameters.AddWithValue("chequeDate", chequeDateFinal.ToString("yyyy-MM-dd"));

                    sqlCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Transaction error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateTransaction(string paidBalance, string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE transaction SET paidBalance = paidBalance + @paidBalance WHERE orNo = @criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("paidBalance", paidBalance);
                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Accounts Receivables updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating Accounts Receivables error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void getTransaction(out List<String> qty, out List<String> productName, out List<String> units, out List<String> productPrice,
                out string orNo, out string clientName, out string clientAddress, out string action, out string yellowBasyoReturned, out string transparentBasyoReturned)
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
            // Set the yellow basyo returned
            yellowBasyoReturned = this.yellowBasyoReturned;
            // set the transparent basyo returned
            transparentBasyoReturned = this.transparentBasyoReturned;
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
            if (Classes.Authentication.Instance.role != "Administrator")
            {
                btnVerify.Visible = false;
            }
            populateTransaction();
            checkTransaction();

            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
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
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Cash");
            checkTransaction();
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Cheque");
            checkTransaction();
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Balance");
            checkTransaction();
            btnOverview.Visible = true;
            btnPayBalance.Visible = true;
        }

        private void lblVerify_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Verified");
            checkTransaction();
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
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

        private void btnPayBalance_Click(object sender, EventArgs e)
        {
            dlgCheckout frm = new dlgCheckout("balance");
            frm.total = lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].SubItems[5].Text;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string paymentMethod = "";
                frm.getProduct(out paymentMethod, out bank, out branch, out chequeName, out chequeDate, out total, out chequeNo);
                if (paymentMethod == "Cheque")
                {
                    insertCheque(bank, branch, chequeName, chequeDate, chequeNo, total);
                }

                frm.getTotalPaid(out balance);
                updateTransaction(balance, lstClients.SelectedItems[0].Text);

                string clientName = lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].SubItems[1].Text;

                double clientId = getClientID(clientName);

                // LOGS
                Classes.ActionLogger.LogAction("", "", "", "Balance", lstClients.SelectedItems[0].Text, clientId.ToString(), paymentMethod, balance, "", "");

                getTransactionByPayment("Balance");
                checkTransaction();
            }
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }
            ReportDialog.dlgIndividualLog log = new ReportDialog.dlgIndividualLog();
            log.logType = "balance";
            log.relationId = lstClients.SelectedItems[0].Text;
            log.ShowDialog();
        }
    }
}
