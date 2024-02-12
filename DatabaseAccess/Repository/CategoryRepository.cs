using DatabaseAccess.DataConnection;
using RazorModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repository
{
	/// <summary>
	/// First it implements Repository<Category> class file provided to show which table are we talking about
	/// and also implements iCategoryRepository for the update method
	/// </summary>
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		/// <summary>
		/// DbContext for talking with the DB
		/// </summary>
		private readonly ApplicationDbContext _db;

		/// <summary>
		/// Constructor used for dependency injection
		/// </summary>
		/// <param name="db"></param>
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		/// <summary>
		/// used to save changes to the DB
		/// </summary>
		//public void Save()
		//{
		//	_db.SaveChanges();
		//}

		/// <summary>
		/// Used to retrieve one value based on the category object and then make changes to it
		/// </summary>
		/// <param name="category"></param>
		public void Update(Category category)
		{
			var objFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
			objFromDb.Name = category.Name;
			objFromDb.DisplayOrder = category.DisplayOrder;
		}
	}
}
