using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetCategories() => CategoryDAO.Instance.GetAllCategory();
        public Category? GetCategoryByID(int categoryID) => CategoryDAO.Instance.GetCategoryByID(categoryID);
    }
}
