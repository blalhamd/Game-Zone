using DotNetMvcEight.Core.Interfaces.IServices;
using DotNetMvcEight.Core.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMvcEight.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = await _categoryService.GetAllAsync();

            return View("GetAll", query);
        }

		[HttpGet]
		public async Task<IActionResult> GetById(int id)
		{
			var query = await _categoryService.GetByIdAsync(id);

			return View("GetById", query);
		}

		public IActionResult AddForm()
        {
            return View("AddForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategory(model);

                return RedirectToAction("Index","Home");
            }

            return View("AddForm", model);
        }

        public async Task<IActionResult> UpdateForm(int Id)
        {
            var query = await _categoryService.GetByIdAsync(Id);

            ViewBag.categories = await _categoryService.GetAllAsync();

            return View("UpdateForm", query);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(int id,UpdateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateCategory(id, model);

                return RedirectToAction("GetAll", "Category");
			}

            else
            {
				ViewBag.categories = await _categoryService.GetAllAsync();
				return View("UpdateForm", model);
			}
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);

            return RedirectToAction("GetAll", "Category");
        }

    }
}
