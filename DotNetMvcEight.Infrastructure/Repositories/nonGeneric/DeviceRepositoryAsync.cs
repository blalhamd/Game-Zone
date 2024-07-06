

namespace DotNetMvcEight.Infrastructure.Repositories.nonGeneric
{
    public class DeviceRepositoryAsync : GenericRepositoryAsync<Device>, IDeviceRepositoryAsync
    {
        public DeviceRepositoryAsync(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }


}
