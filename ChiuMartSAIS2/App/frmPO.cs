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
    public partial class frmPO : Form
    {

        private string status = "active";
        private string filter = "Supplier"; 
        private Classes.Configuration conf;
        private List<String> qty = new List<string>();
        private List<String> itemName = new List<string>();
        private List<String> units = new List<string>();
        private List<String> unitPrice = new List<string>();
        private string orNumber;
        private string clientName;
        private string address;
        private string action;

        public frmPO()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populatePo()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, s.supplierName, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId  WHERE p.status = @status";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();

                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstPO.Items.Count > 0)
                        {
                            if (reader["poId"].ToString() == lstPO.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstPO.Items[ctr].SubItems[2].Text);
                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstPO.Items[ctr].SubItems[2].Text = (lstAmount + totalAmount).ToString();
                            }
                            else
                            {
                                lstPO.Items.Add(reader["poId"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(totalAmount.ToString());

                                // converts the poDate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstPO.Items.Add(reader["poId"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(totalAmount.ToString());

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
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

        private void getPoByStatus(string poStatus)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, s.supplierName, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status";
                    DateTime dateNow = DateTime.Today;
                    if (poStatus == "Delivered")
                    {
                        sqlQuery = "SELECT p.*, s.supplierName, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = 'active' AND p.poStatus = 'Delivered'";
                    }
                    else if (poStatus == "BackOrder")
                    {
                        sqlQuery = "SELECT p.*, s.supplierName, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = 'active' AND p.poStatus = 'Back Order'";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("status", this.status);
                    
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstPO.Items.Count > 0)
                        {
                            if (reader["poId"].ToString() == lstPO.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstPO.Items[ctr].SubItems[2].Text);
                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstPO.Items[ctr].SubItems[2].Text = (lstAmount + totalAmount).ToString();
                            }
                            else
                            {
                                lstPO.Items.Add(reader["poId"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(totalAmount.ToString());

                                // converts the poDate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstPO.Items.Add(reader["poId"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(totalAmount.ToString());

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
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

        private void searchPo(string filter, string critera)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();

                    string sqlQuery = "SELECT p.*, s.supplierName, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status AND supplierName LIKE @crit";
                    
                    if (filter == "Supplier")
                    {
                        sqlQuery = "SELECT p.*, s.supplierName, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status AND supplierName LIKE @crit";
                    } else if (filter == "poid") {
                        sqlQuery = "SELECT p.*, s.supplierName, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status AND poId LIKE @crit";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    // SQL Query Parameters
                    sqlCmd.Parameters.AddWithValue("crit", "%" + critera + "%");
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstPO.Items.Count > 0)
                        {
                            if (reader["poId"].ToString() == lstPO.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstPO.Items[ctr].SubItems[2].Text);
                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstPO.Items[ctr].SubItems[2].Text = (lstAmount + totalAmount).ToString();
                            }
                            else
                            {
                                lstPO.Items.Add(reader["poId"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                                double price = double.Parse(reader["productPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(totalAmount.ToString());

                                // converts the poDate to datetime
                                DateTime aDate;
                                DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstPO.Items.Add(reader["poId"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                            double price = double.Parse(reader["productPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(totalAmount.ToString());

                            // converts the transdate to datetime
                            DateTime aDate;
                            DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
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

        private void backPo(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE po SET poStatus='Back Order' WHERE id=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "PO turned to Back Order", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Back Order PO error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deletePo(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE po SET status='inactive' WHERE id=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Po successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Deleting po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getEditPo()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, s.supplierName, s.supplierAddress, pr.productName, u.unitDesc, pr.productPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId INNER JOIN units as u ON p.unitId = u.unitId WHERE p.poId = @crit";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        qty.Add(reader["qty"].ToString());
                        itemName.Add(reader["productName"].ToString());
                        units.Add(reader["unitDesc"].ToString());
                        unitPrice.Add(reader["productPrice"].ToString());
                        orNumber = reader["poId"].ToString();
                        clientName = reader["supplierName"].ToString();
                        address = reader["supplierAddress"].ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkPo()
        {
            // Check the po status
            foreach (ListViewItem lvw in lstPO.Items)
            {
                // Check for delivered
                if (lvw.SubItems[4].Text == "Delivered")
                {
                    lvw.BackColor = Color.White;
                }

                // Check for delivered
                if (lvw.SubItems[4].Text == "Back Order")
                {
                    lvw.BackColor = Color.IndianRed;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPO_Load(object sender, EventArgs e)
        {
            populatePo();
            checkPo();
        }

        private void lblAll_Click(object sender, EventArgs e)
        {
            getPoByStatus("All");
            checkPo();
        }

        private void lblDelivered_Click(object sender, EventArgs e)
        {
            getPoByStatus("Delivered");
            checkPo();
        }

        private void lblBackOrder_Click(object sender, EventArgs e)
        {
            getPoByStatus("BackOrder");
            checkPo();
        }

        private void btnAcceptPO_Click(object sender, EventArgs e)
        {
            action = "Add";
            Dialogs.dlgPo frm = new Dialogs.dlgPo(null, null, null, null, "", "", "", this.action);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                populatePo();
                checkPo();
            }
        }

        private void btnBackOrdder_Click(object sender, EventArgs e)
        {
            if (lstPO.SelectedItems.Count <= 0)
            {
                return;
            }

            int id = Int32.Parse(lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text);

            if (MessageBox.Show(this, "Do you want to back order this po?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                backPo(id);
                populatePo();
                checkPo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPO.SelectedItems.Count <= 0)
            {
                return;
            }

            int id = Int32.Parse(lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text);

            if (MessageBox.Show(this, "Do you want to delete this po?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deletePo(id);
                populatePo();
                checkPo();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            filter = "Supplier";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            filter = "poid";
        }

        private void rboInactive_CheckedChanged(object sender, EventArgs e)
        {
            status = "inactive";
            btnDelete.Text = "&Restore";
            populatePo();
        }

        private void rboActicve_CheckedChanged(object sender, EventArgs e)
        {
            status = "active";
            btnDelete.Text = "&Delete";
            populatePo();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchPo(filter, txtSearch.Text);
            checkPo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstPO.SelectedItems.Count <= 0)
            {
                return;
            }

            action = "Edit";
            Dialogs.dlgPo frm = new Dialogs.dlgPo(this.qty, this.itemName, this.units, this.unitPrice, this.orNumber, this.clientName, this.address, this.action);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                populatePo();
                checkPo();
            }

        }

        private void lstPO_Click(object sender, EventArgs e)
        {
            clearVars();
            getEditPo();
        }
    }
}
