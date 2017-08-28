namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class portfolioUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvestmentAccounts", "Returns", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Portfolios", "Name", c => c.String());
            AddColumn("dbo.Portfolios", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolios", "CreatedDate");
            DropColumn("dbo.Portfolios", "Name");
            DropColumn("dbo.InvestmentAccounts", "Returns");
        }
    }
}
