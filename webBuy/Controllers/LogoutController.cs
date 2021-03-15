using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webBuy.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            Session["userProfile"] = null;
            Session["shopProfile"] = null;
            Session["products"]    = null;
            return RedirectToAction("Index","Login"); ;
        }
    }
}