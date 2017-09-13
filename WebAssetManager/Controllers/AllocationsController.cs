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
            string UserId = ViewBag.UserId;
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == UserId), "Id", "AccountName");
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == UserId), "StrategyId", "Name");
            return View();
        }

        // POST: Allocations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StrategyId,AccountId,Amount")] Allocation allocation)
        {
            string UserId = ViewBag.UserId;
            if (ModelState.IsValid)
            {
                db.Allocations.Add(allocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == UserId), "Id", "AccountName", allocation.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == UserId), "StrategyId", "Name", allocation.StrategyId);
            return View(allocation);
        }

        // GET: Allocations/Edit/5
        public ActionResult Edit(int? id)
        {
            string UserId = ViewBag.UserId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocation allocation = db.Allocations.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == UserId), "Id", "AccountName", allocation.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == UserId), "StrategyId", "Name", allocation.StrategyId);
            return View(allocation);
        }

        // POST: Allocations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StrategyId,AccountId,Amount")] Allocation allocation)
        {
            string UserId = ViewBag.UserId;
            if (ModelState.IsValid)
            {
                db.Entry(allocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == UserId), "Id", "AccountName", allocation.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == UserId), "StrategyId", "Name", allocation.StrategyId);
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
