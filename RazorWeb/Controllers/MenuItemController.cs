using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RazorModels.Model;

namespace RazorWeb.Controllers
{
	/// <summary>
	/// APi Controller for Datatables
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class MenuItemController : Controller
	{
		/// <summary>
		/// Unit of work to communicate with the Database
		/// </summary>
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// _hostEnvironment to delete images from system.
		/// </summary>
		private readonly IWebHostEnvironment _hostEnvironment;

		/// <summary>
		/// Constrcutor for constructor dependency injection
		/// </summary>
		/// <param name="unitOfWork"></param>
		/// <param name="hostEnvironment"></param>
		public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
			_unitOfWork = unitOfWork;
			_hostEnvironment = hostEnvironment;

		}

		/// <summary>
		/// Get method to retrieve menuItem table from database and associated FoodType and Category entries
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{
			var menuItemList = _unitOfWork.MenuItem.GetAll("FoodType,Category");
			return Json(new { data = menuItemList });
		}

		/// <summary>
		/// Delete method to delete menuitem entry from database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			// Since we are only deleting menu item entry and not its associated fact table entry we are keeping
			// foodtype and category blank
			var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
			var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}
			_unitOfWork.MenuItem.Remove(objFromDb);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete successful." });
		}
	}
}
