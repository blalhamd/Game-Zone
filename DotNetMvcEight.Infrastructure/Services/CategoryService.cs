
using DotNetMvcEight.Core.Interfaces.common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNetMvcEight.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepositoryAsync categoryRepositoryAsync, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepositoryAsync = categoryRepositoryAsync;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCategory(AddCategoryViewModel categoryViewModel)
        {
            var query = await _categoryRepositoryAsync.FirstOrDefaultAsync(x=> x.Name.ToLower() == categoryViewModel.Name.ToLower());

            if(query is not null)
            {
                throw new ItemAlreadyExistExecption("This Category Already Exist");
            }

            var map = _mapper.Map<Category>(categoryViewModel);

            await _categoryRepositoryAsync.AddAsync(map);
            await _unitOfWork.Save();

        }


		public async Task<IList<CategoryViewModel>> GetAllAsync()
        {
            var query = await _categoryRepositoryAsync.GetAllAsync();

            if (query is null)
            {
                throw new ItemNotFoundExecption("Not Exist Categories");
            }

            var map = _mapper.Map<List<CategoryViewModel>>(query);

            return map;
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var query = await _categoryRepositoryAsync.GetByIdAsync(id);

            if (query is null)
            {
                throw new ItemNotFoundExecption($"Not Exist Category with this Id {id}");
            }

            var map = _mapper.Map<CategoryViewModel>(query);

            return map;
        }

        public async Task UpdateCategory(int id, UpdateCategoryViewModel categoryViewModel)
        {
            var query = await _categoryRepositoryAsync.FirstOrDefaultAsync(x => x.Name.ToLower() == categoryViewModel.Name.ToLower());

            if (query is not null)
            {
                throw new ItemAlreadyExistExecption("This Category Already Exist");
            }

            var category = await _categoryRepositoryAsync.GetByIdAsync(id);

			if (category is null)
			{
				throw new ItemNotFoundExecption("This Category is Not Exist");
			}

            category.Name = categoryViewModel.Name;

			await _categoryRepositoryAsync.UpdateAsync(category);
            await _unitOfWork.Save();
        }

		public async Task DeleteCategory(int id)
		{
			var category = await _categoryRepositoryAsync.GetByIdAsync(id);

			if (category is null)
			{
				throw new ItemNotFoundExecption("This Category is Not Exist");
			}

            await _categoryRepositoryAsync.DeleteAsync(category);
            await _unitOfWork.Save();
		}


	}
}
