namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        StockName = c.String(),
                        EntryTime = c.DateTime(nullable: false),
                        EntryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Direction = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ExitTime = c.DateTime(nullable: false),
                        ExitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProfitLoss = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalFees = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MAE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MFE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Strategy_StrategyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Strategies", t => t.Strategy_StrategyId)
                .Index(t => t.Strategy_StrategyId);
            
            AddColumn("dbo.Strategies", "Description", c => c.String());
            AlterColumn("dbo.InvestmentAccounts", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CurrentGain", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "GainPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "TotalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.InvestmentAccounts", "Returns");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvestmentAccounts", "Returns", c => c.Decimal(precision: 18, scale: 2));
            DropForeignKey("dbo.Trades", "Strategy_StrategyId", "dbo.Strategies");
            DropIndex("dbo.Trades", new[] { "Strategy_StrategyId" });
            DropColumn("dbo.Strategies", "Description");
            DropTable("dbo.Trades");

            AlterColumn("dbo.Positions", "CurrentPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "TotalValue", c => c.Int());
            AlterColumn("dbo.Positions", "GainPercent", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CurrentGain", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "CostPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvestmentAccounts", "Balance", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
