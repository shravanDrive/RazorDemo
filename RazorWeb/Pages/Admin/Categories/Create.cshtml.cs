using DatabaseAccess.DataConnection;
using DatabaseAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RazorModels.Model;
using System.Data;


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
        public async void OnGet()
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

		/// <summary>
		/// Experimenting to check on Stored procedure calls from Entity Framework Core
		/// </summary>
		public async void ExpSPCall()
		{
            try
            {
                IEnumerable<Guid> studentIds = new List<Guid>
            {
                Guid.Parse("08BFC8F0-41D8-4490-B507-39911F5AFF0D")  // Example Guid 1
			};

                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(Guid));
                foreach (Guid id in studentIds)
                {
                    table.Rows.Add(id);
                }

                // object[] parameters = table.Cast<object>().ToArray();
                object[] parameters = table.Rows.Cast<DataRow>()
                        .SelectMany(row => row.ItemArray)
                        .ToArray();

                var jsonString = "{\"ID\": \"08BFC8F0-41D8-4490-B507-39911F5AFF0D\"}";
                var studentGuid = JsonConvert.DeserializeObject<StudentGuid>(jsonString);

                var idParam = new SqlParameter("@Student_id_list", studentGuid.ID);

                var output = await _unitOfWork.SpOutput.ExecuteStoredProcedureAsync("getDataFromSP @Student_id_list", idParam);
            }
            catch (Exception ex)
            {

            }
        }
	}
}
