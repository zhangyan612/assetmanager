using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

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
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Allocation> Allocations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        //    modelBuilder.Entity<Portfolio>().MapToStoredProcedures();
        //}

    }
}