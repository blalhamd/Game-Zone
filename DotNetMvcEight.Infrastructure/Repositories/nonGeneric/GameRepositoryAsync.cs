

namespace DotNetMvcEight.Infrastructure.Repositories.nonGeneric
{
    public class GameRepositoryAsync : GenericRepositoryAsync<Game>, IGameRepositoryAsync
    {
        private readonly AppDbContext _context;
        public GameRepositoryAsync(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

		public async Task<Game?> GetByIdWithIncludesAsync(int id, string[] includes = null!)
		{
            var query = _context.Games.AsQueryable();

            if(includes is not null)
            {
                foreach(var include in includes)
                {
                   query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
		}


	}
}
