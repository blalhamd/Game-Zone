
namespace DotNetMvcEight.Infrastructure.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category,CategoryViewModel>().ReverseMap();
            CreateMap<AddCategoryViewModel,Category>().ReverseMap();
            CreateMap<UpdateCategoryViewModel,Category>().ReverseMap();

			CreateMap<Device, DeviceViewModel>().ReverseMap();
			CreateMap<AddDeviceViewModel, Device>().ReverseMap();
			CreateMap<UpdateDeviceViewModel, Device>().ReverseMap();

			CreateMap<Game, GameViewModel>().ReverseMap();
			CreateMap<AddGameViewModel, Game>().ReverseMap();
			CreateMap<UpdateGameViewModel, Game>().ReverseMap();


		}
    }
}
