namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Users", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
