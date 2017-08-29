namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnrichStrategy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Strategies", "TotalReturn", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Strategies", "ExpectedAnnualReturn", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Strategies", "RebalancePeriod", c => c.Int(nullable: false));
            AddColumn("dbo.Strategies", "MaxDrawDown", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Strategies", "StockHolding", c => c.Int(nullable: false));
            AddColumn("dbo.Strategies", "BacktestStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Strategies", "BacktestEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Strategies", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Strategies", "Type");
            DropColumn("dbo.Strategies", "BacktestEnd");
            DropColumn("dbo.Strategies", "BacktestStart");
            DropColumn("dbo.Strategies", "StockHolding");
            DropColumn("dbo.Strategies", "MaxDrawDown");
            DropColumn("dbo.Strategies", "RebalancePeriod");
            DropColumn("dbo.Strategies", "ExpectedAnnualReturn");
            DropColumn("dbo.Strategies", "TotalReturn");
        }
    }
}
