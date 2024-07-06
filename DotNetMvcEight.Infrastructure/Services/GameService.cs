
using DotNetMvcEight.Core.Interfaces.common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace DotNetMvcEight.Infrastructure.Services
{
    public class GameService : IGameService
    {

		private readonly IGameRepositoryAsync _GameRepositoryAsync;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _webHostEnvironment;
        public GameService(IGameRepositoryAsync GameRepositoryAsync, IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _GameRepositoryAsync = GameRepositoryAsync;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddGame(AddGameViewModel GameViewModel)
		{
			var query = await _GameRepositoryAsync.FirstOrDefaultAsync(x => x.Name.ToLower() == GameViewModel.Name.ToLower());

			if (query is not null)
			{
				throw new ItemAlreadyExistExecption("This Game Already Exist");
			}

            var UniqueFileName = await getUniqueName(GameViewModel.Image);

            var map = _mapper.Map<Game>(GameViewModel);
			map.ImagePath = UniqueFileName;

            await _GameRepositoryAsync.AddAsync(map);
			await _unitOfWork.Save();

		}


		public async Task<IList<GameViewModel>> GetAllAsync()
		{
			var query = await _GameRepositoryAsync.GetAllAsync(["Category"]);

			if (query is null)
			{
				throw new ItemNotFoundExecption("Not Exist Categories");
			}

			var map = _mapper.Map<List<GameViewModel>>(query);

			return map;
		}

		public async Task<GameViewModel> GetByIdAsync(int id)
		{
			var query = await _GameRepositoryAsync.GetByIdWithIncludesAsync(id, ["Category"]);

			if (query is null)
			{
				throw new ItemNotFoundExecption($"Not Exist Game with this Id {id}");
			}

			var map = _mapper.Map<GameViewModel>(query);

			return map;
		}

		public async Task UpdateGame(int id, UpdateGameViewModel GameViewModel)
		{
			var query = await _GameRepositoryAsync.FirstOrDefaultAsync(x => x.Name.ToLower() == GameViewModel.Name.ToLower() && 
			                                                                x.Description == GameViewModel.Description &&
																			x.CategoryId == GameViewModel.CategoryId 
																			);

			if (query is not null)
			{
				throw new ItemAlreadyExistExecption("This Game Already Exist");
			}

			var game = await _GameRepositoryAsync.GetByIdAsync(id);

			if (game is null)
			{
				throw new ItemNotFoundExecption("This Game is Not Exist");
			}

            var oldImage = game.ImagePath; // for Keeping the old path to remove old Image.
         
			var UniqueFileName = await getUniqueName(GameViewModel.Image);

            game.Name = GameViewModel.Name;
			game.Description = GameViewModel.Description;
			game.CategoryId = GameViewModel.CategoryId;
			game.ImagePath = UniqueFileName;

            await _GameRepositoryAsync.UpdateAsync(game);
			var count = await _unitOfWork.Save();

			if(count > 0)
			{
				await DeleteExistedImage(oldImage);
            }
		}

		public async Task DeleteGame(int id)
		{
			var Game = await _GameRepositoryAsync.GetByIdAsync(id);

			if (Game is null)
			{
				throw new ItemNotFoundExecption("This Game is Not Exist");
			}

			await _GameRepositoryAsync.DeleteAsync(Game);
			var count = await _unitOfWork.Save();

			if(count > 0)
			{
				await DeleteExistedImage(Game.ImagePath);
			}
		}

        private Task DeleteExistedImage(string image)
        {
            string? imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", image ?? "");

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            return Task.CompletedTask;
        }

        private async Task<string> getUniqueName(IFormFile file)
        {

            string UploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

            string UniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetExtension(file.FileName);
            string FilePath = Path.Combine(UploadsFolder, UniqueFileName);

            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Close();
            }

            return UniqueFileName;
        }

    }
}
