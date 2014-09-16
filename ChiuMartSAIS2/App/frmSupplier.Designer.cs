namespace ChiuMartSAIS2.App
{
    partial class frmSupplier
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rboSupName = new System.Windows.Forms.RadioButton();
            this.rboSupConPerson = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboInactive = new System.Windows.Forms.RadioButton();
            this.rboActive = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(188, 112);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(997, 357);
            this.listView1.TabIndex = 35;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Id";
            this.columnHeader7.Width = 73;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            this.columnHeader8.Width = 194;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Address";
            this.columnHeader9.Width = 221;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Contact";
            this.columnHeader10.Width = 160;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Contact Person";
            this.columnHeader11.Width = 201;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Created Date";
            this.columnHeader12.Width = 147;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Updated Date";
            this.columnHeader13.Width = 139;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Status";
            this.columnHeader14.Width = 109;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1198, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(15, 328);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 57);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(15, 260);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 57);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(15, 186);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(149, 57);
            this.btnEdit.TabIndex = 38;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(15, 111);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(149, 57);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1173, 26);
            this.txtSearch.TabIndex = 43;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Search :";
            // 
            // rboSupName
            // 
            this.rboSupName.AutoSize = true;
            this.rboSupName.Checked = true;
            this.rboSupName.Location = new System.Drawing.Point(15, 71);
            this.rboSupName.Name = "rboSupName";
            this.rboSupName.Size = new System.Drawing.Size(131, 24);
            this.rboSupName.TabIndex = 46;
            this.rboSupName.TabStop = true;
            this.rboSupName.Text = "Supplier Name";
            this.rboSupName.UseVisualStyleBackColor = true;
            // 
            // rboSupConPerson
            // 
            this.rboSupConPerson.AutoSize = true;
            this.rboSupConPerson.Location = new System.Drawing.Point(170, 71);
            this.rboSupConPerson.Name = "rboSupConPerson";
            this.rboSupConPerson.Size = new System.Drawing.Size(199, 24);
            this.rboSupConPerson.TabIndex = 47;
            this.rboSupConPerson.TabStop = true;
            this.rboSupConPerson.Text = "Supplier Contact Person";
            this.rboSupConPerson.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboInactive);
            this.groupBox1.Controls.Add(this.rboActive);
            this.groupBox1.Location = new System.Drawing.Point(999, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 45);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // rboInactive
            // 
            this.rboInactive.AutoSize = true;
            this.rboInactive.Location = new System.Drawing.Point(99, 15);
            this.rboInactive.Name = "rboInactive";
            this.rboInactive.Size = new System.Drawing.Size(82, 24);
            this.rboInactive.TabIndex = 16;
            this.rboInactive.Text = "Inactive";
            this.rboInactive.UseVisualStyleBackColor = true;
            this.rboInactive.CheckedChanged += new System.EventHandler(this.rboInactive_CheckedChanged);
            // 
            // rboActive
            // 
            this.rboActive.AutoSize = true;
            this.rboActive.Checked = true;
            this.rboActive.Location = new System.Drawing.Point(23, 15);
            this.rboActive.Name = "rboActive";
            this.rboActive.Size = new System.Drawing.Size(70, 24);
            this.rboActive.TabIndex = 15;
            this.rboActive.TabStop = true;
            this.rboActive.Text = "Active";
            this.rboActive.UseVisualStyleBackColor = true;
            this.rboActive.CheckedChanged += new System.EventHandler(this.rboActive_CheckedChanged);
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rboSupConPerson);
            this.Controls.Add(this.rboSupName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Maintenance";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rboSupName;
        private System.Windows.Forms.RadioButton rboSupConPerson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboInactive;
        private System.Windows.Forms.RadioButton rboActive;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
    }
}