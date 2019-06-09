using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Erpdbtest.Entities
{
    public class ErpDbContext :  DbContext
    {
        public ErpDbContext(string connString) : base(connString) {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
