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
    public partial class dlgUnits : Form
    {
        //variable declarations
        private string _action;
        private int _crit;

        public string unitDesc;
        public dlgUnits(string action, int crit)
        {
            InitializeComponent();

            _action = action;
            _crit = crit;
        }

        /// <summary>
        /// This will give out the unit value to the parent form
        /// </summary>
        /// <param name="client">unit variable to handle the given/setted unit</param>
        public void getUnit(out int unitId, out string unitDesc)
        {
            // Set the unit id
            unitId = _crit;

            // Set the unit description
            unitDesc = txtUnitDescription.Text;
        }

        private void dlgUnits_Load(object sender, EventArgs e)
        {
            txtUnitDescription.Text = unitDesc;
        }

        private void txtUnitDescription_TextChanged(object sender, EventArgs e)
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
            if (txtUnitDescription.Text == "")
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
