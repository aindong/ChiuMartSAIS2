namespace ChiuMartSAIS2.App
{
    partial class frmChequeMonitoring
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
            this.lblAll = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCleared = new System.Windows.Forms.Label();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstCheques = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblProcessing = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rboInactive = new System.Windows.Forms.RadioButton();
            this.rboActive = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblVerify = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.BackColor = System.Drawing.Color.White;
            this.lblAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAll.Location = new System.Drawing.Point(17, 66);
            this.lblAll.Name = "lblAll";
            this.lblAll.Padding = new System.Windows.Forms.Padding(10);
            this.lblAll.Size = new System.Drawing.Size(50, 43);
            this.lblAll.TabIndex = 23;
            this.lblAll.Text = "All";
            this.lblAll.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(906, 455);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 49);
            this.button3.TabIndex = 21;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Search Name";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(17, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1058, 29);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblCleared
            // 
            this.lblCleared.AutoSize = true;
            this.lblCleared.BackColor = System.Drawing.Color.LimeGreen;
            this.lblCleared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCleared.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleared.Location = new System.Drawing.Point(186, 66);
            this.lblCleared.Name = "lblCleared";
            this.lblCleared.Padding = new System.Windows.Forms.Padding(10);
            this.lblCleared.Size = new System.Drawing.Size(85, 43);
            this.lblCleared.TabIndex = 14;
            this.lblCleared.Text = "Cleared";
            this.lblCleared.Click += new System.EventHandler(this.lblCleared_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Processing Date";
            this.columnHeader6.Width = 153;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Total Amount";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Branch";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bank";
            this.columnHeader3.Width = 190;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 185;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Cheque No.";
            this.columnHeader1.Width = 125;
            // 
            // lstCheques
            // 
            this.lstCheques.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9});
            this.lstCheques.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCheques.FullRowSelect = true;
            this.lstCheques.GridLines = true;
            this.lstCheques.Location = new System.Drawing.Point(17, 115);
            this.lstCheques.Name = "lstCheques";
            this.lstCheques.Size = new System.Drawing.Size(1063, 334);
            this.lstCheques.TabIndex = 12;
            this.lstCheques.UseCompatibleStateImageBehavior = false;
            this.lstCheques.View = System.Windows.Forms.View.Details;
            this.lstCheques.Click += new System.EventHandler(this.lstCheques_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "id";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Status";
            this.columnHeader7.Width = 130;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Cheque Status";
            this.columnHeader9.Width = 200;
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.BackColor = System.Drawing.Color.White;
            this.lblProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcessing.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessing.Location = new System.Drawing.Point(73, 66);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Padding = new System.Windows.Forms.Padding(10);
            this.lblProcessing.Size = new System.Drawing.Size(107, 43);
            this.lblProcessing.TabIndex = 13;
            this.lblProcessing.Text = "Processing";
            this.lblProcessing.Click += new System.EventHandler(this.lblProcessing_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboInactive);
            this.groupBox1.Controls.Add(this.rboActive);
            this.groupBox1.Location = new System.Drawing.Point(889, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 45);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // rboInactive
            // 
            this.rboInactive.AutoSize = true;
            this.rboInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboInactive.Location = new System.Drawing.Point(99, 15);
            this.rboInactive.Name = "rboInactive";
            this.rboInactive.Size = new System.Drawing.Size(72, 20);
            this.rboInactive.TabIndex = 16;
            this.rboInactive.Text = "Inactive";
            this.rboInactive.UseVisualStyleBackColor = true;
            this.rboInactive.CheckedChanged += new System.EventHandler(this.rboInactive_CheckedChanged);
            // 
            // rboActive
            // 
            this.rboActive.AutoSize = true;
            this.rboActive.Checked = true;
            this.rboActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboActive.Location = new System.Drawing.Point(23, 15);
            this.rboActive.Name = "rboActive";
            this.rboActive.Size = new System.Drawing.Size(63, 20);
            this.rboActive.TabIndex = 15;
            this.rboActive.TabStop = true;
            this.rboActive.Text = "Active";
            this.rboActive.UseVisualStyleBackColor = true;
            this.rboActive.CheckedChanged += new System.EventHandler(this.rboActive_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(720, 455);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 49);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblVerify
            // 
            this.lblVerify.AutoSize = true;
            this.lblVerify.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblVerify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVerify.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerify.Location = new System.Drawing.Point(277, 66);
            this.lblVerify.Name = "lblVerify";
            this.lblVerify.Padding = new System.Windows.Forms.Padding(10);
            this.lblVerify.Size = new System.Drawing.Size(86, 43);
            this.lblVerify.TabIndex = 33;
            this.lblVerify.Text = "Verified";
            this.lblVerify.Click += new System.EventHandler(this.lblVerify_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(534, 455);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(180, 49);
            this.btnVerify.TabIndex = 34;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // frmChequeMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 516);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.lblVerify);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAll);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCleared);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.lstCheques);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChequeMonitoring";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Monitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChequeMonitoring_FormClosing);
            this.Load += new System.EventHandler(this.frmChequeMonitoring_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCleared;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstCheques;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rboInactive;
        private System.Windows.Forms.RadioButton rboActive;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblVerify;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}