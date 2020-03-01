namespace WebApiMovieRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes(Name,DiscountRate) VALUES ('pay as you go', 0)  ");
            Sql("INSERT INTO MemberShipTypes(Name,DiscountRate) VALUES ('1 month',10) ");
            Sql("INSERT INTO MemberShipTypes(Name,DiscountRate) VALUES ('6 months' , 15) ");
            Sql("INSERT INTO MemberShipTypes(Name,DiscountRate) VALUES ('1 year ',25) ");
        }
        
        public override void Down()
        {
        }
    }
}
