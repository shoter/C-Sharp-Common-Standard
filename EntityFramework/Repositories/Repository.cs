using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Standard.EntityFramework.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            dbSet = context.Set<T>();
        }

        async public Task<T> FirstAsync()
        {
            return await dbSet.FirstAsync();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

    }
}
