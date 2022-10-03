namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableFollowers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FollowerID = c.String(),
                        FolloweeID = c.String(),
                        UserFollowee_Id = c.String(maxLength: 128),
                        UserFollower_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserFollowee_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserFollower_Id)
                .Index(t => t.UserFollowee_Id)
                .Index(t => t.UserFollower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followers", "UserFollower_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "UserFollowee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followers", new[] { "UserFollower_Id" });
            DropIndex("dbo.Followers", new[] { "UserFollowee_Id" });
            DropTable("dbo.Followers");
        }
    }
}
