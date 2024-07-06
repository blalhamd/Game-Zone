
namespace DotNetMvcEight.DebendencyInjection
{
	public static class Container
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services,IConfiguration configuration)
		{
			// Register Connection String.

			var connection = configuration.GetConnectionString("DefaultConnectionString");

			services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connection));
			services.AddScoped<DbContext,AppDbContext>();


			// Register AutoMapper

			services.AddAutoMapper(typeof(Mapping));

			// Register Generic and Non-Generic Repositories

			services.AddScoped(typeof(IGenericRepositoryASync<>), typeof(GenericRepositoryAsync<>));
			services.AddScoped(typeof(IGameRepositoryAsync), typeof(GameRepositoryAsync));
			services.AddScoped(typeof(IDeviceRepositoryAsync), typeof(DeviceRepositoryAsync));
			services.AddScoped(typeof(IGameDeviceRepositoryAsync), typeof(GameDeviceRepositoryAsync));
			services.AddScoped(typeof(ICategoryRepositoryAsync), typeof(CategoryRepositoryAsync));

			// Register Unit Of Work

			services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));


			// Register Services

			services.AddScoped(typeof(IGameService), typeof(GameService));
			services.AddScoped(typeof(IDeviceService), typeof(DeviceService));
			services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
			services.AddScoped(typeof(IGameDeviceService), typeof(GameDeviceService));


			return services;
		}
	}
}
