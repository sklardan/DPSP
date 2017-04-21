namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Enum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Enum");
        }
    }
}
