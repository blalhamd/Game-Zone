

namespace DotNetMvcEight.Core.Interfaces.IRepositories.IUnit
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> Save();
        Task BeginTransaction();
        Task CommitAsync();
        Task RollBack();
    }
}
