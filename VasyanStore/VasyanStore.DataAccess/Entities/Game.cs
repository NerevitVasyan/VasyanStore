using System;

namespace VasyanStore.DataAccess.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        /* Navigation Props */

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }

}