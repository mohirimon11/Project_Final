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
       

        public string LoyaLityPoint(Customer customer)
        {
            return _salesRepository.LoyaLityPoint(customer);
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
        public string saleQuantity(Sales sales)
        {
            return _salesRepository.saleQuantity(sales);
        }
        public string PurchaseQuantity(Sales sales)
        {
            return _salesRepository.PurchaseQuantity(sales);
        }
        public string LoadMRP(Sales sales)
        {
            return _salesRepository.LoadMRP(sales);
        }
        public int addSale(Sales sales)
        {
            return _salesRepository.addSale(sales);
        }
        public string LoadSalesId(Sales sales)
        {
            return _salesRepository.LoadSalesId(sales);
        }
        public int Sell(Sales sales)
        {
            return _salesRepository.Sell(sales);
        }
        public int loyalityUpdate(Sales sales)
        {
            return _salesRepository.loyalityUpdate(sales);
        }
        public string salesCode(Sales sales)
        {
            return _salesRepository.salesCode(sales);
        }

    }
}
