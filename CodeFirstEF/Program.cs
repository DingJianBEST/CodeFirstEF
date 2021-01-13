using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new Initializer());
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();
            }

            Console.WriteLine("Creation finished.");
            Console.Read();
        }
    }
}
