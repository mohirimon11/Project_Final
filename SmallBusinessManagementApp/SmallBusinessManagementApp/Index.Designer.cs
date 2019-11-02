namespace SmallBusinessManagementApp
{
    partial class Index
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
            this.categoryButton = new System.Windows.Forms.Button();
            this.productButton = new System.Windows.Forms.Button();
            this.customerButton = new System.Windows.Forms.Button();
            this.supplierButton = new System.Windows.Forms.Button();
            this.salesButton = new System.Windows.Forms.Button();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.stockButton = new System.Windows.Forms.Button();
            this.reportSalesButton = new System.Windows.Forms.Button();
            this.reportPurchaseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryButton
            // 
            this.categoryButton.Location = new System.Drawing.Point(246, 22);
            this.categoryButton.Name = "categoryButton";
            this.categoryButton.Size = new System.Drawing.Size(154, 23);
            this.categoryButton.TabIndex = 0;
            this.categoryButton.Text = "Category Setup";
            this.categoryButton.UseVisualStyleBackColor = true;
            this.categoryButton.Click += new System.EventHandler(this.categoryButton_Click);
            // 
            // productButton
            // 
            this.productButton.Location = new System.Drawing.Point(246, 51);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(154, 23);
            this.productButton.TabIndex = 0;
            this.productButton.Text = "Product Setup";
            this.productButton.UseVisualStyleBackColor = true;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(246, 80);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(154, 23);
            this.customerButton.TabIndex = 0;
            this.customerButton.Text = "Customer Setup";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // supplierButton
            // 
            this.supplierButton.Location = new System.Drawing.Point(246, 109);
            this.supplierButton.Name = "supplierButton";
            this.supplierButton.Size = new System.Drawing.Size(154, 23);
            this.supplierButton.TabIndex = 0;
            this.supplierButton.Text = "Supplier Setup";
            this.supplierButton.UseVisualStyleBackColor = true;
            this.supplierButton.Click += new System.EventHandler(this.supplierButton_Click);
            // 
            // salesButton
            // 
            this.salesButton.Location = new System.Drawing.Point(246, 167);
            this.salesButton.Name = "salesButton";
            this.salesButton.Size = new System.Drawing.Size(154, 23);
            this.salesButton.TabIndex = 0;
            this.salesButton.Text = "Sales Setup";
            this.salesButton.UseVisualStyleBackColor = true;
            this.salesButton.Click += new System.EventHandler(this.salesButton_Click);
            // 
            // purchaseButton
            // 
            this.purchaseButton.Location = new System.Drawing.Point(246, 138);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Size = new System.Drawing.Size(154, 23);
            this.purchaseButton.TabIndex = 0;
            this.purchaseButton.Text = "Purchase Setup";
            this.purchaseButton.UseVisualStyleBackColor = true;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButton_Click);
            // 
            // stockButton
            // 
            this.stockButton.Location = new System.Drawing.Point(246, 196);
            this.stockButton.Name = "stockButton";
            this.stockButton.Size = new System.Drawing.Size(154, 23);
            this.stockButton.TabIndex = 0;
            this.stockButton.Text = "Stock Setup";
            this.stockButton.UseVisualStyleBackColor = true;
            this.stockButton.Click += new System.EventHandler(this.stockButton_Click);
            // 
            // reportSalesButton
            // 
            this.reportSalesButton.Location = new System.Drawing.Point(246, 225);
            this.reportSalesButton.Name = "reportSalesButton";
            this.reportSalesButton.Size = new System.Drawing.Size(154, 23);
            this.reportSalesButton.TabIndex = 0;
            this.reportSalesButton.Text = "Report(On Sales)";
            this.reportSalesButton.UseVisualStyleBackColor = true;
            this.reportSalesButton.Click += new System.EventHandler(this.reportSalesButton_Click);
            // 
            // reportPurchaseButton
            // 
            this.reportPurchaseButton.Location = new System.Drawing.Point(246, 254);
            this.reportPurchaseButton.Name = "reportPurchaseButton";
            this.reportPurchaseButton.Size = new System.Drawing.Size(154, 23);
            this.reportPurchaseButton.TabIndex = 0;
            this.reportPurchaseButton.Text = "Report(On Purchase)";
            this.reportPurchaseButton.UseVisualStyleBackColor = true;
            this.reportPurchaseButton.Click += new System.EventHandler(this.reportPurchaseButton_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportPurchaseButton);
            this.Controls.Add(this.stockButton);
            this.Controls.Add(this.supplierButton);
            this.Controls.Add(this.purchaseButton);
            this.Controls.Add(this.reportSalesButton);
            this.Controls.Add(this.salesButton);
            this.Controls.Add(this.productButton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.categoryButton);
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Name = "Index";
            this.Text = "Index";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button categoryButton;
        private System.Windows.Forms.Button productButton;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button supplierButton;
        private System.Windows.Forms.Button salesButton;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.Button stockButton;
        private System.Windows.Forms.Button reportSalesButton;
        private System.Windows.Forms.Button reportPurchaseButton;
    }
}