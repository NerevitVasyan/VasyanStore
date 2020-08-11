using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasyanStore.DataAccess.Entities;

namespace VasyanStore.DataAccess.Initializers
{
    public class GamesInit : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "RPG" },
                new Genre { Name = "Action" },
                new Genre { Name = "FPS" },
                new Genre { Name = "Racing" },
                new Genre { Name = "Strategy" }
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();

            var devs = new List<Developer>
            {
                new Developer { Name = "CD Project Red" },
                new Developer { Name = "Bethesda" },
                new Developer { Name = "Ubisoft" },
                new Developer { Name = "Valve" },
                new Developer { Name = "Blizzard" }
            };

            context.Developers.AddRange(devs);
            context.SaveChanges();
        }
    }
}