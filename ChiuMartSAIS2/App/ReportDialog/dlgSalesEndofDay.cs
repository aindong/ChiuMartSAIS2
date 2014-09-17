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

namespace ChiuMartSAIS2.App.ReportDialog
{
    public partial class dlgSalesEndofDay : Form
    {
        private Classes.Configuration conf;

        public dlgSalesEndofDay()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        // get the total number of transaction for cash, cheque, accounts receivables


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgSalesEndofDay_Load(object sender, EventArgs e)
        {

        }
    }
}
