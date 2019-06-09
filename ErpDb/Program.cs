using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpDb.Entitys;

namespace ErpDb
{
    class Program
    {
        static void Main(string[] args) {
            using (var db = new ErpDbContext())
            {
                db.Users.Add(new User()
                {
                    Avatar = "",
                    LoginName = "kk",
                    Password = "123"
                });

           var roles =     db.Roles.Add(new Role()
                {
                    Code = "dsada", Description = "dsadas", Name = "dsada"
                });
          //    var user =  db.Users.Include(x=>x.Roles).FirstOrDefault(x => x.UserId == 1);
          //    var role = db.Roles.FirstOrDefault(x => x.RoleId == 1);
         //    user.Roles.Add(role);
           // db.Roles.Remove(role);
                db.SaveChanges();
            }

            Console.WriteLine("ok");

            Console.ReadKey();
        }
    }
}
