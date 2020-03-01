namespace WebApiMovieRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                        IsSubscribedToNewsFeed = c.Boolean(nullable: false),
                        MemberShipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberShipTypes", t => t.MemberShipTypeId, cascadeDelete: true)
                .Index(t => t.MemberShipTypeId);
            
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DiscountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            DropTable("dbo.MemberShipTypes");
            DropTable("dbo.Customers");
        }
    }
}
