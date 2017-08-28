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
    public class StrategiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Strategies
        public ActionResult Index()
        {
            return View(db.Strategies.ToList());
        }

        // GET: Strategies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strategy strategy = db.Strategies.Find(id);
            if (strategy == null)
            {
                return HttpNotFound();
            }
            return View(strategy);
        }

        // GET: Strategies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Strategies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StrategyId,Name,Url,Source,RequireLogin,LoginUserName,Password")] Strategy strategy)
        {
            if (ModelState.IsValid)
            {
                db.Strategies.Add(strategy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strategy);
        }

        // GET: Strategies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strategy strategy = db.Strategies.Find(id);
            if (strategy == null)
            {
                return HttpNotFound();
            }
            return View(strategy);
        }

        // POST: Strategies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StrategyId,Name,Url,Source,RequireLogin,LoginUserName,Password")] Strategy strategy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strategy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strategy);
        }

        // GET: Strategies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strategy strategy = db.Strategies.Find(id);
            if (strategy == null)
            {
                return HttpNotFound();
            }
            return View(strategy);
        }

        // POST: Strategies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strategy strategy = db.Strategies.Find(id);
            db.Strategies.Remove(strategy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
