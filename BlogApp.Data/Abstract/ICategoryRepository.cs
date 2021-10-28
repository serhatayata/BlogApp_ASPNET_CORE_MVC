using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Abstract
{
    public interface ICategoryRepository
    {
        Category GetById(int categoryID);
        IQueryable<Category> GetAll();
        void AddCategory(Category entity);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryID);
    }
}
