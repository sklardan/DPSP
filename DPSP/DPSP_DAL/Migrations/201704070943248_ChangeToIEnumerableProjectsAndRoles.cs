namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToIEnumerableProjectsAndRoles : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.UserToRoles", "UserId");
            CreateIndex("dbo.UserToRoles", "RoleId");
            AddForeignKey("dbo.UserToRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserToRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserToRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserToRoles", new[] { "RoleId" });
            DropIndex("dbo.UserToRoles", new[] { "UserId" });
        }
    }
}
