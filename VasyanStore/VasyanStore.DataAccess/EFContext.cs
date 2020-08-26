namespace VasyanStore.DataAccess
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using VasyanStore.DataAccess.Entities;
    using VasyanStore.DataAccess.Initializers;

    public class EFContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public EFContext()
            : base("name=storeConnString")
        {
            Database.SetInitializer(new GamesInit());
        }
    }
}