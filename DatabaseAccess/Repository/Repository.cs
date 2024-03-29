﻿using DatabaseAccess.DataConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repository
{
	/// <summary>
	/// Implementation of Repository Class
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Repository<T> : IRepository<T> where T: class
	{
		/// <summary>
		/// application DB Context for dependency injection
		/// </summary>
		private readonly ApplicationDbContext _db;

		/// <summary>
		/// DbSet property for calling the DB
		/// </summary>
		internal DbSet<T> dbSet;

		/// <summary>
		/// Constructor implementation
		/// </summary>
		/// <param name="db"></param>
		public Repository(ApplicationDbContext db)
        {
			_db = db;
			//FoodType,Category
			//_db.MenuItem.Include(u => u.FoodType).Include(u => u.Category);
			//_db.MenuItem.OrderBy(u => u.Name);
			this.dbSet = db.Set<T>();
		}

		/// <summary>
		/// Add entity of the Db Set
		/// </summary>
		/// <param name="entity"></param>
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		/// <summary>
		/// Gets all of the data from the table specified
		/// </summary>
		/// <returns></returns>
		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}

		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (includeProperties != null)
			{
				//abc,,xyz -> abc xyz
				foreach (var includeProperty in includeProperties.Split(
					new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}

			return query.ToList();
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (includeProperties != null)
			{
				//abc,,xyz -> abc xyz
				foreach (var includeProperty in includeProperties.Split(
					new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}
			if (orderby != null)
			{
				return orderby(query).ToList();
			}
			return query.ToList();
		}

		/// <summary>
		/// Gets the first value out based on the filter condition
		/// dataset.where(x=>x.id == id).firstOrDefault() is done in the below code
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return query.FirstOrDefault();
		}

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync(string storedProcedureName, params object[] parameters)
        {
            return await _db.Set<T>().FromSqlRaw(storedProcedureName, parameters).ToListAsync();
        }

        /// <summary>
        /// Deletes the record
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		/// <summary>
		/// Deletes multiple records based on given condition
		/// </summary>
		/// <param name="entity"></param>
		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}
