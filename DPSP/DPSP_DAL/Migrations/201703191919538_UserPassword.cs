namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Salt", c => c.String());
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "Salt");
            DropColumn("dbo.Users", "Password");
        }
    }
}
