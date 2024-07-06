using DotNetMvcEight.Core.Interfaces.IServices;
using DotNetMvcEight.Core.ViewModels.Device;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMvcEight.Web.Controllers
{
	public class DeviceController : Controller
	{
		private readonly IDeviceService _DeviceService;

		public DeviceController(IDeviceService DeviceService)
		{
			_DeviceService = DeviceService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = await _DeviceService.GetAllAsync();

			return View("GetAll", query);
		}

		[HttpGet]
		public async Task<IActionResult> GetById(int id)
		{
			var query = await _DeviceService.GetByIdAsync(id);

			return View("GetById", query);
		}

		public IActionResult AddForm()
		{
			return View("AddForm");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddDevice(AddDeviceViewModel model)
		{
			if (ModelState.IsValid)
			{
				await _DeviceService.AddDevice(model);

				return RedirectToAction("Index", "Home");
			}

			return View("AddForm", model);
		}

		public async Task<IActionResult> UpdateForm(int Id)
		{
			var query = await _DeviceService.GetByIdAsync(Id);

			ViewBag.categories = await _DeviceService.GetAllAsync();

			return View("UpdateForm", query);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateDevice(int id, UpdateDeviceViewModel model)
		{
			if (ModelState.IsValid)
			{
				await _DeviceService.UpdateDevice(id, model);

				return RedirectToAction("GetAll", "Device");
			}

			else
			{
				ViewBag.categories = await _DeviceService.GetAllAsync();
				return View("UpdateForm", model);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _DeviceService.DeleteDevice(id);

			return RedirectToAction("GetAll", "Device");
		}
	}
}
