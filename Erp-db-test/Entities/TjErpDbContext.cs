using Erp_db_test.Entities.Erp;
using Erp_db_test.Entities.QueryModels.DncPermission;

namespace Erp_db_test.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class TjErpDbContext : DbContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        public TjErpDbContext(DbContextOptions<TjErpDbContext> options) : base(options) {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Sleep> Sleeps { get; set; }
        public DbSet<Fuck> Fucks { get; set; }
        public DbSet<Ken> Kens { get; set; }
        public DbSet<TjCustomer> TjCustomer { get; set; }
        public DbSet<TjSku> TjSku { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<DncUser> DncUser { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<DncRole> DncRole { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<DncMenu> DncMenu { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public DbSet<DncIcon> DncIcon { get; set; }

        /// <summary>
        /// 用户-角色多对多映射
        /// </summary>
        public DbSet<DncUserRoleMapping> DncUserRoleMapping { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public DbSet<DncPermission> DncPermission { get; set; }

        /// <summary>
        /// 角色-权限多对多映射
        /// </summary>
        public DbSet<DncRolePermissionMapping> DncRolePermissionMapping { get; set; }

        #region DbQuery

        /// <summary>
        ///
        /// </summary>
        public DbQuery<DncPermissionWithAssignProperty> DncPermissionWithAssignProperty { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DbQuery<DncPermissionWithMenu> DncPermissionWithMenu { get; set; }

        #endregion DbQuery

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.Entity<DncUser>()
            //    .Property(x => x.Status);
            //modelBuilder.Entity<DncUser>()
            //    .Property(x => x.IsDeleted);
            //            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
            //
            //            foreach (var type in typesToRegister)
            //            {
            //                dynamic configurationInstance = Activator.CreateInstance(type);
            //                modelBuilder.ApplyConfiguration(configurationInstance);
            //            }

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.PostId,
                    x.TagId
                });

                entity
                    .HasOne(p => p.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(k => k.PostId)
                    .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

                entity
                    .HasOne(pt => pt.Tag)
                    .WithMany(t => t.PostTags)
                    .HasForeignKey(pt => pt.TagId)
                    .OnDelete(deleteBehavior: DeleteBehavior.Cascade); ;
            });
           

    


            modelBuilder.Entity<Ken>().ToTable("Ken");
            modelBuilder.Entity<Fuck>().ToTable("Fuck");
            
            modelBuilder.Entity<DncRole>(entity =>
            {
                entity.HasIndex(x => x.Code).IsUnique();

            });

            modelBuilder.Entity<DncMenu>(entity =>
            {
                
            });

            modelBuilder.Entity<DncUserRoleMapping>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.UserGuid,
                    x.RoleCode
                });

                entity.HasOne(x => x.DncUser)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.UserGuid)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DncRole)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.RoleCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DncPermission>(entity =>
            {
                entity.HasIndex(x => x.Code)
                    .IsUnique();

                entity.HasOne(x => x.Menu)
                    .WithMany(x => x.Permissions)
                    .HasForeignKey(x => x.MenuGuid);
            });

            modelBuilder.Entity<DncRolePermissionMapping>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.RoleCode,
                    x.PermissionCode
                });

                entity.HasOne(x => x.DncRole)
                    .WithMany(x => x.Permissions)
                    .HasForeignKey(x => x.RoleCode)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DncPermission)
                    .WithMany(x => x.Roles)
                    .HasForeignKey(x => x.PermissionCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}