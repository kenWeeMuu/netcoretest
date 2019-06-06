using System.Collections.Generic;

namespace ef_training_console.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        /// <summary>
        /// 一个学生也可以参加很多门课程
        /// </summary>
        public ICollection<Course> Courses { get; set; }
    }
}