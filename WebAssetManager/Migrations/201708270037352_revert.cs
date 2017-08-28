namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Positions", "Account_Id", "dbo.InvestmentAccounts");
            DropIndex("dbo.Positions", new[] { "Account_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Portfolio_PortfolioId" });
            RenameColumn(table: "dbo.Positions", name: "Account_Id", newName: "AccountId");
            CreateTable(
                "dbo.Strategies",
                c => new
                    {
                        StrategyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Source = c.Int(nullable: false),
                        RequireLogin = c.Boolean(),
                        LoginUserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StrategyId);
            
            AddColumn("dbo.AspNetUsers", "PortfolioId", c => c.String());
            AlterColumn("dbo.Positions", "StrategyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Positions", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Positions", "AccountId");
            CreateIndex("dbo.Positions", "StrategyId");
            AddForeignKey("dbo.Positions", "StrategyId", "dbo.Strategies", "StrategyId", cascadeDelete: true);
            AddForeignKey("dbo.Positions", "AccountId", "dbo.InvestmentAccounts", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "Portfolio_PortfolioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Portfolio_PortfolioId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Positions", "AccountId", "dbo.InvestmentAccounts");
            DropForeignKey("dbo.Positions", "StrategyId", "dbo.Strategies");
            DropIndex("dbo.Positions", new[] { "StrategyId" });
            DropIndex("dbo.Positions", new[] { "AccountId" });
            AlterColumn("dbo.Positions", "AccountId", c => c.Int());
            AlterColumn("dbo.Positions", "StrategyId", c => c.Int());
            DropColumn("dbo.AspNetUsers", "PortfolioId");
            DropTable("dbo.Strategies");
            RenameColumn(table: "dbo.Positions", name: "AccountId", newName: "Account_Id");
            CreateIndex("dbo.AspNetUsers", "Portfolio_PortfolioId");
            CreateIndex("dbo.Positions", "Account_Id");
            AddForeignKey("dbo.Positions", "Account_Id", "dbo.InvestmentAccounts", "Id");
            AddForeignKey("dbo.AspNetUsers", "Portfolio_PortfolioId", "dbo.Portfolios", "PortfolioId");
        }
    }
}
