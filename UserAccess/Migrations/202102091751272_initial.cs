namespace UserAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.roles", "role", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.users", "uname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.users", "password", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "password", c => c.String(nullable: false));
            AlterColumn("dbo.users", "uname", c => c.String(nullable: false));
            AlterColumn("dbo.roles", "role", c => c.String(nullable: false));
        }
    }
}
