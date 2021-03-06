using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindAsync(long id, bool enableTracking = false);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
                                                bool enableTracking = false);
        void Update(TEntity entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(long id);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
        Task<bool> SaveAsync();
    }
}