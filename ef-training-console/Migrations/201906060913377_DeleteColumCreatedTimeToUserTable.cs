namespace ef_training_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColumCreatedTimeToUserTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "CreatedTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "CreatedTime", c => c.DateTime(nullable: false));
        }
    }
}
