namespace VasyanStore.DataAccess
{
    using System.Data.Entity;
    using VasyanStore.DataAccess.Entities;
    using VasyanStore.DataAccess.Initializers;

    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            //Database.SetInitializer(new GamesInit());
        }
    }
}