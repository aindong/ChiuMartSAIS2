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
    public partial class dlgCheckout : Form
    {
        public string total = "";

        public dlgCheckout()
        {
            InitializeComponent();
        }

        private void dlgCheckout_Load(object sender, EventArgs e)
        {
            txtAmount.Text = total;

            txtCashRendered.Focus();
            txtCashRendered.SelectAll();
        }

        private void txtCashRendered_Click(object sender, EventArgs e)
        {
            txtCashRendered.SelectAll();
        }

        private void txtCashRendered_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtChange.Text = ( Math.Abs(double.Parse(txtAmount.Text) - double.Parse(txtCashRendered.Text)) ).ToString();
            }
            catch (Exception ex)
            {
                txtChange.Text = "0.0";
            }
        }
    }
}
