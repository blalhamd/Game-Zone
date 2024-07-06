
namespace DotNetMvcEight.Core.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IList<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel> GetByIdAsync(int id);
        Task AddCategory(AddCategoryViewModel categoryViewModel);
        Task UpdateCategory(int id,UpdateCategoryViewModel categoryViewModel);
        Task DeleteCategory(int id);
    }
}
