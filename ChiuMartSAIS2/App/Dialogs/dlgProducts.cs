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
        private string _crit;

        public List<String> units = new List<string>();

        public dlgProducts(string action, string crit)
        {
            InitializeComponent();

            _action = action;
            _crit = crit;
        }

        private void dlgProducts_Load(object sender, EventArgs e)
        {
            foreach(string unit in units){
                cboUnits.Items.Add(unit);
            }
            
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
