﻿using System;
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
    public partial class frmClient : Form
    {
        private Classes.Configuration conf;

        // fields declaration
        private int clientId = 0;
        private string clientName = "";
        private string clientAddress = "";
        private string clientContact = "";
        private string status = "active";

        public frmClient()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateClient()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM client WHERE status = @status ORDER BY clientName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["clientId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientContact"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientAddress"].ToString());
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
                    MessageBox.Show(this,"Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchClient(string critera)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM client WHERE clientName LIKE @crit AND status = @status ORDER BY clientName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    // SQL Query Parameters
                    sqlCmd.Parameters.AddWithValue("crit", "%" + critera + "%");
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["clientId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientContact"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientAddress"].ToString());
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

        private void insertClient(string clientName, string clientAddress, string clientContact)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO client (clientName, clientAddress, clientContact, status) VALUES (@clientName, @clientAddress, @clientContact, 'active')";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("clientName", clientName);
                    sqlCmd.Parameters.AddWithValue("clientAddress", clientAddress);
                    sqlCmd.Parameters.AddWithValue("clientContact", clientContact);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Client successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Adding new Client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateClient(string clientName, string clientAddress, string clientContact, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE client SET clientName=@clientName, clientAddress=@clientAddress, clientContact=@clientContact WHERE clientId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("clientName", clientName);
                    sqlCmd.Parameters.AddWithValue("clientAddress", clientAddress);
                    sqlCmd.Parameters.AddWithValue("clientContact", clientContact);
                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Client successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating new Client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteClient(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE client SET status='inactive' WHERE clientId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Client successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Deleting client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void restoreClient(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE client SET status='active' WHERE clientId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Client successfully restored", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgClient frmClientAdd = new Dialogs.dlgClient("add", 0);
            if (frmClientAdd.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmClientAdd.getClient(out clientId, out clientName, out clientAddress, out clientContact);
                insertClient(clientName, clientAddress, clientContact);
                populateClient();
                listView1.Items[listView1.Items.Count - 1].EnsureVisible();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            Dialogs.dlgClient frmClientEdit = new Dialogs.dlgClient("edit", id);
            frmClientEdit.clientName = this.clientName;
            frmClientEdit.clientAddress = this.clientAddress;
            frmClientEdit.clientContact = this.clientContact;
            if (frmClientEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmClientEdit.getClient(out clientId, out clientName, out clientAddress, out clientContact);
                updateClient(clientName, clientAddress, clientContact, clientId);
                populateClient();
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            if (Classes.Authentication.Instance.role != "Administrator")
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }

            populateClient();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            if (btnDelete.Text == "&Delete")
            {
                if (MessageBox.Show(this, "Do you want to delete this client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deleteClient(clientId);
                    populateClient();
                }
            }
            else
            {
                if (MessageBox.Show(this, "Do you want to restore this client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    restoreClient(clientId);
                    populateClient();
                }
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            clientId = id;
            clientName = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[1].Text;
            clientContact = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[2].Text;
            clientAddress = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[3].Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchClient(txtSearch.Text);
        }

        private void rboActive_CheckedChanged(object sender, EventArgs e)
        {
            btnDelete.Text = "&Delete";
            status = "active";
            populateClient();
        }

        private void rboInactive_CheckedChanged(object sender, EventArgs e)
        {
            status = "inactive";
            btnDelete.Text = "&Restore";
            populateClient();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            Dialogs.dlgClient frmClientEdit = new Dialogs.dlgClient("edit", id);
            frmClientEdit.clientName = this.clientName;
            frmClientEdit.clientAddress = this.clientAddress;
            frmClientEdit.clientContact = this.clientContact;
            if (frmClientEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmClientEdit.getClient(out clientId, out clientName, out clientAddress, out clientContact);
                updateClient(clientName, clientAddress, clientContact, clientId);
                populateClient();
            }
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
