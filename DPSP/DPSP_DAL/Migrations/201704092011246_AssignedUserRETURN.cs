namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignedUserRETURN : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignedUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropIndex("dbo.AssignedUsers", new[] { "Project_Id" });
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        Project_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.User_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Projects", "User_Id");
            DropTable("dbo.AssignedUsers");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "User_Id", c => c.Guid());
            DropForeignKey("dbo.ProjectUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ProjectUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectUsers", new[] { "User_Id" });
            DropIndex("dbo.ProjectUsers", new[] { "Project_Id" });
            DropTable("dbo.ProjectUsers");
            CreateIndex("dbo.AssignedUsers", "Project_Id");
            CreateIndex("dbo.Projects", "User_Id");
            AddForeignKey("dbo.Projects", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.AssignedUsers", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
