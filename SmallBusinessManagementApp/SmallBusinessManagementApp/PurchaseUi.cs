using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.BLL;

namespace SmallBusinessManagementApp
{
    public partial class PurchaseUi : Form
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        private Product product;
        private Purchase purchase;
        private List<Purchase> purchasesList;
        private DataTable dataTable;
        private int a = 0;
        private int PurchaseId;

        public PurchaseUi()
        {
            InitializeComponent();
            product = new Product();
            purchase = new Purchase();
            purchasesList = new List<Purchase>();

        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                purchase = new Purchase();
                //sales = new Sales();

                // stockOut.ItemID = _stockManager.LoadItemID(stock);

                purchase.Supplier_id = Convert.ToInt32(supplierComboBox.SelectedValue);
                purchase.InvoiceNo = invoiceNoTextBox.Text;
                purchase.Date1 = DateTime.Now;
                purchase.SupplierName = supplierComboBox.Text;
                purchase.Product_id = Convert.ToInt32(productsComboBox.SelectedValue);
                purchase.Purchase_Id = PurchaseId;
                purchase.ProuctCode = codeTextBox.Text;
                purchase.ProductName = productsComboBox.Text;
                purchase.Manufacture_Date = manufactureDateTimePicker.Value;
                purchase.Expire_Date = ExpireDateTimePicker.Value;
                purchase.Unit_Price = Convert.ToDouble(unitPriceTextBox.Text);
                purchase.Quantity = Convert.ToInt32(quantityTextBox.Text);
                purchase.TotalPrice = Convert.ToDouble(totalPriceTextBox.Text);
                purchase.MRP = Convert.ToDouble(mrpTextBox.Text);
                purchase.Remarks = remarksTextBox.Text;





                purchasesList.Add(purchase);
                showDataGridView.DataSource = null;
                showDataGridView.DataSource = purchasesList;


                foreach (DataGridViewRow row in showDataGridView.Rows)
                {
                    row.Cells["SL"].Value = (row.Index + 1).ToString();
                }
            }
            Reset();
        }

        private void Reset()
        {
            categoryComboBox.Text = "-setect-";
            productsComboBox.Text = "-select-";
            codeTextBox.Text = "<View>";
            quantityTextBox.Text = "";
            unitPriceTextBox.Text = "";
            totalPriceTextBox.Text = "<View>";
            previousUnitPriceTextBox.Text = "<view>";
            previousMRPTextBox.Text = "<View>";
            mrpTextBox.Text = "<View>";
            manufactureDateTimePicker.Value = DateTime.Now;
            ExpireDateTimePicker.Value = DateTime.Now;
            remarksTextBox.Text = "";
        }


        private void PurchaseUi_Load(object sender, EventArgs e)
        {
           
            categoryComboBox.DataSource = _purchaseManager.LoadCatagory();
            categoryComboBox.Text = "-select-";
            productsComboBox.Text = "-select-";
            supplierComboBox.DataSource = _purchaseManager.LoadSupplier();
            supplierComboBox.Text = "-select-";
            codeTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
            totalPriceTextBox.Text = "<View>";
            previousUnitPriceTextBox.Text = "<View>";
            previousMRPTextBox.Text = "<View>";


        }
        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadProductCode();
            //LoadQuantity();
            LoadPreviousPrice();
            LoadPreviousMrp();


        }
        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPurchaseId();
        }

        private void LoadPurchaseId()
        {
            purchase.SupplierName = supplierComboBox.Text;
            //int PurchaseId = 0;
            PurchaseId = Convert.ToInt32(_purchaseManager.LoadPurchaseId(purchase));
        }
        private void LoadProductCode()
        {
            //stock.ItemName = itemComboBox.Text;
            //reorderLevelTextBox.Text = _stockManager.LoadReorder(stock);
            product.Name = productsComboBox.Text;
            codeTextBox.Text = _purchaseManager.LoadProductCode(product);
        }
        //private void LoadQuantity()
        //{
        //    purchase.ProductName = productsComboBox.Text;
        //    availableQuantityTextBox.Text = "0";
        //    availableQuantityTextBox.Text = _purchaseManager.LoadQuantity(purchase);
        //}

        private void LoadPreviousPrice()
        {
            purchase.ProductName = productsComboBox.Text;
            previousUnitPriceTextBox.Text = "0";
            previousUnitPriceTextBox.Text = _purchaseManager.LoadPreviousPrice(purchase);
        }

        private void LoadPreviousMrp()
        {
            purchase.ProductName = productsComboBox.Text;
            previousMRPTextBox.Text = "0";
            previousMRPTextBox.Text = _purchaseManager.LoadPreviousMrp(purchase);


        }


        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsComboBox.DataSource = null;
            productsComboBox.DataSource = _purchaseManager.ProductLoad(Convert.ToInt32(categoryComboBox.SelectedValue));
            productsComboBox.DisplayMember = "Name";
            productsComboBox.ValueMember = "Id";
            productsComboBox.Text = "-select-";
            codeTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
            previousUnitPriceTextBox.Text = "<View>";
            previousMRPTextBox.Text = "<View>";



        }
        private bool IsFormValid()
        {
            //messageLabel.Text = "";

            if (supplierComboBox.Text.Equals("-Select-"))
            {
                
                MessageBox.Show("Select Supplier!");
                return false;
            }

            if (categoryComboBox.Text.Equals("-Select-"))
            {
                //messageLabel.Text = "Select category";
                MessageBox.Show("Select category!");
                return false;
            }

            if (productsComboBox.Text.Equals("-Select-"))
            {
                MessageBox.Show("Select Product!");
                return false;
            }

            if (quantityTextBox.Text == "")
            {
                MessageBox.Show("Pleae Insert Quantity!");
                return false;
            }

            if (unitPriceTextBox.Text == "")
            {
                MessageBox.Show("Please Insert Unit_Price");
                return false;
            }

           

            if (remarksTextBox.Text == "")
            {
                return false;
            }



            return true;
        }

        private void unitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(unitPriceTextBox.Text))
                {
                    //MessageBox.Show("Please Insert Unit Price!");
                    warningLabel.Text = "Please Insert Unit Price!";
                    return;
                }
                else
                {
                    //totalPriceTextBox.Data
                    double unitPrice = Convert.ToDouble(unitPriceTextBox.Text);
                    int quantity = Convert.ToInt32(quantityTextBox.Text);
                    totalPriceTextBox.Text = (unitPrice * quantity).ToString();
                    double totalPrice = Convert.ToDouble(totalPriceTextBox.Text);
                    double mrp1 = totalPrice * 25 / 100;
                    mrpTextBox.Text = Convert.ToString(mrp1 + totalPrice);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
               
            }
          
           
        }

        private void PurhaseAdd()
        {

        }

        private void Sell()
        {
            purchase = new Purchase();
            foreach (DataGridViewRow row in showDataGridView.Rows)
            {
                purchase.Purchase_Id = PurchaseId;
                purchase.Product_id = Convert.ToInt32(row.Cells["productidDataGridViewTextBoxColumn"].Value.ToString());
                purchase.Quantity = Convert.ToInt32(row.Cells["quantityDataGridViewTextBoxColumn"].Value.ToString());
                purchase.Date1 = DateTime.Now;
                purchase.Unit_Price = Convert.ToDouble(row.Cells["unitPriceDataGridViewTextBoxColumn"].Value.ToString());
                purchase.MRP = Convert.ToDouble(row.Cells["mRPDataGridViewTextBoxColumn"].Value.ToString());
                purchase.Remarks = row.Cells["remarksDataGridViewTextBoxColumn"].Value.ToString();
                purchase.Manufacture_Date = Convert.ToDateTime(row.Cells["manufactureDateDataGridViewTextBoxColumn"].Value.ToString());
                purchase.Expire_Date = Convert.ToDateTime(row.Cells["expireDateDataGridViewTextBoxColumn"].Value.ToString());
                //stockOut.Status = stock.Status;

                product.Id = purchase.Product_id;
               

                int isExecuted = 0;

                isExecuted = _purchaseManager.Sell(purchase);

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

            purchasesList = new List<Purchase>();
            showDataGridView.DataSource = null;
            showDataGridView.DataSource = purchasesList;
        }


        private void addPurchase()
        {
            purchase = new Purchase();
            
               // purchase.Date1 = Convert.ToDateTime(row.Cells["date1DataGridViewTextBoxColumn"].Value.ToString());
               purchase.Date1=DateTime.Now;
               a++;
               string text = "2019-00";
               string code = text + Convert.ToInt32(a);
               purchase.Code = code;
               purchase.InvoiceNo = invoiceNoTextBox.Text;
               purchase.Supplier_id = Convert.ToInt32(supplierComboBox.SelectedValue);
              // purchase.Code = row.Cells["codeDataGridViewTextBoxColumn"].Value.ToString();
               

                product.Id = purchase.Product_id;


                int isExecuted = 0;

                isExecuted = _purchaseManager.addPurchase(purchase);

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

        private void submitButton_Click_1(object sender, EventArgs e)
        {
            Sell();
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            addPurchase();

        }

       
    }
}
