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

namespace ChiuMartSAIS2.App
{
    public partial class frmSalesGeneration : Form
    {
        private List<String> qty = new List<string>();
        private List<String> itemName = new List<string>();
        private List<String> units = new List<string>();
        private List<String> unitPrice = new List<string>();
        private List<String> prodId = new List<string>();
        private List<String> prodQty = new List<string>();
        private string orNumber;
        private string clientName;
        private string address;
        private string action;

        private Classes.Configuration conf;

         public frmSalesGeneration()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void frmSalesGeneration_Load(object sender, EventArgs e)
        {
            populateTransaction();
        }

        public string crit { get; set; }

        private void getEditPos()
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
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearVars()
        {
            units.Clear();
            itemName.Clear();
            unitPrice.Clear();
            qty.Clear();
            orNumber = "";
            clientName = "";
            address = "";

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
                    string sqlQuery = "SELECT t.*, c.clientName, p.productPrice FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId INNER JOIN products as p ON t.productId = p.productId  WHERE c.clientName LIKE @criteria ORDER BY orNo ASC";

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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE transStatus != 'Verified' ORDER BY orNo ASC";

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
                    string sqlQuery = "SELECT t.*, c.clientName FROM transaction as t LEFT JOIN client as c ON t.clientId = c.clientId WHERE DATE_FORMAT(t.transDate,'%Y-%m-%d') BETWEEN @from AND @to ORDER BY orNo ASC";

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchTransaction();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }

            action = "birReport";
            frmPOS frm = new frmPOS(this.qty, this.itemName, this.units, this.unitPrice, this.orNumber, this.clientName, this.address, this.action);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void lstClients_Click(object sender, EventArgs e)
        {
            crit = lstClients.SelectedItems[0].Text;

            clearVars();
            getEditPos();
        }

        private void lstClients_DoubleClick(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count <= 0)
            {
                return;
            }

            action = "birReport";
            frmPOS frm = new frmPOS(this.qty, this.itemName, this.units, this.unitPrice, this.orNumber, this.clientName, this.address, this.action);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchClient(txtSearch.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            action = "Print";
        }
    }
}
