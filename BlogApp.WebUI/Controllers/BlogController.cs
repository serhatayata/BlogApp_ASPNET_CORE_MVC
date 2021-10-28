using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        private ICategoryRepository _categoryRepository;
        public BlogController(IBlogRepository _blogRepo,ICategoryRepository _categoryRepo)
        {
            _blogRepository = _blogRepo;
            _categoryRepository = _categoryRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_blogRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            blog.AddedTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _blogRepository.AddBlog(blog);
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View(blog);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View(_blogRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.UpdateBlog(blog);
                TempData["message"] = $"{blog.Title} güncellendi.";
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View(blog);
        }

    }
}
