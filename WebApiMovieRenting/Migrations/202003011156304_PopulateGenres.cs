namespace WebApiMovieRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(id,Name) VALUES (1,'Action') ");
            Sql("INSERT INTO Genres(id,Name) VALUES (2,'Comedy') ");
            Sql("INSERT INTO Genres(id,Name) VALUES (3,'Horror') ");
            Sql("INSERT INTO Genres(id,Name) VALUES (4,'Drama') ");
        }
        
        public override void Down()
        {
        }
    }
}
