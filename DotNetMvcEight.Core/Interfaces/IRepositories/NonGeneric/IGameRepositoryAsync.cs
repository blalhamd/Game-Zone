

namespace DotNetMvcEight.Core.Interfaces.IRepositories.NonGeneric
{
    public interface IGameRepositoryAsync : IGenericRepositoryASync<Game>
    {
		Task<Game> GetByIdWithIncludesAsync(int id, string[] includes = null!);

	}
}
