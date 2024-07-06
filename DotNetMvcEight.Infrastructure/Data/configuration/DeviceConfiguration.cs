
using DotNetMvcEight.Infrastructure.Data.Seeding;

namespace DotNetMvcEight.Infrastructure.Data.configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices").HasKey(x => x.Id);
            builder.HasData(SeedData.LoadDevices());

        }
    }

}
