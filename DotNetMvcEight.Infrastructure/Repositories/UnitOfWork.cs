

using DotNetMvcEight.Core.Interfaces.IRepositories.IUnit;
using Microsoft.EntityFrameworkCore.Storage;

namespace DotNetMvcEight.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private IDbContextTransaction _dbContextTransaction;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task BeginTransaction()
        {
            _dbContextTransaction = await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await Save();
                await _dbContextTransaction.CommitAsync();
            }
            finally
            {
                await DisposeAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _appDbContext.DisposeAsync();
          
            if( _dbContextTransaction != null )
            {
               await _dbContextTransaction.DisposeAsync();
            }
        }

        public async Task RollBack()
        {
            try
            {
               await _dbContextTransaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<int> Save()
        {
            var count = await _appDbContext.SaveChangesAsync();

            return count;
        }
    }
}
