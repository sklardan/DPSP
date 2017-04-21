namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesWithDisplayName2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Name");
        }
    }
}
