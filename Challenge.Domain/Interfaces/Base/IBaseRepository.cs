using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Interfaces.Base
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		TEntity Select(int id);
		IQueryable<TEntity> Select();
		IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Remove(TEntity entity);
	}
}
