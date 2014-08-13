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
    public partial class frmUnits : Form
    {
        // fields declaration
        private int unitId = 0;
        private string unitDesc = "";
        private string status = "active";

        private Classes.Configuration conf;
        public frmUnits()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        /// <summary>
        /// Searching of units.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="critera"></param>
        private void searchUnit(string filter, string critera)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    
                    
                     string sqlQuery = "SELECT * FROM units WHERE unitDesc LIKE @crit AND status = @status";
                   

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    // SQL Query Parameters
                    sqlCmd.Parameters.AddWithValue("crit", "%" + critera + "%");
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["unitId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
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
        private void populateUnits()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM units WHERE status = @status";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["unitId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
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

        private void insertUnit(string unitDesc)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO units (unitDesc) VALUES (@unitDesc)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("unitDesc", unitDesc);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Unit successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Adding new Unit error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateUnit(string unitDesc, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE units SET unitDesc=@unitDesc WHERE unitId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("unitDesc", unitDesc);
                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Unit successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating Unit error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteUnit()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "DELETE FROM units WHERE unitId=@criteria";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show(this, "Unit data successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Dialogs.dlgUnits frmUnitsAdd = new Dialogs.dlgUnits("add", 0);
            if (frmUnitsAdd.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the unit
                frmUnitsAdd.getUnit(out unitId, out unitDesc);
                insertUnit(unitDesc);
                populateUnits();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgUnits frmUnitsEdit = new Dialogs.dlgUnits("edit", unitId);
            frmUnitsEdit.unitDesc = this.unitDesc;
            if (frmUnitsEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmUnitsEdit.getUnit(out unitId, out unitDesc);
                updateUnit(unitDesc, unitId);
                populateUnits();
            }
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            populateUnits();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteUnit();
            populateUnits();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            unitId = id;
            unitDesc = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[1].Text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Setting filter for unit.
            string filter = "unitDesc";
            searchUnit(filter, txtSearch.Text);
        }
    }
}
