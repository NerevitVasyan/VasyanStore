using Binbin.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //public bool isEven(int a)
        //{
        //    if (a % 2 == 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool isEven2(int a) => (a % 2 == 0);

        //public Func<int, bool> isEven3 = (a => a % 2 == 0);

        public ICollection<Game> GetAllGames(List<GameFilter> filters)
        {
            //Витягуємо всі ігри
            var games = _repos.GetAll(x => x.Developer, x => x.Genre);

            //якщо є фільтри, то робимо фільтрацію
            if (filters != null)
            {
                // For example filters
                // filter1.Predicate = (x=>x.Developer.Name == "Bethesda")
                // filter2.Predicate = (x=>x.Developer.Name == "Blizzard")
                // filter3.Predicate = (x=>x.Developer.Name == "Valve")

                // ...Where(filter1.Predicate || filter2.Predicate || filter3.Predicate)

                //ліпимо всі фільтри в один предикат
                var predicate = PredicateBuilder.Create(filters[0].Predicate);

                for(int i = 1; i < filters.Count; i++)
                {
                    predicate = predicate.Or(filters[i].Predicate);
                }

                //витягуємо ті ігри які підходять по нашим предикатам
                games = games.Where(predicate.Compile());
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