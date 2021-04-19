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
        ProductRepository productRepository = new ProductRepository();
        private HttpPostedFileBase window;

        public List<Category> categories()
        {
            return categoryRepository.GetAll();
        }

        public ActionResult Index()
        {
            Session["products"] = productRepository.GetProducts((Session["shopProfile"] as Shop).shopId);
            if(Session["products"] == null)
            {
                TempData["msg"] = "You Have no products yet! Add some products.";
                return RedirectToAction("Index");
            }
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

                        productRepository.Insert(product);

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
            if(Session["categories"] == null)
            {
                Session["categories"] = categories();
            }
            ViewBag.categories = Session["categories"];
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
            Session["categories"] = ViewBag.categories;
            return View();
        }
        [HttpGet]
        public ActionResult ProductView(int id)
        {
            var product = productRepository.Get(id);

            if (Session["categories"] == null)
            {
                Session["categories"] = categories();
            }
            ViewBag.categories = Session["categories"];

            
            ViewBag.product = product;
            return View();
        }
        [HttpPost]
        public ActionResult ProductView(Product product)
        {
            product.productStatus = 1;
            product.shopId = (Session["shopProfile"] as Shop).shopId;

            if (ModelState.IsValid)
            {
                try
                {
                    if (product.productPicture.ContentLength > 0)
                    {
                        
                        string path = Path.Combine(Server.MapPath("~/Images/"), product.image);
                        product.productPicture.SaveAs(path);


                        productRepository.Update(product);
                        TempData["msg"] = "Product updated";
                        return RedirectToAction("ProductView");
                    }
                }
                catch
                {
                    product = productRepository.Get(product.productId);

                    if (Session["categories"] == null)
                    {
                        Session["categories"] = categories();
                    }
                    ViewBag.categories = Session["categories"];
                    ViewBag.product = product;
                    return View();
                }

                
            }

            var the_product = productRepository.Get(product.productId);

            if (Session["categories"] == null)
            {
                Session["categories"] = categories();
            }
            ViewBag.categories = Session["categories"];
            ViewBag.product = the_product;
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            productRepository.Delete(id);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult Sold()
        {
            return View();
        }
    }
}