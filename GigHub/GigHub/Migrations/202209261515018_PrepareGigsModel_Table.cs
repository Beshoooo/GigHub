namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrepareGigsModel_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datatime = c.DateTime(nullable: false),
                        Location = c.String(nullable: false, maxLength: 255),
                        Artist_Id = c.String(nullable: false, maxLength: 128),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Types");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropTable("dbo.Types");
            DropTable("dbo.Gigs");
        }
    }
}
