using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExistingDatabaseSample
{
    class Program
    {
        static void Main(string[] args) {

          var db = new ErpDbContext();

          db.DncUser.ToList().ForEach(u =>
          {
              PrintProperties(u);
          });


          Console.ReadKey();

        }


        public static void PrintProperties(Object obj) {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj)) {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("{0}={1}", name, value);
            }
        }
    }
}
