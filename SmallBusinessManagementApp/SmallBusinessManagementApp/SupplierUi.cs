using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.BLL;
namespace SmallBusinessManagementApp
{
    public partial class SupplierUi : Form
    {
        int Id_value;
        SupplierManager _supplierManager = new SupplierManager();
        public SupplierUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code Should consists of 4 character");
                return;
            }
            supplier.Code = codeTextBox.Text;
            if (_supplierManager.IsCodeExists(supplier))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Cannot be Empty");
                return;
            }
            supplier.Name = nameTextBox.Text;

            if (String.IsNullOrEmpty(contactTextBox.Text)||contactTextBox.Text.Length!=11)
            {
                MessageBox.Show("contact should be of 11 character");
                return;
            }
            supplier.Contact = contactTextBox.Text;

            if (_supplierManager.IsContactExists(supplier))
            {
                MessageBox.Show(contactTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Cannot be Empty");
                return;
            }

            supplier.Email = emailTextBox.Text;
            if (_supplierManager.IsEmailExists(supplier))
            {
                MessageBox.Show(emailTextBox.Text + " Already Exists");
                return;
            }

            supplier.Address = addressTextBox.Text;
            supplier.Contact_Person = contactPersonTextBox.Text;

            if (_supplierManager.Add(supplier))
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Save Error");
            }
            showDataGridView.DataSource = _supplierManager.Display();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please input name to search");
            }
            supplier.Name = nameTextBox.Text;
            showDataGridView.DataSource = _supplierManager.Search(supplier);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.Id = Id_value;

            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code Should consists of 4 character");
                return;
            }

            supplier.Code = codeTextBox.Text;
            if (_supplierManager.UpdateIsCodeExists(supplier))
            {
                MessageBox.Show(codeTextBox.Text+" Already Exists");
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Cannot be Empty");
                return;
            }

            supplier.Name = nameTextBox.Text;
            supplier.Address = addressTextBox.Text;

            if (String.IsNullOrEmpty(contactTextBox.Text) || contactTextBox.Text.Length != 11)
            {
                MessageBox.Show("contact should be of 11 character");
                return;
            }

            supplier.Contact = contactTextBox.Text;
            if (_supplierManager.UpdateIsContactExists(supplier))
            {
                MessageBox.Show(contactTextBox.Text+" Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Cannot be Empty");
                return;
            }

            supplier.Email = emailTextBox.Text;
            if (_supplierManager.UpdateIsEmailExists(supplier))
            {
                MessageBox.Show(emailTextBox.Text+" Already Exists");
                return;
            }

            supplier.Contact_Person = contactPersonTextBox.Text;

            if (_supplierManager.Update(supplier))
            {
                MessageBox.Show("Data Updated Successfully");
            }
            else
            {
                MessageBox.Show("Update Error");
            }
            showDataGridView.DataSource = _supplierManager.Display();

        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataGridView.CurrentRow.Selected = true;
            Id_value = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            codeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            addressTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
            contactTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Contact"].FormattedValue.ToString();
            emailTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
            contactPersonTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Contact_Person"].FormattedValue.ToString();
        }

        private void SupplierUi_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _supplierManager.Display();
        }
    }
}
