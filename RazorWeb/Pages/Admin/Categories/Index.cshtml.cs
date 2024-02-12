using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels.Model;

namespace RazorWeb.Pages.Admin.Categories
{
    /// <summary>
    /// IndexModel for Categories table
    /// </summary>
    public class IndexModel : PageModel
    {
		/// <summary>
		/// 
		/// </summary>
		//private readonly ApplicationDbContext _db;
		//private readonly ICategoryRepository _dbCategory;
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// Categories
		/// </summary>
		public IEnumerable<Category> Categories { get; set; }

        /// <summary>
        /// Constructor used to inject value
        /// </summary>
        /// <param name="db"></param>
        public IndexModel(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

        /// <summary>
        /// On page load this function would run
        /// </summary>
        public void OnGet()
        {
			Categories = _unitOfWork.Category.GetAll();
		}
    }
}
