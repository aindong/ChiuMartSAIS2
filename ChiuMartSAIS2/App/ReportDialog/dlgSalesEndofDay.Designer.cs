namespace ChiuMartSAIS2.App.ReportDialog
{
    partial class dlgSalesEndofDay
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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblCheque = new System.Windows.Forms.Label();
            this.lblAccountsReceivables = new System.Windows.Forms.Label();
            this.lblTransparentBasyo = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.btnAccountsReceivables = new System.Windows.Forms.Button();
            this.btnChequeView = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 88);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 50);
            this.button1.TabIndex = 16;
            this.button1.Text = "&Filter Record";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "To";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(306, 46);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpEnd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "From";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(63, 46);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please select a report date";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(961, 67);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cash: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(961, 68);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cheque: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(961, 68);
            this.label6.TabIndex = 3;
            this.label6.Text = "Accounts Receivables: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gainsboro;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(961, 88);
            this.label7.TabIndex = 4;
            this.label7.Text = "Basyo:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCash.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(389, 99);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(88, 45);
            this.lblCash.TabIndex = 9;
            this.lblCash.Text = "Cash";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCheque
            // 
            this.lblCheque.AutoSize = true;
            this.lblCheque.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCheque.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheque.Location = new System.Drawing.Point(389, 167);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(129, 45);
            this.lblCheque.TabIndex = 10;
            this.lblCheque.Text = "Cheque";
            this.lblCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountsReceivables
            // 
            this.lblAccountsReceivables.AutoSize = true;
            this.lblAccountsReceivables.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAccountsReceivables.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountsReceivables.Location = new System.Drawing.Point(389, 235);
            this.lblAccountsReceivables.Name = "lblAccountsReceivables";
            this.lblAccountsReceivables.Size = new System.Drawing.Size(325, 45);
            this.lblAccountsReceivables.TabIndex = 11;
            this.lblAccountsReceivables.Text = "Accounts Receivables";
            this.lblAccountsReceivables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTransparentBasyo
            // 
            this.lblTransparentBasyo.AutoSize = true;
            this.lblTransparentBasyo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTransparentBasyo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransparentBasyo.Location = new System.Drawing.Point(389, 313);
            this.lblTransparentBasyo.Name = "lblTransparentBasyo";
            this.lblTransparentBasyo.Size = new System.Drawing.Size(280, 45);
            this.lblTransparentBasyo.TabIndex = 12;
            this.lblTransparentBasyo.Text = "Transparent basyo";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(645, 486);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(149, 48);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(800, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(149, 48);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(961, 68);
            this.label10.TabIndex = 16;
            this.label10.Text = "Total Sales: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.Location = new System.Drawing.Point(389, 391);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(172, 45);
            this.lblTotalSales.TabIndex = 17;
            this.lblTotalSales.Text = "Total Sales";
            this.lblTotalSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAccountsReceivables
            // 
            this.btnAccountsReceivables.Location = new System.Drawing.Point(771, 235);
            this.btnAccountsReceivables.Name = "btnAccountsReceivables";
            this.btnAccountsReceivables.Size = new System.Drawing.Size(149, 48);
            this.btnAccountsReceivables.TabIndex = 18;
            this.btnAccountsReceivables.Text = "View";
            this.btnAccountsReceivables.UseVisualStyleBackColor = true;
            this.btnAccountsReceivables.Click += new System.EventHandler(this.btnAccountsReceivables_Click);
            // 
            // btnChequeView
            // 
            this.btnChequeView.Location = new System.Drawing.Point(771, 167);
            this.btnChequeView.Name = "btnChequeView";
            this.btnChequeView.Size = new System.Drawing.Size(149, 48);
            this.btnChequeView.TabIndex = 19;
            this.btnChequeView.Text = "View";
            this.btnChequeView.UseVisualStyleBackColor = true;
            this.btnChequeView.Click += new System.EventHandler(this.btnChequeView_Click);
            // 
            // dlgSalesEndofDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 546);
            this.Controls.Add(this.btnChequeView);
            this.Controls.Add(this.btnAccountsReceivables);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTransparentBasyo);
            this.Controls.Add(this.lblAccountsReceivables);
            this.Controls.Add(this.lblCheque);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgSalesEndofDay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES SUMMARY";
            this.Load += new System.EventHandler(this.dlgSalesEndofDay_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblCheque;
        private System.Windows.Forms.Label lblAccountsReceivables;
        private System.Windows.Forms.Label lblTransparentBasyo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAccountsReceivables;
        private System.Windows.Forms.Button btnChequeView;

    }
}