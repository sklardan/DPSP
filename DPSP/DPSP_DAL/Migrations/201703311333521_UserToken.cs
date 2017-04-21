namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Token", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.Users", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "Token");
        }
    }
}
