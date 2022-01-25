using GCS.Domain.Abstract;
using GCS.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.EntityFramework
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected DbContext _context;
        internal DbSet<TEntity> _dbSet;
        public EfRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
             _dbSet.AddAsync(entity);                      
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteAll(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return  _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                    ? _context.Set<TEntity>().ToList()
                    : _context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
