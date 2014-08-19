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
        private int discounts;
        private int pos;
        private int inventoryMonitoring;
        private int purchaseOrder;
        private int inventoryReport;
        private int usersReport;
        private int logsreport;
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
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["discounts"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["pos"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["inventorymonitoring"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["purchaseorder"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["inventoryreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["salesreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["usersreport"].ToString() == "1" ? "True" : "False");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["logsreport"].ToString() == "1" ? "True" : "False");
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
        /// <param name="role"></param>
        /// <param name="products"></param>
        /// <param name="categories"></param>
        /// <param name="units"></param>
        /// <param name="suppliers"></param>
        /// <param name="clients"></param>
        /// <param name="users"></param>
        /// <param name="discounts"></param>
        /// <param name="pos"></param>
        /// <param name="inventoryMonitoring"></param>
        /// <param name="purchaseOrder"></param>
        /// <param name="inventoryReport"></param>
        /// <param name="usersReport"></param>
        /// <param name="logsreport"></param>
        /// <param name="systemUtilities"></param>
        private void insertPermission(string role, int products, int categories, int units, int suppliers, int clients, 
            int users, int discounts, int pos, int inventoryMonitoring, int purchaseOrder, int inventoryReport, 
            int usersReport, int logsreport, int systemUtilities)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO permission(role, products, categories, units, suppliers, clients, users, discounts, ";
                    sqlQuery += "pos, inventorymonitoring, purchaseorder, inventoryreport, usersreport, logsreport, systemutilities, status) ";
                    sqlQuery += "VALUES(@role, @products, @categories, @units, @suppliers, @clients, @users, @discounts, ";
                    sqlQuery += "@pos, @inventorymonitoring, @purchaseorder, @inventoryreport, @usersreport, @logsreport, @systemutilities, 'active') ";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("role", role);
                    sqlCmd.Parameters.AddWithValue("products", products);
                    sqlCmd.Parameters.AddWithValue("categories", categories);
                    sqlCmd.Parameters.AddWithValue("units", units);
                    sqlCmd.Parameters.AddWithValue("suppliers", suppliers);
                    sqlCmd.Parameters.AddWithValue("clients", clients);
                    sqlCmd.Parameters.AddWithValue("users", users);
                    sqlCmd.Parameters.AddWithValue("discouts", discounts);
                    sqlCmd.Parameters.AddWithValue("pos", pos);
                    sqlCmd.Parameters.AddWithValue("inventorymonitoring", inventoryMonitoring);
                    sqlCmd.Parameters.AddWithValue("purchaseorder", purchaseOrder);
                    sqlCmd.Parameters.AddWithValue("inventoryreport", inventoryReport);
                    sqlCmd.Parameters.AddWithValue("usersreport", usersReport);
                    sqlCmd.Parameters.AddWithValue("logsreport", logsreport);
                    sqlCmd.Parameters.AddWithValue("systemutilities", systemUtilities);

                    sqlCmd.ExecuteNonQuery();
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
        /// <param name="role"></param>
        /// <param name="products"></param>
        /// <param name="categories"></param>
        /// <param name="units"></param>
        /// <param name="suppliers"></param>
        /// <param name="clients"></param>
        /// <param name="users"></param>
        /// <param name="discounts"></param>
        /// <param name="pos"></param>
        /// <param name="inventoryMonitoring"></param>
        /// <param name="purchaseOrder"></param>
        /// <param name="inventoryReport"></param>
        /// <param name="usersReport"></param>
        /// <param name="logsreport"></param>
        /// <param name="systemUtilities"></param>
        private void updatePermission(string role, int products, int categories, int units, int suppliers, int clients,
            int users, int discounts, int pos, int inventoryMonitoring, int purchaseOrder, int inventoryReport,
            int usersReport, int logsreport, int systemUtilities)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "UPDATE permission SET role = @role, products = @products, categories = @categories, units = @units, suppliers = @suppliers, clients = @clients, users = @users, discounts = @discounts, ";
                    sqlQuery += "pos = @pos, inventorymonitoring = @inventorymonitoring, purchaseorder = @purchaseorder, inventoryreport = @inventoryreport, usersreport = @usersreport, logsreport = @logsreport, systemutilities = @systemutilities, status";
                    sqlQuery += " WHERE permissionId = @crit";
                    
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("role", role);
                    sqlCmd.Parameters.AddWithValue("products", products);
                    sqlCmd.Parameters.AddWithValue("categories", categories);
                    sqlCmd.Parameters.AddWithValue("units", units);
                    sqlCmd.Parameters.AddWithValue("suppliers", suppliers);
                    sqlCmd.Parameters.AddWithValue("clients", clients);
                    sqlCmd.Parameters.AddWithValue("users", users);
                    sqlCmd.Parameters.AddWithValue("discouts", discounts);
                    sqlCmd.Parameters.AddWithValue("pos", pos);
                    sqlCmd.Parameters.AddWithValue("inventorymonitoring", inventoryMonitoring);
                    sqlCmd.Parameters.AddWithValue("purchaseorder", purchaseOrder);
                    sqlCmd.Parameters.AddWithValue("inventoryreport", inventoryReport);
                    sqlCmd.Parameters.AddWithValue("usersreport", usersReport);
                    sqlCmd.Parameters.AddWithValue("logsreport", logsreport);
                    sqlCmd.Parameters.AddWithValue("systemutilities", systemUtilities);
                    sqlCmd.Parameters.AddWithValue("crit", permissionId);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            }
        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            populatePermission();
        }
    }
}
