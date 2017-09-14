using CSRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;

namespace WebAssetManager.Controllers
{
    public class TradeController : Controller
    {
        public ActionResult Order(string key, string strategy, string symbol, string price, string amount)
        {
            if(key != "redis")
            {
                return Json("Bad request", JsonRequestBehavior.DenyGet);
            }
            string result = "";
            var data = string.Join(";", strategy, symbol, price, amount);
            using (var redis = new RedisClient("123.206.205.245", 6379))
            {
                redis.PublishAsync("Orders", data);
                result = redis.GetAsync(strategy).Result;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}
