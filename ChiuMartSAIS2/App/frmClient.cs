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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgClient frmClientAdd = new Dialogs.dlgClient("add", "");
            if (frmClientAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgClient frmClientEdit = new Dialogs.dlgClient("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmClientEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            populateClient();
        }
    }
}
