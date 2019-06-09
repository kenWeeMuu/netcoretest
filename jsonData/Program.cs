using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpDb.Entitys;
using Newtonsoft.Json;

namespace jsonData
{
    class Program
    {
        static void Main(string[] args) {
            using (var db = new ErpDbContext())
            {

                var users = db.Users.ToList();

               writeJson<User>(users);
               writeJson<Role>(db.Roles.ToList());
               writeJson<Permission>(db.Permissions.ToList());
               writeJson<Menu>(db.Menus.ToList());

            }


            Console.WriteLine("done");

           

            
        }


        static void writeJson<T>(  object data)
        {
            File.WriteAllText($"{typeof(T).Name}.txt", JsonConvert.SerializeObject(data));
        }
    }
}
