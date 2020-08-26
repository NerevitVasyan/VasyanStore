using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasyanStore.DataAccess;
using VasyanStore.DataAccess.Entities;
using VasyanStore.DataAccess.Repository.Abstraction;
using VasyanStore.DataAccess.Repository.Implementation;

namespace VasyanStore.Examples
{
    class Program
    {
        static void efLogging(string log)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(log);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {

        }
    }
}
