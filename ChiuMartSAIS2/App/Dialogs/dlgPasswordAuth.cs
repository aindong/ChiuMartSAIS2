using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace ChiuMartSAIS2.App.Dialogs
{
    public partial class dlgPasswordAuth : Form
    {

        private Classes.Configuration conf;
        private Classes.StringHash stringHash;

        public dlgPasswordAuth()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
            stringHash = new Classes.StringHash();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Authenticate the user
            Classes.Authentication.Instance.userLogin(stringHash.hashIt(txtPassword.Text));

            // Check the user permission
            if (Classes.Authentication.Instance.pointOfSale == 1)
            {
                App.frmPOS frm = new App.frmPOS();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry but you don't have a permission to open this feature", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
