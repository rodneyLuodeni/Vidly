namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenrePopulate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Horror')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Romantic')");
        }
        
        public override void Down()
        {
        }
    }
}
