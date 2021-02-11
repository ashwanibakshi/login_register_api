namespace UserAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.users", "password");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.users", "password", unique: true, name: "password");
        }
    }
}
