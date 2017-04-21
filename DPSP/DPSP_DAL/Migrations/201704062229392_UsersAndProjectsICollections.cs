namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersAndProjectsICollections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Project_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Project_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "User_Id", "dbo.Users");
            DropIndex("dbo.UserProjects", new[] { "Project_Id" });
            DropIndex("dbo.UserProjects", new[] { "User_Id" });
            DropTable("dbo.UserProjects");
        }
    }
}
