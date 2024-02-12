using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
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
		//private readonly ApplicationDbContext _db;

		/// <summary>
		/// _dbCategory used instead of AppliactionDbContext
		/// </summary>
		//private readonly ApplicationDbContext _db;
		//private readonly ICategoryRepository _dbCategory;
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// Category label used for 2-way binding
		/// </summary>
		public Category Category { get; set; }

		/// <summary>
		/// Constructor for injecting DB object
		/// </summary>
		/// <param name="db"></param>
        public CreateModel(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
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
				_unitOfWork.Category.Add(Category);
				_unitOfWork.Save();
				TempData["success"] = "Category created successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}
