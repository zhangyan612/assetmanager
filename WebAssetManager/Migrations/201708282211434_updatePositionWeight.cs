namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePositionWeight : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "AccountId", "dbo.InvestmentAccounts");
            DropIndex("dbo.Positions", new[] { "AccountId" });
            AddColumn("dbo.Positions", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Strategies", "InitialBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Positions", "AccountId", c => c.Int());
            CreateIndex("dbo.Positions", "AccountId");
            AddForeignKey("dbo.Positions", "AccountId", "dbo.InvestmentAccounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "AccountId", "dbo.InvestmentAccounts");
            DropIndex("dbo.Positions", new[] { "AccountId" });
            AlterColumn("dbo.Positions", "AccountId", c => c.Int(nullable: false));
            DropColumn("dbo.Strategies", "InitialBalance");
            DropColumn("dbo.Positions", "Weight");
            CreateIndex("dbo.Positions", "AccountId");
            AddForeignKey("dbo.Positions", "AccountId", "dbo.InvestmentAccounts", "Id", cascadeDelete: true);
        }
    }
}
