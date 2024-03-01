using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Admin.Categories
{
	[BindProperties]
	public class EditModel : PageModel
    {
		//private readonly ApplicationDbContext _db;
		private readonly IUnitOfWork _unitOfWork;
		public Category Category { get; set; }
		public EditModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void OnGet(int id)
		{
			Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
			//Category = _db.Category.FirstOrDefault(u=>u.Id==id);
			//Category = _db.Category.SingleOrDefault(u=>u.Id==id);
			//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
		}

		public async Task<IActionResult> OnPost()
		{
			if (Category.Name == Category.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
			}
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Update(Category);
				_unitOfWork.Save();
				TempData["success"] = "Category updated successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}

		//public IActionResult OnPostIncrement()
		//{
		//	return Page();
		//}
	}
}
