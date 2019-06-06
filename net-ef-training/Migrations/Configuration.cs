using net_ef_training.Models;

namespace net_ef_training.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<net_ef_training.DataBase.TrainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(net_ef_training.DataBase.TrainContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var js = new Course()
            {
                CourseName = "javascript �γ�",

            };

            var python = new Course()
            {
                CourseName = "python �γ�",

            };
            var csharp = new Course()
            {
                CourseName = "c# �γ�",

            };

            db.Courses.AddOrUpdate(csharp);
            db.Courses.AddOrUpdate(python);
            db.Courses.AddOrUpdate(js);
            var ss = new Student() { StudentName = "˧˧" };
            var kk = new Student() { StudentName = "����" };
            var mm = new Student() { StudentName = "èè" };

            db.Students.AddOrUpdate(ss);
            db.Students.AddOrUpdate(kk);
            db.Students.AddOrUpdate(mm);


            db.SaveChanges();
        }
    }
}
