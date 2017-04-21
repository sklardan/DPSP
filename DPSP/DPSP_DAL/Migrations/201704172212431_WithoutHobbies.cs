namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithoutHobbies : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Hobbies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        CreatedUtc = c.DateTime(nullable: false),
                        ModifiedUtc = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
