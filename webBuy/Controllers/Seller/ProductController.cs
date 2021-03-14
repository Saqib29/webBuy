using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBuy.Repositories;

namespace webBuy.Controllers.Seller
{
    public class ProductController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SeeCategories()
        {
            
           ViewBag.categories = categoryRepository.GetAll();
            if(ViewBag.categories.Count == 0)
            {
                TempData["msg"] = "No categories";
                return View();
            }
            return View();
        }
    }
}