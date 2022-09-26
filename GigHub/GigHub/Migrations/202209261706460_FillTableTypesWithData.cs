namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillTableTypesWithData : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Types values('Jazz')");
            Sql("insert into Types values('Rock')");
            Sql("insert into Types values('Soul')");
            Sql("insert into Types values('Funk')");
            Sql("insert into Types values('Romantic')");
        }
        
        public override void Down()
        {
            Sql("delete from Types where Id in(1,2,3,4,5)");
        }
    }
}
