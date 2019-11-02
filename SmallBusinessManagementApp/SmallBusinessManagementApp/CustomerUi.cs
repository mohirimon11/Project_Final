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
    public partial class CustomerUi : Form
    {
        int Id_value;
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code Should consists of 4 character");
                return;
            }
            customer.Code = codeTextBox.Text;
            if (_customerManager.IsCodeExists(customer))
            {
                MessageBox.Show(codeTextBox.Text+" Already Exists");
                return;
            }
           
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Cannot be Empty");
                return;
            }
            customer.Name = nameTextBox.Text;

            if (String.IsNullOrEmpty(contactTextBox.Text)||contactTextBox.Text.Length!=11)
            {
                MessageBox.Show("contact should be of 11 character");
                return;
            }
            customer.Contact = contactTextBox.Text;

            if (_customerManager.IsContactExists(customer))
            {
                MessageBox.Show(contactTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Cannot be Empty");
                return;
            }
            customer.Email = emailTextBox.Text;
            if (_customerManager.IsEmailExists(customer))
            {
                MessageBox.Show(emailTextBox.Text + " Already Exists");
                return;
            }


            customer.Address = addressTextBox.Text;
            customer.Loyality_point = Convert.ToDouble(loyalityPointTextBox.Text);

            if (_customerManager.Add(customer))
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Save Error");
            }
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please input name to search");
                return;
            }
            customer.Name = nameTextBox.Text;
           showDataGridView.DataSource= _customerManager.Search(customer);
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
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Id = Id_value;
            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code Should consists of 4 character");
                return;
            }
            customer.Code = codeTextBox.Text;
            if (_customerManager.UpdateIsCodeExists(customer))
            {
                MessageBox.Show(codeTextBox.Text+" Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Cannot be Empty");
                return;
            }
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            if (String.IsNullOrEmpty(contactTextBox.Text)||contactTextBox.Text.Length!=11)
            {
                MessageBox.Show("contact should be of 11 character");
                return;
            }

            customer.Contact = contactTextBox.Text;
            if (_customerManager.UpdateIsCodeExists(customer))
            {
                MessageBox.Show(contactTextBox.Text+" Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Cannot be Empty");
                return;
            }
            customer.Email = emailTextBox.Text;
            if (_customerManager.UpdateIsCodeExists(customer))
            {
                MessageBox.Show(emailTextBox.Text+" Already Exists");
                return;
            }

            if (_customerManager.Update(customer))
            {
                MessageBox.Show("Data Updated Successfully");
            }
            else
            {
                MessageBox.Show("Update Error");
            }
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void CustomerUi_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();
        }
    }
}
