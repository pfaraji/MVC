namespace EventHandlingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbmodel_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "personId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "personId");
        }
    }
}
