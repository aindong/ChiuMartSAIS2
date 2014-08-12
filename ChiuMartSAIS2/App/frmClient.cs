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
    public partial class frmClient : Form
    {
        private Classes.Configuration conf;

        // fields declaration
        private int clientId = 0;
        private string clientName = "";
        private string clientAddress = "";
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
                    string sqlQuery = "SELECT * FROM client";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["clientId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientAddress"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this,errorCode + "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void insertClient(string clientName, string clientAddress)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO client (clientName, clientAddress) VALUES (@clientName, @clientAddress)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("clientName", clientName);
                    sqlCmd.Parameters.AddWithValue("clientAddress", clientAddress);

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

        private void updateClient(string clientName, string clientAddress, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE client SET clientName=@clientName, clientAddress=@clientAddress WHERE clientId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("clientName", clientName);
                    sqlCmd.Parameters.AddWithValue("clientAddress", clientAddress);
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

        private void deleteClient()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "DELETE FROM client WHERE clientId=@criteria";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show(this, "Client data successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Dialogs.dlgClient frmClientAdd = new Dialogs.dlgClient("add", 0);
            if (frmClientAdd.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmClientAdd.getClient(out clientId, out clientName, out clientAddress);
                insertClient(clientName, clientAddress);
                populateClient();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            Dialogs.dlgClient frmClientEdit = new Dialogs.dlgClient("edit", clientId);
            frmClientEdit.clientName = this.clientName;
            frmClientEdit.clientAddress = this.clientAddress;
            if (frmClientEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmClientEdit.getClient(out clientId, out clientName, out clientAddress);
                updateClient(clientName, clientAddress, clientId);
                populateClient();
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            populateClient();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteClient();
            populateClient();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            clientId = id;
            clientName = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[1].Text;
            clientAddress = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[2].Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
