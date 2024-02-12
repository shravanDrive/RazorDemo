using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Admin.FoodTypes
{
	public class IndexModel : PageModel
	{
		//private readonly ApplicationDbContext _db;
		private readonly IUnitOfWork _unitOfWork;
		public IEnumerable<FoodType> FoodTypes { get; set; }
		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void OnGet()
		{
			FoodTypes = _unitOfWork.FoodType.GetAll();
		}
	}
}
