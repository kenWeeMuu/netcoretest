namespace CodeFirstExistingDatabaseSample
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ErpDbContext : DbContext
    {
        public ErpDbContext()
            : base("name=ErpConnection") {
        }

        public virtual DbSet<DncIcon> DncIcon { get; set; }
        public virtual DbSet<DncMenu> DncMenu { get; set; }
        public virtual DbSet<DncPermission> DncPermission { get; set; }
        public virtual DbSet<DncRole> DncRole { get; set; }
        public virtual DbSet<DncRolePermissionMapping> DncRolePermissionMapping { get; set; }
        public virtual DbSet<DncUser> DncUser { get; set; }
        public virtual DbSet<DncUserRoleMapping> DncUserRoleMapping { get; set; }
        public virtual DbSet<TjCustomer> TjCustomer { get; set; }
        public virtual DbSet<TjSku> TjSku { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<DncMenu>()
                .HasMany(e => e.DncPermission)
                .WithRequired(e => e.DncMenu)
                .HasForeignKey(e => e.MenuGuid);

            modelBuilder.Entity<DncPermission>()
                .HasMany(e => e.DncRolePermissionMapping)
                .WithRequired(e => e.DncPermission)
                .HasForeignKey(e => e.PermissionCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DncRole>()
                .HasMany(e => e.DncRolePermissionMapping)
                .WithRequired(e => e.DncRole)
                .HasForeignKey(e => e.RoleCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DncRole>()
                .HasMany(e => e.DncUserRoleMapping)
                .WithRequired(e => e.DncRole)
                .HasForeignKey(e => e.RoleCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DncUser>()
                .HasMany(e => e.DncUserRoleMapping)
                .WithRequired(e => e.DncUser)
                .HasForeignKey(e => e.UserGuid)
                .WillCascadeOnDelete(false);
        }
    }
}
