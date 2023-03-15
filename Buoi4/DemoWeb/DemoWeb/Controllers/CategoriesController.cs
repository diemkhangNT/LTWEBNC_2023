using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoWeb.Models;

namespace DemoWeb.Controllers
{
    public class CategoriesController : Controller
    {
        DBSportStoreEntities database = new DBSportStoreEntities();
        // GET: Categories
        public ActionResult Index()
        {
            var categories = database.Categories.ToList();
            return View(categories);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                database.Categories.Add(category);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Lỗi tạo mới CATEGORY!");
            }
        }
    }
}