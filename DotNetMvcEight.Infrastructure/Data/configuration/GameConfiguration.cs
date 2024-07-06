
using DotNetMvcEight.Infrastructure.Data.Seeding;

namespace DotNetMvcEight.Infrastructure.Data.configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games").HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(2500);
            builder.HasData(SeedData.LoadGames());

        }
    }
}
