using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Model;
using SmallBusinessManagementApp.Repository;
using System.Data;

namespace SmallBusinessManagementApp.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }
        public DataTable Display()
        {
            return _customerRepository.Display();
        }
        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
        public DataTable Search(Customer customer)
        {
            return _customerRepository.Search(customer);
        }
        public bool IsContactExists(Customer customer)
        {
            return _customerRepository.IsContactExists(customer);
        }
        public bool IsCodeExists(Customer customer)
        {
            return _customerRepository.IsCodeExists(customer);
        }
        public bool IsEmailExists(Customer customer)
        {
            return _customerRepository.IsEmailExists(customer);
        }
        public bool UpdateIsContactExists(Customer customer)
        {
            return _customerRepository.UpdateIsContactExists(customer);
        }
        public bool UpdateIsCodeExists(Customer customer)
        {
            return _customerRepository.UpdateIsCodeExists(customer);
        }
        public bool UpdateIsEmailExists(Customer customer)
        {
            return _customerRepository.UpdateIsEmailExists(customer);
        }



    }
}
