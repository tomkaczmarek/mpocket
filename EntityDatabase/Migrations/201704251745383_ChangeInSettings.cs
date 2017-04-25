namespace EntityDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInSettings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Settings_Id", "dbo.Settings");
            DropIndex("dbo.Users", new[] { "Settings_Id" });
            AddColumn("dbo.Settings", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Settings_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Settings_Id", c => c.Int());
            DropColumn("dbo.Settings", "UserId");
            CreateIndex("dbo.Users", "Settings_Id");
            AddForeignKey("dbo.Users", "Settings_Id", "dbo.Settings", "Id");
        }
    }
}
