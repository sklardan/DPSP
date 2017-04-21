namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserToRoleVirtualConnection : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserToProjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserToProjects", new[] { "ProjectId" });
            DropIndex("dbo.UserToProjects", new[] { "UserId" });
            DropTable("dbo.UserToProjects");
        }
    }
}
