using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.Repository;

namespace SmallBusinessManagementApp.BLL
{
    public class ReportOnSalesManager
    {
        ReportOnSalesRepository _reportOnSalesRepository = new ReportOnSalesRepository();

        public DataTable Search(Sales sales)
        {
            return _reportOnSalesRepository.Search(sales);
        }
    }
}
