using System;
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
        static void Main(string[] args)
        {
            IGenericRepository<Game> repos = new EfRepository<Game>(new EFContext());

            repos.Create(new Game { Name = "Skyrim", Price = 60, ReleaseDate = DateTime.Now });

            var games = repos.GetAll();

            foreach(var game in games)
            {
                Console.WriteLine(game.Name);
            }
        }
    }
}
