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

namespace ChiuMartSAIS2.App.ReportDialog
{
    public partial class dlgSupplierReport : Form
    {
        private string status = "active";

        private Classes.Configuration conf;

        public dlgSupplierReport()
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

        private void searchSupplier(string critera)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM supplier WHERE supplierName LIKE @crit AND status = @status ORDER BY supplierName ASC";
                    
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rboActive_CheckedChanged(object sender, EventArgs e)
        {
            status = "active";
            populateSupplier();
        }

        private void rboInactive_CheckedChanged(object sender, EventArgs e)
        {
            status = "inactive";
            populateSupplier();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchSupplier(txtSearch.Text);
        }

        private void dlgSupplierReport_Load(object sender, EventArgs e)
        {
            populateSupplier();
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            dlgIndividualLog log = new dlgIndividualLog();
            log.logType = "supplier";
            log.relationId = listView1.SelectedItems[0].Text;
            log.ShowDialog();
        }
    }
}
