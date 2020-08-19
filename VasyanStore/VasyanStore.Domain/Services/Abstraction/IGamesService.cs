using System.Collections.Generic;
using VasyanStore.DataAccess.Entities;

namespace VasyanStore.Domain.Services.Abstraction
{
    public interface IGamesService
    {
        ICollection<Game> GetAllGames();
        void AddGame(Game model);

        // TODO: Create Genres Serivice and Developer Service
        IEnumerable<string> GetGenres();
        IEnumerable<string> GetDevelopers();
    }
}
