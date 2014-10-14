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
using System.Text.RegularExpressions;

namespace ChiuMartSAIS2.App.ReportDialog
{
    public partial class dlgManualInventory : Form
    {
        private string status = "active";

        private Classes.Configuration conf;
        public dlgManualInventory()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateProduct()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT productId, productName FROM products WHERE status = @status ORDER BY productName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    dgvProduct.Rows.Clear();

                    while (reader.Read())
                    {
                        string[] dataRow = new string[] { reader["productId"].ToString(), reader["productName"].ToString() };
                        dgvProduct.Rows.Add(dataRow);
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string checkStatus(int physical, int actual)
        {
            string result = "";
            if (physical > actual)
            {
                result = "OVER - " + (physical - actual);
                return result;
            }
            else if (actual > physical)
            {
                result = "SHORT - " + (actual - physical);                
                return result;
            }
            else
            {
                result = "TALLY";
                return result;
            }
        }

        private string populateStocks(string id)
        {
            string result = "";
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT productStock FROM products WHERE status = @status AND productId = @id ORDER BY productName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);
                    sqlCmd.Parameters.AddWithValue("id", id);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader["productStock"].ToString();                      
                    }
                    return result;
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result;
                }
            }
        }

        private void dlgManualInventory_Load(object sender, EventArgs e)
        {
            populateProduct();
        }

        private void dgvProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.CurrentCell.ColumnIndex == 2)
            {
                string id = dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells[0].Value.ToString();
                int physical = Int32.Parse(dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells[2].Value.ToString());
                dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells[3].Value = populateStocks(id);
                int actual = Int32.Parse(dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells[3].Value.ToString());
                
                dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells[4].Value = checkStatus(physical, actual);
            }
        }

        private void dgvProduct_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvProduct.CurrentCell.ColumnIndex != 2)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
