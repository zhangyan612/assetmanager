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
    public class PositionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Positions
        public ActionResult Index()
        {
            string userId = ViewBag.UserId;
            var positions = db.Positions.Include(p => p.Account).Include(p => p.Strategy).Where(a=> a.UserId == userId);
            return View(positions.ToList());
        }

        // GET: Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            if (position.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            string userId = ViewBag.UserId;
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == userId), "Id", "AccountName");
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == userId), "StrategyId", "Name");
            return View();
        }

        // POST: Positions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,AccountId,StrategyId,StockName,Symbol,Description,HoldingAmount,SellableAmount,CostPrice,CurrentPrice,Weight,FundNumber")] Position position)
        {
            position.UserId = ViewBag.UserId;
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == position.UserId), "Id", "AccountName", position.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == position.UserId), "StrategyId", "Name", position.StrategyId);
            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            if (position.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == position.UserId), "Id", "AccountName", position.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == position.UserId), "StrategyId", "Name", position.StrategyId);
            return View(position);
        }

        // POST: Positions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,AccountId,StrategyId,StockName,Symbol,Description,HoldingAmount,SellableAmount,CostPrice,CurrentPrice,Weight,FundNumber")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (position.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            ViewBag.AccountId = new SelectList(db.InvestmentAccounts.Where(a => a.UserId == position.UserId), "Id", "AccountName", position.AccountId);
            ViewBag.StrategyId = new SelectList(db.Strategies.Where(a => a.UserId == position.UserId), "StrategyId", "Name", position.StrategyId);
            return View(position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            if (position.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);
            if (position.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            db.Positions.Remove(position);
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
