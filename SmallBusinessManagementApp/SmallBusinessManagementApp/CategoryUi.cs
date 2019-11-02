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
    public partial class CategoryUi : Form
    {
        int Id_value;
        CategoryManager _categoryManager = new CategoryManager();
        public CategoryUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code Should consists of 4 character");
                return;
            }
            category.Code = codeTextBox.Text;

            if (_categoryManager.IsCodeExists(category))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Product Name cannot be empty");
                return;
            }
            category.Name = nameTextBox.Text;
            if (_categoryManager.IsNameExists(category))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists");
                return;
            }
            if (_categoryManager.Add(category))
            {
                MessageBox.Show("Data is successfully Saved!");
            }
            else
            {
                MessageBox.Show("Save Error");
            }
            showDataGridView.DataSource = _categoryManager.Display();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Id = Id_value;
            if (String.IsNullOrEmpty(codeTextBox.Text) || codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Category Code Should consists of 4 character");
                return;
            }
            category.Code = codeTextBox.Text;
            if (_categoryManager.UpdateIsCodeExists(category))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Category Name Cannot be empty");
                return;
            }
            category.Name = nameTextBox.Text;
            if (_categoryManager.UpdateIsNameExists(category))
            {
                MessageBox.Show(nameTextBox.Text+" Already Exists");
                return;
            }

            if (_categoryManager.Update(category))
            {
                MessageBox.Show("Data is successfully Updated!");
            }
            else
            {
                MessageBox.Show("Update Error");
            }
            showDataGridView.DataSource = _categoryManager.Display();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please Enter the Name to search");
                return;  
            }

            category.Name = nameTextBox.Text;
            showDataGridView.DataSource = _categoryManager.Search(category);
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataGridView.CurrentRow.Selected = true;
            Id_value = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            codeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
        }

        private void CategoryUi_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _categoryManager.Display();

        }
    }
}
