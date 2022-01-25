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
        public async Task<bool> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return true;           
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteAll(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return true;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                    ? await _context.Set<TEntity>().ToListAsync()
                    : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
