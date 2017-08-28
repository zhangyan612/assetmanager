using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAssetManager.Models;

namespace WebAssetManager.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;

        public DashboardController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public DashboardController()
        {
        }


        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPortfolio()
        {
            var userId = User.Identity.GetUserId();

            var user = db.Users.Find(userId);

            //var user = UserManager.FindByIdAsync(userId).Result;
            var portfolio = user.PortfolioId;

            Portfolio UserPortfolio = new Portfolio();
            if (string.IsNullOrEmpty(portfolio))
            {
                // create a portfolio by default
                UserPortfolio.PortfolioId = Guid.NewGuid().ToString();
                UserPortfolio.Name = "My Portfolio";
                UserPortfolio.CreatedDate = DateTime.Now;
                UserPortfolio.UserId = userId;

                user.PortfolioId = UserPortfolio.PortfolioId;
                UserManager.UpdateAsync(user);
                db.Portfolios.Add(UserPortfolio);
                db.SaveChanges();
            }
            else
            {
                UserPortfolio = db.Portfolios.Find(portfolio);
                var accounts = from a in db.InvestmentAccounts
                               where a.PortfolioId == portfolio
                               select a;
                UserPortfolio.Accounts = accounts.ToList();
            }

            return Json(UserPortfolio, JsonRequestBehavior.AllowGet);
        }


    }
}