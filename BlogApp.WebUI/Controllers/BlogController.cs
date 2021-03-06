using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;
        private ICategoryRepository _categoryRepository;
        public BlogController(IBlogRepository _blogRepo, ICategoryRepository _categoryRepo)
        {
            _blogRepository = _blogRepo;
            _categoryRepository = _categoryRepo;
        }
        public IActionResult Index(int? id, string q)
        {
            var query = _blogRepository.GetAll().Where(x => x.isApproved).OrderByDescending(x => x.AddedTime);
            if (id != null)
            {
                ViewBag.ChosenCategory = id;
                query = query.Where(a => a.CategoryID == id).OrderByDescending(x => x.AddedTime);
            }
            if (!string.IsNullOrEmpty(q))
            {
                //query = query.Where(x => x.Title.Contains(q) || x.Description.Contains(q) || x.Body.Contains(q)).OrderByDescending(x=>x.AddedTime);
                query = query.Where(x => EF.Functions.Like(x.Title, "%" + q + "%") || EF.Functions.Like(x.Description, "%" + q + "%") || EF.Functions.Like(x.Body, "%" + q + "%")).OrderByDescending(x => x.AddedTime);
            }
            return View(query);
        }
        public IActionResult Details(int id)
        {
            return View(_blogRepository.GetById(id));
        }
        public IActionResult List()
        {
            return View(_blogRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View(new Blog());
        }
        [HttpPost]
        public IActionResult Create(Blog entity)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.SaveBlog(entity);
                TempData["message"] = $"{entity.Title} başlıklı blog kayıt edildi.";
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View(_blogRepository.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Blog entity,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    entity.Image = file.FileName;
                }
                
                _blogRepository.SaveBlog(entity);
                TempData["message"] = $"{entity.Title} başlıklı kayıt güncellendi.";
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "CategoryID", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_blogRepository.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int blogID)
        {
            _blogRepository.DeleteBlog(blogID);
            TempData["message"] = $"{blogID} numaralı kayıt silindi.";
            return RedirectToAction("List");
        }
    }
}
