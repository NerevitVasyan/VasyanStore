using System.Collections.Generic;
using VasyanStore.DataAccess.Entities;
using VasyanStore.Domain.Filters;

namespace VasyanStore.Domain.Services.Abstraction
{
    public interface IGamesService
    {
        ICollection<Game> GetAllGames(List<GameFilter> filters);
        void AddGame(Game model);

        // TODO: Create Genres Serivice and Developer Service
        IEnumerable<string> GetGenres();
        IEnumerable<string> GetDevelopers();
    }
}
