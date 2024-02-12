using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Admin.Categories
{
	[BindProperties]
	public class DeleteModel : PageModel
    {
		//private readonly ApplicationDbContext _db;
		private readonly IUnitOfWork _unitOfWork;
		public Category Category { get; set; }
		public DeleteModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void OnGet(int id)
		{
			Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
			//Category = _db.Category.Find(id);
			//Category = _db.Category.FirstOrDefault(u=>u.Id==id);
			//Category = _db.Category.SingleOrDefault(u=>u.Id==id);
			//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
		}

		public async Task<IActionResult> OnPost()
		{
			var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
			if (categoryFromDb != null)
			{
				_unitOfWork.Category.Remove(categoryFromDb);
				_unitOfWork.Save();
				TempData["success"] = "Category deleted successfully";
				return RedirectToPage("Index");
			}

			return Page();
		}
	}
}
