using RazorModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repository
{
	/// <summary>
	/// Interface for the Category table in DB
	/// </summary>
	public interface ICategoryRepository : IRepository<Category>
	{
		/// <summary>
		/// Update has been specifically added and not made in generic class
		/// </summary>
		/// <param name="category"></param>
		void Update(Category category);
		//void Save();
	}
}
