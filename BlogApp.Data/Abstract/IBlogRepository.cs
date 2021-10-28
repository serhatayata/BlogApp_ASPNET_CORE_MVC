using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Abstract
{
    public interface IBlogRepository
    {
        Blog GetById(int blogID);
        IQueryable<Blog> GetAll();
        void AddBlog(Blog entity);
        void UpdateBlog(Blog entity);
        void DeleteBlog(int blogID);
    }
}
