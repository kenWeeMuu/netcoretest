using System.Data.Entity;
using ef_training_console.Models;

namespace ef_training_console.DataBase
{
    public class TrainDbInitializer : DropCreateDatabaseIfModelChanges<TrainContext>
    {
        protected override void Seed(TrainContext context)
        {

            var user = new User()
            {
                DisplayName = "Morisato",
                Username = "Ken"
            };

            context.Users.Add(user);


            base.Seed(context);
        }
    }
}