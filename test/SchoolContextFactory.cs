using System.Data.Entity.Infrastructure;

namespace test
{
    public class SchoolContextFactory : IDbContextFactory<SchoolContext>
    {
        public SchoolContext Create() {
            return new SchoolContext(@"Data Source=SC-201810210901\\SQLEXPRESS;Initial Catalog=sss;Integrated Security=True");
        }
    }
}