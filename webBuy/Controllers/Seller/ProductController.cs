using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBuy.Models;
using webBuy.Repositories;

namespace webBuy.Controllers.Seller
{
    public class ProductController : AuthenticationController
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.shopId = (Session["shopProfile"] as Shop).shopId;
            ViewBag.categories = categoryRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.productStatus = 1;
            product.shopId = (Session["shopProfile"] as Shop).shopId;
            if (ModelState.IsValid)
            {
                try
                {
                    if(product.productPicture.ContentLength > 0)
                    {
                        string filename = Guid.NewGuid() + product.productPicture.FileName;
                        string path = Path.Combine(Server.MapPath("~/Images/"), filename);
                        product.productPicture.SaveAs(path);
                        product.image = filename;

                        TempData["succ-msg"] =  " Prosuct created success fully";
                        return RedirectToAction("Create");
                    }
                }
                catch
                {
                    TempData["msg"] = "File upload failed";
                    return RedirectToAction("Create", "Product");
                }
                return Content("It's Ok");
            }
            ViewBag.categories = categoryRepository.GetAll();
            ViewBag.shopId = (Session["shopProfile"] as Shop).shopId;
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