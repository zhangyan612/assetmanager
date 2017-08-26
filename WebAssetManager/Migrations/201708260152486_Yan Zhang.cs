namespace WebAssetManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YanZhang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateCreated");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
