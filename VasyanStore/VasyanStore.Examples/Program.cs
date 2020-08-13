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
            //IGenericRepository<Game> repos = new EfRepository<Game>(new EFContext());
            //var games = repos.GetAll(x=>x.Genre,x=>x.Developer);

            var context = new EFContext();
            context.Database.Log = efLogging;

            var games = context.Games.Include(x => x.Genre).Include(x => x.Developer).ToList();
            //select * from games left join genres on games.genreId = genres.id left join dev...

            foreach (var game in games)
            {
                Console.WriteLine(game.Id);
                Console.WriteLine(game.Name);
                Console.WriteLine(game.Price);
                Console.WriteLine(game.ReleaseDate);
                Console.WriteLine(game.Genre.Name);
                Console.WriteLine(game.Developer.Name);
            }
        }
    }
}
