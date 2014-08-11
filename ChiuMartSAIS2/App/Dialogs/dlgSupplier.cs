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
    public partial class dlgSupplier : Form
    {
        //variable declarations
        private string _action;
        private string _crit;
        public dlgSupplier(string action, string crit)
        {
            InitializeComponent();

            _action = action;
            _crit = crit;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dlgSupplier_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_action == "add")
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
            else
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
        }

        /// <summary>
        /// checks if the fields are properly inputted
        /// </summary>
        /// <returns></returns>
        private bool checkEmpty()
        {
            if (txtSupplierName.Text == "")
            {
                return false;
            }
            else
            {
                if (txtSupplierAddress.Text == "")
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
