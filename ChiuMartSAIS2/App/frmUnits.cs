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
        private Classes.Configuration conf;
        public frmUnits()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateUnits()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM units";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["unitId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
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
            Dialogs.dlgUnits frmUnitsAdd = new Dialogs.dlgUnits("add", "");
            if (frmUnitsAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgUnits frmUnitsEdit = new Dialogs.dlgUnits("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmUnitsEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            populateUnits();
        }
    }
}
