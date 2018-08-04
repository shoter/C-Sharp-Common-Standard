using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Standard.EntityFramework.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            dbSet = context.Set<TEntity>();
        }

        async public Task<TEntity> FirstAsync()
        {
            return await dbSet.FirstAsync();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.First(predicate);
        }

        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.FirstAsync(predicate);
        }

        public IQueryable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return dbSet.OrderBy(keySelector);
        }

        public IQueryable<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return dbSet.OrderByDescending(keySelector);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
    }
}
