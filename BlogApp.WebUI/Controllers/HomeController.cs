using BlogApp.Data.Abstract;
using BlogApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepo;
        public HomeController(IBlogRepository repos)
        {
            blogRepo = repos;
        }
        public IActionResult Index()
        {
            var model = new HomeBlogModel();
            model.HomeBlogs = blogRepo.GetAll().Where(x => x.isApproved && x.isHome).ToList();
            model.SliderBlogs = blogRepo.GetAll().Where(x => x.isApproved && x.isSlider).ToList();
            return View(model);
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
