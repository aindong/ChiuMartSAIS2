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
    public partial class dlgInventoryAdjust : Form
    {
        private int _crit;

        public int productStocks;
        public dlgInventoryAdjust(int crit)
        {
            InitializeComponent();

            _crit = crit;
        }

        /// <summary>
        /// This will give out the product stocks value to the parent form
        /// </summary>
        /// <param name="stocks">stocks variable to handle the given/setted stocks</param>
        public void getStocks(out int productId, out int productStocks, out string adjustment)
        {
            // Set the product id
            productId = _crit;

            // Set the product quantity
            productStocks = Int32.Parse(txtQuantity.Text);

            // checks if the stocks will increase or decrease
            if (rdbIncrease.Checked == true)
            {
                adjustment = "Increase";
            }
            else
            {
                adjustment = "Decrease";
            }
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            if (checkEmpty() == false)
            {
                MessageBox.Show("Please fill out all the required fields", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// checks if the fields are properly inputted
        /// </summary>
        /// <returns></returns>
        private bool checkEmpty()
        {
            if (txtQuantity.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dlgInventoryAdjust_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = productStocks.ToString();
        }
    }
}
