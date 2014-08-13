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
        private string supplierContact = "";
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
                    string sqlQuery = "SELECT * FROM supplier WHERE status = @status";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["supplierId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierContact"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["updated_date"].ToString());
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

        private void insertSupplier(string supplierName, string supplierContact)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO supplier (supplierName, supplierContact) VALUES (@supplierName, @supplierContact)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("supplierName", supplierName);
                    sqlCmd.Parameters.AddWithValue("supplierContact", supplierContact);

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

        private void updateSupplier(string supplierName, string supplierContact, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE supplier SET supplierName=@supplierName, supplierContact=@supplierContact WHERE supplierId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("supplierName", supplierName);
                    sqlCmd.Parameters.AddWithValue("supplierContact", supplierContact);
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

        private void deleteSupplier()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "DELETE FROM supplier WHERE supplierId=@criteria";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show(this, "Supplier data successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgSupplier frmSupplierAdd = new Dialogs.dlgSupplier("add", 0);
            if (frmSupplierAdd.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the supplier
                frmSupplierAdd.getSupplier(out supplierId, out supplierName, out supplierContact);
                insertSupplier(supplierName, supplierContact);
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
            if (frmSupplierEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the supplier
                frmSupplierEdit.getSupplier(out supplierId, out supplierName, out supplierContact);
                updateSupplier(supplierName, supplierContact, supplierId);
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
            supplierContact = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[2].Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteSupplier();
            populateSupplier();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
