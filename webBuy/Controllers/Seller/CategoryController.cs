using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBuy.Models;
using webBuy.Repositories;

namespace webBuy.Controllers.Seller
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            ViewBag.category =  categoryRepository.GetAll() as List<Category>;
            if(ViewBag.category.Count == 0)
            {
                TempData["msg"] = "No categories! please create category first";
                return RedirectToAction("Index", "Seller");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return Content("Category Create Page");
        }
    }
}