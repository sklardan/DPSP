namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFormatedPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FormatedPassword", c => c.String());
            AddColumn("dbo.Users", "Hash", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "Hash");
            DropColumn("dbo.Users", "FormatedPassword");
        }
    }
}
