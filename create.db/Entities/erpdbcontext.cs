using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using create.db.Entities.Erp;

namespace create.db.Entities
{
    class erpdbcontext :DbContext
    {
        public erpdbcontext() : base(
            @"Data Source=SC-201810210901\SQLEXPRESS;Initial Catalog=erpdb;Integrated Security=True") {
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<erpdbcontext, Configuration>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           


            modelBuilder.Entity<DncMenu>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Menu)
                .HasForeignKey(e => e.MenuGuid);

            modelBuilder.Entity<DncPermission>()
                .HasMany(e => e.Roles)
                .WithRequired(e => e.DncPermission)
                .HasForeignKey(e => e.PermissionCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DncRole>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.DncRole)
                .HasForeignKey(e => e.RoleCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DncRole>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.DncRole)
                .HasForeignKey(e => e.RoleCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DncUser>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.DncUser)
                .HasForeignKey(e => e.UserGuid)
                .WillCascadeOnDelete(false);
        }
 
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

 
 


        
    }
}
