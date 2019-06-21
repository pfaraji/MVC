namespace EventHandlingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee_prop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "EmpId", c => c.Int());
            AddColumn("dbo.People", "Gender", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Gender");
            DropColumn("dbo.People", "EmpId");
        }
    }
}
