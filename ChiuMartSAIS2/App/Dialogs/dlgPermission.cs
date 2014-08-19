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
    public partial class dlgPermission : Form
    {
        public dlgPermission()
        {
            InitializeComponent();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            toggleCheckAll("check");
        }

        /// <summary>
        /// Toggle the checkall and uncheckall of the checkboxes on the form
        /// </summary>
        /// <param name="state">Pass the state that you want, either check or uncheck all checkboxes</param>
        private void toggleCheckAll(string state)
        {
            // Iterate through each panel of the form
            foreach (Control obj in this.Controls)
            {
                // Check if the current object is a panel
                if (obj is Panel)
                {
                    // Iterate through each of the checkbox control of the current panel we are in
                    foreach (Control chk in obj.Controls)
                    {
                        // Check if the current control of the panel is a checkbox
                        if (chk is CheckBox)
                        {
                            // Create a temporary clone
                            CheckBox c = (CheckBox)chk;

                            // Do the action
                            if (state == "check")
                            {
                                c.Checked = true;
                            }
                            else
                            {
                                c.Checked = false;
                            }
                        }
                    }
                }
            }
        }

        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            toggleCheckAll("uncheck");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
