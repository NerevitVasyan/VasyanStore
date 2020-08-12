using System.Collections.Generic;
using VasyanStore.DataAccess.Entities;

namespace VasyanStore.Domain.Services.Abstraction
{
    public interface IGamesService
    {
        ICollection<Game> GetAllGames();
    }
}
