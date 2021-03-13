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
        }

        public ActionResult profileUpdate()
        {
            return View();
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