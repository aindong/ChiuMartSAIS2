using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiuMartSAIS2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //TODO: SHOW CONFIRMATION DIALOG FIRST AND ASK THE USER BEFORE THEY EXIT THE PROGRAM
            this.Close();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            App.frmProduct frm = new App.frmProduct();
            frm.ShowDialog();
        }

        private void btnUnits_Click(object sender, EventArgs e)
        {
            App.frmUnits frm = new App.frmUnits();
            frm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            App.frmCategory frm = new App.frmCategory();
            frm.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            App.frmSupplier frm = new App.frmSupplier();
            frm.ShowDialog();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            App.frmClient frm = new App.frmClient();
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            App.frmUsers frm = new App.frmUsers();
            frm.ShowDialog();
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            App.frmPermissions frm = new App.frmPermissions();
            frm.ShowDialog();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth dlg = new App.Dialogs.dlgPasswordAuth();
            dlg.ShowDialog();
        }

        private void btnInventoryMonitoring_Click(object sender, EventArgs e)
        {
            App.frmInventoryMonitoring frm = new App.frmInventoryMonitoring();
            frm.ShowDialog();
        }

    
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            //This will open the built-in calculator on windows. 
            System.Diagnostics.Process.Start("calc");
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("timedate.cpl");
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\Sysnative\StikyNot.exe");
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            App.ReportDialog.dlgProductReport frm = new App.ReportDialog.dlgProductReport();
            frm.ShowDialog();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {

        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            App.ReportDialog.dlgAuditTrailReport frm = new App.ReportDialog.dlgAuditTrailReport();
            frm.ShowDialog();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            App.ReportDialog.dlgClientListReport frm = new App.ReportDialog.dlgClientListReport();
            frm.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            App.ReportDialog.dlgSupplierReport frm = new App.ReportDialog.dlgSupplierReport();
            frm.ShowDialog();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgRestoreDB frm = new App.Dialogs.dlgRestoreDB();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            App.frmChequeMonitoring frm = new App.frmChequeMonitoring();
            frm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            App.frmPO frm = new App.frmPO();
            frm.ShowDialog();
        }
    }
}
