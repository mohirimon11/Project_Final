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
    public partial class ProductUi : Form
    {
        int Id_value;
        ProductManager _productManager = new ProductManager();
        
        public ProductUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code Should consists of 4 character");
                return;
            }
            product.Code = codeTextBox.Text;

            if (_productManager.IsCodeExists(product))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Product Name cannot be empty");
                return;
            }
            product.Name = nameTextBox.Text;
            if (_productManager.IsNameExists(product))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(reorderLevelTextBox.Text))
            {
                MessageBox.Show("Reorder level  cannot be empty");
                return;
            }
           
            
            product.Reorder_Level =Convert.ToInt32(reorderLevelTextBox.Text);

           
            product.Descriptions = descriptionRichTextBox.Text;

            product.Category_Id = Convert.ToInt32(categoryComboBox.SelectedValue);

            if (_productManager.Add(product))
            {
                MessageBox.Show("Data is saved");
            }
            else
            {
                MessageBox.Show("Save Error");
            }
            showDataGridView.DataSource = _productManager.Display();

        }

        private void ProductUi_Load(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = _productManager.CategoryCombo();
            showDataGridView.DataSource = _productManager.Display();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Id = Id_value;
            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code Should consists of 4 character");
                return;
            }
            product.Code = codeTextBox.Text;
            if (_productManager.UpdateIsCodeExists(product))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists");
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Product Name cannot be empty");
                return;
            }

            product.Name = nameTextBox.Text;

            if (_productManager.UpdateIsNameExists(product))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(reorderLevelTextBox.Text))
            {
                MessageBox.Show("Reorder level  cannot be empty");
                return;
            }

            product.Reorder_Level =Convert.ToInt32(reorderLevelTextBox.Text);
            product.Descriptions = descriptionRichTextBox.Text;

            product.Category_Id = Convert.ToInt32(categoryComboBox.SelectedValue);
            if (_productManager.Update(product))
            {
                MessageBox.Show("Data Updated");
            }
            else
            {
                MessageBox.Show("Update Error");
            }
            showDataGridView.DataSource = _productManager.Display();

        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            showDataGridView.CurrentRow.Selected = true;
            Id_value = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            codeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            reorderLevelTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Reorder_Level"].FormattedValue.ToString();
            descriptionRichTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Descriptions"].FormattedValue.ToString();
            categoryComboBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Category"].FormattedValue.ToString();
        }

       
    }
}
