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
    public partial class frmInventoryMonitoring : Form
    {
        // Objects declaration
        private Classes.Configuration conf;

        public int productId;
        public int productStocks;
        public string adjustment;

        public frmInventoryMonitoring()
        {
            InitializeComponent();

            // Create the configuration object
            conf = new Classes.Configuration();
        }


        private void frmInventoryMonitoring_Load(object sender, EventArgs e)
        {
            // Populare the listview with product data
            populateProduct();
            checkStockLevel();
        }

        /// <summary>
        /// This function will get the products from the database and will populate
        /// the listview for products.
        /// </summary>
        private void populateProduct()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.status = 'active' ORDER BY p.productName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstProducts.Items.Clear();

                    while (reader.Read())
                    {
                        lstProducts.Items.Add(reader["productId"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productStock"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productSafetyStock"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["status"].ToString());
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
        /// This function is responsible for getting the product list by stock level
        /// </summary>
        private void getProductByStockLevel(string stockLevel)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.status = 'active' ORDER BY p.productName ASC";
                    if (stockLevel == "Good")
                    {
                        sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.productStock > p.productSafetyStock AND p.status = 'active' ORDER BY p.productName ASC";
                    }
                    else if (stockLevel == "Safety")
                    {
                        sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.productStock = p.productSafetyStock AND p.status = 'active' ORDER BY p.productName ASC";
                    }
                    else if (stockLevel == "Critical")
                    {
                        sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.productStock < p.productSafetyStock AND p.productStock != 0 AND p.status = 'active' ORDER BY p.productName ASC";
                    }
                    else if (stockLevel == "Out of Stock")
                    {
                        sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.productStock <= 0 AND p.status = 'active' ORDER BY p.productName ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstProducts.Items.Clear();

                    while (reader.Read())
                    {
                        lstProducts.Items.Add(reader["productId"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productStock"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productSafetyStock"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this, errorCode+"Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// This function is responsible for searching a specific product on the stocks
        /// </summary>
        private void searchProduct(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT p.*, u.*, c.* FROM products as p INNER JOIN units as u ON p.unitId = u.unitId INNER JOIN category as c ON p.categoryId = c.categoryId WHERE p.productName LIKE @criteria ORDER BY p.productName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("criteria", "%" + criteria + "%");

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstProducts.Items.Clear();

                    while (reader.Read())
                    {
                        lstProducts.Items.Add(reader["productId"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productStock"].ToString());
                        lstProducts.Items[lstProducts.Items.Count - 1].SubItems.Add(reader["productSafetyStock"].ToString());
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
        /// Updates the stocks of selected product
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="criteria"></param>
        private void updateStock(int productStock, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE products SET productStock=@productStock WHERE productId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("productStock", productStock);
                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Stock successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating stock error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// This function is responsible for checking the stock level of a product, it will change the color of a row for
        /// a specific stock level
        /// </summary>
        private void checkStockLevel()
        {
            // Check the stock of current product
            foreach (ListViewItem lvw in lstProducts.Items)
            {
                int currentStock = Int32.Parse(lvw.SubItems[3].Text);
                int safetyStock = Int32.Parse(lvw.SubItems[4].Text);

                // Check for safety stocks
                if (currentStock == safetyStock)
                {
                    lvw.BackColor = Color.LimeGreen;
                }

                // Check for CRITICAL STOCKS
                if (currentStock < safetyStock)
                {
                    lvw.BackColor = Color.IndianRed;
                }

                // Then check if it's out of stock
                if (currentStock <= 0)
                {
                    lvw.BackColor = Color.Red;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchProduct(textBox1.Text);
            checkStockLevel();
        }

        private void lblAll_Click(object sender, EventArgs e)
        {
            getProductByStockLevel("All");
            checkStockLevel();
        }

        private void lblGood_Click(object sender, EventArgs e)
        {
            getProductByStockLevel("Good");
            checkStockLevel();
        }

        private void lblSafety_Click(object sender, EventArgs e)
        {
            getProductByStockLevel("Safety");
            checkStockLevel();
        }

        private void lblCritical_Click(object sender, EventArgs e)
        {
            getProductByStockLevel("Critical");
            checkStockLevel();
        }

        private void lblOutOfStock_Click(object sender, EventArgs e)
        {
            getProductByStockLevel("Out of Stock");
            checkStockLevel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgInventoryAdjust frmInventoryAdjust = new Dialogs.dlgInventoryAdjust(productId);
            frmInventoryAdjust.productStocks = this.productStocks;
            if (frmInventoryAdjust.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the quantity
                frmInventoryAdjust.getStocks(out productId, out productStocks, out adjustment);
                int stock = Int32.Parse(lstProducts.SelectedItems[lstProducts.SelectedItems.Count - 1].SubItems[3].Text);
                if (adjustment == "Increase")
                {
                    int total = stock + productStocks;
                    updateStock(total, productId);
                    populateProduct();
                    checkStockLevel();
                }
                else
                {
                    int total = stock - productStocks;
                    updateStock(total, productId);
                    populateProduct();
                    checkStockLevel();
                }
            }
        }

        private void lstProducts_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(lstProducts.SelectedItems[lstProducts.SelectedItems.Count - 1].Text);
            productId = id;
            productStocks = Int32.Parse(lstProducts.SelectedItems[lstProducts.SelectedItems.Count - 1].SubItems[3].Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
