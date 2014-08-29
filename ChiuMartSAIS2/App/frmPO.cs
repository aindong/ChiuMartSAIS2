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
                    string sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();

                    while (reader.Read())
                    {
                        lstPO.Items.Add(reader["id"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poQty"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());

                        // converts the chequeDate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
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
                    string sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status";
                    DateTime dateNow = DateTime.Today;
                    if (poStatus == "Waiting")
                    {
                        sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = 'active' AND p.poStatus = 'Waiting'";
                    }
                    else if (poStatus == "Delivered")
                    {
                        sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = 'active' AND p.poStatus = 'Delivered'";
                    }
                    else if (poStatus == "BackOrder")
                    {
                        sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = 'inactive' AND p.poStatus = 'Back Order'";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("status", this.status);
                    
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();

                    while (reader.Read())
                    {
                        lstPO.Items.Add(reader["id"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poQty"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());

                        // converts the chequeDate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
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
                    
                        string sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status AND supplierName LIKE @crit";
                    
                    if (filter == "Supplier")
                    {
                        sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status AND supplierName LIKE @crit";
                    } else if (filter == "Product") {
                        sqlQuery = "SELECT p.id, p.poQty, p.poStatus, p.poDate, p.status, s.supplierName, pr.productName FROM po as p INNER JOIN supplier as s ON p.supplierId = s.supplierId INNER JOIN products as pr ON p.productId = pr.productId WHERE p.status = @status AND productName LIKE @crit";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    // SQL Query Parameters
                    sqlCmd.Parameters.AddWithValue("crit", "%" + critera + "%");
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstPO.Items.Clear();

                    while (reader.Read())
                    {
                        lstPO.Items.Add(reader["id"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poQty"].ToString());
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["poStatus"].ToString());

                        // converts the chequeDate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["poDate"].ToString(), out aDate);
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));
                        lstPO.Items[lstPO.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void acceptPo(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE po SET poStatus='Delivered' WHERE id=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Po accepted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Accepting po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string sqlQuery = "UPDATE po SET poStatus='Delivered', status='inactive' WHERE id=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Po turned to Back Order", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Back Order po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void checkPo()
        {
            // Check the po status
            foreach (ListViewItem lvw in lstPO.Items)
            {

                // Check for waiting
                if (lvw.SubItems[4].Text == "Waiting")
                {
                    lvw.BackColor = Color.Lime;
                }

                // Check for delivered
                if (lvw.SubItems[4].Text == "Delivered")
                {
                    lvw.BackColor = Color.LightSeaGreen;
                }

                // Check for delivered
                if (lvw.SubItems[6].Text == "Inactive" && lvw.SubItems[4].Text == "Delivered")
                {
                    lvw.BackColor = Color.IndianRed;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void lblWaiting_Click(object sender, EventArgs e)
        {
            getPoByStatus("Waiting");
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
            if (lstPO.SelectedItems.Count <= 0)
            {
                return;
            }

            int id = Int32.Parse(lstPO.SelectedItems[lstPO.SelectedItems.Count - 1].Text);

            if (MessageBox.Show(this, "Do you want to accept this po?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                acceptPo(id);
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
            filter = "Product";
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
    }
}
