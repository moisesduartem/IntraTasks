using IntraTasks.DataAccess.Context;
using IntraTasks.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IntraTasks.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            _context.Set<T>().Add(entity);
        }

        public virtual IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return Get().FirstOrDefault(predicate);
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
