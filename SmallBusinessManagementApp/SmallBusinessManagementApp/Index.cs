using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmallBusinessManagementApp
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

     

        private void categoryButton_Click(object sender, EventArgs e)
        {
            
            CategoryUi categoryUi = new CategoryUi();
            categoryUi.Tag = this;
            categoryUi.Show(this);
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            ProductUi productui = new ProductUi();
            productui.Tag = this;
            productui.Show(this);
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerUi customerUi = new CustomerUi();
            customerUi.Tag = this;
            customerUi.Show(this);
        }

        private void supplierButton_Click(object sender, EventArgs e)
        {
            SupplierUi supplierUi = new SupplierUi();
            supplierUi.Tag = this;
            supplierUi.Show(this);
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            PurchaseUi purchaseUi = new PurchaseUi();
            purchaseUi.Tag = this;
            purchaseUi.Show(this);
        }

        private void salesButton_Click(object sender, EventArgs e)
        {
            SalesUi salesUi = new SalesUi();
            salesUi.Tag = this;
            salesUi.Show(this);
        }

        private void stockButton_Click(object sender, EventArgs e)
        {
            StockUi stockUi = new StockUi();
            stockUi.Tag = this;
            stockUi.Show(this);
        }

        private void reportSalesButton_Click(object sender, EventArgs e)
        {
            ReportOnSalesUi reportOnSalesUi = new ReportOnSalesUi();
            reportOnSalesUi.Tag = this;
            reportOnSalesUi.Show(this);
        }

        private void reportPurchaseButton_Click(object sender, EventArgs e)
        {
            ReportOnPurchaseUi reportOnPurchaseUi = new ReportOnPurchaseUi();
            reportOnPurchaseUi.Tag = this;
            reportOnPurchaseUi.Show(this);
        }
    }
}
