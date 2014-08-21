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
    public partial class frmPermissions : Form
    {
        private Classes.Configuration conf;
        private int permissionId;
        private string role;
        private int products;
        private int categories;
        private int units;
        private int suppliers;
        private int clients;
        private int users;
        private int permissions;
        private int pos;
        private int inventoryMonitoring;
        private int purchaseOrder;
        private int chequemonitoring;
        private int inventoryReport;
        private int salesReport;
        private int usersReport;
        private int logsreport;
        private int clientReport;
        private int supplierReport;
        private int systemUtilities;

        public frmPermissions()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        /// <summary>
        /// Gets the permission list on the database and put it on the listview
        /// </summary>
        private void populatePermission()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM permission WHERE status = 'active'";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["permissionId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["role"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["products"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["categories"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["units"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["suppliers"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clients"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["users"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["permission"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["pos"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["inventorymonitoring"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["purchaseorder"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["chequemonitoring"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["inventoryreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["salesreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["usersreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["logsreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["systemutilities"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["updated_date"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        /// <summary>
        /// This function is called to insert a new permission
        /// </summary>
        private void insertPermission()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO permission(role, products, categories, units, suppliers, clients, users, permission, ";
                    sqlQuery += "pos, inventorymonitoring, purchaseorder, chequemonitoring, inventoryreport, salesreport, usersreport, logsreport, clientreport, supplierreport, systemutilities, status) ";
                    sqlQuery += "VALUES(@role, @products, @categories, @units, @suppliers, @clients, @users, @permissions, ";
                    sqlQuery += "@pos, @inventorymonitoring, @purchaseorder, @chequemonitoring, @inventoryreport, @salesreport, @usersreport, @logsreport, @clientreport, @supplierreport, @systemutilities, 'active') ";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("role", role);
                    sqlCmd.Parameters.AddWithValue("products", products);
                    sqlCmd.Parameters.AddWithValue("categories", categories);
                    sqlCmd.Parameters.AddWithValue("units", units);
                    sqlCmd.Parameters.AddWithValue("suppliers", suppliers);
                    sqlCmd.Parameters.AddWithValue("clients", clients);
                    sqlCmd.Parameters.AddWithValue("users", users);
                    sqlCmd.Parameters.AddWithValue("permissions", permissions);
                    sqlCmd.Parameters.AddWithValue("pos", pos);
                    sqlCmd.Parameters.AddWithValue("inventorymonitoring", inventoryMonitoring);
                    sqlCmd.Parameters.AddWithValue("purchaseorder", purchaseOrder);
                    sqlCmd.Parameters.AddWithValue("chequemonitoring", chequemonitoring);
                    sqlCmd.Parameters.AddWithValue("inventoryreport", inventoryReport);
                    sqlCmd.Parameters.AddWithValue("salesreport", salesReport);
                    sqlCmd.Parameters.AddWithValue("usersreport", usersReport);
                    sqlCmd.Parameters.AddWithValue("logsreport", logsreport);
                    sqlCmd.Parameters.AddWithValue("clientreport", clientReport);
                    sqlCmd.Parameters.AddWithValue("supplierreport", supplierReport);
                    sqlCmd.Parameters.AddWithValue("systemutilities", systemUtilities);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Permission successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This will update a given permission
        /// </summary>
        private void updatePermission()
        {
            //try
            //{
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "UPDATE permission SET role = @role, products = @products, categories = @categories, units = @units, suppliers = @suppliers, clients = @clients, users = @users, permission = @permissions, ";
                    sqlQuery += "pos = @pos, inventorymonitoring = @inventorymonitoring, purchaseorder = @purchaseorder, chequemonitoring = @chequemonitoring, inventoryreport = @inventoryreport, salesreport = @salesreport, usersreport = @usersreport, logsreport = @logsreport, clientreport = @clientreport, supplierreport = @supplierreport, systemutilities = @systemutilities";
                    sqlQuery += " WHERE permissionId = @crit";
                    
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("role", role);
                    sqlCmd.Parameters.AddWithValue("products", products);
                    sqlCmd.Parameters.AddWithValue("categories", categories);
                    sqlCmd.Parameters.AddWithValue("units", units);
                    sqlCmd.Parameters.AddWithValue("suppliers", suppliers);
                    sqlCmd.Parameters.AddWithValue("clients", clients);
                    sqlCmd.Parameters.AddWithValue("users", users);
                    sqlCmd.Parameters.AddWithValue("permissions", permissions);
                    sqlCmd.Parameters.AddWithValue("pos", pos);
                    sqlCmd.Parameters.AddWithValue("inventorymonitoring", inventoryMonitoring);
                    sqlCmd.Parameters.AddWithValue("purchaseorder", purchaseOrder);
                    sqlCmd.Parameters.AddWithValue("chequemonitoring", chequemonitoring);
                    sqlCmd.Parameters.AddWithValue("inventoryreport", inventoryReport);
                    sqlCmd.Parameters.AddWithValue("salesreport", salesReport);
                    sqlCmd.Parameters.AddWithValue("usersreport", usersReport);
                    sqlCmd.Parameters.AddWithValue("logsreport", logsreport);
                    sqlCmd.Parameters.AddWithValue("clientreport", clientReport);
                    sqlCmd.Parameters.AddWithValue("supplierreport", supplierReport);
                    sqlCmd.Parameters.AddWithValue("systemutilities", systemUtilities);
                    sqlCmd.Parameters.AddWithValue("crit", permissionId);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Permission successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            /*}
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        /// <summary>
        /// This will make a permission inactive
        /// </summary>
        private void deletePermission()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "UPDATE permission SET status = 'inactive' WHERE permissionId = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("crit", permissionId);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Permission successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgPermission dlg = new Dialogs.dlgPermission();
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Get the data on the dialog
                dlg.GetData(out permissionId, out role, out products, out categories, out units, out suppliers, 
                    out clients, out users, out permissions, out pos, out inventoryMonitoring, out purchaseOrder, out chequemonitoring, out inventoryReport, 
                    out salesReport, out usersReport, out logsreport, out clientReport, out supplierReport, out systemUtilities);

                // Insert the new permission to the database
                insertPermission();

                // Populate the list again
                populatePermission();
            }
        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            populatePermission();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Dialogs.dlgPermission dlg = new Dialogs.dlgPermission();

                // Set the fields
                dlg.permissionId = this.permissionId;
                dlg.role = this.role;
                dlg.products = this.products;
                dlg.categories = this.categories;
                dlg.units = this.units;
                dlg.suppliers = this.suppliers;
                dlg.clients = this.clients;
                dlg.users = this.users;
                dlg.permissions = this.permissions;
                dlg.pos = this.pos;
                dlg.inventoryMonitoring = this.inventoryMonitoring;
                dlg.purchaseOrder = this.purchaseOrder;
                dlg.chequemonitoring = this.chequemonitoring;
                dlg.inventoryReport = this.inventoryReport;
                dlg.salesReport = this.salesReport;
                dlg.usersReport = this.usersReport;
                dlg.logsreport = this.logsreport;
                dlg.clientReport = this.clientReport;
                dlg.supplierReport = this.supplierReport;
                dlg.systemUtilities = this.systemUtilities;

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    // Get the data on the dialog
                    dlg.GetData(out permissionId, out role, out products, out categories, out units, out suppliers,
                        out clients, out users, out permissions, out pos, out inventoryMonitoring, out purchaseOrder, out chequemonitoring, out inventoryReport,
                        out salesReport, out usersReport, out logsreport, out clientReport, out supplierReport, out systemUtilities);

                    // Insert the new permission to the database
                    updatePermission();

                    // Populate the list again
                    populatePermission();
                }
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            permissionId = Int32.Parse( listView1.SelectedItems[0].Text );
            role = listView1.SelectedItems[0].SubItems[1].Text;
            products = listView1.SelectedItems[0].SubItems[2].Text == "True" ? 1 : 0;
            categories = listView1.SelectedItems[0].SubItems[3].Text == "True" ? 1 : 0;
            units = listView1.SelectedItems[0].SubItems[4].Text == "True" ? 1 : 0;
            suppliers = listView1.SelectedItems[0].SubItems[5].Text == "True" ? 1 : 0;
            clients = listView1.SelectedItems[0].SubItems[6].Text == "True" ? 1 : 0;
            users = listView1.SelectedItems[0].SubItems[7].Text == "True" ? 1 : 0;
            permissions = listView1.SelectedItems[0].SubItems[8].Text == "True" ? 1 : 0;
            pos = listView1.SelectedItems[0].SubItems[9].Text == "True" ? 1 : 0;
            inventoryMonitoring = listView1.SelectedItems[0].SubItems[10].Text == "True" ? 1 : 0;
            purchaseOrder = listView1.SelectedItems[0].SubItems[11].Text == "True" ? 1 : 0;
            chequemonitoring = listView1.SelectedItems[0].SubItems[12].Text == "True" ? 1 : 0;
            inventoryReport = listView1.SelectedItems[0].SubItems[13].Text == "True" ? 1 : 0;
            salesReport = listView1.SelectedItems[0].SubItems[14].Text == "True" ? 1 : 0;
            usersReport = listView1.SelectedItems[0].SubItems[15].Text == "True" ? 1 : 0;
            logsreport = listView1.SelectedItems[0].SubItems[16].Text == "True" ? 1 : 0;
            clientReport = listView1.SelectedItems[0].SubItems[17].Text == "True" ? 1 : 0;
            supplierReport = listView1.SelectedItems[0].SubItems[18].Text == "True" ? 1 : 0;
            systemUtilities = listView1.SelectedItems[0].SubItems[19].Text == "True" ? 1 : 0;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deletePermission();
                    populatePermission();
                }
            }
        }
    }
}
