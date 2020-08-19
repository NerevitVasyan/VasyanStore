using System.Collections.Generic;
using System.Linq;
using VasyanStore.DataAccess.Entities;
using VasyanStore.DataAccess.Repository.Abstraction;
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

        public ICollection<Game> GetAllGames()
        {
            var games = _repos.GetAll(x => x.Developer, x => x.Genre);
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