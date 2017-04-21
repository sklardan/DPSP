namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectDepartments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Department = c.Int(nullable: false),
                        Client = c.String(),
                        Manager = c.String(),
                        Employees = c.String(),
                        Introduction = c.String(),
                        Content = c.String(),
                        Conclusion = c.String(),
                        Budget = c.String(),
                        OpenDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(),
                        CreatedUtc = c.DateTime(nullable: false),
                        ModifiedUtc = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
