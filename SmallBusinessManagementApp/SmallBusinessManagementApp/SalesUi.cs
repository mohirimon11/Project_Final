using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmallBusinessManagementApp.BLL;
using SmallBusinessManagementApp.Model;

namespace SmallBusinessManagementApp
{
    public partial class SalesUi : Form
    {
        SalesManager _salesManager = new SalesManager();
        private Sales sales;
        private Product product;
        private List<Sales> salesList;

        private Customer customer;
        private Purchase purchase;
        private int SalesId;
        private int CodeIncriment=0;
        private double g_Total;
        private double LPoint;
        private double discount;
        private double loyalityPoint;
        int purchaseQuantity;
        int salesQuantity;




        public SalesUi()
        {
            InitializeComponent();
            sales = new Sales();
            product = new Product();
            customer=new Customer();
            purchase=new Purchase();
            salesList = new List<Sales>();
        }
       

        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                
                sales =new Sales();


                sales.ProductName = productComboBox.Text;
                sales.Product_Id = Convert.ToInt32(productComboBox.SelectedValue);
                sales.Quantity = Convert.ToInt32(qualityTextBox.Text);
                sales.MRP = Convert.ToDouble(mrpTextBox.Text);
                sales.TotalMrp = Convert.ToDouble(totalMRPTextBox.Text);
                sales.CustomerName = customerComboBox.Text;
                sales.Date1=DateTime.Now;
                sales.Sales_Id = SalesId;
                sales.TotalMrp = Convert.ToDouble(totalMRPTextBox.Text);

                salesList.Add(sales);
                showDataGridView.DataSource = null;
                showDataGridView.DataSource = salesList;


                foreach (DataGridViewRow row in showDataGridView.Rows)
                {
                    row.Cells["SL"].Value = (row.Index + 1).ToString();
                }
                decimal Total = 0;

                for (int i = 0; i < showDataGridView.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(showDataGridView.Rows[i].Cells["totalMrpDataGridViewTextBoxColumn"].Value);
                }

                g_Total = Convert.ToDouble(Total);
                grandTotalTextBox.Text = g_Total.ToString();
                LPoint = g_Total / 1000;

                try
                {
                    if (String.IsNullOrEmpty(loyalityPointTextBox.Text))
                    {
                        MessageBox.Show("Select Customer first!");
                    }
                    else
                    {
                        discount = Convert.ToDouble(loyalityPointTextBox.Text) / 10;

                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

                int dis = Convert.ToInt32(discount);
                discountTextBox.Text = dis.ToString();
                discountAmounTextBox.Text = (g_Total * discount / 100).ToString();
                double c = Convert.ToDouble(loyalityPointTextBox.Text) - Convert.ToDouble(discountTextBox.Text);
                payableAmountTextBox.Text = (g_Total - Convert.ToDouble(discountAmounTextBox.Text)).ToString();
                loyalityPoint = LPoint + c;

            }

        }

        private void SalesUi_Load(object sender, EventArgs e)
        {
            //For Customer
            customerComboBox.DataSource = _salesManager.LoadCustomerLoad();
            customerComboBox.Text = "-select-";
            //For Category
            categoryComboBox.DataSource = _salesManager.LoadCatagory();
            categoryComboBox.Text = "-select-";
            //For Product
            productComboBox.Text = "-select-";
            loyalityPointTextBox.Text="<View>";

            availableQualityTextBox.Text = "<View>";
            totalMRPTextBox.Text = "<View>";
            grandTotalTextBox.Text = "<View>";
            discountTextBox.Text = "<View>";
            discountAmounTextBox.Text = "<View>";
            payableAmountTextBox.Text = "<View>";
            mrpTextBox.Text = "<View>";
            pTotalLable.Text = "";
            sTotalLable.Text = "";
            mrpTextBox.Text = "<View>";





        }
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addSale();
            LoyaLityPoint();
            LoadSaleId();
        }
        private void LoadSaleId()
        {
            sales.CustomerName = customerComboBox.Text;
            //int PurchaseId = 0;
            SalesId = Convert.ToInt32(_salesManager.LoadSalesId(sales));
        }
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productComboBox.DataSource = null;
            productComboBox.DataSource = _salesManager.LoadProduct(Convert.ToInt32(categoryComboBox.SelectedValue));
            productComboBox.DisplayMember = "Name";
            productComboBox.ValueMember = "Id";
            productComboBox.Text = "-select-";
            pTotalLable.Text = "";
            sTotalLable.Text = "";
            mrpTextBox.Text = "<View>";
            availableQualityTextBox.Text = "<View>";

        }
        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            LoadQuantity();
            try
            {
                if (String.IsNullOrEmpty(Convert.ToString(purchaseQuantity)))
                {

                }
                purchaseQuantity = Convert.ToInt32(pTotalLable.Text);

            }
            catch (Exception exception)
            {

            }
            try
            {
                if (String.IsNullOrEmpty(Convert.ToString(salesQuantity)))
                {

                }
                salesQuantity = Convert.ToInt32(sTotalLable.Text);

            }
            catch (Exception exception)
            {

            }


            int avalable = purchaseQuantity - salesQuantity;
            availableQualityTextBox.Text = Convert.ToString(avalable);

            LoaMRP();
        }

        int loypointTxt;
        private void LoyaLityPoint()
        {
            customer.Name = customerComboBox.Text;
            loyalityPointTextBox.Text = "0";
            try
            {
                loypointTxt = Convert.ToInt32(_salesManager.LoyaLityPoint(customer));

            }
            catch (Exception e)
            {
                
            }

            loyalityPointTextBox.Text = loypointTxt.ToString();
        }

        private void LoadQuantity()
        {
            sales.ProductName = productComboBox.Text;
            availableQualityTextBox.Text = "0";
            pTotalLable.Text = _salesManager.PurchaseQuantity(sales);
            sTotalLable.Text = _salesManager.saleQuantity(sales);

        }

        private void LoaMRP()
        {
            purchase.ProductName = productComboBox.Text;
            mrpTextBox.Text = "0";
            mrpTextBox.Text = _salesManager.LoadMRP(sales);
        }


        private bool IsFormValid()
        {
            //messageLabel.Text = "";

            if (customerComboBox.Text.Equals("-Select-"))
            {
                //messageLabel.Text = "Select company";
                return false;
            }

            if (categoryComboBox.Text.Equals("-Select-"))
            {
                //messageLabel.Text = "Select category";
                return false;
            }

            if (productComboBox.Text.Equals("-Select-"))
            {
                //messageLabel.Text = "Select item";
                return false;
            }

            if (qualityTextBox.Text == "")
            {
                return false;
            }


            if (String.IsNullOrEmpty(mrpTextBox.Text))
            {
                return false;
            }

            return true;
        }


        private void mrpTextBox_TextChanged(object sender, EventArgs e)
        {

            //totalPriceTextBox.Data
            

                   

                

        }

        private void qualityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(qualityTextBox.Text))
                {
                    MessageBox.Show("Insert Value!");
                }
                else
                {
                    double MRP = Convert.ToDouble(mrpTextBox.Text);
                    int Quantity = Convert.ToInt32(qualityTextBox.Text);
                    totalMRPTextBox.Text = (MRP * Quantity).ToString();
                    double TotalMRP = Convert.ToDouble(totalMRPTextBox.Text);
                   
                    
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           

        }

        private void loadTotalQuantityButton_Click(object sender, EventArgs e)
        {
            
           
        }
        private void addSale()
        {
            purchase = new Purchase();

            // purchase.Date1 = Convert.ToDateTime(row.Cells["date1DataGridViewTextBoxColumn"].Value.ToString());
            sales.Date1 = DateTime.Now;
            CodeIncriment = Convert.ToInt32(_salesManager.salesCode(sales));
            CodeIncriment++;
            //string text = "2019-";
            string code =CodeIncriment.ToString();
            sales.Code = code;
           // purchase.InvoiceNo = invoiceNoTextBox.Text;
           sales.Customer_Id = Convert.ToInt32(customerComboBox.SelectedValue);
           // purchase.Supplier_id = Convert.ToInt32(supplierComboBox.SelectedValue);
            // purchase.Code = row.Cells["codeDataGridViewTextBoxColumn"].Value.ToString();

            product.Id = sales.Product_Id;
            product.Id = purchase.Product_id;


            int isExecuted = 0;

            //isExecuted = _purchaseManager.addPurchase(purchase);
            isExecuted = _salesManager.addSale(sales);

            if (isExecuted > 0)
            {
                //messageLabel.Text = "Save Successful.";
                MessageBox.Show("Save Successful");
            }
            else
            {
                // messageLabel.Text = "Save Failed!";
                MessageBox.Show("Save Failed!");
            }

        }

        private void saleAddButton_Click(object sender, EventArgs e)
        {
            
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Sell();
        }
        private void Sell()
        {
           
            sales =new Sales();
            foreach (DataGridViewRow row in showDataGridView.Rows)
            {

                sales.Loyality_Point = loyalityPoint;
                sales.Sales_Id = SalesId;
                sales.CustomerName = customerComboBox.Text;
                sales.Product_Id = Convert.ToInt32(row.Cells["productIdDataGridViewTextBoxColumn"].Value.ToString());
                sales.Quantity = Convert.ToInt32(row.Cells["quantityDataGridViewTextBoxColumn"].Value.ToString());
                sales.MRP = Convert.ToInt32(row.Cells["mRPDataGridViewTextBoxColumn"].Value.ToString());
           
                product.Id = purchase.Product_id;


                int isExecuted = 0;

                isExecuted = _salesManager.Sell(sales);
                isExecuted = _salesManager.loyalityUpdate(sales);

                if (isExecuted > 0)
                {
                    //messageLabel.Text = "Save Successful.";
                    MessageBox.Show("Save Successful");
                }
                else
                {
                    // messageLabel.Text = "Save Failed!";
                    MessageBox.Show("Save Failed!");
                }
            }

            salesList = new List<Sales>();
            showDataGridView.DataSource = null;
            showDataGridView.DataSource = salesList;
        }

    }
}
