using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiuMartSAIS2.App.Dialogs
{
    public partial class dlgProducts : Form
    {
        //variable declarations
        private string _action;
        private double _crit;

        public List<String> units = new List<string>();
        public List<String> category = new List<string>();
        public string productName;
        public string productCategory;
        public string productUnit;
        public double productStocks;
        public double productSafetyStock;
        public double productPrice;
        public double productId;

        public dlgProducts(string action, double crit)
        {
            InitializeComponent();

            _action = action;
            _crit = crit;
        }

        /// <summary>
        /// This will give out the product value to the parent form
        /// </summary>
        /// <param name="product">product variable to handle the given/setted product</param>
        public void getProduct(out double productId, out double productPrice, out double productSafetyStock, out double productStocks,
            out string productName, out string productCategory, out string productUnit)
        {
            // Set the product id
            productId = _crit;
            // Set the product price
            double price = double.Parse(txtPrice.Text);
            productPrice = price;
            // Set the product stock
            double stock = double.Parse(txtStocks.Text);
            productStocks = stock;
            // Set the product safety stock
            double safety = double.Parse(txtSafetyStocks.Text);
            productSafetyStock = safety;
            // Set the product name
            productName = txtProductName.Text;
            // Set the product category
            productCategory = cboCategory.Text;
            // Set the product unit
            productUnit = cboUnits.Text;
        }

        private void dlgProducts_Load(object sender, EventArgs e)
        {
            foreach(string unit in units){
                cboUnits.Items.Add(unit);
            } 

            foreach (string cat in category)
            {
                cboCategory.Items.Add(cat);
            }

            txtPrice.Text = productPrice.ToString();
            txtProductName.Text = productName;
            txtSafetyStocks.Text = productSafetyStock.ToString();
            txtStocks.Text = productStocks.ToString();
            cboUnits.Text = productUnit;
            cboCategory.Text = productCategory;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkEmpty() == false)
            {
                MessageBox.Show("Please fill out all the required fields", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_action == "add")
            {
                double price, stock, safetystock;
                //parse the txtPrice if it's double or not
                if (!(double.TryParse(txtStocks.Text, out stock)))
                {
                    MessageBox.Show("Stocks must be a number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!(double.TryParse(txtPrice.Text, out price)))
                {
                    MessageBox.Show("Price must be a number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!(double.TryParse(txtSafetyStocks.Text, out safetystock)))
                {
                    MessageBox.Show("Safety Stocks must be a number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }

            }
            else
            {
                double price, stock, safetystock;
                //parse the txtPrice if it's double or not
                if (!(double.TryParse(txtStocks.Text, out stock)))
                {
                    MessageBox.Show("Stocks must be a number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!(double.TryParse(txtPrice.Text, out price)))
                {
                    MessageBox.Show("Price must be a number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!(double.TryParse(txtSafetyStocks.Text, out safetystock)))
                {
                    MessageBox.Show("Safety Stocks must be a number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// checks if the fields are properly inputted
        /// </summary>
        /// <returns></returns>
        private bool checkEmpty()
        {
            if (txtStocks.Text == "")
            {
                return false;
            }
            else
            {
                if (txtProductName.Text == "")
                {
                    return false;
                }
                else
                {
                    if (txtSafetyStocks.Text == "")
                    {
                        return false;
                    }
                    else
                    {
                        if (txtPrice.Text == "")
                        {
                            return false;
                        }
                        else
                        {
                            if (cboUnits.Text == "")
                            {
                                return false;
                            }
                            else
                            {
                                if (cboCategory.Text == "")
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
