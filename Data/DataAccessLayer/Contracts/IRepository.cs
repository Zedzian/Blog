using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;

namespace Data.DataAccessLayer.Contracts
{
    public interface IRepository<T> where T : EntityBase
	{
		T GetById(int id);

		void Create(T entity);

		void Delete(T entity);

		void Update(T entity);
	}
}
