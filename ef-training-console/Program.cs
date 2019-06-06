using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ef_training_console.DataBase;
using ef_training_console.Models;

namespace ef_training_console
{
    static class Program
    {
        private static TrainContext db;

        public static void Main(string[] args)
        {
            db = new TrainContext();
            //设置课程和学生数据
            //  Course();
            setStudens();
            db.SaveChanges();
            queuryStudens("猫猫");
            queuryStudens("坤坤");

            Console.ReadKey();
        }


        #region mthods

        #region create blog

        private static void CreateBlog()
        {
            // Create and save a new Blog
            Console.Write("Enter a name for a new Blog: ");
            var name = Console.ReadLine();

            var blog = new Blog {Name = name};
            db.Blogs.Add(blog);
            db.SaveChanges();

            // Display all Blogs from the database
            var query = from b in db.Blogs
                orderby b.Name
                select b;

            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #endregion

        #region create many to many entitys

        private static void Course()
        {
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

            db.Courses.AddOrUpdate(c => c.CourseName, js, python, csharp);
            AddStudent();
            setStudens();
        }


        private static void AddStudent()
        {
            var ss = new Student() {StudentName = "帅帅"};
            var kk = new Student() {StudentName = "坤坤"};
            var mm = new Student() {StudentName = "猫猫"};

            db.Students.AddOrUpdate(student => student.StudentName, ss, kk, mm);
//            db.Students.AddOrUpdate(kk);
//            db.Students.AddOrUpdate(mm);
        }

        #endregion


        #region set Studens to Course

        private static void setStudens()
        {

            var student = db.Students.FirstOrDefault(s => s.StudentName == "坤坤");

            Console.WriteLine($"当前学生:{student?.StudentName},参加了{student.Courses?.Count}门课程");

            var courses = db.Courses.ToList();
            courses.ForEach(c => Console.WriteLine($"课程id：{c.CourseId}  ===  课程名称{c.CourseName}"));

            Console.Write("请输入想参加的课程Id");
            var courseIds = Console.ReadLine();
            string[] _ids = courseIds?.Split(',');
            student.Courses = new HashSet<Course>();
            var _courses = courses.Where(w => _ids.Contains(w.CourseId.ToString()));
            foreach (Course course in _courses) {

                student.Courses.Add(course);
            }
            db.SaveChanges();
            var stu = db.Students.FirstOrDefault(s => s.StudentName == "坤坤");
            Console.WriteLine($"当前学生:{stu?.StudentName},参加了{stu.Courses?.Count}门课程");
        }

        #endregion

        #region query  studens

        private static void queuryStudens(string name="坤坤")
        {
            var list = db.Students.Include(x => x.Courses).Where(w => w.StudentName == name).ToList();

            list.ForEach(s =>
            {
                if (s?.Courses != null)
                    foreach (Course objCourse in s.Courses) {
                        if (objCourse != null) {
                            Console.WriteLine($"学生{s.StudentName}参加了{objCourse.CourseName}");
                        }
                    }
            });
        }

        #endregion

        #endregion
    }
}