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
        private Customer customer;
        private Purchase purchase;
        


        public SalesUi()
        {
            InitializeComponent();
            sales = new Sales();
            product = new Product();
            customer=new Customer();
            purchase=new Purchase();
        }
       

        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {

                int availableQuantity = Convert.ToInt32(availableQualityTextBox.Text);

                purchase.Quantity = Convert.ToInt32(qualityTextBox.Text);
                sales.Loyality_Point = Convert.ToInt32(loyalityPointTextBox.Text);
                sales.MRP = Convert.ToDouble(mrpTextBox.Text);

                //purchase.Supplier_id = Convert.ToInt32(supplierComboBox.SelectedValue);
                sales.Category_Id = Convert.ToInt32(categoryComboBox.SelectedValue);
                sales.Product_Id = Convert.ToInt32(productComboBox.SelectedValue);
                sales.Customer_Id = Convert.ToInt32(customerComboBox.SelectedValue);
                //purchase.Product_id = Convert.ToInt32(productsComboBox.SelectedValue);
                //purchase.InvoiceNo = invoiceNoTextBox.Text;
                //purchase.Date1 = DateTime.Now;
                //purchase.Manufacture_Date = manufactureDateTimePicker.Value;
                //purchase.Expire_Date = ExpireDateTimePicker.Value;
                //purchase.MRP = Convert.ToDouble(mrpTextBox.Text);
                //purchase.Remarks = remarksTextBox.Text;



                purchase.Quantity = availableQuantity - purchase.Quantity;
                sales.TotalMrp = purchase.Quantity * sales.MRP;
                sales.Date1 = DateTime.Now;


                //stock.Quantity = availableQuantity + stockInQuantity;
                //stock.Date = DateTime.Now;
                //stock.Status = "Stock In";

                try
                {


                    int isExecuted = _salesManager.PurchaseAdd(sales);
                    if (isExecuted > 0)
                    {
                        MessageBox.Show("Save Successful.");

                        //Reset();
                        //DisplayStock();
                    }
                    else
                    {
                        MessageBox.Show("Save Failed!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

            availableQualityTextBox.Text = "<View>";
            totalMRPTextBox.Text = "<View>";
            grandTotalTextBox.Text = "<View>";
            discountTextBox.Text = "<View>";
            discountAmounTextBox.Text = "<View>";
            payableAmountTextBox.Text = "<View>";
            mrpTextBox.Text = "<View>";





        }
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoyaLityPoint();
        }
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productComboBox.DataSource = null;
            productComboBox.DataSource = _salesManager.LoadProduct(Convert.ToInt32(categoryComboBox.SelectedValue));
            productComboBox.DisplayMember = "Name";
            productComboBox.ValueMember = "Id";
            productComboBox.Text = "-select-";

        }
        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadQuantity();
            LoaMRP();
        }


        private void LoyaLityPoint()
        {
            customer.Name = customerComboBox.Text;
            loyalityPointTextBox.Text = "0";
            loyalityPointTextBox.Text = _salesManager.LoyaLityPoint(customer);
        }

        private void LoadQuantity()
        {
            purchase.ProductName = productComboBox.Text;
            availableQualityTextBox.Text = "0";
            availableQualityTextBox.Text = _salesManager.LoadQuantity(purchase);
        }

        private void LoaMRP()
        {
            purchase.ProductName = productComboBox.Text;
            mrpTextBox.Text = "0";
            mrpTextBox.Text = _salesManager.LoadMRP(purchase);
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
                    grandTotalTextBox.Text = totalMRPTextBox.Text;
                    double grandTotal = Convert.ToDouble(grandTotalTextBox.Text);
                    discountTextBox.Text = (grandTotal / 1000).ToString();
                    double discount = Convert.ToDouble(discountTextBox.Text);
                    discountAmounTextBox.Text = (TotalMRP * discount / 100).ToString();
                    double DiscountAmount = Convert.ToDouble(discountAmounTextBox.Text);
                    payableAmountTextBox.Text = (TotalMRP - DiscountAmount).ToString();
                    
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           

        }
    }
}
