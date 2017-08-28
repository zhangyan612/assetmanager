namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCurrency : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "StrategyId", "dbo.Strategies");
            DropIndex("dbo.Positions", new[] { "StrategyId" });
            AddColumn("dbo.InvestmentAccounts", "Currency", c => c.Int(nullable: false));
            AlterColumn("dbo.Positions", "StrategyId", c => c.Int());
            CreateIndex("dbo.Positions", "StrategyId");
            AddForeignKey("dbo.Positions", "StrategyId", "dbo.Strategies", "StrategyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "StrategyId", "dbo.Strategies");
            DropIndex("dbo.Positions", new[] { "StrategyId" });
            AlterColumn("dbo.Positions", "StrategyId", c => c.Int(nullable: false));
            DropColumn("dbo.InvestmentAccounts", "Currency");
            CreateIndex("dbo.Positions", "StrategyId");
            AddForeignKey("dbo.Positions", "StrategyId", "dbo.Strategies", "StrategyId", cascadeDelete: true);
        }
    }
}
