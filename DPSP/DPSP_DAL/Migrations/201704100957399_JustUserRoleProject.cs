namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustUserRoleProject : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserProjects", newName: "ProjectUsers");
            DropForeignKey("dbo.UserToProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserToProjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserToRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserToProjects", new[] { "UserId" });
            DropIndex("dbo.UserToProjects", new[] { "ProjectId" });
            DropIndex("dbo.UserToRoles", new[] { "UserId" });
            DropIndex("dbo.UserToRoles", new[] { "RoleId" });
            DropPrimaryKey("dbo.ProjectUsers");
            AddPrimaryKey("dbo.ProjectUsers", new[] { "Project_Id", "User_Id" });
            DropTable("dbo.UserToProjects");
            DropTable("dbo.UserToRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserToRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTime(nullable: false),
                        ModifiedUtc = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserToProjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTime(nullable: false),
                        ModifiedUtc = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropPrimaryKey("dbo.ProjectUsers");
            AddPrimaryKey("dbo.ProjectUsers", new[] { "User_Id", "Project_Id" });
            CreateIndex("dbo.UserToRoles", "RoleId");
            CreateIndex("dbo.UserToRoles", "UserId");
            CreateIndex("dbo.UserToProjects", "ProjectId");
            CreateIndex("dbo.UserToProjects", "UserId");
            AddForeignKey("dbo.UserToRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserToRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserToProjects", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserToProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ProjectUsers", newName: "UserProjects");
        }
    }
}
