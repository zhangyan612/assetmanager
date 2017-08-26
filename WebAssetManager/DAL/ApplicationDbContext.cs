using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAssetManager.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<InvestmentAccount> InvestmentAccounts { get; set; }
        public DbSet<Position> Positions { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}