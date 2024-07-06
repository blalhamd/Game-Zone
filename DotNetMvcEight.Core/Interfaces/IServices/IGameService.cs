

namespace DotNetMvcEight.Core.Interfaces.IServices
{
    public interface IGameService
    {
		Task<IList<GameViewModel>> GetAllAsync();
		Task<GameViewModel> GetByIdAsync(int id);
		Task AddGame(AddGameViewModel GameViewModel);
		Task UpdateGame(int id, UpdateGameViewModel GameViewModel);
		Task DeleteGame(int id);
	}

}
