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
        private List<String> prodId = new List<string>();
        private List<String> prodQty = new List<string>();
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
                    string sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND p.poDate BETWEEN @from AND @to AND p.poStatus != 'Verified' ORDER BY poId ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("status", this.status);
                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();

                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstPO.Items.Count > 0)
                        {
                            if (reader["poId"].ToString() == lstPO.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstPO.Items[ctr].SubItems[2].Text, System.Globalization.NumberStyles.Currency);
                                double price = double.Parse(reader["oldPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstPO.Items[ctr].SubItems[2].Text = string.Format("{0:C}", (lstAmount + totalAmount));
                            }
                            else
                            {
                                lstPO.Items.Add(reader["poId"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                                double price = double.Parse(reader["oldPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poDate"].ToString());

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstPO.Items.Add(reader["poId"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                            double price = double.Parse(reader["oldPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poDate"].ToString());

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
                    string sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND p.poStatus != 'Verified' AND p.poDate BETWEEN @from AND @to ORDER BY poId ASC";
                    DateTime dateNow = DateTime.Today;
                    if (poStatus == "Delivered")
                    {
                        sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND p.poStatus = 'Delivered' AND p.poStatus != 'Verified' AND p.poDate BETWEEN @from AND @to ORDER BY poId ASC";
                    }
                    else if (poStatus == "BackOrder")
                    {
                        sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND p.poStatus = 'Back Order' AND p.poStatus != 'Verified' AND p.poDate BETWEEN @from AND @to ORDER BY poId ASC";
                    }
                    else if (poStatus == "Verified")
                    {
                        sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND p.poStatus = 'Verified' AND p.poDate BETWEEN @from AND @to ORDER BY poId ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("status", this.status);
                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.AddDays(1).Date);
                    
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstPO.Items.Count > 0)
                        {
                            if (reader["poId"].ToString() == lstPO.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstPO.Items[ctr].SubItems[2].Text, System.Globalization.NumberStyles.Currency);
                                double price = double.Parse(reader["oldPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstPO.Items[ctr].SubItems[2].Text = (lstAmount + totalAmount).ToString();
                            }
                            else
                            {
                                lstPO.Items.Add(reader["poId"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                                double price = double.Parse(reader["oldPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poDate"].ToString());

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstPO.Items.Add(reader["poId"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                            double price = double.Parse(reader["oldPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poDate"].ToString());

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

                    string sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND supplierName LIKE @crit AND p.poDate BETWEEN @from AND @to ORDER BY poId ASC";
                    
                    if (filter == "Supplier")
                    {
                        sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND supplierName LIKE @crit AND p.poDate BETWEEN @from AND @to ORDER BY poId ASC";
                    } else if (filter == "poid") {
                        sqlQuery = "SELECT p.*, s.supplierName, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId WHERE p.status = @status AND poId LIKE @crit AND p.poDate BETWEEN @from AND @to ORDER BY poId ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    // SQL Query Parameters
                    sqlCmd.Parameters.AddWithValue("crit", "%" + critera + "%");
                    sqlCmd.Parameters.AddWithValue("status", this.status);
                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();
                    int ctr = -1;

                    while (reader.Read())
                    {
                        if (lstPO.Items.Count > 0)
                        {
                            if (reader["poId"].ToString() == lstPO.Items[ctr].Text)
                            {
                                double lstAmount = double.Parse(lstPO.Items[ctr].SubItems[2].Text, System.Globalization.NumberStyles.Currency);
                                double price = double.Parse(reader["oldPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);
                                lstPO.Items[ctr].SubItems[2].Text = string.Format("{0:C}", (lstAmount + totalAmount));
                            }
                            else
                            {
                                lstPO.Items.Add(reader["poId"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                                double price = double.Parse(reader["oldPrice"].ToString());
                                double qty = double.Parse(reader["qty"].ToString());
                                double totalAmount = (price * qty);

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poDate"].ToString());

                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());
                                lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                                ctr++;
                            }
                        }
                        else
                        {
                            lstPO.Items.Add(reader["poId"].ToString());
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());

                            double price = double.Parse(reader["oldPrice"].ToString());
                            double qty = double.Parse(reader["qty"].ToString());
                            double totalAmount = (price * qty);

                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(string.Format("{0:C}", totalAmount));
                            lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poDate"].ToString());

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

        private void backPo(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE po SET poStatus='Back Order' WHERE poId=@criteria";
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

        private void deletePo(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE po SET status='inactive' WHERE poId=@criteria";
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

        private void restorePo(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE po SET status='active' WHERE poId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Po successfully restored", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Restoring po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void verifyPo(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE po SET poStatus='Verified' WHERE poId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Po successfully verified", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Verifiying po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateStocks(string qty, string crit)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE products SET productStock = productStock - @qty WHERE productId = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("qty", qty);
                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    sqlCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating stocks error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// This function will reduce a product stock on queue
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        private void updateProductQueue(string productId, string price, string stock)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "UPDATE po_queue SET stock = stock - @stock WHERE product_id = @productId AND supplier_price = @price";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("stock", stock);
                    sqlCmd.Parameters.AddWithValue("productId", productId);
                    sqlCmd.Parameters.AddWithValue("price", price);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Adding new po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getProductID(string crit)
        {
            prodQty.Clear();
            prodId.Clear();
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT productId, qty, oldPrice FROM po WHERE poId = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        prodId.Add(reader["productId"].ToString());
                        prodQty.Add(reader["qty"].ToString());

                        updateProductQueue(reader["productId"].ToString(), reader["oldPrice"].ToString(), reader["qty"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Message);
                    MessageBox.Show(this, "Error Retrieving product id", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string sqlQuery = "SELECT p.*, s.supplierName, s.supplierAddress, pr.productName, u.unitDesc, p.oldPrice FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId INNER JOIN units as u ON p.unitId = u.unitId WHERE p.poId = @crit";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        qty.Add(reader["qty"].ToString());
                        itemName.Add(reader["productName"].ToString());
                        units.Add(reader["unitDesc"].ToString());
                        unitPrice.Add(reader["oldPrice"].ToString());
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

                // Check for verify
                if (lvw.SubItems[4].Text == "Verified")
                {
                    lvw.BackColor = Color.DeepSkyBlue;
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
            populatePo();
            checkPo();
        }

        private void btnBackOrdder_Click(object sender, EventArgs e)
        {
            if (lstPO.SelectedItems.Count <= 0)
            {
                return;
            }

            if (lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].SubItems[4].Text == "Back Order")
            {
                MessageBox.Show(this, "This purchase order is already a back order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text;

            if (MessageBox.Show(this, "Do you want to back order this purchase order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                getProductID(lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text);
                for (int i = 0; i < (prodId.Count()); i++)
                {
                    int crit = Int32.Parse(prodId[i]);
                    updateStocks(prodQty[i], prodId[i]);

                }
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

            string id = lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text;
            if (btnDelete.Text == "&Delete")
            {
                if (MessageBox.Show(this, "Do you want to delete this purchase order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deletePo(id);
                    populatePo();
                    checkPo();
                }
            }
            else
            {
                if (MessageBox.Show(this, "Do you want to restore this purchase order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    restorePo(id);
                    populatePo();
                    checkPo();
                }
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
            checkPo();
        }

        private void rboActicve_CheckedChanged(object sender, EventArgs e)
        {
            status = "active";
            btnDelete.Text = "&Delete";
            populatePo();
            checkPo();
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

        private void lstPO_DoubleClick(object sender, EventArgs e)
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

        private void lblVerified_Click(object sender, EventArgs e)
        {
            getPoByStatus("Verified");
            checkPo();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (lstPO.SelectedItems.Count <= 0)
            {
                return;
            }

            string id = lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text;

            if (MessageBox.Show(this, "Do you want to verify this purchase order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                verifyPo(id);
                populatePo();
                checkPo();
            }
        }

        private void frmPO_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnChiumartRetail_Click(object sender, EventArgs e)
        {
            frmChiumartRetail frm = new frmChiumartRetail();
           
            if (frm.ShowDialog() == DialogResult.OK)
            {
                populatePo();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            populatePo();
            checkPo();
        }
    }
}
