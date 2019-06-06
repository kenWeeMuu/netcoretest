using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using net_ef_training.Models;

namespace net_ef_training.DataBase
{
    public class TrainContext : DbContext
    {
//        public TrainContext() : base(
//            @"Data Source=SC-201810210901\SQLEXPRESS;Initial Catalog=ef_training_console.DataBase.TrainContext;Integrated Security=True")
//        {
//       
//
//        }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


    }
}
