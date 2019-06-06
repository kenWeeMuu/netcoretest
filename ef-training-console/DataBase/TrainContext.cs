using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ef_training_console.Migrations;
using ef_training_console.Models;

namespace ef_training_console.DataBase
{
    public class TrainContext : DbContext
    {
        public TrainContext() : base(
            @"Data Source=SC-201810210901\SQLEXPRESS;Initial Catalog=ef_training_console.DataBase.TrainContext;Integrated Security=True")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrainContext, Configuration>());

        }
       
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
