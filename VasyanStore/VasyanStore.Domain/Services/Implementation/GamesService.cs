using Binbin.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VasyanStore.DataAccess.Entities;
using VasyanStore.DataAccess.Repository.Abstraction;
using VasyanStore.Domain.Filters;
using VasyanStore.Domain.Services.Abstraction;

namespace VasyanStore.Domain.Services.Implementation
{
    public class GamesService : IGamesService
    {
        private readonly IGenericRepository<Game> _repos;
        private readonly IGenericRepository<Developer> _reposDevs;
        private readonly IGenericRepository<Genre> _reposGenre;
        public GamesService(IGenericRepository<Game> repos,
                            IGenericRepository<Developer> reposDevs,
                            IGenericRepository<Genre> reposGenre )
        {
            _repos = repos;
            _reposDevs = reposDevs;
            _reposGenre = reposGenre;
        }

        public ICollection<Game> GetAllGames(List<GameFilter> filters)
        {
            //Витягуємо всі ігри
            var games = _repos.GetAll(x => x.Developer, x => x.Genre);

            //якщо є фільтри, то робимо фільтрацію
            if (filters != null && filters.Count!=0)
            {
                // For example filters
                // filter1.Predicate = (x=>x.Developer.Name == "Bethesda")
                // filter2.Predicate = (x=>x.Developer.Name == "Blizzard")
                // filter3.Predicate = (x=>x.Developer.Name == "Valve")

                // ...Where(filter1.Predicate || filter2.Predicate || filter3.Predicate)

                //ліпимо всі фільтри в один предикат
                //PredicateBuider це окрема бібліотека яку необхідно скачати в NuGet

                var predicates = new List<Expression<Func<Game, bool>>>();

                // (devFilter1 || devFilter2 || devFilter3) && (genreFilter1||genreFilter2)


                // (x=>x.Developer.Name == "Bethesda" || x=>x.Developer.Name == "Valve" || x=>x.Developer.Name == "Blizzard" )
                // && (x=>x.Genre.Name == "RPG" || x=>x.Developer.Name == "Action")

                foreach (var type in filters.GroupBy(x => x.Type))
                {
                    var p = PredicateBuilder.Create(type.First().Predicate);
                    for (int i = 1; i < type.Count(); i++)
                    {
                        p = p.Or(filters[i].Predicate);
                    }
                    predicates.Add(p);
                }

                //predicates[0] = (x=>x.Developer.Name == "Bethesda" || x=>x.Developer.Name == "Valve" || x=>x.Developer.Name == "Blizzard" )
                //predicates[1] = (x=>x.Genre.Name == "RPG" || x=>x.Developer.Name == "Action")

                var pred = PredicateBuilder.Create(predicates[0]);

                for (int i = 1; i < predicates.Count; i++)
                {
                    pred = pred.And(predicates[i]);
                }

                //витягуємо ті ігри які підходять по нашим предикатам
                games = games.Where(pred.Compile());
            }

            //повертаємо ігри
            return games.ToList();
        }

        public void AddGame(Game model)
        {
            var dev = _reposDevs.GetAll().FirstOrDefault(x => x.Name == model.Developer.Name);
            if(dev != null)
            {
                model.Developer = dev;
            }

            var genre = _reposGenre.GetAll().FirstOrDefault(x => x.Name == model.Genre.Name);
            if (genre != null)
            {
                model.Genre = genre;
            }

            _repos.Create(model);
        }

        public IEnumerable<string> GetGenres()
        {
            return _reposGenre.GetAll().Select(x => x.Name);
        }

        public IEnumerable<string> GetDevelopers()
        {
            return _reposDevs.GetAll().Select(x => x.Name);
        }
    }
}