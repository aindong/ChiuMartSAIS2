namespace ChiuMartSAIS2.App
{
    partial class frmPermissions
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboInactive = new System.Windows.Forms.RadioButton();
            this.rboActive = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1051, 22);
            this.txtSearch.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-84, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Search :";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(172, 99);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(894, 420);
            this.listView1.TabIndex = 44;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Id";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Role";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Products";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Categories";
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Units";
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Suppliers";
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Permissions";
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Clients";
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Users";
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "POS";
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Inventory Monitoring";
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "Purchase Order";
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Cheque Monitoring";
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Inventory Report";
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Sales Report";
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Users Report";
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "Logs Report";
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "Client Report";
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Supplier Report";
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "System Utilities";
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Created Date";
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "Update Date";
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "Status";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(15, 316);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 57);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(15, 248);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 57);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(15, 174);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(145, 57);
            this.btnEdit.TabIndex = 46;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(15, 99);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(145, 57);
            this.btnAdd.TabIndex = 45;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Search :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboInactive);
            this.groupBox1.Controls.Add(this.rboActive);
            this.groupBox1.Location = new System.Drawing.Point(880, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 45);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // rboInactive
            // 
            this.rboInactive.AutoSize = true;
            this.rboInactive.Location = new System.Drawing.Point(116, 15);
            this.rboInactive.Name = "rboInactive";
            this.rboInactive.Size = new System.Drawing.Size(64, 17);
            this.rboInactive.TabIndex = 16;
            this.rboInactive.Text = "Inactive";
            this.rboInactive.UseVisualStyleBackColor = true;
            // 
            // rboActive
            // 
            this.rboActive.AutoSize = true;
            this.rboActive.Checked = true;
            this.rboActive.Location = new System.Drawing.Point(23, 15);
            this.rboActive.Name = "rboActive";
            this.rboActive.Size = new System.Drawing.Size(55, 17);
            this.rboActive.TabIndex = 15;
            this.rboActive.TabStop = true;
            this.rboActive.Text = "Active";
            this.rboActive.UseVisualStyleBackColor = true;
            // 
            // frmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 526);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermissions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permissions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPermissions_FormClosing);
            this.Load += new System.EventHandler(this.frmPermissions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboInactive;
        private System.Windows.Forms.RadioButton rboActive;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.ColumnHeader columnHeader47;
    }
}