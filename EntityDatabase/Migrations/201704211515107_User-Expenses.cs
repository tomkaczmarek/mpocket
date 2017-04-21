namespace EntityDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserExpenses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Users_Id", c => c.Int());
            CreateIndex("dbo.Expenses", "Users_Id");
            AddForeignKey("dbo.Expenses", "Users_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Users_Id", "dbo.Users");
            DropIndex("dbo.Expenses", new[] { "Users_Id" });
            DropColumn("dbo.Expenses", "Users_Id");
        }
    }
}
