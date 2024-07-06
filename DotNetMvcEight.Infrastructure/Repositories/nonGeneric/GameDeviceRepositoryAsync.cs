
namespace DotNetMvcEight.Infrastructure.Repositories.nonGeneric
{
    public class GameDeviceRepositoryAsync : GenericRepositoryAsync<GameDevice>, IGameDeviceRepositoryAsync
    {
        public GameDeviceRepositoryAsync(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }


}
