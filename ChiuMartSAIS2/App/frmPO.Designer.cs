namespace ChiuMartSAIS2.App
{
    partial class frmPO
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
            this.lstPO = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAcceptPO = new System.Windows.Forms.Button();
            this.btnBackOrdder = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAll = new System.Windows.Forms.Label();
            this.lblDelivered = new System.Windows.Forms.Label();
            this.lblBackOrder = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rboInactive = new System.Windows.Forms.RadioButton();
            this.rboActicve = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateArrival = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.lblVerified = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnChiumartRetail = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPO
            // 
            this.lstPO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1});
            this.lstPO.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPO.FullRowSelect = true;
            this.lstPO.GridLines = true;
            this.lstPO.Location = new System.Drawing.Point(13, 121);
            this.lstPO.MultiSelect = false;
            this.lstPO.Name = "lstPO";
            this.lstPO.Size = new System.Drawing.Size(956, 419);
            this.lstPO.TabIndex = 0;
            this.lstPO.UseCompatibleStateImageBehavior = false;
            this.lstPO.View = System.Windows.Forms.View.Details;
            this.lstPO.Click += new System.EventHandler(this.lstPO_Click);
            this.lstPO.DoubleClick += new System.EventHandler(this.lstPO_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PO Number";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Supplier";
            this.columnHeader3.Width = 244;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Amount";
            this.columnHeader4.Width = 149;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date of Arrival";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "PO Status";
            this.columnHeader6.Width = 148;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Status";
            this.columnHeader1.Width = 135;
            // 
            // btnAcceptPO
            // 
            this.btnAcceptPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptPO.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptPO.Location = new System.Drawing.Point(14, 546);
            this.btnAcceptPO.Name = "btnAcceptPO";
            this.btnAcceptPO.Size = new System.Drawing.Size(124, 51);
            this.btnAcceptPO.TabIndex = 2;
            this.btnAcceptPO.Text = "Add";
            this.btnAcceptPO.UseVisualStyleBackColor = true;
            this.btnAcceptPO.Click += new System.EventHandler(this.btnAcceptPO_Click);
            // 
            // btnBackOrdder
            // 
            this.btnBackOrdder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackOrdder.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackOrdder.Location = new System.Drawing.Point(274, 546);
            this.btnBackOrdder.Name = "btnBackOrdder";
            this.btnBackOrdder.Size = new System.Drawing.Size(124, 51);
            this.btnBackOrdder.TabIndex = 5;
            this.btnBackOrdder.Text = "Back Order";
            this.btnBackOrdder.UseVisualStyleBackColor = true;
            this.btnBackOrdder.Click += new System.EventHandler(this.btnBackOrdder_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(144, 546);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 51);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(845, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAll
            // 
            this.lblAll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAll.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAll.Location = new System.Drawing.Point(12, 75);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(111, 40);
            this.lblAll.TabIndex = 5;
            this.lblAll.Text = "All";
            this.lblAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAll.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // lblDelivered
            // 
            this.lblDelivered.BackColor = System.Drawing.Color.White;
            this.lblDelivered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDelivered.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelivered.Location = new System.Drawing.Point(129, 75);
            this.lblDelivered.Name = "lblDelivered";
            this.lblDelivered.Size = new System.Drawing.Size(135, 40);
            this.lblDelivered.TabIndex = 7;
            this.lblDelivered.Text = "Delivered";
            this.lblDelivered.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDelivered.Click += new System.EventHandler(this.lblDelivered_Click);
            // 
            // lblBackOrder
            // 
            this.lblBackOrder.BackColor = System.Drawing.Color.IndianRed;
            this.lblBackOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBackOrder.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackOrder.Location = new System.Drawing.Point(270, 75);
            this.lblBackOrder.Name = "lblBackOrder";
            this.lblBackOrder.Size = new System.Drawing.Size(135, 40);
            this.lblBackOrder.TabIndex = 8;
            this.lblBackOrder.Text = "Back Order";
            this.lblBackOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBackOrder.Click += new System.EventHandler(this.lblBackOrder_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rboInactive);
            this.panel1.Controls.Add(this.rboActicve);
            this.panel1.Location = new System.Drawing.Point(769, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 40);
            this.panel1.TabIndex = 9;
            // 
            // rboInactive
            // 
            this.rboInactive.AutoSize = true;
            this.rboInactive.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboInactive.Location = new System.Drawing.Point(117, 10);
            this.rboInactive.Name = "rboInactive";
            this.rboInactive.Size = new System.Drawing.Size(78, 24);
            this.rboInactive.TabIndex = 1;
            this.rboInactive.Text = "Inactive";
            this.rboInactive.UseVisualStyleBackColor = true;
            this.rboInactive.CheckedChanged += new System.EventHandler(this.rboInactive_CheckedChanged);
            // 
            // rboActicve
            // 
            this.rboActicve.AutoSize = true;
            this.rboActicve.Checked = true;
            this.rboActicve.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboActicve.Location = new System.Drawing.Point(14, 10);
            this.rboActicve.Name = "rboActicve";
            this.rboActicve.Size = new System.Drawing.Size(68, 24);
            this.rboActicve.TabIndex = 0;
            this.rboActicve.TabStop = true;
            this.rboActicve.Text = "Active";
            this.rboActicve.UseVisualStyleBackColor = true;
            this.rboActicve.CheckedChanged += new System.EventHandler(this.rboActicve_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(12, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(537, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(99, 13);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(82, 24);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Supplier";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(187, 13);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(104, 24);
            this.radioButton4.TabIndex = 13;
            this.radioButton4.Text = "PO Number";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(551, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Date";
            // 
            // dtpDateArrival
            // 
            this.dtpDateArrival.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateArrival.Location = new System.Drawing.Point(555, 37);
            this.dtpDateArrival.Name = "dtpDateArrival";
            this.dtpDateArrival.Size = new System.Drawing.Size(414, 25);
            this.dtpDateArrival.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(715, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblVerified
            // 
            this.lblVerified.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblVerified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVerified.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVerified.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerified.Location = new System.Drawing.Point(411, 75);
            this.lblVerified.Name = "lblVerified";
            this.lblVerified.Size = new System.Drawing.Size(135, 40);
            this.lblVerified.TabIndex = 16;
            this.lblVerified.Text = "Verified";
            this.lblVerified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVerified.Click += new System.EventHandler(this.lblVerified_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(404, 546);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(124, 51);
            this.btnVerify.TabIndex = 17;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnChiumartRetail
            // 
            this.btnChiumartRetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiumartRetail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiumartRetail.Location = new System.Drawing.Point(534, 546);
            this.btnChiumartRetail.Name = "btnChiumartRetail";
            this.btnChiumartRetail.Size = new System.Drawing.Size(175, 51);
            this.btnChiumartRetail.TabIndex = 18;
            this.btnChiumartRetail.Text = "Chiumart Retail";
            this.btnChiumartRetail.UseVisualStyleBackColor = true;
            this.btnChiumartRetail.Click += new System.EventHandler(this.btnChiumartRetail_Click);
            // 
            // frmPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 607);
            this.Controls.Add(this.btnChiumartRetail);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.lblVerified);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpDateArrival);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBackOrder);
            this.Controls.Add(this.lblDelivered);
            this.Controls.Add(this.lblAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBackOrdder);
            this.Controls.Add(this.btnAcceptPO);
            this.Controls.Add(this.lstPO);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPO";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPO_FormClosing);
            this.Load += new System.EventHandler(this.frmPO_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstPO;
        private System.Windows.Forms.Button btnAcceptPO;
        private System.Windows.Forms.Button btnBackOrdder;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Label lblDelivered;
        private System.Windows.Forms.Label lblBackOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rboInactive;
        private System.Windows.Forms.RadioButton rboActicve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateArrival;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblVerified;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnChiumartRetail;
    }
}