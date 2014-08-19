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
        public int permissionId = 0;
        public string role = "";
        public int products = 0;
        public int categories = 0;
        public int units = 0;
        public int suppliers = 0;
        public int clients = 0;
        public int users = 0;
        public int permissions = 0;
        public int discounts = 0;
        public int pos = 0;
        public int inventoryMonitoring = 0;
        public int purchaseOrder = 0;
        public int chequemonitoring = 0;
        public int inventoryReport = 0;
        public int salesReport = 0;
        public int usersReport = 0;
        public int logsreport = 0;
        public int clientReport = 0;
        public int supplierReport = 0;
        public int systemUtilities = 0;

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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public void GetData(out int permissionId, out string role, out int products, out int categories, out int units, out int suppliers, out int clients,
            out int users, out int permissions, out int pos, out int inventoryMonitoring, out int purchaseOrder, out int chequemonitoring, out int inventoryReport,
            out int salesReport, out int usersReport, out int logsreport, out int clientReport, out int supplierReport, out int systemUtilities)
        {
            permissionId = this.permissionId;
            role = txtRoleName.Text;

            // Permissions
            products = chkProducts.Checked == true ? 1 : 0;
            categories = chkCategories.Checked == true ? 1 : 0;
            units = chkUnits.Checked == true ? 1 : 0;
            suppliers = chkSuppliers.Checked == true ? 1 : 0;
            clients = chkClients.Checked == true ? 1 : 0;
            users = chkUsers.Checked == true ? 1 : 0;
            permissions = chkPermissions.Checked == true ? 1 : 0;
            pos = chkPointOfSales.Checked == true ? 1 : 0;
            inventoryMonitoring = chkInventoryMonitoring.Checked == true ? 1 : 0;
            salesReport = chkSalesReport.Checked == true ? 1 : 0;
            purchaseOrder = chkPurchaseOrder.Checked == true ? 1 : 0;
            chequemonitoring = chkChequeMonitoring.Checked == true ? 1 : 0;
            inventoryReport = chkInventoryReport.Checked == true ? 1 : 0;
            usersReport = chkUsersList.Checked == true ? 1 : 0;
            logsreport = chkLogsReport.Checked == true ? 1 : 0;
            clientReport = chkClientReport.Checked  == true ? 1 : 0;
            supplierReport = chkSupplierReport.Checked == true ? 1 : 0;
            systemUtilities = chkSystemUtilities.Checked == true ? 1 : 0;
        }

        private void dlgPermission_Load(object sender, EventArgs e)
        {
            txtRoleName.Text = role;
            chkProducts.Checked = products == 1 ? true : false;
            chkCategories.Checked = categories == 1 ? true : false;
            chkUnits.Checked = units == 1 ? true : false;
            chkSuppliers.Checked = suppliers == 1 ? true : false;
            chkClients.Checked = clients == 1 ? true : false;
            chkUsers.Checked = users == 1 ? true : false;
            chkPermissions.Checked = permissions == 1 ? true : false;
            chkPointOfSales.Checked = pos == 1 ? true : false;
            chkInventoryMonitoring.Checked = inventoryMonitoring == 1 ? true : false;
            chkPurchaseOrder.Checked = purchaseOrder == 1 ? true : false;
            chkChequeMonitoring.Checked = chequemonitoring == 1 ? true : false;
            chkSalesReport.Checked = salesReport == 1 ? true : false;
            chkInventoryReport.Checked = inventoryReport == 1 ? true : false;
            chkUsersList.Checked = usersReport == 1 ? true : false;
            chkLogsReport.Checked = logsreport == 1 ? true : false;
            chkClientReport.Checked = clientReport == 1 ? true : false;
            chkSupplierReport.Checked = supplierReport == 1 ? true : false;
            chkSystemUtilities.Checked = systemUtilities == 1 ? true : false;
        }
    }
}
