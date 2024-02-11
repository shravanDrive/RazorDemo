using DatabaseAccess.DataConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Admin.FoodTypes
{
	/// <summary>
	/// Delete Razor Page for Food Type
	/// </summary>
	[BindProperties]
	public class DeleteModel : PageModel
    {
		/// <summary>
		/// Application DB COntext for database Connection
		/// </summary>
		private readonly ApplicationDbContext _db;

		/// <summary>
		/// 2-way Binding food type property method
		/// </summary>
		public FoodType FoodType { get; set; }

		/// <summary>
		/// Delete Model Constructor
		/// </summary>
		/// <param name="db"></param>
		public DeleteModel(ApplicationDbContext db)
		{
			_db = db;
		}

		/// <summary>
		/// Run when the page load happens fetches the desired category to be edited
		/// </summary>
		/// <param name="id"></param>
		public void OnGet(int id)
		{
			FoodType = _db.FoodType.Find(id);
			//Category = _db.Category.FirstOrDefault(u=>u.Id==id);
			//Category = _db.Category.SingleOrDefault(u=>u.Id==id);
			//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
		}

		/// <summary>
		/// On Click event used to save changes to the Database
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPost()
		{
			var foodTypeFromDb = _db.FoodType.Find(FoodType.Id);
			if (foodTypeFromDb != null)
			{
				_db.FoodType.Remove(foodTypeFromDb);
				await _db.SaveChangesAsync();
				TempData["success"] = "FoodType deleted successfully";
				return RedirectToPage("Index");

			}

			return Page();
		}
	}
}
