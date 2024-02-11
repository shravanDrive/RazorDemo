using DatabaseAccess.DataConnection;
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
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }

        /// <summary>
        /// Constructor used to inject value
        /// </summary>
        /// <param name="db"></param>
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// On page load this function would run
        /// </summary>
        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
