using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBuy.Models;
using webBuy.Repositories;

namespace webBuy.Controllers.Seller
{
    public class ShopController : Controller
    {
        ShopRepository shopRepository = new ShopRepository();
        public ActionResult Create()
        {
            if(Session["shopProfile"] == null)
            {
                ViewBag.email = (Session["userProfile"] as User).email;
                return View();
            }

            TempData["msg"] = "Already A Shop Exists under this user";
            return RedirectToAction("Index", "Seller");
        }
        [HttpPost]
        public ActionResult Create(Shop shop)
        {
            if (ModelState.IsValid)
            {
                shopRepository.Insert(shop);
                return RedirectToAction("Index", "Seller");
            }
            ViewBag.email = (Session["userProfile"] as User).email;
            return View();
        }

        [HttpGet]
        public ActionResult UpdateShop()
        {
            if(Session["shopProfile"] == null)
            {
                TempData["msg"] = "No shop to update! First create Shop";
                return RedirectToAction("Index", "Seller");
            }
            ViewBag.shop = Session["shopProfile"];
            return View();
        }
        [HttpPost]
        public ActionResult UpdateShop(Shop shop)
        {
            if (shop.shopStatus == null)
            {
                TempData["msg"] = "Your shop must need to be activated by an Admin";
                return RedirectToAction("Index", "Seller");
            }
            if (ModelState.IsValid)
            {
                TempData["update-msg"] = "Updated Shop";
                shopRepository.Update(shop);
                return RedirectToAction("Index", "Seller");
            }
            ViewBag.shop = Session["shopProfile"];
            return View();
        }
    }
}