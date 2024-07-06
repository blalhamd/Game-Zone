using DotNetMvcEight.Core.Interfaces.IServices;
using DotNetMvcEight.Core.ViewModels.Game;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMvcEight.Web.Controllers
{
	public class GameController : Controller
	{
		private readonly IGameService _GameService;
		private readonly ICategoryService _categoryService;

        public GameController(IGameService GameService, ICategoryService categoryService)
        {
            _GameService = GameService;
            _categoryService = categoryService;
        }

        [HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = await _GameService.GetAllAsync();

			return View("GetAll", query);
		}

		[HttpGet]
		public async Task<IActionResult> GetById(int id)
		{
			var query = await _GameService.GetByIdAsync(id);

			return View("GetById", query);
		}

		public async Task<IActionResult> AddForm()
		{
			ViewBag.Categories = await _categoryService.GetAllAsync();

			return View("AddForm");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddGame(AddGameViewModel model)
		{
			if (ModelState.IsValid)
			{
                await _GameService.AddGame(model);

				return RedirectToAction("Index", "Home");
			}

            ViewBag.Categories = await _categoryService.GetAllAsync();

            return View("AddForm", model);
		}

		public async Task<IActionResult> UpdateForm(int Id)
		{
			var query = await _GameService.GetByIdAsync(Id);

			ViewBag.categories = await _categoryService.GetAllAsync();

			return View("UpdateForm", query);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateGame(int id, UpdateGameViewModel model)
		{
			if (ModelState.IsValid)
			{
                await _GameService.UpdateGame(id, model);

				return RedirectToAction("GetAll", "Game");
			}
			else
			{
				ViewBag.categories = await _GameService.GetAllAsync();
				return View("UpdateForm", model);
			}
		}


		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _GameService.DeleteGame(id);

			return RedirectToAction("GetAll", "Game");
		}

		

	}
}
