
namespace DotNetMvcEight.Infrastructure.Data.context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Device> devices { get; set; }
        public DbSet<GameDevice> gameDevices { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }


    }
}
