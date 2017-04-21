namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesWithDisplayName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Roles", "Enum", unique: true, name: "UX_Enum");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Roles", "UX_Enum");
            DropColumn("dbo.Roles", "Name");
        }
    }
}
