namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignedUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProject", "ProjectRefId", "dbo.Projects");
            DropForeignKey("dbo.UserProject", "UserRefId", "dbo.Users");
            DropIndex("dbo.UserProject", new[] { "ProjectRefId" });
            DropIndex("dbo.UserProject", new[] { "UserRefId" });
            CreateTable(
                "dbo.AssignedUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedUtc = c.DateTime(nullable: false),
                        ModifiedUtc = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsActive = c.Boolean(nullable: false),
                        Project_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            AddColumn("dbo.Projects", "User_Id", c => c.Guid());
            CreateIndex("dbo.Projects", "User_Id");
            AddForeignKey("dbo.Projects", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Roles", "Name");
            DropTable("dbo.UserProject");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProject",
                c => new
                    {
                        ProjectRefId = c.Guid(nullable: false),
                        UserRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectRefId, t.UserRefId });
            
            AddColumn("dbo.Roles", "Name", c => c.String());
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AssignedUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.AssignedUsers", new[] { "Project_Id" });
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropColumn("dbo.Projects", "User_Id");
            DropTable("dbo.AssignedUsers");
            CreateIndex("dbo.UserProject", "UserRefId");
            CreateIndex("dbo.UserProject", "ProjectRefId");
            AddForeignKey("dbo.UserProject", "UserRefId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProject", "ProjectRefId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
