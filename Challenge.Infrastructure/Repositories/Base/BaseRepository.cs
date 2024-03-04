using Challenge.Domain.Interfaces.Base;
using Challenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Challenge.Infrastructure.Repositories.Base
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		private readonly SqliteContext _context;


		public BaseRepository(SqliteContext context)
		{
			_context = context;
		}

		public TEntity Select(int id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		public IQueryable<TEntity> Select()
		{
			return _context.Set<TEntity>().AsQueryable();
		}

		public IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Set<TEntity>().Where(predicate).AsQueryable();
		}

		public void Add(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			_context.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			_context.SaveChanges();
		}

		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			_context.SaveChanges();
		}
	}
}
