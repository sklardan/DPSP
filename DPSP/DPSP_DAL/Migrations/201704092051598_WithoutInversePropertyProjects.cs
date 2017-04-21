namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithoutInversePropertyProjects : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectUsers", newName: "UserProjects");
            DropPrimaryKey("dbo.UserProjects");
            AddPrimaryKey("dbo.UserProjects", new[] { "User_Id", "Project_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserProjects");
            AddPrimaryKey("dbo.UserProjects", new[] { "Project_Id", "User_Id" });
            RenameTable(name: "dbo.UserProjects", newName: "ProjectUsers");
        }
    }
}
