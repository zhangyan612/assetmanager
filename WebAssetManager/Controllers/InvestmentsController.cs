using Microsoft.AspNet.Identity;
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
    public class InvestmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public InvestmentsController()
        //{
        //    UserId = User.Identity.GetUserId();
        //}
        // GET: Investments
        public ActionResult Index()
        {
            string UserId = ViewBag.UserId;
            var investmentAccounts = db.InvestmentAccounts.Include(i => i.Portfolio).Where(a => a.UserId == UserId);
            return View(investmentAccounts.ToList());
        }

        // GET: Investments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = db.InvestmentAccounts.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            if (investmentAccount.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            return View(investmentAccount);
        }

        // GET: Investments/Create
        public ActionResult Create()
        {
            string UserId = ViewBag.UserId;
            ViewBag.PortfolioId = new SelectList(db.Portfolios.Where(a => a.UserId == UserId), "PortfolioId", "Name");
            return View();
        }

        // POST: Investments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PortfolioId,AccountName,Type,Balance,Currency,WebUrl,Returns,UserName,Password")] InvestmentAccount investmentAccount)
        {
            if (ModelState.IsValid)
            {
                investmentAccount.UserId = ViewBag.UserId;
                db.InvestmentAccounts.Add(investmentAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PortfolioId = new SelectList(db.Portfolios.Where(a => a.UserId == investmentAccount.UserId), "PortfolioId", "Name", investmentAccount.PortfolioId);
            return View(investmentAccount);
        }

        // GET: Investments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = db.InvestmentAccounts.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            if (investmentAccount.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            ViewBag.PortfolioId = new SelectList(db.Portfolios.Where(a => a.UserId == investmentAccount.UserId), "PortfolioId", "Name", investmentAccount.PortfolioId);
            return View(investmentAccount);
        }

        // POST: Investments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PortfolioId,AccountName,Type,Balance,Currency,WebUrl,Returns,UserName,Password")] InvestmentAccount investmentAccount)
        {
            if (investmentAccount.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(investmentAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PortfolioId = new SelectList(db.Portfolios.Where(a => a.UserId == investmentAccount.UserId), "PortfolioId", "Name", investmentAccount.PortfolioId);
            return View(investmentAccount);
        }

        // GET: Investments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = db.InvestmentAccounts.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            if (investmentAccount.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            return View(investmentAccount);
        }

        // POST: Investments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentAccount investmentAccount = db.InvestmentAccounts.Find(id);
            if (investmentAccount.UserId != ViewBag.UserId)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            db.InvestmentAccounts.Remove(investmentAccount);
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
