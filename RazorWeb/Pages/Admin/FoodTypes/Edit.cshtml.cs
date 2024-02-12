using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Admin.FoodTypes
{
	/// <summary>
	/// Edit Model created to edit FoodType page
	/// </summary>
	[BindProperties]
	public class EditModel : PageModel
    {
		/// <summary>
		/// Application Db context for connection to the database
		/// </summary>
		//private readonly ApplicationDbContext _db;
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// Food Type for 2 way Binding
		/// </summary>
		public FoodType FoodType { get; set; }

		/// <summary>
		/// Constructor used for Dependency Injection
		/// </summary>
		/// <param name="db"></param>
		public EditModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Run when the page gets loaded used to fetch data
		/// </summary>
		/// <param name="id"></param>
		public void OnGet(int id)
		{
			FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
			//FoodType = _db.FoodType.Find(id);
			//Category = _db.Category.FirstOrDefault(u=>u.Id==id);
			//Category = _db.Category.SingleOrDefault(u=>u.Id==id);
			//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
		}

		/// <summary>
		/// on Click event used to save changes to the database
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.FoodType.Update(FoodType);
				_unitOfWork.Save();
				//_db.FoodType.Update(FoodType);
				//await _db.SaveChangesAsync();
				TempData["success"] = "FoodType updated successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}
