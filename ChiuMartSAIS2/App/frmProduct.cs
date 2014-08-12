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
    public partial class frmProduct : Form
    {
        public List<String> units = new List<string>();

        private Classes.Configuration conf;
        public frmProduct()
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

                    units.Clear();

                    while (reader.Read())
                    {
                        units.Add(reader["unitDesc"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this, errorCode + "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void populateProduct()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["productId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productStock"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["categoryName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productPrice"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productSafetyStock"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this, errorCode + "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgProducts frmProductsAdd = new Dialogs.dlgProducts("add", "");
            populateUnits();
            frmProductsAdd.units = this.units;
            if (frmProductsAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgProducts frmProductsAdd = new Dialogs.dlgProducts("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmProductsAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            populateProduct();
        }
    }
}
