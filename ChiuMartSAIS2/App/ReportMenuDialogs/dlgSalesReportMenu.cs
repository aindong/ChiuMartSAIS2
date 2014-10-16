using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiuMartSAIS2.App.ReportMenuDialogs
{
    public partial class dlgSalesReportMenu : Form
    {
        public dlgSalesReportMenu()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDialog.dlgSalesEndofDay rpt = new ReportDialog.dlgSalesEndofDay();
            rpt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportDialog.dlgSalesReport frm = new ReportDialog.dlgSalesReport();
            frm.ShowDialog();
        }
    }
}
