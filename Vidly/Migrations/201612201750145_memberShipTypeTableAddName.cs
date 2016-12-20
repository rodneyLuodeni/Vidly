namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberShipTypeTableAddName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Pay as you go' WHERE id=1");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Monthly' WHERE id=2");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Weekly' WHERE id=3");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Annually' WHERE id=4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
