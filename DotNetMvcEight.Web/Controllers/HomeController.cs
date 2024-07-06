using DotNetMvcEight.Core.Interfaces.IServices;
using DotNetMvcEight.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetMvcEight.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameService _GameService;
		public HomeController(ILogger<HomeController> logger, IGameService gameService)
		{
			_logger = logger;
			_GameService = gameService;
		}

		public async Task<IActionResult> Index()
		{
			var query = await _GameService.GetAllAsync();

			return View(query);
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
