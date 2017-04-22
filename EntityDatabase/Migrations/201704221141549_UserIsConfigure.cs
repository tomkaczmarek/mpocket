namespace EntityDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIsConfigure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsConfigure", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsConfigure");
        }
    }
}
