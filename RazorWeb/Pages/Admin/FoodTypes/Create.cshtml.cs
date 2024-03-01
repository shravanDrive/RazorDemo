using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Admin.FoodTypes
{
	/// <summary>
	/// Create Model for FoodTypes
	/// </summary>
	[BindProperties]
	public class CreateModel : PageModel
    {
		/// <summary>
		/// Application DB context instance for database connection
		/// </summary>
		//private readonly ApplicationDbContext _db;
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// 2 way Binding property of FoodType
		/// </summary>
		public FoodType FoodType { get; set; }

		/// <summary>
		/// Constructor used for dependency injection
		/// </summary>
		/// <param name="db"></param>
		public CreateModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Run at when the page loads
		/// </summary>
		public void OnGet()
        {
            
        }

		/// <summary>
		/// On click event save the changes to the database
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPost()
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.FoodType.Add(FoodType);
				_unitOfWork.Save();
				TempData["success"] = "FoodType created successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}
