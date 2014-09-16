namespace ChiuMartSAIS2.App.Dialogs
{
    partial class dlgInventoryAdjust
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
            this.btnAdjust = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.rdbIncrease = new System.Windows.Forms.RadioButton();
            this.rdbDecrease = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnAdjust
            // 
            this.btnAdjust.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjust.Location = new System.Drawing.Point(12, 102);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(284, 42);
            this.btnAdjust.TabIndex = 5;
            this.btnAdjust.Text = "Adjust";
            this.btnAdjust.UseVisualStyleBackColor = true;
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stock";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(12, 63);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(284, 33);
            this.txtQuantity.TabIndex = 3;
            // 
            // rdbIncrease
            // 
            this.rdbIncrease.AutoSize = true;
            this.rdbIncrease.Checked = true;
            this.rdbIncrease.Location = new System.Drawing.Point(12, 13);
            this.rdbIncrease.Name = "rdbIncrease";
            this.rdbIncrease.Size = new System.Drawing.Size(89, 24);
            this.rdbIncrease.TabIndex = 6;
            this.rdbIncrease.TabStop = true;
            this.rdbIncrease.Text = "Increase";
            this.rdbIncrease.UseVisualStyleBackColor = true;
            // 
            // rdbDecrease
            // 
            this.rdbDecrease.AutoSize = true;
            this.rdbDecrease.Location = new System.Drawing.Point(107, 13);
            this.rdbDecrease.Name = "rdbDecrease";
            this.rdbDecrease.Size = new System.Drawing.Size(96, 24);
            this.rdbDecrease.TabIndex = 7;
            this.rdbDecrease.Text = "Decrease";
            this.rdbDecrease.UseVisualStyleBackColor = true;
            // 
            // dlgInventoryAdjust
            // 
            this.AcceptButton = this.btnAdjust;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 162);
            this.Controls.Add(this.rdbDecrease);
            this.Controls.Add(this.rdbIncrease);
            this.Controls.Add(this.btnAdjust);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuantity);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgInventoryAdjust";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Adjustment";
            this.Load += new System.EventHandler(this.dlgInventoryAdjust_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdjust;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.RadioButton rdbIncrease;
        private System.Windows.Forms.RadioButton rdbDecrease;
    }
}