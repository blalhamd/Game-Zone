
using DotNetMvcEight.Infrastructure.Data.Seeding;

namespace DotNetMvcEight.Infrastructure.Data.configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(x => x.Id);

            builder.HasData(SeedData.LoadCategories());
        }
    }
}
