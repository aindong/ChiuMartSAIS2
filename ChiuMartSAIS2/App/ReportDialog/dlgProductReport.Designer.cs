namespace ChiuMartSAIS2.App.ReportDialog
{
    partial class dlgProductReport
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rboActive = new System.Windows.Forms.RadioButton();
            this.rboInactive = new System.Windows.Forms.RadioButton();
            this.rboProductName = new System.Windows.Forms.RadioButton();
            this.rboProductID = new System.Windows.Forms.RadioButton();
            this.rboCategory = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lstProducts
            // 
            this.lstProducts.FullRowSelect = true;
            this.lstProducts.GridLines = true;
            this.lstProducts.Location = new System.Drawing.Point(12, 105);
            this.lstProducts.MultiSelect = false;
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(866, 285);
            this.lstProducts.TabIndex = 0;
            this.lstProducts.UseCompatibleStateImageBehavior = false;
            this.lstProducts.View = System.Windows.Forms.View.Details;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(149, 396);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(259, 48);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(424, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(259, 48);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(11, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(628, 27);
            this.txtSearch.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // rboActive
            // 
            this.rboActive.AutoSize = true;
            this.rboActive.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboActive.Location = new System.Drawing.Point(654, 25);
            this.rboActive.Name = "rboActive";
            this.rboActive.Size = new System.Drawing.Size(68, 24);
            this.rboActive.TabIndex = 5;
            this.rboActive.TabStop = true;
            this.rboActive.Text = "Active";
            this.rboActive.UseVisualStyleBackColor = true;
            // 
            // rboInactive
            // 
            this.rboInactive.AutoSize = true;
            this.rboInactive.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboInactive.Location = new System.Drawing.Point(760, 25);
            this.rboInactive.Name = "rboInactive";
            this.rboInactive.Size = new System.Drawing.Size(78, 24);
            this.rboInactive.TabIndex = 6;
            this.rboInactive.TabStop = true;
            this.rboInactive.Text = "Inactive";
            this.rboInactive.UseVisualStyleBackColor = true;
            // 
            // rboProductName
            // 
            this.rboProductName.AutoSize = true;
            this.rboProductName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboProductName.Location = new System.Drawing.Point(12, 52);
            this.rboProductName.Name = "rboProductName";
            this.rboProductName.Size = new System.Drawing.Size(122, 24);
            this.rboProductName.TabIndex = 7;
            this.rboProductName.TabStop = true;
            this.rboProductName.Text = "Product Name";
            this.rboProductName.UseVisualStyleBackColor = true;
            // 
            // rboProductID
            // 
            this.rboProductID.AutoSize = true;
            this.rboProductID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboProductID.Location = new System.Drawing.Point(140, 52);
            this.rboProductID.Name = "rboProductID";
            this.rboProductID.Size = new System.Drawing.Size(95, 24);
            this.rboProductID.TabIndex = 8;
            this.rboProductID.TabStop = true;
            this.rboProductID.Text = "Product Id";
            this.rboProductID.UseVisualStyleBackColor = true;
            // 
            // rboCategory
            // 
            this.rboCategory.AutoSize = true;
            this.rboCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboCategory.Location = new System.Drawing.Point(241, 52);
            this.rboCategory.Name = "rboCategory";
            this.rboCategory.Size = new System.Drawing.Size(87, 24);
            this.rboCategory.TabIndex = 9;
            this.rboCategory.TabStop = true;
            this.rboCategory.Text = "Category";
            this.rboCategory.UseVisualStyleBackColor = true;
            // 
            // dlgProductReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 456);
            this.Controls.Add(this.rboCategory);
            this.Controls.Add(this.rboProductID);
            this.Controls.Add(this.rboProductName);
            this.Controls.Add(this.rboInactive);
            this.Controls.Add(this.rboActive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lstProducts);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgProductReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstProducts;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rboActive;
        private System.Windows.Forms.RadioButton rboInactive;
        private System.Windows.Forms.RadioButton rboProductName;
        private System.Windows.Forms.RadioButton rboProductID;
        private System.Windows.Forms.RadioButton rboCategory;
    }
}