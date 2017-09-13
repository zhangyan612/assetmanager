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
    [Authorize]
    public class WatchListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WatchLists
        public ActionResult Index()
        {
            string UserId = ViewBag.UserId;
            var watchLists = db.WatchLists.Include(w => w.Account).Where(a =>a.UserId == UserId);
            return View(watchLists.ToList());
        }

        // GET: WatchLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchList watchList = db.WatchLists.Find(id);
            if (watchList == null)
            {
                return HttpNotFound();
            }
            if (watchList.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            return View(watchList);
        }

        // GET: WatchLists/Create
        public ActionResult Create()
        {
            string UserId = ViewBag.UserId;

            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == UserId), "Id", "AccountName");
            return View();
        }

        // POST: WatchLists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockName,Symbol,Description,AccountId")] WatchList watchList)
        {
            watchList.UserId = ViewBag.UserId;
            if (ModelState.IsValid)
            {
                watchList.CreatedDate = DateTime.Now;
                db.WatchLists.Add(watchList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == watchList.UserId), "Id", "AccountName", watchList.AccountId);
            return View(watchList);
        }

        // GET: WatchLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchList watchList = db.WatchLists.Find(id);
            if (watchList == null)
            {
                return HttpNotFound();
            }
            if (watchList.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == watchList.UserId), "Id", "AccountName", watchList.AccountId);
            return View(watchList);
        }

        // POST: WatchLists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockName,Symbol,Description,AccountId,CreatedDate")] WatchList watchList)
        {
            if (watchList.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(watchList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == watchList.UserId), "Id", "AccountName", watchList.AccountId);
            return View(watchList);
        }

        // GET: WatchLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchList watchList = db.WatchLists.Find(id);
            if (watchList == null)
            {
                return HttpNotFound();
            }
            if (watchList.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            return View(watchList);
        }

        // POST: WatchLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WatchList watchList = db.WatchLists.Find(id);
            if (watchList.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            db.WatchLists.Remove(watchList);
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
