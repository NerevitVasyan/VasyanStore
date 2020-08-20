using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VasyanStore.DataAccess.Entities;

namespace VasyanStore.Domain.Filters
{
    public class GameFilter
    {
        public string Name { get; set; } //Bethesda
        public string Type { get; set; } //Developer
        public Expression<Func<Game,bool>> Predicate { get; set; } // x => x.Developer.Name == "Bethesda"

    }
}
