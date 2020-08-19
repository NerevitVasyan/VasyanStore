using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasyanStore.DataAccess.Entities;
using VasyanStore.Domain.Services.Abstraction;

namespace VasyanStore.Domain.Services.Implementation
{
    // NOT FOR COPY!!!!!
    public class TestGamesService : IGamesService
    {
        public void AddGame(Game model)
        {
            throw new NotImplementedException();
        }

        public ICollection<Game> GetAllGames()
        {
            var games = new List<Game>
            {
                new Game
                {
                    Name = "Test",
                    Price = 122,
                    ReleaseDate = DateTime.Now
                }
            };

            return games;
        }

        public IEnumerable<string> GetDevelopers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetGenres()
        {
            throw new NotImplementedException();
        }
    }
}
