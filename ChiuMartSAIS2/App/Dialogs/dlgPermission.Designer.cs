namespace ChiuMartSAIS2.App.Dialogs
{
    partial class dlgPermission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkPermissions = new System.Windows.Forms.CheckBox();
            this.chkUsers = new System.Windows.Forms.CheckBox();
            this.chkClients = new System.Windows.Forms.CheckBox();
            this.chkSuppliers = new System.Windows.Forms.CheckBox();
            this.chkUnits = new System.Windows.Forms.CheckBox();
            this.chkCategories = new System.Windows.Forms.CheckBox();
            this.chkProducts = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkChequeMonitoring = new System.Windows.Forms.CheckBox();
            this.chkPurchaseOrder = new System.Windows.Forms.CheckBox();
            this.chkInventoryMonitoring = new System.Windows.Forms.CheckBox();
            this.chkPointOfSales = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkSupplierReport = new System.Windows.Forms.CheckBox();
            this.chkClientReport = new System.Windows.Forms.CheckBox();
            this.chkLogsReport = new System.Windows.Forms.CheckBox();
            this.chkUsersList = new System.Windows.Forms.CheckBox();
            this.chkSalesReport = new System.Windows.Forms.CheckBox();
            this.chkInventoryReport = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkSystemUtilities = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUnCheckAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(967, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check the functions that you wanted this position will have access.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Position name";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleName.Location = new System.Drawing.Point(16, 89);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(939, 27);
            this.txtRoleName.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkPermissions);
            this.panel1.Controls.Add(this.chkUsers);
            this.panel1.Controls.Add(this.chkClients);
            this.panel1.Controls.Add(this.chkSuppliers);
            this.panel1.Controls.Add(this.chkUnits);
            this.panel1.Controls.Add(this.chkCategories);
            this.panel1.Controls.Add(this.chkProducts);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(16, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 243);
            this.panel1.TabIndex = 3;
            // 
            // chkPermissions
            // 
            this.chkPermissions.AutoSize = true;
            this.chkPermissions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPermissions.Location = new System.Drawing.Point(19, 184);
            this.chkPermissions.Name = "chkPermissions";
            this.chkPermissions.Size = new System.Drawing.Size(105, 24);
            this.chkPermissions.TabIndex = 8;
            this.chkPermissions.Text = "Permissions";
            this.chkPermissions.UseVisualStyleBackColor = true;
            // 
            // chkUsers
            // 
            this.chkUsers.AutoSize = true;
            this.chkUsers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsers.Location = new System.Drawing.Point(160, 143);
            this.chkUsers.Name = "chkUsers";
            this.chkUsers.Size = new System.Drawing.Size(63, 24);
            this.chkUsers.TabIndex = 7;
            this.chkUsers.Text = "Users";
            this.chkUsers.UseVisualStyleBackColor = true;
            // 
            // chkClients
            // 
            this.chkClients.AutoSize = true;
            this.chkClients.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClients.Location = new System.Drawing.Point(19, 143);
            this.chkClients.Name = "chkClients";
            this.chkClients.Size = new System.Drawing.Size(72, 24);
            this.chkClients.TabIndex = 6;
            this.chkClients.Text = "Clients";
            this.chkClients.UseVisualStyleBackColor = true;
            // 
            // chkSuppliers
            // 
            this.chkSuppliers.AutoSize = true;
            this.chkSuppliers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSuppliers.Location = new System.Drawing.Point(160, 103);
            this.chkSuppliers.Name = "chkSuppliers";
            this.chkSuppliers.Size = new System.Drawing.Size(89, 24);
            this.chkSuppliers.TabIndex = 5;
            this.chkSuppliers.Text = "Suppliers";
            this.chkSuppliers.UseVisualStyleBackColor = true;
            // 
            // chkUnits
            // 
            this.chkUnits.AutoSize = true;
            this.chkUnits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnits.Location = new System.Drawing.Point(19, 103);
            this.chkUnits.Name = "chkUnits";
            this.chkUnits.Size = new System.Drawing.Size(61, 24);
            this.chkUnits.TabIndex = 4;
            this.chkUnits.Text = "Units";
            this.chkUnits.UseVisualStyleBackColor = true;
            // 
            // chkCategories
            // 
            this.chkCategories.AutoSize = true;
            this.chkCategories.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCategories.Location = new System.Drawing.Point(160, 60);
            this.chkCategories.Name = "chkCategories";
            this.chkCategories.Size = new System.Drawing.Size(99, 24);
            this.chkCategories.TabIndex = 3;
            this.chkCategories.Text = "Categories";
            this.chkCategories.UseVisualStyleBackColor = true;
            // 
            // chkProducts
            // 
            this.chkProducts.AutoSize = true;
            this.chkProducts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProducts.Location = new System.Drawing.Point(19, 60);
            this.chkProducts.Name = "chkProducts";
            this.chkProducts.Size = new System.Drawing.Size(85, 24);
            this.chkProducts.TabIndex = 2;
            this.chkProducts.Text = "Products";
            this.chkProducts.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.ForestGreen;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 47);
            this.label3.TabIndex = 1;
            this.label3.Text = "File Maintenance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkChequeMonitoring);
            this.panel2.Controls.Add(this.chkPurchaseOrder);
            this.panel2.Controls.Add(this.chkInventoryMonitoring);
            this.panel2.Controls.Add(this.chkPointOfSales);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(346, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 243);
            this.panel2.TabIndex = 4;
            // 
            // chkChequeMonitoring
            // 
            this.chkChequeMonitoring.AutoSize = true;
            this.chkChequeMonitoring.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChequeMonitoring.Location = new System.Drawing.Point(19, 184);
            this.chkChequeMonitoring.Name = "chkChequeMonitoring";
            this.chkChequeMonitoring.Size = new System.Drawing.Size(156, 24);
            this.chkChequeMonitoring.TabIndex = 5;
            this.chkChequeMonitoring.Text = "Cheque Monitoring";
            this.chkChequeMonitoring.UseVisualStyleBackColor = true;
            // 
            // chkPurchaseOrder
            // 
            this.chkPurchaseOrder.AutoSize = true;
            this.chkPurchaseOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPurchaseOrder.Location = new System.Drawing.Point(19, 143);
            this.chkPurchaseOrder.Name = "chkPurchaseOrder";
            this.chkPurchaseOrder.Size = new System.Drawing.Size(128, 24);
            this.chkPurchaseOrder.TabIndex = 4;
            this.chkPurchaseOrder.Text = "Purchase Order";
            this.chkPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // chkInventoryMonitoring
            // 
            this.chkInventoryMonitoring.AutoSize = true;
            this.chkInventoryMonitoring.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInventoryMonitoring.Location = new System.Drawing.Point(19, 103);
            this.chkInventoryMonitoring.Name = "chkInventoryMonitoring";
            this.chkInventoryMonitoring.Size = new System.Drawing.Size(167, 24);
            this.chkInventoryMonitoring.TabIndex = 3;
            this.chkInventoryMonitoring.Text = "Inventory Monitoring";
            this.chkInventoryMonitoring.UseVisualStyleBackColor = true;
            // 
            // chkPointOfSales
            // 
            this.chkPointOfSales.AutoSize = true;
            this.chkPointOfSales.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPointOfSales.Location = new System.Drawing.Point(19, 60);
            this.chkPointOfSales.Name = "chkPointOfSales";
            this.chkPointOfSales.Size = new System.Drawing.Size(118, 24);
            this.chkPointOfSales.TabIndex = 2;
            this.chkPointOfSales.Text = "Point of Sales";
            this.chkPointOfSales.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.ForestGreen;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 47);
            this.label4.TabIndex = 1;
            this.label4.Text = "Transaction";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkSupplierReport);
            this.panel3.Controls.Add(this.chkClientReport);
            this.panel3.Controls.Add(this.chkLogsReport);
            this.panel3.Controls.Add(this.chkUsersList);
            this.panel3.Controls.Add(this.chkSalesReport);
            this.panel3.Controls.Add(this.chkInventoryReport);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(681, 141);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 243);
            this.panel3.TabIndex = 5;
            // 
            // chkSupplierReport
            // 
            this.chkSupplierReport.AutoSize = true;
            this.chkSupplierReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSupplierReport.Location = new System.Drawing.Point(152, 143);
            this.chkSupplierReport.Name = "chkSupplierReport";
            this.chkSupplierReport.Size = new System.Drawing.Size(107, 17);
            this.chkSupplierReport.TabIndex = 7;
            this.chkSupplierReport.Text = "Supplier Report";
            this.chkSupplierReport.UseVisualStyleBackColor = true;
            // 
            // chkClientReport
            // 
            this.chkClientReport.AutoSize = true;
            this.chkClientReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClientReport.Location = new System.Drawing.Point(4, 143);
            this.chkClientReport.Name = "chkClientReport";
            this.chkClientReport.Size = new System.Drawing.Size(115, 24);
            this.chkClientReport.TabIndex = 6;
            this.chkClientReport.Text = "Client Report";
            this.chkClientReport.UseVisualStyleBackColor = true;
            // 
            // chkLogsReport
            // 
            this.chkLogsReport.AutoSize = true;
            this.chkLogsReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLogsReport.Location = new System.Drawing.Point(152, 103);
            this.chkLogsReport.Name = "chkLogsReport";
            this.chkLogsReport.Size = new System.Drawing.Size(108, 24);
            this.chkLogsReport.TabIndex = 5;
            this.chkLogsReport.Text = "Logs Report";
            this.chkLogsReport.UseVisualStyleBackColor = true;
            // 
            // chkUsersList
            // 
            this.chkUsersList.AutoSize = true;
            this.chkUsersList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsersList.Location = new System.Drawing.Point(4, 103);
            this.chkUsersList.Name = "chkUsersList";
            this.chkUsersList.Size = new System.Drawing.Size(89, 24);
            this.chkUsersList.TabIndex = 4;
            this.chkUsersList.Text = "Users List";
            this.chkUsersList.UseVisualStyleBackColor = true;
            // 
            // chkSalesReport
            // 
            this.chkSalesReport.AutoSize = true;
            this.chkSalesReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSalesReport.Location = new System.Drawing.Point(152, 60);
            this.chkSalesReport.Name = "chkSalesReport";
            this.chkSalesReport.Size = new System.Drawing.Size(111, 24);
            this.chkSalesReport.TabIndex = 3;
            this.chkSalesReport.Text = "Sales Report";
            this.chkSalesReport.UseVisualStyleBackColor = true;
            // 
            // chkInventoryReport
            // 
            this.chkInventoryReport.AutoSize = true;
            this.chkInventoryReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInventoryReport.Location = new System.Drawing.Point(4, 60);
            this.chkInventoryReport.Name = "chkInventoryReport";
            this.chkInventoryReport.Size = new System.Drawing.Size(138, 24);
            this.chkInventoryReport.TabIndex = 2;
            this.chkInventoryReport.Text = "Inventory Report";
            this.chkInventoryReport.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.ForestGreen;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(272, 47);
            this.label5.TabIndex = 1;
            this.label5.Text = "Reports";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkSystemUtilities);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(16, 402);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 105);
            this.panel4.TabIndex = 6;
            // 
            // chkSystemUtilities
            // 
            this.chkSystemUtilities.AutoSize = true;
            this.chkSystemUtilities.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSystemUtilities.Location = new System.Drawing.Point(19, 60);
            this.chkSystemUtilities.Name = "chkSystemUtilities";
            this.chkSystemUtilities.Size = new System.Drawing.Size(129, 24);
            this.chkSystemUtilities.TabIndex = 2;
            this.chkSystemUtilities.Text = "System Utilities";
            this.chkSystemUtilities.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.ForestGreen;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 47);
            this.label6.TabIndex = 1;
            this.label6.Text = "Others";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(604, 438);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(171, 37);
            this.btnCheckAll.TabIndex = 7;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.Location = new System.Drawing.Point(781, 438);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(171, 37);
            this.btnUnCheckAll.TabIndex = 8;
            this.btnUnCheckAll.Text = "Un-check All";
            this.btnUnCheckAll.UseVisualStyleBackColor = true;
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(604, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 37);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(781, 486);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(171, 37);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dlgPermission
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 531);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUnCheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPermission";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permissions dialog";
            this.Load += new System.EventHandler(this.dlgPermission_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkProducts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkPointOfSales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkInventoryReport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkSystemUtilities;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkPermissions;
        private System.Windows.Forms.CheckBox chkUsers;
        private System.Windows.Forms.CheckBox chkClients;
        private System.Windows.Forms.CheckBox chkSuppliers;
        private System.Windows.Forms.CheckBox chkUnits;
        private System.Windows.Forms.CheckBox chkCategories;
        private System.Windows.Forms.CheckBox chkPurchaseOrder;
        private System.Windows.Forms.CheckBox chkInventoryMonitoring;
        private System.Windows.Forms.CheckBox chkSupplierReport;
        private System.Windows.Forms.CheckBox chkClientReport;
        private System.Windows.Forms.CheckBox chkLogsReport;
        private System.Windows.Forms.CheckBox chkUsersList;
        private System.Windows.Forms.CheckBox chkSalesReport;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUnCheckAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckBox chkChequeMonitoring;
    }
}