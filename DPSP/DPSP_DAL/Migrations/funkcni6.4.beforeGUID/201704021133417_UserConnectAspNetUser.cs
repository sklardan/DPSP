namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserConnectAspNetUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            AddColumn("dbo.Users", "AspNetUsersId", c => c.String(maxLength: 50));
            CreateIndex("dbo.Users", "AspNetUsersId", unique: true);
            DropColumn("dbo.Users", "Token");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "FormatedPassword");
            DropColumn("dbo.Users", "Hash");
            DropColumn("dbo.Users", "Salt");
            DropColumn("dbo.Users", "BirthDate");
            DropColumn("dbo.Users", "UserType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserType_Id", c => c.Int());
            AddColumn("dbo.Users", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Users", "Salt", c => c.String());
            AddColumn("dbo.Users", "Hash", c => c.String());
            AddColumn("dbo.Users", "FormatedPassword", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Users", "Token", c => c.Guid(nullable: false));
            DropIndex("dbo.Users", new[] { "AspNetUsersId" });
            DropColumn("dbo.Users", "AspNetUsersId");
            CreateIndex("dbo.Users", "UserType_Id");
            CreateIndex("dbo.Users", "Email", unique: true);
            AddForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes", "Id");
        }
    }
}
