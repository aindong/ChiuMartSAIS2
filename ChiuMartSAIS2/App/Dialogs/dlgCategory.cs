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
    public partial class dlgCategory : Form
    {

        //variable declarations
        private string _action;
        private int _crit;

        public string categoryName;

        public dlgCategory(string action, int crit)
        {
            InitializeComponent();

            _action = action;
            _crit = crit;
        }

        private void dlgCategory_Load(object sender, EventArgs e)
        {
            txtCategoryName.Text = categoryName;
        }

        /// <summary>
        /// This will give out the category value to the parent form
        /// </summary>
        /// <param name="category">category variable to handle the given/setted category</param>
        public void getCategory(out int categoryId, out string categoryName)
        {
            // Set the category id
            categoryId = _crit;

            // Set the category name
            categoryName = txtCategoryName.Text;
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
            if (txtCategoryName.Text == "")
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
