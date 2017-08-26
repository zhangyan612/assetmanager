namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvestmentAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        AccountName = c.String(),
                        Type = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Portfolio_PortfolioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_PortfolioId)
                .Index(t => t.Portfolio_PortfolioId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(),
                        Symbol = c.String(),
                        HoldingAmount = c.Int(nullable: false),
                        SellableAmount = c.Int(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentGain = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GainPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalValue = c.Int(nullable: false),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FundNumber = c.String(),
                        InvestmentAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvestmentAccounts", t => t.InvestmentAccount_Id)
                .Index(t => t.InvestmentAccount_Id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        TotalReturn = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PortfolioId);
            
            AddColumn("dbo.AspNetUsers", "Portfolio_PortfolioId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Portfolio_PortfolioId");
            AddForeignKey("dbo.AspNetUsers", "Portfolio_PortfolioId", "dbo.Portfolios", "PortfolioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.InvestmentAccounts", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Positions", "InvestmentAccount_Id", "dbo.InvestmentAccounts");
            DropIndex("dbo.AspNetUsers", new[] { "Portfolio_PortfolioId" });
            DropIndex("dbo.Positions", new[] { "InvestmentAccount_Id" });
            DropIndex("dbo.InvestmentAccounts", new[] { "Portfolio_PortfolioId" });
            DropColumn("dbo.AspNetUsers", "Portfolio_PortfolioId");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Positions");
            DropTable("dbo.InvestmentAccounts");
        }
    }
}
