using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Standard.EntityFramework.Repositories
{
    public interface IRepository
    {

    }

    public interface IRepository<T> : IRepository
        where T : class, IEntity
    {
        Task<T> FirstAsync();

        void Add(T entity);
    }
}
