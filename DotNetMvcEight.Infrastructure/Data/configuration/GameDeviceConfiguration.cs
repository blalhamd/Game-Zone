
namespace DotNetMvcEight.Infrastructure.Data.configuration
{
    public class GameDeviceConfiguration : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.ToTable("GameDevice").HasKey(x => new { x.DeviceId, x.GameId });

            builder.HasOne(x => x.Device)
                   .WithMany(x => x.GameDevices)
                   .HasForeignKey(x => x.DeviceId)
                   .IsRequired();

            builder.HasOne(x => x.Game)
                  .WithMany(x => x.gameDevices)
                  .HasForeignKey(x => x.GameId)
                  .IsRequired();
        }
    }

}
