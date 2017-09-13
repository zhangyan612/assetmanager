using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAssetManager.Models;

namespace WebAssetManager
{
    public class GlobalUserFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (ApplicationDbContext storeDb = new ApplicationDbContext())
            {
                string CurrentUser = HttpContext.Current.User.Identity.GetUserId();

                filterContext.Controller.ViewBag.UserId = CurrentUser;
            }
        }
    }
}