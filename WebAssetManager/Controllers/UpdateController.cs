using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAssetManager.Models;

namespace WebAssetManager.Controllers
{
    public class UpdateController : Controller
    {
        // api for program to update position for specific strategy or account

        public ActionResult UpdateStrategy(string name, List<Position> positions)
        {

            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}
