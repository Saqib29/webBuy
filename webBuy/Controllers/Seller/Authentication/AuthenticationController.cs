using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webBuy.Controllers.Seller
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if(filterContext.HttpContext.Session["userProfile"] == null)
            {
                TempData["msg"] = "Please Login First";
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
        }
    }
}