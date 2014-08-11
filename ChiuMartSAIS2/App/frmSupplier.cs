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
                    string sqlQuery = "SELECT * FROM supplier";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["supplierId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierContact"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this, errorCode + "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgSupplier frmSupplierAdd = new Dialogs.dlgSupplier("add", "");
            if (frmSupplierAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgSupplier frmSupplierEdit = new Dialogs.dlgSupplier("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmSupplierEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            populateSupplier();
        }
    }
}
