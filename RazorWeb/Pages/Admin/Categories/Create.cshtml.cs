using DatabaseAccess.DataConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;


namespace RazorWeb.Pages.Admin.Categories
{
	[BindProperties]
	public class CreateModel : PageModel
    {
		/// <summary>
		/// Application DB Context used for injecting database object
		/// </summary>
		private readonly ApplicationDbContext _db;

		/// <summary>
		/// Category label used for 2-way binding
		/// </summary>
		public Category Category { get; set; }

		/// <summary>
		/// Constructor for injecting DB object
		/// </summary>
		/// <param name="db"></param>
        public CreateModel(ApplicationDbContext db)
        {
			_db = db;
		}
        public void OnGet()
        {			
		}

		/// <summary>
		/// Add the new category object to the database
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPost()
		{
			if (Category.Name == Category.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
			}
			if (ModelState.IsValid)
			{
				await _db.Category.AddAsync(Category);
				await _db.SaveChangesAsync();
				TempData["success"] = "Category created successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}
