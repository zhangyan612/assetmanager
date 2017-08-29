namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePosition : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Positions", "Weight", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Positions", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
