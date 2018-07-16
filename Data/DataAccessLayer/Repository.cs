using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Context;
using Data.DataAccessLayer.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccessLayer
{
	public class Repository<T> : IRepository<T> where T : EntityBase
	{
		private BlogContext context;

		public Repository(BlogContext context)
		{
			this.context = context;
		}

		public virtual void Create(T entity)
		{
			context.Set<T>().Add(entity);
		}

		public virtual void Delete(T entity)
		{
			context.Set<T>().Remove(entity);
		}

		public T GetById(int id)
		{

			T query = context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
			return query;
		}

		public virtual void Update(T entity)
		{
			context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Save()
		{
			context.SaveChanges();
		}
	}
}
