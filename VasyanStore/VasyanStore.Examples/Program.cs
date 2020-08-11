using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasyanStore.DataAccess;
using VasyanStore.DataAccess.Entities;

namespace VasyanStore.Examples
{
    class Program
    {

        static void Main(string[] args)
        {
            Developer dev = null;

            using (ApplicationContext db1 = new ApplicationContext())
            {
                dev = db1.Developers.First();
            }

            /* 2 hours later */

            dev.Name = "Petro";

            using (ApplicationContext db2 = new ApplicationContext())
            {
                db2.Entry(dev).State = System.Data.Entity.EntityState.Modified;
                db2.SaveChanges();
            }

        }
    }
}
