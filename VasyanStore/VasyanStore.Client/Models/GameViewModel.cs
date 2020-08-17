using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VasyanStore.Client.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
    }
}