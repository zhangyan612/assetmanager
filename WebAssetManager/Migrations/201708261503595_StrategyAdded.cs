namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrategyAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Positions");
            DropColumn("dbo.InvestmentAccounts", "UserId");
            DropColumn("dbo.Positions", "Id");

            RenameColumn(table: "dbo.Positions", name: "InvestmentAccount_Id", newName: "Account_Id");
            RenameColumn(table: "dbo.InvestmentAccounts", name: "Portfolio_PortfolioId", newName: "PortfolioId");
            RenameIndex(table: "dbo.InvestmentAccounts", name: "IX_Portfolio_PortfolioId", newName: "IX_PortfolioId");
            RenameIndex(table: "dbo.Positions", name: "IX_InvestmentAccount_Id", newName: "IX_Account_Id");
            AddColumn("dbo.InvestmentAccounts", "Balance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.InvestmentAccounts", "WebUrl", c => c.String());
            AddColumn("dbo.Positions", "PositionId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Positions", "StrategyId", c => c.Int());
            AlterColumn("dbo.InvestmentAccounts", "Returns", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CostPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CurrentGain", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "GainPercent", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "TotalValue", c => c.Int());
            AlterColumn("dbo.Positions", "CurrentPrice", c => c.Decimal(precision: 18, scale: 2));
            AddPrimaryKey("dbo.Positions", "PositionId");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "StrategyId");
            DropColumn("dbo.Positions", "PositionId");
            DropColumn("dbo.InvestmentAccounts", "WebUrl");
            DropColumn("dbo.InvestmentAccounts", "Balance");
            DropPrimaryKey("dbo.Positions");

            AddColumn("dbo.Positions", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.InvestmentAccounts", "UserId", c => c.String());
            AlterColumn("dbo.Positions", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "TotalValue", c => c.Int(nullable: false));
            AlterColumn("dbo.Positions", "GainPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CurrentGain", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvestmentAccounts", "Returns", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.Positions", "Id");
            RenameIndex(table: "dbo.Positions", name: "IX_Account_Id", newName: "IX_InvestmentAccount_Id");
            RenameIndex(table: "dbo.InvestmentAccounts", name: "IX_PortfolioId", newName: "IX_Portfolio_PortfolioId");
            RenameColumn(table: "dbo.InvestmentAccounts", name: "PortfolioId", newName: "Portfolio_PortfolioId");
            RenameColumn(table: "dbo.Positions", name: "Account_Id", newName: "InvestmentAccount_Id");
        }
    }
}
