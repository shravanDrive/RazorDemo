using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repository
{
	/// <summary>
	/// Adding all generic methods inside IRepository
	/// Get All, Get By ID or First or Default, ADD, REmove, RemoveRange
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : class
	{
		/// <summary>
		/// Generic method to add the data in DB
		/// </summary>
		/// <param name="entity"></param>
		void Add(T entity);
		/// <summary>
		/// Generic method to remove the data from DB
		/// </summary>
		/// <param name="entity"></param>
		void Remove(T entity);
		/// <summary>
		/// Generic method to remove more than one object in DB
		/// </summary>
		/// <param name="entity"></param>
		void RemoveRange(IEnumerable<T> entity);
		/// <summary>
		/// Get All will return all of the records from the database
		/// </summary>
		/// <returns>return type is iEnumerable just because it returns more than one object</returns>
		IEnumerable<T> GetAll();
		/// <summary>
		/// Defines what are the properties that you want to include when we are getting all the results back
		/// </summary>
		/// <param name=""></param>
		/// <param name=""></param>
		/// <returns></returns>
		IEnumerable<T> GetAll(string? includeProperties=null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="orderby"></param>
		/// <param name="includeProperties"></param>
		/// <returns></returns>
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, 
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, 
			string? includeProperties = null);
		/// <summary>
		/// Getting the first or default record back to the user
		/// </summary>
		/// <param name="filter">of type expression so that we can add .SingleOrDefault(x=>x.id==id) in the argument</param>
		/// <returns></returns>
		T GetFirstOrDefault(Expression<Func<T,bool>>? filter=null);

	}
}
