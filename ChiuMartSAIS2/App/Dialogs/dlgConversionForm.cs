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

        // Check stocks
        private int checkStockByProductName(string productName)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT productStock FROM products WHERE productName = @productName";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("productName", productName);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = Int32.Parse(reader["productStock"].ToString());
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

        private List<int> poStock = new List<int>();
        private List<String> poSupplierPrice = new List<string>();
        // Get The PO Queue
        private void getPoQueue(string crit)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM po_queue WHERE product_id = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    poStock.Clear();
                    poSupplierPrice.Clear();

                    while (reader.Read())
                    {
                        poStock.Add(Int32.Parse(reader["stock"].ToString()));
                        poSupplierPrice.Add(reader["supplier_price"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Message);
                    MessageBox.Show(this, "Error Retrieving queue stocks", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        // Add a product stock on queue
        private void updateProductQueueAdd(string productId, string price, string stock)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "UPDATE po_queue SET stock = stock + @stock WHERE product_id = @productId AND supplier_price = @price";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("stock", stock);
                    sqlCmd.Parameters.AddWithValue("productId", productId);
                    sqlCmd.Parameters.AddWithValue("price", price);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Adding new po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Subtract a product stock on queue
        private void updateProductQueueSubtract(string productId, string price, string stock)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "UPDATE po_queue SET stock = stock - @stock WHERE product_id = @productId AND supplier_price = @price";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("stock", stock);
                    sqlCmd.Parameters.AddWithValue("productId", productId);
                    sqlCmd.Parameters.AddWithValue("price", price);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Adding new po error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string[] rows = new string[5];
                        rows[0] = reader["quantity"].ToString();
                        rows[1] = getProductName(reader["product_id"].ToString());
                        rows[2] = reader["price"].ToString();
                        rows[3] = getProductName(reader["relationId"].ToString());
                        rows[4] = reader["supplierPrice"].ToString();

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
        private void insertLog(int qty, string productName, string originalProductName, int originalQty, string price)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "INSERT INTO logs(quantity, product_id, relationId, price, clientId, username, log_type, supplierPrice) VALUES(@quantity, @product_id, @relationId, @price, @clientId, @username, @log_type, @supplierPrice)";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("quantity", qty);
                    sqlCmd.Parameters.AddWithValue("product_id", getProductIdByName(productName));
                    sqlCmd.Parameters.AddWithValue("relationId", getProductIdByName(originalProductName));
                    sqlCmd.Parameters.AddWithValue("price", originalQty);
                    sqlCmd.Parameters.AddWithValue("clientId", getConversionId() + 1);
                    sqlCmd.Parameters.AddWithValue("username", Classes.Authentication.Instance.username);
                    sqlCmd.Parameters.AddWithValue("log_type", "Conversion");
                    sqlCmd.Parameters.AddWithValue("supplierPrice", price);
                    
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

        private Boolean checkProductQueue(string productId, string price)
        {
            bool result = false;

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM po_queue WHERE product_id = @productId AND supplier_price = @price";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("productId", productId);
                    sqlCmd.Parameters.AddWithValue("price", price);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Adding new purchase order error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            return result;
        }

        private void updateProductQueue(string productId, string price, string stock)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "UPDATE po_queue SET stock = stock + @stock WHERE product_id = @productId AND supplier_price = @price";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("stock", stock);
                    sqlCmd.Parameters.AddWithValue("productId", productId);
                    sqlCmd.Parameters.AddWithValue("price", price);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Adding new purchase order error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertProductQueue(string productId, string price, string stock)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO po_queue(product_id, supplier_price, stock) VALUES(@productId, @price, @stock)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("productId", productId);
                    sqlCmd.Parameters.AddWithValue("price", price);
                    sqlCmd.Parameters.AddWithValue("stock", stock);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Adding new purchase order error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startConversion()
        {
            for (int i = 0; i < dgvConvert.Rows.Count - 1; i++)
            {
                // If the row has null value, then don't include it
                if (dgvConvert.Rows[i].Cells[1].Value == null)
                {
                    continue;
                }

                if (dgvConvert.Rows[i].Cells[1].Value.ToString() != "")
                {
                    string productName = dgvConvert.Rows[i].Cells[3].Value.ToString();
                    int qty = Int32.Parse(dgvConvert.Rows[i].Cells[2].Value.ToString());

                    string originalProductName = dgvConvert.Rows[i].Cells[1].Value.ToString();
                    int originalQty = Int32.Parse(dgvConvert.Rows[i].Cells[0].Value.ToString());
                    string newPrice = dgvConvert.Rows[i].Cells[4].Value.ToString();

                    // Add new product stock
                    updateStockByProductName(productName, qty, false);
                    // Subtract from source product stock
                    updateStockByProductName(originalProductName, originalQty, true);

                    int originalProductId = getProductIdByName(originalProductName);
                    int prodId = getProductIdByName(productName);
                    getPoQueue(originalProductId.ToString());

                    // Subtract the PO Queue of the source product
                    for (int j = 0; j < poStock.Count; j++)
                    {
                        if (poStock[j] >= originalQty)
                        {
                            updateProductQueueSubtract(originalProductId.ToString(), poSupplierPrice[j], originalQty.ToString());
                            break;
                        }
                        else
                        {
                            if (poStock[j] != 0)
                            {
                                updateProductQueueSubtract(originalProductId.ToString(), poSupplierPrice[j], poStock[j].ToString());
                            }
                        }
                        originalQty = originalQty - poStock[j];
                    }

                    // TODO: GET THE HIGHEST PRICE SOLD
                    // CHECK IF PRODUCT_ID EXIST ON THE PO_QUEUE TABLE
                    // IF NOT, ADD A NEW PO_QUEUE FOR THIS PRODUCT
                    // 
                    //Update queue as well
                    if (checkProductQueue(prodId.ToString(), newPrice) == true)
                    {
                        updateProductQueue(prodId.ToString(), newPrice, qty.ToString());
                    }
                    else
                    {
                        insertProductQueue(prodId.ToString(), newPrice, qty.ToString());
                    }

                    // Insert log
                    insertLog(qty, productName, originalProductName, originalQty, newPrice);
                }
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                int icolumn = dgvConvert.CurrentCell.ColumnIndex;
                int irow = dgvConvert.CurrentCell.RowIndex;

                if (keyData == Keys.Enter)
                {
                    if (icolumn == dgvConvert.Columns.Count - 1)
                    {
                        dgvConvert.Rows.Add();
                        dgvConvert.CurrentCell = dgvConvert[0, irow + 1];
                    }
                    else
                    {
                        dgvConvert.CurrentCell = dgvConvert[icolumn + 1, irow];
                    }
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch (NullReferenceException ex)
            {
                return false;
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

        private void dgvConvert_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConvert.CurrentCell.ColumnIndex == 1)
            {
                string prodName = dgvConvert.Rows[dgvConvert.CurrentRow.Index].Cells[1].Value.ToString();
                int wantConvert = Int32.Parse(dgvConvert.Rows[dgvConvert.CurrentRow.Index].Cells[0].Value.ToString());

                if (checkStockByProductName(prodName) <= 0)
                {
                    MessageBox.Show("This product is out of stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvConvert.Rows.Remove(dgvConvert.Rows[dgvConvert.CurrentRow.Index]);
                    return;
                }

                if (checkStockByProductName(prodName) <= wantConvert)
                {
                    MessageBox.Show("This product only has " + checkStockByProductName(prodName) + " left", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvConvert.Rows.Remove(dgvConvert.Rows[dgvConvert.CurrentRow.Index]);
                    return;
                }
            }
        }
    }
}
