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
    public class AllocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Allocations
        public ActionResult Index()
        {
            var allocations = db.Allocations.Include(a => a.Account).Include(a => a.Strategy);
            return View(allocations.ToList());
        }

        // GET: Allocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocation allocation = db.Allocations.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        // GET: Allocations/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName");
            ViewBag.StrategyId = new SelectList(db.Strategies, "StrategyId", "Name");
            return View();
        }

        // POST: Allocations/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StrategyId,AccountId,Amount")] Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                db.Allocations.Add(allocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName", allocation.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies, "StrategyId", "Name", allocation.StrategyId);
            return View(allocation);
        }

        // GET: Allocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocation allocation = db.Allocations.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName", allocation.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies, "StrategyId", "Name", allocation.StrategyId);
            return View(allocation);
        }

        // POST: Allocations/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StrategyId,AccountId,Amount")] Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts, "Id", "AccountName", allocation.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies, "StrategyId", "Name", allocation.StrategyId);
            return View(allocation);
        }

        // GET: Allocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocation allocation = db.Allocations.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        // POST: Allocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allocation allocation = db.Allocations.Find(id);
            db.Allocations.Remove(allocation);
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
