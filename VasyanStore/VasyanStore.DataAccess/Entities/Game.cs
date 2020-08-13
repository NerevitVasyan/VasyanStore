using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VasyanStore.DataAccess.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        /* Navigation Props */

        [ForeignKey("Genre")]
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        [ForeignKey("Developer")]
        public int? DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }

}