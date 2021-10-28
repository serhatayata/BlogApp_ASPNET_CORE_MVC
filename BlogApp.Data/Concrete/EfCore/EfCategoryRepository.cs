using BlogApp.Data.Abstract;
using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private BlogContext context;
        public EfCategoryRepository(BlogContext _context)
        {
            context = _context;
        }
        public void AddCategory(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryID)
        {
            var ct = context.Categories.FirstOrDefault(x=>x.CategoryID==categoryID);
            if (ct != null)
            {
                context.Categories.Remove(ct);
                context.SaveChanges();
            }
        }
        public IQueryable<Category> GetAll()
        {
            return context.Categories;
        }
        public Category GetById(int categoryID)
        {
            return context.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
        }

        public void UpdateCategory(Category category)
        {
            var _category = GetById(category.CategoryID);
            if (_category != null)
            {
                _category.Name = category.Name;
            }
            context.SaveChanges();
        }
    }
}
