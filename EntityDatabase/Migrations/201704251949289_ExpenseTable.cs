namespace EntityDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Expenses", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "UserId", c => c.Int(nullable: false));
        }
    }
}
