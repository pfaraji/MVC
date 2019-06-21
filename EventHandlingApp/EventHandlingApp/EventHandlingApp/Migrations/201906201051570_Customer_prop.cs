namespace EventHandlingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer_prop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "CustId", c => c.Int());
            AddColumn("dbo.People", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Phone");
            DropColumn("dbo.People", "CustId");
        }
    }
}
