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
            AutomaticMigrationsEnabled = true;//�Զ�Ǩ��Ϊtrue
            AutomaticMigrationDataLossAllowed = true;//�������ݶ�ʧ,Ĭ������ʱû����һ��������һ��ʱ��ֻ�����/ɾ��ʵ����ʱ�Զ����ɣ��������ɾ����ʵ�����һ�����Ծͻ��׳��쳣��
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

            context.Courses.AddOrUpdate(c => c.CourseName, js, python, csharp);

            var ss = new Student() { StudentName = "˧˧" };
            var kk = new Student() { StudentName = "����" };
            var mm = new Student() { StudentName = "èè" };
            var noone = new Student() { StudentName = "noone" };

            context.Students.AddOrUpdate(student => student.StudentName, ss, kk, mm, noone);

            context.Users.AddOrUpdate(user);

            context.SaveChanges();
        }
    }
}
