

using System.Linq.Expressions;

namespace DotNetMvcEight.Core.Interfaces.IRepositories.Genric
{
    public interface IGenericRepositoryASync<T> where T : class
    {

        Task<IList<T>> GetAllAsync(string[] includes = null!);
        Task<IList<T>> GetWithCondition(Expression<Func<T, bool>> condition);
        Task<T> GetByIdAsync(object id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition, string[] includes = null!);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task<long> CountAsync();
        Task<long> CountWithConditionAsync(Expression<Func<T, bool>> condition);

    }
}
