using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using create.db.Entities;

namespace create.db
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new erpdbcontext();
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
