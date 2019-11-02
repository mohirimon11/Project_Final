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
    public partial class ReportOnSalesUi : Form
    {
        ReportOnSalesManager _reportOnSalesManager = new ReportOnSalesManager();
        public ReportOnSalesUi()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Date1 = startDateTimePicker.Value;
            sales.Date2 = endDateTimePicker.Value;

            showDataGridView.DataSource= _reportOnSalesManager.Search(sales);

        }
    }
}
