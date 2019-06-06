using ef_training_console.Models;

namespace ef_training_console.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ef_training_console.DataBase.TrainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//自动迁移为true
            AutomaticMigrationDataLossAllowed = true;//允许数据丢失,默认生成时没有这一项（不添加这一项时，只在添加/删除实体类时自动生成，如果我们删除了实体类的一个属性就会抛出异常）
        }

        protected override void Seed(ef_training_console.DataBase.TrainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var user = new User()
            {
                Age = 35, DisplayName = "caonimaseed", Username = "you dad"
            };

            var js = new Course()
            {
                CourseName = "javascript 课程",
            };

            var python = new Course()
            {
                CourseName = "python 课程",
            };
            var csharp = new Course()
            {
                CourseName = "c# 课程",
            };

            context.Courses.AddOrUpdate(c => c.CourseName, js, python, csharp);

            var ss = new Student() { StudentName = "帅帅" };
            var kk = new Student() { StudentName = "坤坤" };
            var mm = new Student() { StudentName = "猫猫" };
            var noone = new Student() { StudentName = "noone" };

            context.Students.AddOrUpdate(student => student.StudentName, ss, kk, mm, noone);

            context.Users.AddOrUpdate(user);

            context.SaveChanges();
        }
    }
}
