namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesAndGuids : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedUtc = c.DateTime(nullable: false),
                        ModifiedUtc = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Users", "CreatedUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedUtc", c => c.DateTime());
            AddColumn("dbo.Users", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            DropColumn("dbo.Users", "CreatedAt");
            DropColumn("dbo.Users", "UpdatedAt");
            DropTable("dbo.UserTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "Version");
            DropColumn("dbo.Users", "ModifiedUtc");
            DropColumn("dbo.Users", "CreatedUtc");
            DropTable("dbo.UserToRoles");
            DropTable("dbo.Roles");
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
