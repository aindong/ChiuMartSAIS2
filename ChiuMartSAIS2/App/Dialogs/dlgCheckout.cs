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
        private string method = "";
        private string bank = "";
        private string branch = "";
        private string cheque = "";
        private string chequeName = "";
        private string chequeDate = "";

        public dlgCheckout()
        {
            InitializeComponent();
        }

        public void getProduct(out string method, out string bank, out string branch, out string chequeName, out string chequeDate, out string total, out string chequeNo)
        {
            // Set the payment method
            method = this.method;
            // Set the bank
            bank = this.bank;
            // Set the branch
            branch = this.branch;
            // Set the name
            chequeName = this.chequeName;
            // Set the number
            chequeNo = this.cheque;
            // Set the date
            chequeDate = this.chequeDate;
            // Set the total
            total = this.total;
        }

        private void dlgCheckout_Load(object sender, EventArgs e)
        {
            txtAmount.Text = total;
            txtReceivableTotal.Text = total;
            txtTotal.Text = total;

            txtCashRendered.Focus();
            txtCashRendered.SelectAll();
        }

        private bool checkEmpty()
        {
            if (txtBank.Text == "")
            {
                return false;
            }
            else
            {
                if (txtBranch.Text == "")
                {
                    return false;
                }
                else
                {
                    if (txtName.Text == "")
                    {
                        return false;
                    }
                    else
                    {
                        if (txtChequeNumber.Text == "")
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

        private void txtCashRendered_Click(object sender, EventArgs e)
        {
            txtCashRendered.SelectAll();
        }

        private void txtCashRendered_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtChange.Text = ((double.Parse(txtCashRendered.Text) - double.Parse(txtAmount.Text))).ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                txtChange.Text = "0.0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            method = "Cash";
            DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkEmpty() == false)
            {
                MessageBox.Show("Please fill out all the required fields", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                method = "Cheque";
                bank = txtBank.Text;
                branch = txtBranch.Text;
                cheque = txtChequeNumber.Text;
                chequeName = txtName.Text;
                chequeDate = dtpDate.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            method = "Balance";
            DialogResult = DialogResult.OK;
        }

        private void txtCashRendered_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
