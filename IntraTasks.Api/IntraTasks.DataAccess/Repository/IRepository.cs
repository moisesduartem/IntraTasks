using System;
using System.Linq;
using System.Linq.Expressions;

namespace IntraTasks.DataAccess.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetByCondition(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
