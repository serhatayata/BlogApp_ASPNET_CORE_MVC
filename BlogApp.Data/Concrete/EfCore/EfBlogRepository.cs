using BlogApp.Data.Abstract;
using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfBlogRepository : IBlogRepository
    {
        private BlogContext context;
        public EfBlogRepository(BlogContext _context)
        {
            context = _context;
        }
        public void AddBlog(Blog entity)
        {
            context.Blogs.Add(entity);
            context.SaveChanges();
        }

        public void DeleteBlog(int blogID)
        {
            var bl = context.Blogs.FirstOrDefault(x=>x.BlogID==blogID);
            if (bl != null)
            {
                context.Blogs.Remove(bl);
                context.SaveChanges();
            }
        }
        public IQueryable<Blog> GetAll()
        {
            return context.Blogs;
        }

        public Blog GetById(int blogID)
        {
            return context.Blogs.FirstOrDefault(x => x.BlogID == blogID);
        }

        public void SaveBlog(Blog entity)
        {
            if (entity.BlogID == 0)
            {
                entity.AddedTime = DateTime.Now;
                context.Blogs.Add(entity);
            }
            else
            {
                var _blog = GetById(entity.BlogID);
                if (_blog != null)
                {
                    _blog.Title = entity.Title;
                    _blog.Description = entity.Description;
                    _blog.CategoryID = entity.CategoryID;
                    _blog.Image = entity.Image;
                    _blog.isHome = entity.isHome;
                    _blog.isApproved = entity.isApproved;
                }
            }
            context.SaveChanges();
        }

        public void UpdateBlog(Blog entity)
        {
            var _blog = GetById(entity.BlogID);
            if (_blog != null)
            {
                _blog.Title = entity.Title;
                _blog.Description = entity.Description;
                _blog.CategoryID = entity.CategoryID;
                _blog.Image = entity.Image;

                context.SaveChanges();
            }
            context.SaveChanges();
        }
    }
}
