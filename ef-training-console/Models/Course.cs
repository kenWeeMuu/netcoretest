using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_training_console.Models
{

    /// <summary>
    /// 课程
    /// </summary>
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        /// <summary>
        /// 一门课程可以有很多个学生参与
        /// </summary>
        public ICollection<Student> Students { get; set; }
    }

 
}