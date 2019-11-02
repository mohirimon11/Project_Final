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
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();
        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }
        public DataTable Display()
        {
            return _productRepository.Display();
        }
        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }
        public DataTable CategoryCombo()
        {
            return _productRepository.CategoryCombo();
        }

        public bool IsNameExists(Product product)
        {
            return _productRepository.IsNameExists(product);
        }
        public bool IsCodeExists(Product product)
        {
            return _productRepository.IsCodeExists(product);
        }
        public bool UpdateIsNameExists(Product product)
        {
            return _productRepository.UpdateIsNameExists(product);
        }
        public bool UpdateIsCodeExists(Product product)
        {
            return _productRepository.UpdateIsCodeExists(product);
        }


    }
}
