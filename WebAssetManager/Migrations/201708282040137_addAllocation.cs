namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAllocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StrategyName = c.String(),
                        StrategyId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvestmentAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvestmentAccounts", t => t.InvestmentAccount_Id)
                .ForeignKey("dbo.Strategies", t => t.StrategyId, cascadeDelete: true)
                .Index(t => t.StrategyId)
                .Index(t => t.InvestmentAccount_Id);
            
            CreateTable(
                "dbo.WatchLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(),
                        Symbol = c.String(),
                        Description = c.String(),
                        AccountId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvestmentAccounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchLists", "AccountId", "dbo.InvestmentAccounts");
            DropForeignKey("dbo.Allocations", "StrategyId", "dbo.Strategies");
            DropForeignKey("dbo.Allocations", "InvestmentAccount_Id", "dbo.InvestmentAccounts");
            DropIndex("dbo.WatchLists", new[] { "AccountId" });
            DropIndex("dbo.Allocations", new[] { "InvestmentAccount_Id" });
            DropIndex("dbo.Allocations", new[] { "StrategyId" });
            DropTable("dbo.WatchLists");
            DropTable("dbo.Allocations");
        }
    }
}
