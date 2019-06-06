namespace ef_training_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAgeUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Age");
            DropColumn("dbo.User", "CreatedTime");
        }
    }
}
