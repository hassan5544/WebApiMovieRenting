namespace WebApiMovieRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        customerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        RentDate = c.DateTime(nullable: false),
                        Statuas = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.customerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rents", "customerId", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "MovieId" });
            DropIndex("dbo.Rents", new[] { "customerId" });
            DropTable("dbo.Rents");
        }
    }
}
