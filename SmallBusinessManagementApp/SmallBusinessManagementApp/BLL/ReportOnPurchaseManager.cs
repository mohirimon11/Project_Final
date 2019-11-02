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
    public class ReportOnPurchaseManager
    {
        ReportOnPurchaseRepository _reportOnPurchaseRepository = new ReportOnPurchaseRepository();
        public DataTable Search(Purchase purchase)
        {
            return _reportOnPurchaseRepository.Search(purchase);


        }
    }
}
