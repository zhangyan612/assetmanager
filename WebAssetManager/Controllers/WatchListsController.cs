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
            var watchLists = db.WatchLists.Include(w => w.Account);
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
            return View(watchList);
        }

        // GET: WatchLists/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName");
            return View();
        }

        // POST: WatchLists/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockName,Symbol,Description,AccountId")] WatchList watchList)
        {
            if (ModelState.IsValid)
            {
                watchList.CreatedDate = DateTime.Now;
                db.WatchLists.Add(watchList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName", watchList.AccountId);
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
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName", watchList.AccountId);
            return View(watchList);
        }

        // POST: WatchLists/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockName,Symbol,Description,AccountId,CreatedDate")] WatchList watchList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watchList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName", watchList.AccountId);
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
            return View(watchList);
        }

        // POST: WatchLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WatchList watchList = db.WatchLists.Find(id);
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
