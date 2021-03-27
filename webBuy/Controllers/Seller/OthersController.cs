using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBuy.Models;
using webBuy.Repositories;

namespace webBuy.Controllers.Seller
{
    public class OthersController : AuthenticationController
    {
        ProductRepository productRepository = new ProductRepository();

        public ActionResult Index()
        {
            if(Session["products"] == null)
            {
                Session["products"] = productRepository.GetProducts((Session["shopProfile"] as Shop).shopId);
            }
            ViewBag.Shop = Session["shopProfile"] as Shop;
            ViewBag.totalProducts = (Session["products"] as List<Product>).Count;
            return View();
        }
        [HttpGet]
        public ActionResult withdraw()
        {
            ViewBag.Shop = Session["shopProfile"] as Shop;
            return View();
        }
    }
}