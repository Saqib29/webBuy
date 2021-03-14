using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webBuy.Models;
using webBuy.Repositories;

namespace webBuy.Controllers.Seller
{
    public class SellerController : Controller
    {
        UserRepository userRepository = new UserRepository();
        ShopRepository shopRepository = new ShopRepository();
        public ActionResult Index()
        {
            Session["shopProfile"] = shopRepository.GetShop((Session["userProfile"] as User).email.ToString());

            return View();
            //var t = shopRepository.GetShop((Session["userProfile"] as User).email.ToString());
            //return Content("");
        }
        [HttpGet]
        public ActionResult profileUpdate()
        {
            ViewBag.user = Session["userProfile"] as User;
            return View();
        }
        [HttpPost]
        public ActionResult profileUpdate(User user)
        {
            if (ModelState.IsValid)
            {
                User profile = userRepository.Get((Session["userProfile"] as User).userId);
                profile.name = user.name;
                profile.phone = user.phone;
                profile.address = user.address;
                profile.password = user.password;
                profile.confirmPassword = user.confirmPassword;
                Session["userProfile"] = profile;
                TempData["update-msg"] = "Profile Updated";
                userRepository.Update(profile);
                return RedirectToAction("Index");
            }
            ViewBag.user = Session["userProfile"] as User;
            return View("profileUpdate");
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.OldPassword == null || changePassword.NewPassword == null || changePassword.ConfirmNewPassword == null)
            {
                TempData["msg-type"] = "danger";
                TempData["msg"] = "All fields need to be filled";
            }
            else
            {
                User profile = userRepository.Get((Session["userProfile"] as User).userId);
                if (profile.password != changePassword.OldPassword)
                {
                    TempData["msg-type"] = "danger";
                    TempData["msg"] = "Old password does not match";
                }
                else
                {
                    if (changePassword.NewPassword != changePassword.ConfirmNewPassword)
                    {
                        TempData["msg-type"] = "danger";
                        TempData["msg"] = "New password & confirm new password is not matching";
                    }
                    else
                    {
                        //return Content(changePassword.NewPassword +" "+ changePassword.ConfirmNewPassword + " " + changePassword.OldPassword);
                        profile.password = changePassword.NewPassword;
                        profile.confirmPassword = changePassword.NewPassword;
                        userRepository.Update(profile);
                        Session["userProfile"] = profile;
                        TempData["msg-type"] = "success";
                        TempData["msg"] = "Password changed";
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}