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

namespace ChiuMartSAIS2.App.Dialogs
{
    public partial class dlgConversionForm : Form
    {

        private AutoCompleteStringCollection prodSource = new AutoCompleteStringCollection();

        private Classes.Configuration conf;
        public bool viewing = false;
        public int id = 0;

        public dlgConversionForm()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        // for product suggestion
        private void populateProductTextbox()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.status = 'active'";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string product = reader["productName"].ToString();
                        prodSource.AddRange(new String[] { product });
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // update stocks
        private void updateStockByProductName(string productName, int qty, bool add)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "";

                    // check if we wants to add or subtract a product stock
                    if (add)
                    {
                        sql = "UPDATE products SET productStock = productStock + @qty WHERE productName = @productName";
                    }
                    else
                    {
                        sql = "UPDATE products SET productStock = productStock - @qty WHERE productName = @productName";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("qty", qty);
                    sqlCmd.Parameters.AddWithValue("productName", productName);

                    sqlCmd.ExecuteNonQuery();

                   //MessageBox.Show("New conversion of products was ma/de successfully", "Conversion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Get productId by productName
        private int getProductIdByName(string productName)
        {
            int result = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT productId FROM products WHERE productName = @productName LIMIT 1";

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("productName", productName);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = Int32.Parse(reader["productId"].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        // Populate listview for viewing
        private void populateListviewForViewing()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT * FROM logs WHERE clientId = @id AND log_type = 'Conversion'";

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("id", this.id);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] rows = new string[4];
                        rows[0] = reader["quantity"].ToString();
                        rows[1] = getProductName(reader["product_id"].ToString());
                        rows[2] = reader["price"].ToString();
                        rows[3] = getProductName(reader["relationId"].ToString());

                        dgvConvert.Rows.Add(rows);
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        // Get product name
        private string getProductName(string productId)
        {
            string result = "";

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT productName FROM products WHERE productId = @productId LIMIT 1";

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("productId", productId);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader["productName"].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        // Insert conversion log
        private void insertLog(int qty, string productName, string originalProductName, int originalQty)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "INSERT INTO logs(quantity, product_id, relationId, price, clientId, username, log_type) VALUES(@quantity, @product_id, @relationId, @price, @clientId, @username, @log_type)";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("quantity", qty);
                    sqlCmd.Parameters.AddWithValue("product_id", getProductIdByName(productName));
                    sqlCmd.Parameters.AddWithValue("relationId", getProductIdByName(originalProductName));
                    sqlCmd.Parameters.AddWithValue("price", originalQty);
                    sqlCmd.Parameters.AddWithValue("clientId", getConversionId() + 1);
                    sqlCmd.Parameters.AddWithValue("username", Classes.Authentication.Instance.username);
                    sqlCmd.Parameters.AddWithValue("log_type", "Conversion");
                    
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show("Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int getConversionId()
        {
            int result = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT id FROM conversion ORDER BY id DESC LIMIT 1";

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = Int32.Parse(reader["id"].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Getting conversion id error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void startConversion()
        {
            for (int i = 0; i < dgvConvert.Rows.Count - 1; i++)
            {
                if (dgvConvert.Rows[i].Cells[1].Value.ToString() != "")
                {
                    string productName = dgvConvert.Rows[i].Cells[1].Value.ToString();
                    int qty = Int32.Parse(dgvConvert.Rows[i].Cells[0].Value.ToString());

                    string originalProductName = dgvConvert.Rows[i].Cells[3].Value.ToString();
                    int originalQty = Int32.Parse(dgvConvert.Rows[i].Cells[2].Value.ToString());

                    // Add new product stock
                    updateStockByProductName(productName, qty, false);
                    // Subtract from source product stock
                    updateStockByProductName(originalProductName, originalQty, true);

                    // Insert log
                    insertLog(qty, productName, originalProductName, originalQty);
                }
            }
        }

        private void dlgConversionForm_Load(object sender, EventArgs e)
        {
            if (viewing && this.id > 0)
            {
                btnSave.Enabled = false;
                btnRemove.Enabled = false;
                populateListviewForViewing();
            }

            populateProductTextbox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update the stocks
            if (dgvConvert.Rows.Count > 0)
            {
                startConversion();
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvConvert_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox prodName = e.Control as TextBox;
            if (dgvConvert.CurrentCell.ColumnIndex == 1 || dgvConvert.CurrentCell.ColumnIndex == 3)
            {
                if (prodName != null)
                {
                    prodName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodName.AutoCompleteCustomSource = prodSource;
                }
            }
            else
            {
                prodName.AutoCompleteCustomSource = null;
            }

        }
    }
}
