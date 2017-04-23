namespace EntityDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsManual = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Settings_Id", c => c.Int());
            CreateIndex("dbo.Users", "Settings_Id");
            AddForeignKey("dbo.Users", "Settings_Id", "dbo.Settings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Settings_Id", "dbo.Settings");
            DropIndex("dbo.Users", new[] { "Settings_Id" });
            DropColumn("dbo.Users", "Settings_Id");
            DropTable("dbo.Settings");
        }
    }
}
