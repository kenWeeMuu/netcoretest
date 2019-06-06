namespace ef_training_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlAdd2Tables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Blogs", newName: "Blog");
            RenameTable(name: "dbo.Posts", newName: "Post");
            DropForeignKey("dbo.SysUserRoles", "SysRoleID", "dbo.SysRoles");
            DropForeignKey("dbo.SysUserRoles", "SysUserID", "dbo.SysUsers");
            DropIndex("dbo.SysUserRoles", new[] { "SysUserID" });
            DropIndex("dbo.SysUserRoles", new[] { "SysRoleID" });
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseId })
                .ForeignKey("dbo.Student", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_CourseId);
            
            AddColumn("dbo.Blog", "Url", c => c.String());
            DropTable("dbo.SysRoles");
            DropTable("dbo.SysUserRoles");
            DropTable("dbo.SysUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SysUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SysUserID = c.Int(nullable: false),
                        SysRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SysRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RoleDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.StudentCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Student_StudentId", "dbo.Student");
            DropIndex("dbo.StudentCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentCourse", new[] { "Student_StudentId" });
            DropColumn("dbo.Blog", "Url");
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
            CreateIndex("dbo.SysUserRoles", "SysRoleID");
            CreateIndex("dbo.SysUserRoles", "SysUserID");
            AddForeignKey("dbo.SysUserRoles", "SysUserID", "dbo.SysUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SysUserRoles", "SysRoleID", "dbo.SysRoles", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.Post", newName: "Posts");
            RenameTable(name: "dbo.Blog", newName: "Blogs");
        }
    }
}
