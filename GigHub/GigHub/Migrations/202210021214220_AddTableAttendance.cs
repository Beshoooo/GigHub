namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        User_atttendee_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GigId, t.UserId })
                .ForeignKey("dbo.Gigs", t => t.GigId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_atttendee_Id)
                .Index(t => t.GigId)
                .Index(t => t.User_atttendee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "User_atttendee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            DropIndex("dbo.Attendances", new[] { "User_atttendee_Id" });
            DropIndex("dbo.Attendances", new[] { "GigId" });
            DropTable("dbo.Attendances");
        }
    }
}
