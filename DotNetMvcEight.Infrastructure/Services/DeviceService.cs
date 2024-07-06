

using DotNetMvcEight.Core.Interfaces.common;

namespace DotNetMvcEight.Infrastructure.Services
{
    public class DeviceService : IDeviceService
    {

		private readonly IDeviceRepositoryAsync _DeviceRepositoryAsync;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DeviceService(IDeviceRepositoryAsync DeviceRepositoryAsync, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_DeviceRepositoryAsync = DeviceRepositoryAsync;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task AddDevice(AddDeviceViewModel DeviceViewModel)
		{
			var query = await _DeviceRepositoryAsync.FirstOrDefaultAsync(x => x.Name.ToLower() == DeviceViewModel.Name.ToLower());

			if (query is not null)
			{
				throw new ItemAlreadyExistExecption("This Device Already Exist");
			}

			var map = _mapper.Map<Device>(DeviceViewModel);

			await _DeviceRepositoryAsync.AddAsync(map);
			await _unitOfWork.Save();

		}


		public async Task<IList<DeviceViewModel>> GetAllAsync()
		{
			var query = await _DeviceRepositoryAsync.GetAllAsync();

			if (query is null)
			{
				throw new ItemNotFoundExecption("Not Exist Categories");
			}

			var map = _mapper.Map<List<DeviceViewModel>>(query);

			return map;
		}

		public async Task<DeviceViewModel> GetByIdAsync(int id)
		{
			var query = await _DeviceRepositoryAsync.GetByIdAsync(id);

			if (query is null)
			{
				throw new ItemNotFoundExecption($"Not Exist Device with this Id {id}");
			}

			var map = _mapper.Map<DeviceViewModel>(query);

			return map;
		}

		public async Task UpdateDevice(int id, UpdateDeviceViewModel DeviceViewModel)
		{
			var query = await _DeviceRepositoryAsync.FirstOrDefaultAsync(x => x.Name.ToLower() == DeviceViewModel.Name.ToLower());

			if (query is not null)
			{
				throw new ItemAlreadyExistExecption("This Device Already Exist");
			}

			var device = await _DeviceRepositoryAsync.GetByIdAsync(id);

			if (device is null)
			{
				throw new ItemNotFoundExecption("This Device is Not Exist");
			}

			device.Name = DeviceViewModel.Name;
			device.Icon = DeviceViewModel.Icon;

			await _DeviceRepositoryAsync.UpdateAsync(device);
			await _unitOfWork.Save();
		}

		public async Task DeleteDevice(int id)
		{
			var Device = await _DeviceRepositoryAsync.GetByIdAsync(id);

			if (Device is null)
			{
				throw new ItemNotFoundExecption("This Device is Not Exist");
			}

			await _DeviceRepositoryAsync.DeleteAsync(Device);
			await _unitOfWork.Save();
		}


	}
}
