using BlogApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            BlogContext context = app.ApplicationServices.GetRequiredService<BlogContext>();
            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category() { Name="Category1" },
                    new Category() { Name="Category2" },
                    new Category() { Name="Category3" }

                    );
                context.SaveChanges();
            }

            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Blog() { Title="Blog Title1", Description="Blog Desc1",Body="Blog Body1",Image="IMG1.JPG",AddedTime=DateTime.Now.AddDays(-5),isApproved=true,CategoryID=1}, new Blog() { Title = "Blog Title2", Description = "Blog Desc2", Body = "Blog Body1", Image = "IMG2.JPG", AddedTime = DateTime.Now.AddDays(-6), isApproved = true, CategoryID = 2 }, new Blog() { Title = "Blog Title3", Description = "Blog Desc3", Body = "Blog Body1", Image = "IMG3.JPG", AddedTime = DateTime.Now.AddDays(-7), isApproved = true, CategoryID = 3 }
                    );
                context.SaveChanges();
            }
            
        }
    }
}
