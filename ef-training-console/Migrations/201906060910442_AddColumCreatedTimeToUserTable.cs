namespace ef_training_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumCreatedTimeToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "CreatedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "CreatedTime");
        }
    }
}
