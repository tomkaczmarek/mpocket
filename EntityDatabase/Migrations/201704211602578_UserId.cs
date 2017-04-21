namespace EntityDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "Users_Id", "dbo.Users");
            DropIndex("dbo.Expenses", new[] { "Users_Id" });
            AddColumn("dbo.Expenses", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Expenses", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "Users_Id", c => c.Int());
            DropColumn("dbo.Expenses", "UserId");
            CreateIndex("dbo.Expenses", "Users_Id");
            AddForeignKey("dbo.Expenses", "Users_Id", "dbo.Users", "Id");
        }
    }
}
