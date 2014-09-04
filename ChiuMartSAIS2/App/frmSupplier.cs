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
    public partial class frmSupplier : Form
    {

        // fields declaration
        private int supplierId = 0;
        private string supplierName = "";
        private string supplierAddress = "";
        private string supplierContact = "";
        private string supplierContactPerson = "";
        private string status = "active";

        private Classes.Configuration conf;
        public frmSupplier()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateSupplier()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM supplier WHERE status = @status ORDER BY supplierName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["supplierId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierAddress"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierContact"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierContactPerson"].ToString());
                        // converts the transdate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["created_date"].ToString(), out aDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                        // converts the transdate to datetime
                        DateTime uDate;
                        DateTime.TryParse(reader["updated_date"].ToString(), out uDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(uDate.ToString("MMMM dd, yyyy"));
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void insertSupplier(string supplierName, string supplierAddress, string supplierContact, string supplierContactPerson)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO supplier (supplierName, supplierAddress, supplierContact, supplierContactPerson, status) VALUES (@supplierName, @supplierAddress, @supplierContact, @supplierContactPerson, 'active')";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("supplierName", supplierName);
                    sqlCmd.Parameters.AddWithValue("supplierAddress", supplierAddress);
                    sqlCmd.Parameters.AddWithValue("supplierContact", supplierContact);
                    sqlCmd.Parameters.AddWithValue("supplierContactPerson", supplierContactPerson);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Supplier successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Adding new Supplier error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateSupplier(string supplierName, string supplierAddress, string supplierContact, string supplierContactPerson, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE supplier SET supplierName=@supplierName, supplierAddress=@supplierAddress, supplierContact=@supplierContact, supplierContactPerson=@supplierContactPerson WHERE supplierId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("supplierName", supplierName);
                    sqlCmd.Parameters.AddWithValue("supplierAddress", supplierAddress);
                    sqlCmd.Parameters.AddWithValue("supplierContact", supplierContact);
                    sqlCmd.Parameters.AddWithValue("supplierContactPerson", supplierContactPerson);
                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Supplier successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating Supplier error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteSupplier(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE supplier SET status='inactive' WHERE supplierId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Supplier successfully delete", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Deleting Supplier error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void restoreSupplier(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE supplier SET status='active' WHERE supplierId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Supplier successfully restored", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Restoring Supplier error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgSupplier frmSupplierAdd = new Dialogs.dlgSupplier("add", 0);
            if (frmSupplierAdd.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the supplier
                frmSupplierAdd.getSupplier(out supplierId, out supplierName, out supplierAddress, out supplierContact, out supplierContactPerson);
                insertSupplier(supplierName, supplierAddress, supplierContact, supplierContactPerson);
                populateSupplier();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgSupplier frmSupplierEdit = new Dialogs.dlgSupplier("edit", supplierId);
            frmSupplierEdit.supplierName = this.supplierName;
            frmSupplierEdit.supplierContact = this.supplierContact;
            frmSupplierEdit.supplierContactPerson = this.supplierContactPerson;
            frmSupplierEdit.supplierAddress = this.supplierAddress;
            if (frmSupplierEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the supplier
                frmSupplierEdit.getSupplier(out supplierId, out supplierName, out supplierAddress, out supplierContact, out supplierContactPerson);
                updateSupplier(supplierName, supplierAddress, supplierContact, supplierContactPerson, supplierId);
                populateSupplier();
            }
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            populateSupplier();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            supplierId = id;
            supplierName = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[1].Text;
            supplierAddress = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[2].Text;
            supplierContact = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[3].Text;
            supplierContactPerson = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[4].Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            if (btnDelete.Text == "&Delete")
            {
                if (MessageBox.Show(this, "Do you want to delete this supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deleteSupplier(supplierId);
                    populateSupplier();
                }
            }
            else
            {
                if (MessageBox.Show(this, "Do you want to restore this supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    restoreSupplier(supplierId);
                    populateSupplier();
                }
            }
        }

        /// <summary>
        /// Searching of Suppliers using filters. 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="critera"></param>
        private void searchSupplier(string filter, string critera)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "";
                    if (filter == "supName")
                    {
                        sqlQuery = "SELECT * FROM supplier WHERE supplierName LIKE @crit AND status = @status ORDER BY supplierName ASC";
                    }
                    else if (filter == "supConPerson")
                    {
                        sqlQuery = "SELECT * FROM supplier WHERE supplierContactPerson LIKE @crit AND status = @status ORDER BY supplierName ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    // SQL Query Parameters
                    sqlCmd.Parameters.AddWithValue("crit", "%" + critera + "%");
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["supplierId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierAddress"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierContact"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierContactPerson"].ToString());
                        // converts the transdate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["created_date"].ToString(), out aDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                        // converts the transdate to datetime
                        DateTime uDate;
                        DateTime.TryParse(reader["updated_date"].ToString(), out uDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(uDate.ToString("MMMM dd, yyyy"));
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Selecting which filter to use. 

            string filter = "";

            if (rboSupName.Checked)
            {
                filter = "supName";
            }
            else if (rboSupConPerson.Checked)
            {
                filter = "supConPerson";
            }


            searchSupplier(filter, txtSearch.Text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rboActive_CheckedChanged(object sender, EventArgs e)
        {
            status = "active";
            btnDelete.Text = "&Delete";
            populateSupplier();
        }

        private void rboInactive_CheckedChanged(object sender, EventArgs e)
        {
            status = "inactive";
            btnDelete.Text = "&Restore";
            populateSupplier();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
