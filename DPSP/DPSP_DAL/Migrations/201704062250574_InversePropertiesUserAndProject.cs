namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InversePropertiesUserAndProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProjects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects");
            DropIndex("dbo.UserProjects", new[] { "User_Id" });
            DropIndex("dbo.UserProjects", new[] { "Project_Id" });
            DropTable("dbo.UserProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Project_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Project_Id });
            
            CreateIndex("dbo.UserProjects", "Project_Id");
            CreateIndex("dbo.UserProjects", "User_Id");
            AddForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProjects", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
