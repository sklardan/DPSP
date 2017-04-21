namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnModelCreatingWihtICollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserProject",
                c => new
                    {
                        ProjectRefId = c.Guid(nullable: false),
                        UserRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectRefId, t.UserRefId })
                .ForeignKey("dbo.Projects", t => t.ProjectRefId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserRefId, cascadeDelete: true)
                .Index(t => t.ProjectRefId)
                .Index(t => t.UserRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProject", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.UserProject", "ProjectRefId", "dbo.Projects");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropIndex("dbo.UserProject", new[] { "UserRefId" });
            DropIndex("dbo.UserProject", new[] { "ProjectRefId" });
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropTable("dbo.UserProject");
            DropTable("dbo.RoleUsers");
        }
    }
}
