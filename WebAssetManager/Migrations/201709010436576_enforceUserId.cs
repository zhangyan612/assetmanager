namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enforceUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvestmentAccounts", "UserId", c => c.String());
            AddColumn("dbo.Positions", "UserId", c => c.String());
            AddColumn("dbo.Strategies", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.WatchLists", "UserId", c => c.String());
            CreateIndex("dbo.Strategies", "UserId");
            AddForeignKey("dbo.Strategies", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Strategies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Strategies", new[] { "UserId" });
            DropColumn("dbo.WatchLists", "UserId");
            DropColumn("dbo.Strategies", "UserId");
            DropColumn("dbo.Positions", "UserId");
            DropColumn("dbo.InvestmentAccounts", "UserId");
        }
    }
}
