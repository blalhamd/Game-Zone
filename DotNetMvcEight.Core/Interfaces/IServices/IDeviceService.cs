
namespace DotNetMvcEight.Core.Interfaces.IServices
{
    public interface IDeviceService
    {
		Task<IList<DeviceViewModel>> GetAllAsync();
		Task<DeviceViewModel> GetByIdAsync(int id);
		Task AddDevice(AddDeviceViewModel DeviceViewModel);
		Task UpdateDevice(int id, UpdateDeviceViewModel DeviceViewModel);
		Task DeleteDevice(int id);
	}
}
