namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "Description");
            DropColumn("dbo.Addresses", "OpenningHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "OpenningHours", c => c.String());
            AddColumn("dbo.Addresses", "Description", c => c.String());
        }
    }
}
