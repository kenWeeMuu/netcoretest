namespace ef_training_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.SysRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RoleDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SysUserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SysUserID = c.Int(nullable: false),
                        SysRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysRoles", t => t.SysRoleID, cascadeDelete: true)
                .ForeignKey("dbo.SysUsers", t => t.SysUserID, cascadeDelete: true)
                .Index(t => t.SysUserID)
                .Index(t => t.SysRoleID);
            
            CreateTable(
                "dbo.SysUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysUserRoles", "SysUserID", "dbo.SysUsers");
            DropForeignKey("dbo.SysUserRoles", "SysRoleID", "dbo.SysRoles");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.SysUserRoles", new[] { "SysRoleID" });
            DropIndex("dbo.SysUserRoles", new[] { "SysUserID" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropTable("dbo.SysUsers");
            DropTable("dbo.SysUserRoles");
            DropTable("dbo.SysRoles");
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
