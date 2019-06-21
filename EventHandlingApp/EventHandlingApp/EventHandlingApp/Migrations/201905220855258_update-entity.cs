namespace EventHandlingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        NationalCode = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventLocations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        size = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Rent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Time = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Participants = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReceptionPackages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Person_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Person_Id");
            AddForeignKey("dbo.AspNetUsers", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventLocations", "Id", "dbo.Events");
            DropForeignKey("dbo.ReceptionPackages", "Id", "dbo.Events");
            DropForeignKey("dbo.AspNetUsers", "Person_Id", "dbo.People");
            DropIndex("dbo.ReceptionPackages", new[] { "Id" });
            DropIndex("dbo.EventLocations", new[] { "Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Person_Id" });
            DropColumn("dbo.AspNetUsers", "Person_Id");
            DropTable("dbo.ReceptionPackages");
            DropTable("dbo.Events");
            DropTable("dbo.EventLocations");
            DropTable("dbo.People");
        }
    }
}
