using BusinessObjects.Entities;
using DataAccessObjects;
using DataAccessObjects.AppDbContext;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void ChangeStatus(Category category) => CategoryManagement.Instance.ChangeStatus(category);

        public void DeleteCategory(Category category) => CategoryManagement.Instance.Remove(category);

        public Category GetCategoryByID(int id) => CategoryManagement.Instance.GetCategoryById(id);

        public IEnumerable<Category> GetCategorys() => CategoryManagement.Instance.GetCategoryList();

        public void InsertCategory(Category category) => CategoryManagement.Instance.AddNew(category);

        public IEnumerable<Category> Search(string search) => CategoryManagement.Instance.Search(search);

        public void UpdateCategory(Category category) => CategoryManagement.Instance.Update(category);
    }
}
