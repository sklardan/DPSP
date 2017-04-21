namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Token", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "FormatedPassword", c => c.String());
            AddColumn("dbo.Users", "Hash", c => c.String());
            AddColumn("dbo.Users", "Salt", c => c.String());
            AddColumn("dbo.Users", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Users", "Status", c => c.Int(nullable: false));
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
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "BirthDate");
            DropColumn("dbo.Users", "Salt");
            DropColumn("dbo.Users", "Hash");
            DropColumn("dbo.Users", "FormatedPassword");
            DropColumn("dbo.Users", "Token");
        }
    }
}
