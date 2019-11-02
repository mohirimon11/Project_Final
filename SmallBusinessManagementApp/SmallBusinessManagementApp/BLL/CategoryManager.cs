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
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }
        public DataTable Display()
        {
            return _categoryRepository.Display();
        }
        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
        public DataTable Search(Category category)
        {
            return _categoryRepository.Search(category);
        }
        public bool IsNameExists(Category category)
        {
            return _categoryRepository.IsNameExists(category);
        }
        public bool IsCodeExists(Category category)
        {
            return _categoryRepository.IsCodeExists(category);
        }
        public bool UpdateIsNameExists(Category category)
        {
            return _categoryRepository.UpdateIsNameExists(category);
        }
        public bool UpdateIsCodeExists(Category category)
        {
            return _categoryRepository.UpdateIsCodeExists(category);
        }
    }
}
