namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTrade : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Positions", "CurrentGain");
            DropColumn("dbo.Positions", "GainPercent");
            DropColumn("dbo.Positions", "TotalValue");

            AddColumn("dbo.Positions", "Description", c => c.String());
            AddColumn("dbo.Trades", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trades", "Description");
            DropColumn("dbo.Positions", "Description");

            AddColumn("dbo.Positions", "TotalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Positions", "GainPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Positions", "CurrentGain", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
