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

namespace ChiuMartSAIS2.App
{
    public partial class frmPOS : Form
    {
        private Classes.Configuration conf;
        private AutoCompleteStringCollection prodSource = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection unitSource = new AutoCompleteStringCollection();
        private List<String> qty = new List<string>();
        private List<String> productName = new List<string>();
        private List<String> units = new List<string>();
        private List<String> productPrice = new List<string>();
        private List<int> poStock = new List<int>();
        private List<String> poSupplierPrice = new List<string>();
        private string orNo;
        private string clientName;
        private string clientAddress;
        private string action;
        private string bank = "";
        private string branch = "";
        private string chequeNo = "";
        private string chequeName = "";
        private string chequeDate = "";
        private string total = "";
        private string yellowBasyoReturned;
        private string transparentBasyoReturned;
        private string status;
        private DateTime transDate;

        public frmPOS(List<String> _qty, List<String> _productName, List<String> _units, List<String> _productPrice, string _poId, string _clientName, string _clientAddress, string _action)
        {
            InitializeComponent();
            action = _action;
            qty = _qty;
            productName = _productName;
            units = _units;
            productPrice = _productPrice;
            orNo = _poId;
            clientName = _clientName;
            clientAddress = _clientAddress;

            conf = new Classes.Configuration();
        }

        /// <summary>
        /// This function will get data from database and populate the textbox for client
        /// </summary>
        private void populateClientTextbox()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM client WHERE status = 'active'";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string client = reader["clientName"] + " - " + reader["clientId"];
                        txtClient.AutoCompleteCustomSource.AddRange(new String[] { client });
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void insertTransaction(string orNo, string productId, string clientId, string qty, string unitId, string paymentMethod, string supplierPrice, string unitPrice, string yellowBasyoReturned, string transparentBasyoReturned)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO transaction (orNo, productId, clientId, paymentMethod, qty, unitId, transStatus, supplierPrice, unitPrice, yellowBasyoReturned, transparentBasyoReturned) VALUES (@orNo, @productId, @clientId, @paymentMethod, @qty, @unitId, 'Completed', @supplierPrice, @unitPrice, @yellowBasyoReturned, @transparentBasyoReturned)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("orNo", orNo);
                    sqlCmd.Parameters.AddWithValue("productId", productId);
                    sqlCmd.Parameters.AddWithValue("clientId", clientId);
                    sqlCmd.Parameters.AddWithValue("qty", qty);
                    sqlCmd.Parameters.AddWithValue("unitId", unitId);
                    sqlCmd.Parameters.AddWithValue("paymentMethod", paymentMethod);
                    sqlCmd.Parameters.AddWithValue("supplierPrice", supplierPrice);
                    sqlCmd.Parameters.AddWithValue("unitPrice", unitPrice);
                    sqlCmd.Parameters.AddWithValue("yellowBasyoReturned", yellowBasyoReturned);
                    sqlCmd.Parameters.AddWithValue("transparentBasyoReturned", transparentBasyoReturned);

                    sqlCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Transaction error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateStocks(string qty, string crit, string newPrice)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE products SET productStock = productStock - @qty, productPrice = @newPrice WHERE productId = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("qty", qty);
                    sqlCmd.Parameters.AddWithValue("newPrice", newPrice);
                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    sqlCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating stocks error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Return stocks
        /// </summary>
        /// <param name="qty"></param>
        /// <param name="productId"></param>
        private void revertStocks(string qty, string productId)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE products SET productStock = productStock + @qty WHERE productId = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("qty", qty);
                    sqlCmd.Parameters.AddWithValue("crit", productId);

                    sqlCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating stocks error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Update the status of a sales into a VOID
        /// </summary>
        /// <param name="orNo"></param>
        private void voidTransaction(string orNo)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "UPDATE transaction SET transStatus = 'Void' WHERE orNo = @orNo";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("orNo", orNo);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Transaction status changing error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //get unit ID
        private string getUnitID(string crit)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT unitId FROM units WHERE unitDesc = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    string tmp = "";
                    while (reader.Read())
                    {
                        tmp = reader["unitId"].ToString();
                    }

                    return tmp;
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Message);
                    MessageBox.Show(this, "Error Retrieving unit id", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }

            }
        }

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

        private void insertCheque(string bank, string branch, string chequeName, string chequeDate, string chequeNo, string amount)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    DateTime chequeDateFinal;
                    DateTime.TryParse(chequeDate, out chequeDateFinal);

                    Con.Open();
                    string sqlQuery = "INSERT INTO cheque (chequeNo, chequeName, chequeBank, chequeBranch, chequeAmount, chequeDate, status) VALUES (@chequeNo, @chequeName, @chequeBank, @chequeBranch, @chequeAmount, @chequeDate, 'active')";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("chequeNo", chequeNo);
                    sqlCmd.Parameters.AddWithValue("chequeName", chequeName);
                    sqlCmd.Parameters.AddWithValue("chequeBank", bank);
                    sqlCmd.Parameters.AddWithValue("chequeBranch", branch);
                    sqlCmd.Parameters.AddWithValue("chequeAmount", amount);
                    sqlCmd.Parameters.AddWithValue("chequeDate", chequeDateFinal.ToString("yyyy-MM-dd"));

                    sqlCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Transaction error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //get product ID
        private string getProductID(string crit)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT productId FROM products WHERE productName = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    string tmp = "";
                    while (reader.Read())
                    {
                        tmp = reader["productId"].ToString();
                    }

                    return tmp;
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Message);
                    MessageBox.Show(this, "Error Retrieving product id", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }

            }
        }

        /// <summary>
        /// This function will get data from database and populate the product textbox
        /// </summary>
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

        private void updateProductQueue(string productId, string price, string stock)
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

        /// <summary>
        /// Get the product by product name
        /// </summary>
        /// <param name="prodname">Name of the product</param>
        /// <returns>Product Array</returns>
        private String[] getProductByName(string prodname)
        {
            string[] result = new string[6];
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.status = 'active' AND p.productName = @prodname";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("prodname", prodname);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result[0] = reader["productId"].ToString();
                        result[1] = "1";
                        result[2] = reader["productName"].ToString();
                        result[3] = reader["unitDesc"].ToString();
                        result[4] = reader["productPrice"].ToString();

                        double total = double.Parse(result[1]) * double.Parse(result[4]);
                        result[5] = total.ToString();
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

        private void clearUI()
        {
            btnVoid.Enabled = true;
            btnVoid.Visible = false;
            cboTransactionType.Enabled = true;
            cboTransactionType.SelectedIndex = 0;

            dgvCart.ForeColor = Color.Black;

            dgvCart.Rows.Clear();
            label1.Text = "Chiumart POS";
            lblTotal.Text = "0.0";
            txtAddress.Text = "";
            txtClient.Text = "Walk-in Client";
            dgvCart.Enabled = true;
            btnCheckout.Text = "Checkout";
            txtAddress.ReadOnly = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            txtClient.ReadOnly = false;
            btnCheckout.Enabled = true;
            // GENERATE NEW OR
            txtOrNo.Text = generateOR();
            txtClient.Focus();
        }

        private String getProductSupplierPrice(string prodname)
        {
            string result = "";
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT supplier_price FROM products INNER JOIN po_queue ON products.productId = po_queue.product_id WHERE products.productName = @prodname AND stock > 0 ORDER BY po_queue.id ASC LIMIT 1";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("prodname", prodname);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader["supplier_price"].ToString();
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

        private String getProductProductPrice(string prodname)
        {
            string result = "";
            string client = "0";

            if (txtClient.Text == "")
            {
                return "0";
            }

            if (txtClient.Text == "Walk-in Client")
            {
                client = "0";
            }
            else
            {
                string[] clientId = txtClient.Text.Split(new string[] { " - " }, StringSplitOptions.None);
                client = clientId[1];
            }


            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT t.unitPrice FROM products p INNER JOIN transaction t  ON p.productId = t.productId WHERE p.productName = @prodname AND t.clientId = @clientId";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("prodname", prodname);
                    sqlCmd.Parameters.AddWithValue("clientId", client);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader["unitPrice"].ToString();
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

        private String getClientAddress(string id)
        {
            string result = "";
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT clientAddress FROM client WHERE clientId = @clientId";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("clientId", id);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader["clientAddress"].ToString();
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

        /// <summary>
        /// Check the product stock
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns>Product Stock</returns>
        private int checkProductStockById(int id)
        {
            int result = 0;
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.* FROM products as p WHERE p.status = 'active' AND p.productId = @id";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("id", id);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = Int32.Parse(reader["productStock"].ToString());
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

        private void frmPOS_Load(object sender, EventArgs e)
        {
            cboTransactionType.SelectedIndex = 0;
            populateClientTextbox();
            populateProductTextbox();
            
            // Set status bar labels
            txtCashier.Text = Classes.Authentication.Instance.userFullName;
            lblUsername.Text = Classes.Authentication.Instance.username;
            lblDate.Text = DateTime.Today.ToLongDateString().ToString();
            //lblTime.Text = DateTime.Today.ToLocalTime().ToString();
            if (action == "birReport")
            {
                button8.Visible = false;
                btnNewTransaction.Visible = false;
                btnBasyo.Visible = false;
                btnCheckout.Text = "Print";
                btnVoid.Text = "Remove";
                populatePosUi();

            }
            else
            {
                // GENERATE NEW OR
                txtOrNo.Text = generateOR();
            }

        }

        private void txtClient_Click(object sender, EventArgs e)
        {
            txtClient.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Parse the product string
            if (txtAddress.Text != "")
            {
                string[] product = Regex.Split(txtAddress.Text, " - ");
                int id = Int32.Parse(product[1]);

                // update the full total price of items on the cart
                updateTotalPrice();
            }
            else
            {
                MessageBox.Show("You have to select a product first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void txtProduct_Click(object sender, EventArgs e)
        {
            txtAddress.SelectAll();
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // cartUpdateTotal();
        }

        /// <summary>
        /// This will update the changes on the cart
        /// </summary>
        private void cartUpdateTotal()
        {
            //try
           // {
                // update for the total
                for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
                {
                    if (action == "birReport")
                    {
                        if (dgvCart.Rows[i].Cells[4].Value != null)
                        {
                            double totalBIR = double.Parse(dgvCart.Rows[i].Cells[4].Value.ToString()) * double.Parse(dgvCart.Rows[i].Cells[1].Value.ToString());
                            dgvCart.Rows[i].Cells[5].Value = string.Format("{0:C}", totalBIR);
                        }

                    }
                    else
                    {
                        // Check the update on quantity if there's enough stocks
                        // if not, set it to maximum stocks
                        if (dgvCart.Rows[i].Cells[0].Value != null)
                        {

                            int id = Int32.Parse(dgvCart.Rows[i].Cells[0].Value.ToString());
                            int stock = checkProductStockById(id);
                            int updatedStock = Int32.Parse(dgvCart.Rows[i].Cells[1].Value.ToString());

                            if (stock < updatedStock && stock != 0)
                            {
                                MessageBox.Show(this, "Insufficient Stocks\nYou only have " + stock + " left for this product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvCart.Rows[i].Cells[1].Value = 0;
                            }
                            else if (stock == 0)
                            {
                                MessageBox.Show(this, "You do not have stocks for this product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvCart.Rows[i].Cells[1].Value = 0;
                                dgvCart.Rows.Remove(dgvCart.Rows[i]);
                            }

                            // update the total
                            string tmpQty = dgvCart.Rows[i].Cells[4].Value.ToString() == null || dgvCart.Rows[i].Cells[4].Value.ToString() == "" ? "0" : dgvCart.Rows[i].Cells[4].Value.ToString();
                            double total = double.Parse(tmpQty) * double.Parse(dgvCart.Rows[i].Cells[1].Value.ToString());
                            dgvCart.Rows[i].Cells[5].Value = string.Format("{0:C}", total);

                        }
                    }
                }

                // update the full total price of items on the cart
                updateTotalPrice();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void updateTotalPrice()
        {
            try
            {
                double total = 0;
                for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
                {
                    total += double.Parse(dgvCart.Rows[i].Cells[5].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }

                if (checkBox1.Checked == true)
                {
                    total -= double.Parse(txtTransBasyo.Text) * 100;
                }

                if (checkBox1.Checked == true)
                {
                    total -= double.Parse(txtYellowBasyo.Text) * 130;
                }

                lblTotal.Text = string.Format("{0:C}", total);

            }
            catch(Exception ex)
            {

            }
        }

        private void updateTotalAmount()
        {
            try
            {
                double total = 0;
                for (int i = 0; i < (dgvCart.Rows.Count); i++)
                {
                    total += double.Parse(dgvCart.Rows[i].Cells[5].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }

                lblTotal.Text = total.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (action == "birReport")
            {
                if (dgvCart.Rows.Count <= 1)
                {
                    MessageBox.Show("There's no item to print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (btnCheckout.Text == "Checkout")
                {
                    // Check if ability to checkout
                    if (dgvCart.Rows.Count <= 1)
                    {
                        MessageBox.Show("There's no item available for checkout because the cart is empty or the total is zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Open the checkout form
                    Dialogs.dlgCheckout frm = new Dialogs.dlgCheckout("POS");
                    // Set the variables
                    frm.total = lblTotal.Text;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
                        {
                            string paymentMethod = "";
                            frm.getProduct(out paymentMethod, out bank, out branch, out chequeName, out chequeDate, out total, out chequeNo);
                            if (paymentMethod == "Cheque")
                            {
                                insertCheque(bank, branch, chequeName, chequeDate, chequeNo, total);
                            }

                            // Check if the cell has a product, if not, continue the loop
                            if (dgvCart.Rows[i].Cells[3].Value.ToString() == "")
                            {
                                continue;
                            }

                            string prodId = getProductID(dgvCart.Rows[i].Cells[3].Value.ToString());
                            string unitId = getUnitID(dgvCart.Rows[i].Cells[2].Value.ToString());
                            string currentPrice = getProductProductPrice(dgvCart.Rows[i].Cells[3].Value.ToString());
                            string supplierPrice = getProductSupplierPrice(dgvCart.Rows[i].Cells[3].Value.ToString());

                            string str = txtClient.Text;
                            string[] clientId = new string[2];
                            if (str == "Walk-in Client")
                            {
                                clientId[1] = "0";
                            }
                            else
                            {
                                clientId = str.Split(new string[] { " - " }, StringSplitOptions.None);
                            }
                            string qty = dgvCart.Rows[i].Cells[1].Value.ToString();
                            string newPrice = dgvCart.Rows[i].Cells[4].Value.ToString();
                            int prodqty = Int32.Parse(qty);

                            getPoQueue(prodId);
                            for (int j = 0; j < poStock.Count; j++)
                            {
                                if (poStock[j] >= prodqty)
                                {
                                    updateProductQueue(prodId, poSupplierPrice[j], prodqty.ToString());
                                    insertTransaction(txtOrNo.Text, prodId, clientId[1], prodqty.ToString(), unitId, paymentMethod, poSupplierPrice[j], newPrice, txtYellowBasyo.Text, txtTransBasyo.Text);
                                    break;
                                }
                                else
                                {
                                    updateProductQueue(prodId, poSupplierPrice[j], poStock[j].ToString());
                                    if (poStock[j] != 0)
                                    {
                                        insertTransaction(txtOrNo.Text, prodId, clientId[1], poStock[j].ToString(), unitId, paymentMethod, poSupplierPrice[j], newPrice, txtYellowBasyo.Text, txtTransBasyo.Text);
                                    }
                                    prodqty = prodqty - poStock[j];
                                }
                            }
                            updateStocks(qty, prodId, newPrice);
                            // updateProductQueue(prodId, supplierPrice, qty);

                            // LOGS
                            Classes.ActionLogger.LogAction(qty, unitId, prodId, "transaction", prodId.ToString(), clientId[1], "", newPrice, "", "");
                        }

                        Reports.frmOrReport rpt = new Reports.frmOrReport();
                        rpt.orno = txtOrNo.Text;
                        rpt.ShowDialog();
                        insertNewOR();
                        MessageBox.Show(this, "Transaction Complete", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearUI();
                    }
                }
                else if (btnCheckout.Text == "Return") 
                {
                    if (MessageBox.Show("Are you sure to return this product/s? All item/s in this transaction will go back into the stock and sales will be deducted", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Loop Through each item on the cart
                        for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
                        {
                            // Check if the cell has a product, if not, continue the loop
                            if (dgvCart.Rows[i].Cells[3].Value.ToString() == "")
                            {
                                continue;
                            }

                            // Get variables
                            string prodId = getProductID(dgvCart.Rows[i].Cells[3].Value.ToString());
                            string unitId = getUnitID(dgvCart.Rows[i].Cells[2].Value.ToString());
                            string currentPrice = getProductProductPrice(dgvCart.Rows[i].Cells[3].Value.ToString());
                            string supplierPrice = getProductSupplierPrice(dgvCart.Rows[i].Cells[3].Value.ToString());

                            // Get the client
                            string str = txtClient.Text;
                            string[] clientId = new string[2];
                            if (str == "Walk-in Client")
                            {
                                clientId[1] = "0";
                            }
                            else
                            {
                                clientId = str.Split(new string[] { " - " }, StringSplitOptions.None);
                            }

                            // Get variables
                            string qty = dgvCart.Rows[i].Cells[1].Value.ToString();
                            string newPrice = dgvCart.Rows[i].Cells[4].Value.ToString();
                            int prodqty = Int32.Parse(qty);

                            for (int j = 0; j < poStock.Count; j++)
                            {
                                if (poStock[j] >= prodqty)
                                {
                                    insertTransaction(txtOrNo.Text, prodId, clientId[1], prodqty.ToString(), unitId, "Cash", poSupplierPrice[j], newPrice, txtYellowBasyo.Text, txtTransBasyo.Text);
                                    break;
                                }
                                else
                                {
                                    updateProductQueue(prodId, poSupplierPrice[j], poStock[j].ToString());
                                    if (poStock[j] != 0)
                                    {
                                        insertTransaction(txtOrNo.Text, prodId, clientId[1], poStock[j].ToString(), unitId, "Cash", poSupplierPrice[j], newPrice, txtYellowBasyo.Text, txtTransBasyo.Text);
                                    }
                                    prodqty = prodqty - poStock[j];
                                }
                            }

                            revertStocks(qty, prodId);
                        }


                        MessageBox.Show("Transaction successfully RETURNED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCart.ForeColor = Color.Red;
                        cboTransactionType.SelectedIndex = 1;
                        dgvCart.Enabled = false;
                        txtClient.Enabled = false;
                        txtAddress.Enabled = false;
                        btnCheckout.Enabled = false;
                    }
                }
                else
                {
                    Reports.frmOrReport rpt = new Reports.frmOrReport();
                    rpt.orno = txtOrNo.Text;
                    rpt.ShowDialog();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string tDate;
            // Open the transaction history form
            Dialogs.dlgTransactionHistoy frm = new Dialogs.dlgTransactionHistoy();
            // Set the variables
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.getTransaction(out qty, out productName, out units, out productPrice,
                out orNo, out clientName, out clientAddress, out action, out yellowBasyoReturned, out transparentBasyoReturned, out status, out tDate);
                if (action == "View")
                {
                    btnVoid.Visible = true;
                    cboTransactionType.Enabled = false;

                    dgvCart.Enabled = false;
                    txtAddress.ReadOnly = true;
                    txtClient.ReadOnly = true;
                    txtTransBasyo.Text = transparentBasyoReturned;
                    txtYellowBasyo.Text = yellowBasyoReturned;

                    label1.Text = "View Transaction";
                    btnCheckout.Text = "Reprint";
                    populatePosUi();

                    if (status == "Return" || status == "Void")
                    {
                        cboTransactionType.SelectedIndex = 1;
                        dgvCart.ForeColor = Color.Red;
                    }
                    else
                    {
                        cboTransactionType.SelectedIndex = 0;
                    }

                    // Check if date today is equal to date of transaction;
                    transDate = DateTime.Parse(tDate);
                    if (transDate.Date.CompareTo(DateTime.Now.Date) < 0)
                    {
                        btnVoid.Enabled = false;
                    }
                }
                else
                {
                    label1.Text = "Chiumart POS";
                }
            }
        }

        private void populatePosUi()
        {
            txtAddress.Text = clientAddress;
            txtClient.Text = clientName;
            if (clientName == "")
            {
                txtClient.Text = "Walk-in Client";
            }
            txtOrNo.Text = orNo;
            int ctr = 0;
            if (action == "birReport")
            {
                dgvCart.RowCount = qty.Count + 1;
            }
            else
            {
                dgvCart.RowCount = qty.Count;
            }
            foreach (string q in qty)
            {
                dgvCart.Rows[ctr].Cells[1].Value = q;
                ctr++;
            }
            ctr = 0;
            foreach (string item in productName)
            {
                dgvCart.Rows[ctr].Cells[3].Value = item;
                ctr++;
            }
            ctr = 0;
            foreach (string unit in units)
            {
                dgvCart.Rows[ctr].Cells[2].Value = unit;
                ctr++;
            }
            ctr = 0;
            foreach (string price in productPrice)
            {
                dgvCart.Rows[ctr].Cells[4].Value = price;
                ctr++;
            }
            for (int i = 0; i < (ctr); i++)
            {
                double total = double.Parse(dgvCart.Rows[i].Cells[4].Value.ToString()) * double.Parse(dgvCart.Rows[i].Cells[1].Value.ToString());
                dgvCart.Rows[i].Cells[5].Value = string.Format("{0:C}", total);
            }
            updateTotalAmount();
        }

        /// <summary>
        /// GENERATE NEW OR NUMBER
        /// </summary>
        private string generateOR()
        {
            string lastOrNumber = "";
            DateTime today = DateTime.Today;
            int currentYear = today.Year;
            int currentMonth = today.Month + 1;

            string generatedOR = "";

            // Get the last OR number
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM `or` ORDER BY id DESC LIMIT 1";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lastOrNumber = reader["ornumber"].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database: " + ex.Message.ToString(), errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Check if there is no last OR number
            if (lastOrNumber == "")
            {
                // Create the first one
                generatedOR = currentYear.ToString() + currentMonth.ToString("00") + "0001";
            }
            else
            {
                // Create a new one
                string lastYear = lastOrNumber.Substring(0, 4);
                string lastMonth = lastOrNumber.Substring(4, 2);
                string lastOr = lastOrNumber.Substring(6, 4);

                if (currentYear.ToString() == lastYear)
                {
                    currentYear = Int32.Parse(lastYear);
                }
                else
                {
                    lastOr = "0000";
                }

                // convert the or number to int and increment it by 1
                int orNum = Int32.Parse(lastOr) + 1;

                generatedOR = currentYear.ToString() + currentMonth.ToString() + orNum.ToString("0000");
            }

            return generatedOR;
        }

        private void insertNewOR()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "INSERT INTO `or`(ornumber) VALUES(@ornumber)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("ornumber", txtOrNo.Text);

                    sqlCmd.ExecuteNonQuery();
                }
            } 
            catch(MySqlException ex) 
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database: " + ex.Message.ToString(), errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCart_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox prodName = e.Control as TextBox;
            if (dgvCart.CurrentCell.ColumnIndex == 3)
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

        private void dgvCart_EditModeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Done editing");
        }

        private Boolean checkProduct(string productName)
        {
            bool result = false;
            int count = 0;

            for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
            {
                if (dgvCart.Rows[i].Cells[3].Value.ToString() == productName)
                {
                    count++;
                }

                if (count > 1)
                {
                    result = true;
                }
            }

            return result;
        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvCart.CurrentCell.ColumnIndex == 3)
            {

                // Check if the product is already on the cart
                if (checkProduct(dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[3].Value.ToString()))
                {
                    if (MessageBox.Show("This product is already exists on the CART. Do you want to add this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        dgvCart.Rows.Remove(dgvCart.Rows[dgvCart.CurrentRow.Index]);
                        return;
                    }
                }

                try
                {
                    string[] item = getProductByName(dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[3].Value.ToString());

                    dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[0].Value = item[0];
                    //dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[1].Value = 1;
                    dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[2].Value = item[3];

                    string price = getProductProductPrice(dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[3].Value.ToString());

                    dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[4].Value = price == "" ? "0" : price;
                    dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[5].Value = string.Format("{0:C}", item[5]);

                    if (action != "birReport")
                    {
                        for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
                        {
                            // Check the update on quantity if there's enough stocks
                            // if not, set it to maximum stocks
                            int id = Int32.Parse(dgvCart.Rows[i].Cells[0].Value.ToString());
                            int stock = checkProductStockById(id);
                            int updatedStock = Int32.Parse(dgvCart.Rows[i].Cells[1].Value.ToString());

                            if (stock < updatedStock && stock != 0)
                            {
                                MessageBox.Show(this, "Insufficient Stocks\nYou only have " + stock + " left for this product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvCart.Rows[i].Cells[1].Value = 0;

                            }
                            else if (stock == 0)
                            {
                                MessageBox.Show(this, "You do not have stocks for this product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvCart.Rows[i].Cells[1].Value = 0;
                                dgvCart.Rows.Remove(dgvCart.Rows[i]);
                            }
                        }
                    }
                    dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[1].Selected = true;
                    updateTotalPrice();
                    cartUpdateTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Please enter a product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            else if (dgvCart.CurrentCell.ColumnIndex == 4)
            {
                if (action != "birReport")
                {
                    string currentPrice = getProductProductPrice(dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[3].Value.ToString());
                    double supplierPrice = double.Parse(getProductSupplierPrice(dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[3].Value.ToString()));
                    double updatedPrice = double.Parse(dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[4].Value.ToString());

                    if (updatedPrice < supplierPrice)
                    {
                        MessageBox.Show(this, "The price is less than the supplier price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvCart.Rows[dgvCart.CurrentRow.Index].Cells[4].Value = currentPrice;
                    }
                    else if (updatedPrice == supplierPrice)
                    {
                        MessageBox.Show(this, "The price is equal to the supplier price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                cartUpdateTotal();
                updateTotalPrice();
            }
            else
            {
                cartUpdateTotal();
                updateTotalPrice();
            }
            
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            clearUI();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to close the Point of Sales?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void txtClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                MessageBox.Show("You entered");
            }
        }

        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus(); 
                string str = txtClient.Text;
                string[] clientId = new string[2];
                if (str == "Walk-in Client")
                {
                    clientId[1] = "0";
                }
                else
                {
                    clientId = str.Split(new string[] { " - " }, StringSplitOptions.None);
                }

                string address = "";
                
                try
                {
                    address = getClientAddress(clientId[1]);
                }
                catch(IndexOutOfRangeException ex)
                {
                    MessageBox.Show(this, "Client doesn't exists. Reverting to walk-in client", "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClient.Text = "Walk-in Client";
                }

                txtAddress.Text = address;

                int rowCount = dgvCart.Rows.Count;

                try
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        dgvCart.Rows.RemoveAt(i);
                        --rowCount;
                    }
                }
                catch(Exception ex) 
                {

                }
                  
                cartUpdateTotal();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvCart.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            lblTime.Text = dateTime.ToString("hh:mm:ss tt");
            /*
            if (Classes.GetLastUserInput.formStatusIdle == false)
            {
                if (Classes.GetLastUserInput.GetIdleTickCount() >= 300000)
                {
                    Classes.GetLastUserInput.formStatusIdle = true;
                    Dialogs.dlgIdleStatus idle = new Dialogs.dlgIdleStatus();
                    idle.ShowDialog();
                }
            }*/
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtTransBasyo.Enabled = true;
                txtTransBasyo.Focus();
                txtTransBasyo.SelectAll();
            }
            else
            {
                txtTransBasyo.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtYellowBasyo.Enabled = true;
                txtYellowBasyo.Focus();
                txtYellowBasyo.SelectAll();
            }
            else
            {
                txtYellowBasyo.Enabled = false;
            }
        }

        private void frmPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtTransBasyo_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                updateTotalPrice();
            }
        }

        private void txtYellowBasyo_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                updateTotalPrice();
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (action == "birReport")
            {
                if (dgvCart.SelectedRows.Count != 0)
                {
                    int selectedIndex = dgvCart.CurrentCell.RowIndex;
                    if (selectedIndex > -1)
                    {
                        dgvCart.Rows.RemoveAt(selectedIndex);
                        dgvCart.Refresh(); // if needed
                        updateTotalAmount();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to void this transaction? All items in this transaction will go back into the stock and sales will be deducted", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    voidTransaction(txtOrNo.Text);

                    for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
                    {
                        string prodId = getProductID(dgvCart.Rows[i].Cells[3].Value.ToString());
                        string qty = dgvCart.Rows[i].Cells[1].Value.ToString();

                        revertStocks(qty, prodId);
                    }

                    MessageBox.Show("Transaction successfully changed to VOID", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCart.ForeColor = Color.Red;
                    cboTransactionType.SelectedIndex = 1;
                }
            }
        }

        

        private void btnBasyo_Click(object sender, EventArgs e)
        {
            frmBasyo frm = new frmBasyo();
            frm.ShowDialog();
        }

        private void cboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransactionType.SelectedIndex == 0)
            {
                btnCheckout.Text = "Checkout";
                dgvCart.ForeColor = Color.Black;
            }
            else
            {
                btnCheckout.Text = "Return";
                dgvCart.ForeColor = Color.Red;
            }
        }
    }
}
