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
        private string status;
        private string tDate;
        private double totalamount = 0;

        public DateTime fromtDate = DateTime.Now;
        public DateTime toDate = DateTime.Now;

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
                    string sqlQuery = "SELECT t.unitPrice, t.transDate, t.orNo, t.qty, t.yellowBasyoReturned, t.transparentBasyoReturned, t.transStatus, u.unitDesc, c.clientName, c.clientAddress, p.productName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId INNER JOIN units as u ON t.unitId = u.unitId WHERE t.orNo = @crit";

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
                        status = reader["transStatus"].ToString();
                        tDate = reader["transDate"].ToString();
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

        private void getOverAllSales()
        {
            totalamount = 0;
            int count = lstClients.Items.Count; 
            if (count > 0) 
            {
                for (int i = 0; i < count; i++ )
                {
                    totalamount = totalamount + double.Parse(lstClients.Items[i].SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                }
            }
            lblTotal.Text = string.Format("{0:C}", (totalamount));
        }

        private void searchClient(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId WHERE t.transDate BETWEEN @from AND @to AND c.clientName LIKE @criteria ORDER BY orNo ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("criteria", "%" + criteria + "%");

                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstClients.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstClients.Items.Count > 0)
                        {
                            if (reader["orNo"].ToString() == lstClients.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstClients.Items[ctr].SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstClients.Items[ctr].SubItems[3].Text = string.Format("{0:C}", (lstAmount + totalAmount));
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

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE t.transDate BETWEEN @from AND @to AND transStatus != 'Verified' ORDER BY orNo ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstClients.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstClients.Items.Count > 0)
                        {
                            if (reader["orNo"].ToString() == lstClients.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstClients.Items[ctr].SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double grandTotal = lstAmount + totalAmount;
                                lstClients.Items[ctr].SubItems[3].Text = string.Format("{0:C}", (grandTotal));

                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());
                                if (grandTotal != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[ctr].SubItems[5].Text = (string.Format("{0:C}", (grandTotal - balancePayment)));
                                }
                                else
                                {
                                    lstClients.Items[ctr].SubItems[5].Text = (reader["transStatus"].ToString());
                                }
                            }
                            else
                            {
                                lstClients.Items.Add(reader["orNo"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transDate"].ToString());

                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transDate"].ToString());

                            double price = double.Parse(reader["unitPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);
                            double balancePayment = double.Parse(reader["paidBalance"].ToString());
                            string method = (reader["paymentMethod"].ToString());

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE t.transDate BETWEEN @from AND @to ORDER BY orNo ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstClients.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstClients.Items.Count > 0)
                        {
                            if (reader["orNo"].ToString() == lstClients.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstClients.Items[ctr].SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstClients.Items[ctr].SubItems[3].Text = string.Format("{0:C}", (lstAmount + totalAmount));
                            }
                            else
                            {
                                lstClients.Items.Add(reader["orNo"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transDate"].ToString());

                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transDate"].ToString());

                            double price = double.Parse(reader["unitPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);
                            double balancePayment = double.Parse(reader["paidBalance"].ToString());
                            string method = (reader["paymentMethod"].ToString());

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE t.transDate BETWEEN @from AND @to AND t.transStatus != 'Verified' ORDER BY orNo ASC";
                    DateTime dateNow = DateTime.Today;
                    if (status == "Cash")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE paymentMethod = 'Cash' AND t.transDate BETWEEN @from AND @to AND (t.transStatus != 'Verified' AND t.transStatus != 'Void' AND t.transStatus != 'Return') ORDER BY orNo ASC";
                    }
                    else if (status == "Cheque")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE paymentMethod = 'Cheque' AND t.transDate BETWEEN @from AND @to AND (t.transStatus != 'Verified' AND t.transStatus != 'Void' AND t.transStatus != 'Return') ORDER BY orNo ASC";
                    }
                    else if (status == "Balance")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE paymentMethod = 'Balance' AND t.transDate BETWEEN @from AND @to AND (t.transStatus != 'Verified' AND t.transStatus != 'Void' AND t.transStatus != 'Return') ORDER BY orNo ASC";
                    }
                    else if (status == "Verified")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE transStatus = 'Verified' AND t.transDate BETWEEN @from AND @to ORDER BY orNo ASC";
                    }
                    else if (status == "Void")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE transStatus = 'Void' AND t.transDate BETWEEN @from AND @to ORDER BY orNo ASC";
                    }
                    else if (status == "Return")
                    {
                        sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE transStatus = 'Return' AND t.transDate BETWEEN @from AND @to ORDER BY orNo ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstClients.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstClients.Items.Count > 0)
                        {
                            if (reader["orNo"].ToString() == lstClients.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstClients.Items[ctr].SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double grandTotal = lstAmount + totalAmount;
                                lstClients.Items[ctr].SubItems[3].Text = string.Format("{0:C}", (grandTotal));

                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());
                                if (grandTotal != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[ctr].SubItems[5].Text = (string.Format("{0:C}", (grandTotal - balancePayment)));
                                }
                                else
                                {
                                    lstClients.Items[ctr].SubItems[5].Text = (reader["transStatus"].ToString());
                                }
                            }
                            else
                            {
                                lstClients.Items.Add(reader["orNo"].ToString());
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["clientName"].ToString() != "" ? reader["clientName"].ToString() : "WALK-IN CLIENT");

                                // converts the transdate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["transDate"].ToString(), out aDate);
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transDate"].ToString());

                                double price = double.Parse(reader["unitPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                double balancePayment = double.Parse(reader["paidBalance"].ToString());
                                string method = (reader["paymentMethod"].ToString());

                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                                if (totalAmount != balancePayment && method == "Balance")
                                {
                                    lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(reader["transDate"].ToString());

                            double price = double.Parse(reader["unitPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);
                            double balancePayment = double.Parse(reader["paidBalance"].ToString());
                            string method = (reader["paymentMethod"].ToString());

                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                            lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(method);
                            if (totalAmount != balancePayment && method == "Balance")
                            {
                                lstClients.Items[lstClients.Items.Count - 1].SubItems.Add(string.Format("{0:C}", (totalAmount - balancePayment)));
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

        private void verifyTransaction(string orNo)
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
                {
                    Con.Open();
                    string sqlQuery = "UPDATE transaction SET transStatus = 'Verified' WHERE orNo = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("crit", orNo);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database ", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void unVerifyTransaction()
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
                {
                    Con.Open();
                    string sqlQuery = "UPDATE transaction SET transStatus = 'Completed' WHERE orNo = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Transaction successfully unverified", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database ", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changePaymentMethod(string orNo, string paymentMethod)
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
                {
                    Con.Open();
                    string sqlQuery = "UPDATE transaction SET paymentMethod = @paymentMethod WHERE orNo = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("crit", orNo);
                    sqlCmd.Parameters.AddWithValue("paymentMethod", paymentMethod);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database ", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertCheque(string bank, string branch, string chequeName, string chequeDate, string chequeNo, string amount, string chequeAm, string overAm)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    DateTime chequeDateFinal;
                    DateTime.TryParse(chequeDate, out chequeDateFinal);

                    Con.Open();
                    string sqlQuery = "INSERT INTO cheque (chequeNo, chequeName, chequeBank, chequeBranch, chequeAmount, totalAmount, overAmount, chequeDate, status) VALUES (@chequeNo, @chequeName, @chequeBank, @chequeBranch, @chequeAmount, @totalAmount, @overAmount, @chequeDate, 'active')";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("chequeNo", chequeNo);
                    sqlCmd.Parameters.AddWithValue("chequeName", chequeName);
                    sqlCmd.Parameters.AddWithValue("chequeBank", bank);
                    sqlCmd.Parameters.AddWithValue("chequeBranch", branch);
                    sqlCmd.Parameters.AddWithValue("chequeAmount", amount);
                    sqlCmd.Parameters.AddWithValue("totalAmount", chequeAm);
                    sqlCmd.Parameters.AddWithValue("overAmount", overAm);
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
                out string orNo, out string clientName, out string clientAddress, out string action, out string yellowBasyoReturned, out string transparentBasyoReturned, out string status, out string tDate, out DateTime from, out DateTime to)
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
            status = this.status;
            tDate = this.tDate;

            from = dtpFrom.Value;
            to = dtpTo.Value;
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

                // Check for voided
                if (stat == "Void")
                {
                    lvw.BackColor = Color.Violet;
                }

                // Check for return
                if (stat == "Return")
                {
                    lvw.BackColor = Color.HotPink;
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
            dtpFrom.Value = fromtDate;
            dtpTo.Value = toDate;

            if (Classes.Authentication.Instance.role != "Administrator")
            {
                btnVerify.Visible = false;
            }
            populateTransaction();
            checkTransaction();
            getOverAllSales();

            btnVerify.Text = "Verify";
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
            getOverAllSales();
            btnVerify.Text = "Verify";
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
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
            getOverAllSales();
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
            getOverAllSales();
            btnVerify.Text = "Verify";
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Cash");
            getOverAllSales();
            checkTransaction();
            btnVerify.Text = "Verify";
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Cheque");
            getOverAllSales();
            checkTransaction();
            btnVerify.Text = "Verify";
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Balance");
            getOverAllSales();
            checkTransaction();
            btnVerify.Text = "Verify";
            btnOverview.Visible = true;
            btnPayBalance.Visible = true;
        }

        private void lblVerify_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Verified");
            getOverAllSales();
            checkTransaction();
            btnVerify.Text = "Unverify";
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void removeFromListview(List<int> indexes)
        {
            int lastIndex = lstClients.SelectedItems[0].Index;
            for (int i = 0; i < indexes.Count; i++)
            {
                lstClients.SelectedItems[0].Remove();
            }

            lstClients.Focus();
            lstClients.Items[lastIndex].Selected = true;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }

            string id = lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].Text;
            if (btnVerify.Text == "Verify")
            {
                if (MessageBox.Show(this, "Do you want to verify this transaction/s?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<int> indexes = new List<int>();
                    for (int i = 0; i < lstClients.SelectedItems.Count; i++)
                    {
                        string orNo = lstClients.SelectedItems[i].Text;

                        // Check if ORNO is in balance status
                        if (lstClients.SelectedItems[i].SubItems[4].Text.ToLower() == "balance") {
                            if (MessageBox.Show(this, "TRANSACTION with OR NUMBER OF " + orNo + " has a payment method of BALANCE, DO YOU WANT TO VERIFY THIS?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                            {
                                verifyTransaction(orNo);
                                indexes.Add(i);
                                continue;
                            }
                        }

                        verifyTransaction(orNo);
                        indexes.Add(i);
                    }

                    //MessageBox.Show(this, "Transaction successfully verified", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //populateTransaction();
                    removeFromListview(indexes);
                    checkTransaction();
                }
            }
            else
            {
                if (MessageBox.Show(this, "Do you want to unverify this transaction/s?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    unVerifyTransaction();
                    getTransactionByPayment("Verified");
                    checkTransaction();
                }
            }
            
        }
        private string chequeAmount = "";
        private string overAmount = "";
        private void btnPayBalance_Click(object sender, EventArgs e)
        {
            dlgCheckout frm = new dlgCheckout("balance");
            frm.total = lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].SubItems[5].Text;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string paymentMethod = "";
                frm.getProduct(out paymentMethod, out bank, out branch, out chequeName, out chequeDate, out total, out chequeNo, out chequeAmount, out overAmount);
                if (paymentMethod == "Cheque")
                {
                    insertCheque(bank, branch, chequeName, chequeDate, chequeNo, total, chequeAmount, overAmount);
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

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Void");
            getOverAllSales();
            checkTransaction();
            btnVerify.Text = "Verify";
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            getTransactionByPayment("Return");
            getOverAllSales();
            checkTransaction();
            btnVerify.Text = "Verify";
            btnOverview.Visible = false;
            btnPayBalance.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }

            string payment = lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].SubItems[4].Text;
            string orNo = lstClients.SelectedItems[lstClients.SelectedItems.Count - 1].Text;
            dlgChangePaymentMethod frm = new dlgChangePaymentMethod(payment);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string method;
                frm.getMethod(out method);
                changePaymentMethod(orNo, method);
                populateTransaction();
                checkTransaction();
            }
        }
    }
}
