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
        public GamesService(IGenericRepository<Game> repos)
        {
            _repos = repos;
        }

        public ICollection<Game> GetAllGames()
        {
            var games = _repos.GetAll();
            return games.ToList();
        }
    }
}