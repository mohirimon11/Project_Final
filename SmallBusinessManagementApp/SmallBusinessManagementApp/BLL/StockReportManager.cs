using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.Repository;

namespace SmallBusinessManagementApp.BLL
{
    public class StockReportManager
    {
        StockReportRepository _stockReportRepository = new StockReportRepository();
        public DataTable Search(Purchase purchase, Product product, Category category)
        {
            return _stockReportRepository.Search(purchase, product, category);
        }
    }
}
