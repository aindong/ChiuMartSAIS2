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
        public string total = "";
        private string bank = "";
        private string branch = "";
        private string cheque = "";
        private string chequeName = "";
        private string chequeDate = "";
        private string balance = "";
        private string chequeAmount = "";
        private string overAmount = "";

        public dlgChangePaymentMethod(string paymentMethod, string amount)
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
            txtTotal.Text = amount;
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
                    if (cboPaymentMethod.Text == "Cheque")
                    {
                        bank = txtBank.Text;
                        branch = txtBranch.Text;
                        cheque = txtChequeNumber.Text;
                        chequeName = txtName.Text;
                        chequeDate = dtpDate.Text;
                        chequeAmount = double.Parse(textBox1.Text, System.Globalization.NumberStyles.Currency).ToString();
                        overAmount = double.Parse(txtChequeChange.Text, System.Globalization.NumberStyles.Currency).ToString();
                        total = double.Parse(txtTotal.Text, System.Globalization.NumberStyles.Currency).ToString();
                    }
                    method = cboPaymentMethod.Text;
                }
                DialogResult = DialogResult.OK;
            }
        }

        public void getProduct(out string bank, out string branch, out string chequeName, out string chequeDate, out string total, out string chequeNo, out string chequeAmount, out string overAmount)
        {
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
            chequeAmount = this.chequeAmount;
            overAmount = this.overAmount;
        }

        private void dlgChangePaymentMethod_Load(object sender, EventArgs e)
        {
            txtBank.Enabled = false;
            txtBranch.Enabled = false;
            txtChequeNumber.Enabled = false;
            txtName.Enabled = false;
            dtpDate.Enabled = false;
            textBox1.Enabled = false;
            txtChequeChange.Enabled = false;
            txtTotal.Enabled = false;
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaymentMethod.Text == "Cheque")
            {
                txtBank.Enabled = true;
                txtBranch.Enabled = true;
                txtChequeNumber.Enabled = true;
                txtName.Enabled = true;
                dtpDate.Enabled = true;
                textBox1.Enabled = true;
                txtChequeChange.Enabled = true;
                txtTotal.Enabled = true;
            }
            else
            {
                txtBank.Enabled = false;
                txtBranch.Enabled = false;
                txtChequeNumber.Enabled = false;
                txtName.Enabled = false;
                dtpDate.Enabled = false;
                textBox1.Enabled = false;
                txtChequeChange.Enabled = false;
                txtTotal.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtChequeChange.Text = ((double.Parse(textBox1.Text, System.Globalization.NumberStyles.Currency) - double.Parse(txtTotal.Text, System.Globalization.NumberStyles.Currency))).ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                txtChequeChange.Text = "0.0";
            }
        }
    }
}
