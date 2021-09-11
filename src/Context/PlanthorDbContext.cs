using Microsoft.EntityFrameworkCore;
using PlanthorWebApiServer.Datamodel;

namespace PlanthorWebApiServer.Context
{
    public class PlanthorDbContext : DbContext
    {

        #region Constructors
        public PlanthorDbContext(DbContextOptions<PlanthorDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        protected PlanthorDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        #endregion

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Tribe> Tribes { get; set; }

    }
}