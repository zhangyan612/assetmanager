namespace WebAssetManager.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAssetManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebAssetManager.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Run following command after model change
            //Add-Migration
            //Update-Database

            //var assets = new List<Portfolio>
            //{
            //    new Portfolio{ PortfolioId = Guid.NewGuid().ToString(), TotalReturn = 0.23M },
            //    new Portfolio{ PortfolioId = Guid.NewGuid().ToString(), TotalReturn = 0.23M },

            //};
            //assets.ForEach(s => context.Portfolios.Add(s));
            //context.SaveChanges();

        }
    }
}
