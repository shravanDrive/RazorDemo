using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Customer.Home
{
	/// <summary>
	/// Index Model for home Page in Customer Login
	/// </summary>
    public class IndexModel : PageModel
    {
		/// <summary>
		/// IUnit of work for conversations with the database
		/// </summary>
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// Constructor Dependency Injection
		/// </summary>
		/// <param name="unitOfWork"></param>
		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// MenuListItem and CategoryList used to get the data of menu and category
		/// </summary>
		public IEnumerable<MenuItem> MenuItemList { get; set; }
		public IEnumerable<Category> CategoryList { get; set; }

		public void OnGet()
		{
			MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
			CategoryList = _unitOfWork.Category.GetAll();
		}


	}
}
