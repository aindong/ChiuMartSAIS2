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
    public partial class dlgChangePaymentMethod : Form
    {
        private string method = "";

        public dlgChangePaymentMethod(string paymentMethod)
        {
            InitializeComponent();
            if (paymentMethod == "Balance")
            {
                cboPaymentMethod.Text = "Accounts Receivables";
            }
            else
            {
                cboPaymentMethod.Text = paymentMethod;
            }
        }

        public void getMethod(out string method)
        {
            // Set the payment method
            method = this.method;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to change the Payment Method?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cboPaymentMethod.Text == "Accounts Receivables")
                {
                    method = "Balance";
                }
                else
                {
                    method = cboPaymentMethod.Text;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void dlgChangePaymentMethod_Load(object sender, EventArgs e)
        {

        }
    }
}
