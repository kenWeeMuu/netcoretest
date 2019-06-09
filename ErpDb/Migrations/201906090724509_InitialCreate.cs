namespace ErpDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        Alias = c.String(),
                        Icon = c.String(),
                        ParentId = c.Int(nullable: false),
                        ParentName = c.String(),
                        Level = c.Int(nullable: false),
                        Description = c.String(),
                        Sort = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        IsDefaultRouter = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedByUserName = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedByUserId = c.Int(nullable: false),
                        ModifiedByUserName = c.String(),
                        Component = c.String(maxLength: 255),
                        HideInMenu = c.Int(),
                        NotCache = c.Int(),
                        BeforeCloseFun = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        MenuGuid = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ActionCode = c.String(nullable: false),
                        Icon = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedByUserName = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedByUserId = c.Int(nullable: false),
                        ModifiedByUserName = c.String(),
                        Menu_MenuId = c.Int(),
                    })
                .PrimaryKey(t => t.PermissionId)
                .ForeignKey("dbo.Menu", t => t.Menu_MenuId)
                .Index(t => t.Menu_MenuId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedByUserName = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedByUserId = c.Int(nullable: false),
                        ModifiedByUserName = c.String(),
                        IsSuperAdministrator = c.Boolean(nullable: false),
                        IsBuiltin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginName = c.String(nullable: false),
                        DisplayName = c.String(),
                        Password = c.String(),
                        Avatar = c.String(),
                        UserType = c.Int(nullable: false),
                        IsLocked = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedByUserName = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedByUserId = c.Int(nullable: false),
                        ModifiedByUserName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.RolePermission",
                c => new
                    {
                        Role_RoleId = c.Int(nullable: false),
                        Permission_PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.Permission_PermissionId })
                .ForeignKey("dbo.Role", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.Permission_PermissionId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.Permission_PermissionId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Role_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Role_RoleId })
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Role_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RolePermission", "Permission_PermissionId", "dbo.Permission");
            DropForeignKey("dbo.RolePermission", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Permission", "Menu_MenuId", "dbo.Menu");
            DropIndex("dbo.UserRole", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRole", new[] { "User_UserId" });
            DropIndex("dbo.RolePermission", new[] { "Permission_PermissionId" });
            DropIndex("dbo.RolePermission", new[] { "Role_RoleId" });
            DropIndex("dbo.Permission", new[] { "Menu_MenuId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.RolePermission");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Permission");
            DropTable("dbo.Menu");
        }
    }
}
