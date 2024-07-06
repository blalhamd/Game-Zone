
namespace DotNetMvcEight.Infrastructure.Repositories.nonGeneric
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>, ICategoryRepositoryAsync
    {
        public CategoryRepositoryAsync(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }

}
