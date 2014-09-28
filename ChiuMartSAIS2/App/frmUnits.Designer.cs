namespace ChiuMartSAIS2.App
{
    partial class frmUnits
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboInactive = new System.Windows.Forms.RadioButton();
            this.rboActive = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(202, 112);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(740, 320);
            this.listView1.TabIndex = 25;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Units ID";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Units Name";
            this.columnHeader2.Width = 184;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Created Date";
            this.columnHeader3.Width = 157;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Updated Date";
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 105;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(952, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(27, 307);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 51);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(27, 246);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 51);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(27, 179);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(149, 51);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(27, 112);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(149, 51);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(27, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(915, 26);
            this.txtSearch.TabIndex = 33;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Search :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboInactive);
            this.groupBox1.Controls.Add(this.rboActive);
            this.groupBox1.Location = new System.Drawing.Point(756, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 45);
            this.groupBox1.TabIndex = 34;
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
            // frmUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 462);
            this.Controls.Add(this.groupBox1);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnits";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Units Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUnits_FormClosing);
            this.Load += new System.EventHandler(this.frmUnits_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboInactive;
        private System.Windows.Forms.RadioButton rboActive;
    }
}