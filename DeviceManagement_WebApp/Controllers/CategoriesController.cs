using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;
using Microsoft.Extensions.Hosting;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {

       private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;   
        }

        //Get: all categories
        public ActionResult Index()
        {
            return View(_categoriesRepository.GetAll());
        }

        //Create new category
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            cat.CategoryId = Guid.NewGuid();
            cat.DateCreated = DateTime.Now;
            _categoriesRepository.Add(cat);
            return RedirectToAction("Index");
        }

        //Delete category
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            Category cat = _categoriesRepository.GetById(id);
          
                _categoriesRepository.Remove(cat);

            return RedirectToAction("Index");
        }
        //Category Details
        public ActionResult Details(Guid id)
        {
            Category cat = _categoriesRepository.GetById(id);
            return View(cat);
        }
        //Edit Existing Category
        public ActionResult Edit(Guid id)
        {
            Category cat = _categoriesRepository.GetById(id);
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            _categoriesRepository.Update(cat);
            return RedirectToAction("Index");

        }
    }
}
