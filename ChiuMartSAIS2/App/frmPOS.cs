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

        public frmPOS()
        {
            InitializeComponent();

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
                        string product = reader["productName"].ToString() + " - " + reader["productId"].ToString();
                        txtAddress.AutoCompleteCustomSource.AddRange(new String[] { product });
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Get the product by id
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Product Array</returns>
        private String[] getProductById(int id)
        {
            string[] result = new string[6];
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.status = 'active' AND p.productId = @id";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("id", id);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result[0] = reader["productId"].ToString();
                        result[1] = "";
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
            populateClientTextbox();
            populateProductTextbox();
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

                // Add to cart
                dgvCart.Rows.Add(getProductById(id));

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
            //cartUpdateTotal();
        }

        /// <summary>
        /// This will update the changes on the cart
        /// </summary>
        private void cartUpdateTotal()
        {
            // update for the total
            for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
            {
                // Check the update on quantity if there's enough stocks
                // if not, set it to maximum stocks
                int id = Int32.Parse(dgvCart.Rows[i].Cells[0].Value.ToString());
                int stock = checkProductStockById(id);
                int updatedStock = Int32.Parse(dgvCart.Rows[i].Cells[1].Value.ToString());

                if (stock < updatedStock)
                {
                    dgvCart.Rows[i].Cells[1].Value = stock;
                }

                // update the total
                double total = double.Parse(dgvCart.Rows[i].Cells[4].Value.ToString()) * double.Parse(dgvCart.Rows[i].Cells[1].Value.ToString());
                dgvCart.Rows[i].Cells[5].Value = total.ToString();
            }

            // update the full total price of items on the cart
            updateTotalPrice();
        }

        private void updateTotalPrice()
        {
            double total = 0;
            for (int i = 0; i < (dgvCart.Rows.Count - 1); i++)
            {
                total += double.Parse(dgvCart.Rows[i].Cells[5].Value.ToString());
            }

            lblTotal.Text = total.ToString();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Check if ability to checkout
            if (dgvCart.Rows.Count <= 1)
            {
                MessageBox.Show("There's no item available for checkout because the cart is empty or the total is zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open the checkout form
            Dialogs.dlgCheckout frm = new Dialogs.dlgCheckout();
            // Set the variables
            frm.total = lblTotal.Text;
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Open the transaction history form
            Dialogs.dlgTransactionHistoy frm = new Dialogs.dlgTransactionHistoy();
            // Set the variables
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
