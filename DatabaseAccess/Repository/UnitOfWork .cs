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
	/// Unit of work implmementation to segregate and collect all iRepositories
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// Application Db Context to talk to the database
		/// </summary>
		private readonly ApplicationDbContext _db;
		/// <summary>
		/// Constructor used.
		/// </summary>
		/// <param name="db"></param>
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
			FoodType = new FoodTypeRepository(_db);
			MenuItem = new MenuItemRepository(_db);
		}

		/// <summary>
		/// Accordingly you can list out every table repository over here
		/// </summary>
		public ICategoryRepository Category { get; private set; }

		/// <summary>
		/// listing out all repositories
		/// </summary>
		public IFoodTypeRepository FoodType { get; private set; }

		/// <summary>
		/// MenuItemRepository 
		/// </summary>
		public IMenuItemRepository MenuItem { get; private set; }

		/// <summary>
		/// to delte object
		/// </summary>
		public void Dispose()
		{
			_db.Dispose();
		}

		/// <summary>
		/// to save change to DB since save change method always remians the same
		/// </summary>
		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
