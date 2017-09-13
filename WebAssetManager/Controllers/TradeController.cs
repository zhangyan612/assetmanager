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
            var data = string.Join(";", symbol, price, amount);
            using (var redis = new RedisClient("123.206.205.245", 6379))
            {
                // automatic MULTI/EXEC pipeline: start a pipe that is also a MULTI/EXEC transaction
                //redis.StartPipeTransaction();
                //redis.Set(strategy, data);
                //redis.PSubscribe("*");
                redis.Publish(strategy, data);
                //object[] result = redis.EndPipe(); // transaction is EXEC'd automatically if DISCARD was not called first
                result = redis.GetAsync(strategy).Result;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}
