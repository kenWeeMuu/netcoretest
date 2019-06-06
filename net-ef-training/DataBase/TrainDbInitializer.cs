using System.Data.Entity;
using net_ef_training.Models;

namespace net_ef_training.DataBase
{
    public class TrainDbInitializer : DropCreateDatabaseIfModelChanges<TrainContext>
    {
        protected override void Seed(TrainContext context)
        {

            var user = new User()
            {
                DisplayName = "TrainDbInitializer",
                Username = "Ken"
            };

            context.Users.Add(user);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}