using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Repository;
using SmallBusinessManagementApp.Model;

namespace SmallBusinessManagementApp.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public string LoadQuantity(Sales sales)
        {
            return _salesRepository.LoadQuantity(sales);
        }

        public string LoyaLityPoint(Customer customer)
        {
            return _salesRepository.LoyaLityPoint(customer);
        }

        public int PurchaseAdd(Sales sales)
        {
            return _salesRepository.PurchaseAdd(sales);
        }
        public DataTable LoadCustomerLoad()
        {
            return _salesRepository.LoadCustomerLoad();
        }
        public DataTable LoadCatagory()
        {
            return _salesRepository.LoadCatagory();
        }
        public DataTable LoadProduct(int Category_Id)
        {
            return _salesRepository.LoadProduct(Category_Id);
        }

        public string LoadQuantity(Purchase purchase)
        {
            return _salesRepository.LoadQuantity(purchase);
        }

        public string LoadMRP(Purchase purchase)
        {
            return _salesRepository.LoadMRP(purchase);
        }



    }
}
