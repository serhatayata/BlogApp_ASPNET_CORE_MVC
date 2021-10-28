using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;
        public CategoryController(ICategoryRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(repository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.AddCategory(category);
                return RedirectToAction("List");
            }
            return View(category);
        }
    }
}
