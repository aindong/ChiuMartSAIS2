namespace ChiuMartSAIS2.App
{
    partial class frmInventoryMonitoring
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
            this.lstProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGood = new System.Windows.Forms.Label();
            this.lblSafety = new System.Windows.Forms.Label();
            this.lblCritical = new System.Windows.Forms.Label();
            this.lblOutOfStock = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblAll = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstProducts
            // 
            this.lstProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader6});
            this.lstProducts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProducts.FullRowSelect = true;
            this.lstProducts.GridLines = true;
            this.lstProducts.Location = new System.Drawing.Point(12, 52);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(927, 324);
            this.lstProducts.TabIndex = 0;
            this.lstProducts.UseCompatibleStateImageBehavior = false;
            this.lstProducts.View = System.Windows.Forms.View.Details;
            this.lstProducts.Click += new System.EventHandler(this.lstProducts_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product";
            this.columnHeader2.Width = 283;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Unit";
            this.columnHeader3.Width = 143;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Current Stocks";
            this.columnHeader5.Width = 176;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Safety Stocks";
            this.columnHeader4.Width = 132;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Last Updated";
            this.columnHeader6.Width = 184;
            // 
            // lblGood
            // 
            this.lblGood.AutoSize = true;
            this.lblGood.BackColor = System.Drawing.Color.White;
            this.lblGood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGood.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGood.Location = new System.Drawing.Point(73, 6);
            this.lblGood.Name = "lblGood";
            this.lblGood.Padding = new System.Windows.Forms.Padding(10);
            this.lblGood.Size = new System.Drawing.Size(70, 43);
            this.lblGood.TabIndex = 1;
            this.lblGood.Text = "Good";
            this.lblGood.Click += new System.EventHandler(this.lblGood_Click);
            // 
            // lblSafety
            // 
            this.lblSafety.AutoSize = true;
            this.lblSafety.BackColor = System.Drawing.Color.LimeGreen;
            this.lblSafety.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSafety.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSafety.Location = new System.Drawing.Point(149, 6);
            this.lblSafety.Name = "lblSafety";
            this.lblSafety.Padding = new System.Windows.Forms.Padding(10);
            this.lblSafety.Size = new System.Drawing.Size(75, 43);
            this.lblSafety.TabIndex = 2;
            this.lblSafety.Text = "Safety";
            this.lblSafety.Click += new System.EventHandler(this.lblSafety_Click);
            // 
            // lblCritical
            // 
            this.lblCritical.AutoSize = true;
            this.lblCritical.BackColor = System.Drawing.Color.IndianRed;
            this.lblCritical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCritical.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCritical.Location = new System.Drawing.Point(230, 6);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Padding = new System.Windows.Forms.Padding(10);
            this.lblCritical.Size = new System.Drawing.Size(80, 43);
            this.lblCritical.TabIndex = 3;
            this.lblCritical.Text = "Critical";
            this.lblCritical.Click += new System.EventHandler(this.lblCritical_Click);
            // 
            // lblOutOfStock
            // 
            this.lblOutOfStock.AutoSize = true;
            this.lblOutOfStock.BackColor = System.Drawing.Color.Red;
            this.lblOutOfStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutOfStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutOfStock.Location = new System.Drawing.Point(316, 6);
            this.lblOutOfStock.Name = "lblOutOfStock";
            this.lblOutOfStock.Padding = new System.Windows.Forms.Padding(10);
            this.lblOutOfStock.Size = new System.Drawing.Size(125, 43);
            this.lblOutOfStock.TabIndex = 4;
            this.lblOutOfStock.Text = "Out of Stocks";
            this.lblOutOfStock.Click += new System.EventHandler(this.lblOutOfStock_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "Adjust";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 49);
            this.button2.TabIndex = 6;
            this.button2.Text = "Purchase Order";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(523, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(416, 29);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Search Product";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(759, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 49);
            this.button3.TabIndex = 9;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 49);
            this.button4.TabIndex = 10;
            this.button4.Text = "Overview";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.BackColor = System.Drawing.Color.White;
            this.lblAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAll.Location = new System.Drawing.Point(17, 6);
            this.lblAll.Name = "lblAll";
            this.lblAll.Padding = new System.Windows.Forms.Padding(10);
            this.lblAll.Size = new System.Drawing.Size(50, 43);
            this.lblAll.TabIndex = 11;
            this.lblAll.Text = "All";
            this.lblAll.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // frmInventoryMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 443);
            this.Controls.Add(this.lblAll);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblOutOfStock);
            this.Controls.Add(this.lblCritical);
            this.Controls.Add(this.lblSafety);
            this.Controls.Add(this.lblGood);
            this.Controls.Add(this.lstProducts);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventoryMonitoring";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Monitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInventoryMonitoring_FormClosing);
            this.Load += new System.EventHandler(this.frmInventoryMonitoring_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblGood;
        private System.Windows.Forms.Label lblSafety;
        private System.Windows.Forms.Label lblCritical;
        private System.Windows.Forms.Label lblOutOfStock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblAll;
    }
}