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
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.productMaintenance;
            frm.ShowDialog();
        }

        private void btnUnits_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.unitsMaintenance;
            frm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.categoryMaintenance;
            frm.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.suppliersMaintenance;
            frm.ShowDialog();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.clientsMaintenance;
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.usersMaintenance;
            frm.ShowDialog();
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.permissionsMaintenance;
            frm.ShowDialog();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.pointOfSales;
            frm.ShowDialog();
        }

        private void btnInventoryMonitoring_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.inventoryMonitoring;
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
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.inventoryReport;
            frm.ShowDialog();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.salesReport;
            frm.ShowDialog();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.logsReport;
            frm.ShowDialog();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.clientReport;
            frm.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.supplierReport;
            frm.ShowDialog();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgRestoreDB frm = new App.Dialogs.dlgRestoreDB();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.chequeMonitoring;
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
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.purchaseOrder;
            frm.ShowDialog();
        }

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgPasswordAuth frm = new App.Dialogs.dlgPasswordAuth();
            frm.formToOpen = App.Dialogs.FormType.userReport;
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Idle Mode Logic
            if (Properties.Settings.Default.idleMode == true)
            {
                if (Classes.GetLastUserInput.formStatusIdle == false)
                {
                    if (Classes.GetLastUserInput.GetIdleTickCount() >= ChiuMartSAIS2.Properties.Settings.Default.idleInterval)
                    {
                        Classes.GetLastUserInput.formStatusIdle = true;
                        App.Dialogs.dlgIdleStatus idle = new App.Dialogs.dlgIdleStatus();
                        idle.ShowDialog();
                    }
                }
            }
            
        }

        private void btnIntervalSettings_Click(object sender, EventArgs e)
        {
            App.Dialogs.dlgIntervalSettings idleSettings = new App.Dialogs.dlgIntervalSettings();
            if (idleSettings.ShowDialog() == DialogResult.OK)
            {
                // DO NOTHING
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            App.ReportDialog.dlgManualInventory frm = new App.ReportDialog.dlgManualInventory();
            frm.ShowDialog();
        }

        private void btnSalesGeneration_Click(object sender, EventArgs e)
        {
            App.frmSalesGeneration frm = new App.frmSalesGeneration();
            frm.ShowDialog();
        }
    }
}
