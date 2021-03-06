using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces;

namespace Travely.ServiceManager.DAL.Repositories
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ServiceManagerDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ServiceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public virtual TEntity Create(TEntity entity)
        {
            var dbEntity = _dbSet.Add(entity);
            return dbEntity.Entity;
        }

        public virtual async Task DeleteAsync(long entityId)
        {
            var entity = await _dbSet.FindAsync(entityId);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(long entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
