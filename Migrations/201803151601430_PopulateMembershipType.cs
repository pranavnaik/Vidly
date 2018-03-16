namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, 'A')");
            Sql("Insert into MembershipTypes (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (2, 30, 1, 10, 'A')");
            Sql("Insert into MembershipTypes (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (3, 90, 3, 15, 'A')");
            Sql("Insert into MembershipTypes (Id, SingUpFee, DurationInMonths, DiscountRate, Name) VALUES (4, 300, 12, 20, 'A')");
        }
        
        public override void Down()
        {
        }
    }
}
