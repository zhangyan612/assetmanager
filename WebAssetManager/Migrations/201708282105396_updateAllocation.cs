namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAllocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allocations", "InvestmentAccount_Id", "dbo.InvestmentAccounts");
            DropIndex("dbo.Allocations", new[] { "InvestmentAccount_Id" });
            RenameColumn(table: "dbo.Allocations", name: "InvestmentAccount_Id", newName: "AccountId");
            AlterColumn("dbo.Allocations", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Allocations", "AccountId");
            AddForeignKey("dbo.Allocations", "AccountId", "dbo.InvestmentAccounts", "Id", cascadeDelete: true);
            DropColumn("dbo.Allocations", "StrategyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Allocations", "StrategyName", c => c.String());
            DropForeignKey("dbo.Allocations", "AccountId", "dbo.InvestmentAccounts");
            DropIndex("dbo.Allocations", new[] { "AccountId" });
            AlterColumn("dbo.Allocations", "AccountId", c => c.Int());
            RenameColumn(table: "dbo.Allocations", name: "AccountId", newName: "InvestmentAccount_Id");
            CreateIndex("dbo.Allocations", "InvestmentAccount_Id");
            AddForeignKey("dbo.Allocations", "InvestmentAccount_Id", "dbo.InvestmentAccounts", "Id");
        }
    }
}
