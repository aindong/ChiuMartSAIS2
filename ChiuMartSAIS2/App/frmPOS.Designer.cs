namespace ChiuMartSAIS2.App
{
    partial class frmPOS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.btnNewTransaction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrNo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.btnNewTransaction);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 64);
            this.panel1.TabIndex = 0;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(307, 9);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(334, 42);
            this.button8.TabIndex = 8;
            this.button8.Text = "Transaction History";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransaction.Location = new System.Drawing.Point(667, 9);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Size = new System.Drawing.Size(334, 42);
            this.btnNewTransaction.TabIndex = 7;
            this.btnNewTransaction.Text = "New Transaction";
            this.btnNewTransaction.UseVisualStyleBackColor = true;
            this.btnNewTransaction.Click += new System.EventHandler(this.btnNewTransaction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chiumart POS";
            // 
            // txtAddress
            // 
            this.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(12, 140);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(612, 25);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress.Click += new System.EventHandler(this.txtProduct_Click);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address";
            // 
            // txtClient
            // 
            this.txtClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtClient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient.Location = new System.Drawing.Point(225, 92);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(399, 25);
            this.txtClient.TabIndex = 1;
            this.txtClient.Text = "Walk-in Client";
            this.txtClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClient.Click += new System.EventHandler(this.txtClient_Click);
            this.txtClient.TextChanged += new System.EventHandler(this.txtClient_TextChanged);
            this.txtClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClient_KeyDown);
            this.txtClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClient_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Client";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnVoid);
            this.panel2.Controls.Add(this.btnCheckout);
            this.panel2.Location = new System.Drawing.Point(630, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 223);
            this.panel2.TabIndex = 18;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(14, 128);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(334, 52);
            this.button5.TabIndex = 6;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.BackColor = System.Drawing.Color.Red;
            this.btnVoid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoid.Location = new System.Drawing.Point(14, 70);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(334, 52);
            this.btnVoid.TabIndex = 5;
            this.btnVoid.Text = "Void";
            this.btnVoid.UseVisualStyleBackColor = false;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.Location = new System.Drawing.Point(14, 15);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(334, 52);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 571);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Cashier: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel3.Text = "Date: ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel5.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel5.Text = "Time: ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel6.Text = "toolStripStatusLabel6";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Location = new System.Drawing.Point(630, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(371, 238);
            this.panel3.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(118, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "Amount Due";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(14, 57);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(334, 126);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "0.0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvCart
            // 
            this.dgvCart.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvCart.Location = new System.Drawing.Point(12, 171);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(612, 388);
            this.dgvCart.TabIndex = 3;
            this.dgvCart.EditModeChanged += new System.EventHandler(this.dgvCart_EditModeChanged);
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellValueChanged);
            this.dgvCart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellEndEdit);
            this.dgvCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellValueChanged);
            this.dgvCart.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCart_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "QTY";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Item";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unit";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Unit Price";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Total";
            this.Column6.Name = "Column6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "OR Number";
            // 
            // txtOrNo
            // 
            this.txtOrNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOrNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtOrNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrNo.Location = new System.Drawing.Point(12, 92);
            this.txtOrNo.Name = "txtOrNo";
            this.txtOrNo.Size = new System.Drawing.Size(207, 25);
            this.txtOrNo.TabIndex = 22;
            this.txtOrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 593);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrNo);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPOS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point of Sales";
            this.Load += new System.EventHandler(this.frmPOS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnNewTransaction;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrNo;
    }
}