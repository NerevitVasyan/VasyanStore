using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasyanStore.DataAccess.Entities;

namespace VasyanStore.DataAccess.Initializers
{
    public class GamesInit : DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
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
                new Developer { Name = "Blizzard" },
                new Developer { Name = "EA" }
            };

            context.Developers.AddRange(devs);
            context.SaveChanges();

            var games = new List<Game>()
            {
                new Game
                {
                    Name = "Skyrim",
                    Price = 40,
                    ReleaseDate = new DateTime(2011,11,11),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Bethesda"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "RPG")
                },
                 new Game
                {
                    Name = "The Witcher 3: Wild Hunt",
                    Price = 40,
                    ReleaseDate = new DateTime(2015,5,18),
                    Developer = devs.FirstOrDefault(x=>x.Name == "CD Project Red"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "RPG")
                },
                  new Game
                {
                    Name = "Doka 2",
                    Price = 0,
                    ReleaseDate = new DateTime(2010,11,11),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Valve"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Strategy")
                },
                   new Game
                {
                    Name = "Cyberpank 2077",
                    Price = 60,
                    ReleaseDate = new DateTime(2020,11,19),
                    Developer = devs.FirstOrDefault(x=>x.Name == "CD Project Red"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "RPG")
                },
                   new Game
                {
                    Name = "Half-life: Alyx",
                    Price = 60,
                    ReleaseDate = new DateTime(2010,11,11),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Valve"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Action")
                },
                   new Game
                {
                    Name = "Assasins Creed: Valhalla",
                    Price = 60,
                    ReleaseDate = new DateTime(2020,11,17),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Ubisoft"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Action")
                },
                   new Game
                {
                    Name = "Need For Speed Most Wanted",
                    Price = 30,
                    ReleaseDate = new DateTime(2007,5,9),
                    Developer = devs.FirstOrDefault(x=>x.Name == "EA"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Racing")
                },
                   new Game
                {
                    Name = "Warcraft 3",
                    Price = 20,
                    ReleaseDate = new DateTime(2002,1,5),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Blizzard"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Strategy")
                },
                   new Game
                {
                    Name = "Overwatch",
                    Price = 0,
                    ReleaseDate = new DateTime(2017,5,6),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Blizzard"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Action")
                },
                   new Game
                {
                    Name = "Starcfart 2",
                    Price = 60,
                    ReleaseDate = new DateTime(2011,11,11),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Blizzard"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Strategy")
                },
                   new Game
                {
                    Name = "BattleField",
                    Price = 80,
                    ReleaseDate = new DateTime(2010,11,11),
                    Developer = devs.FirstOrDefault(x=>x.Name == "EA"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Action")
                },
                   new Game
                {
                    Name = "Fallout 4",
                    Price = 50,
                    ReleaseDate = new DateTime(2010,11,11),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Bethesda"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Action")
                },
                   new Game
                {
                    Name = "Fallout 76",
                    Price = 60,
                    ReleaseDate = new DateTime(2010,11,11),
                    Developer = devs.FirstOrDefault(x=>x.Name == "Bethesda"),
                    Genre = genres.FirstOrDefault(x=>x.Name == "Action")
                }
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
}