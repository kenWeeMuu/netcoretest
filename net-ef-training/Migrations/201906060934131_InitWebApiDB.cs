namespace net_ef_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitWebApiDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blog", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
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
                "dbo.User",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Post", "BlogId", "dbo.Blog");
            DropIndex("dbo.StudentCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentCourse", new[] { "Student_StudentId" });
            DropIndex("dbo.Post", new[] { "BlogId" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.User");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
            DropTable("dbo.Post");
            DropTable("dbo.Blog");
        }
    }
}
