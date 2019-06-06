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
                CourseName = "javascript ¿Î³Ì",

            };

            var python = new Course()
            {
                CourseName = "python ¿Î³Ì",

            };
            var csharp = new Course()
            {
                CourseName = "c# ¿Î³Ì",

            };

            db.Courses.AddOrUpdate(csharp);
            db.Courses.AddOrUpdate(python);
            db.Courses.AddOrUpdate(js);
            var ss = new Student() { StudentName = "Ë§Ë§" };
            var kk = new Student() { StudentName = "À¤À¤" };
            var mm = new Student() { StudentName = "Ã¨Ã¨" };

            db.Students.AddOrUpdate(ss);
            db.Students.AddOrUpdate(kk);
            db.Students.AddOrUpdate(mm);


            db.SaveChanges();
        }
    }
}
