
using DotNetMvcEight.Core.Interfaces.IRepositories.Genric;
using DotNetMvcEight.Infrastructure.Data.context;
using System.Linq.Expressions;

namespace DotNetMvcEight.Infrastructure.Repositories.generic
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryASync<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<T> _entity;

        public GenericRepositoryAsync(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entity = _appDbContext.Set<T>();
        }

        public DbSet<T> Entity { get => _entity; set => _entity = value; }

        public async Task<IList<T>> GetAllAsync(string[] includes = null!)
        {
            var query = _entity.AsQueryable();

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var entity = await _entity.FindAsync(id);

            return entity;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> condition, string[] includes = null!)
        {
            var query = _entity.AsQueryable();

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(condition);
        }

        public async Task AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entity.AddRangeAsync(entities);
        }

        public async Task<long> CountAsync()
        {
            var count = await _entity.CountAsync();

            return count;
        }

        public async Task<long> CountWithConditionAsync(Expression<Func<T, bool>> condition)
        {
            var count = await _entity.LongCountAsync(condition);

            return count;
        }


        public async Task<IList<T>> GetWithCondition(Expression<Func<T, bool>> condition)
        {
            var query = await _entity.Where(condition).ToListAsync();

            return query;
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _entity.Update(entity);

                // or 

                //_entity.Attach(entity);
                //_appDbContext.Entry(entity).State = EntityState.Modified;
            });
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() =>
            {
                _entity.UpdateRange(entities);
            });
        }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                _entity.Remove(entity);
            });
        }



    }

}
