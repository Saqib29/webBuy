﻿using System;
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
        withdrawRepository withdrawRepository = new withdrawRepository();
        ShopRepository shopRepository = new ShopRepository();
        ComissionRepository comissionRepository = new ComissionRepository();

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
        [HttpPost]
        public ActionResult withdraw(Withdraw withdraw)
        {
            withdraw.userId = (Session["userProfile"] as User).userId;
            withdraw.shopId = (Session["shopProfile"] as Shop).shopId;
            if(withdraw.amount == null)
            {
                TempData["empty"] = "Must insert amount";
                return RedirectToAction("withdraw");
            }
            else if(withdraw.amount < 20)
            {

                TempData["empty"] = "You don't have enought money to withdraw";
                return RedirectToAction("withdraw");
            }
            else if(withdraw.amount > (Session["shopProfile"] as Shop).balance)
            {

                TempData["empty"] = "Please write a valid amount";
                return RedirectToAction("withdraw");
            }

            var balance = (Session["shopProfile"] as Shop).balance - withdraw.amount;
            Shop shop = new Shop();
            shop = (Session["shopProfile"] as Shop);
            shop.balance = balance;

            //Comission set
            Comission comission = new Comission();
            comission.amount = withdraw.amount * (Convert.ToDouble((Session["shopProfile"] as Shop).setComission) / 100);
            comission.date = DateTime.Today.ToString();
            comission.shopId = (Session["shopProfile"] as Shop).shopId;

            comissionRepository.Insert(comission);

            //Update shop balance
            shopRepository.Update(shop);

            //insert withdraw history
            withdrawRepository.Insert(withdraw);

            TempData["withdraw"] = comission.amount + " Tk withdraw successfull";
            return RedirectToAction("withdraw");
        }
    }
}