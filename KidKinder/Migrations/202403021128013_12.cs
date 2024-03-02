namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                    })
                .PrimaryKey(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parents");
        }
    }
}
