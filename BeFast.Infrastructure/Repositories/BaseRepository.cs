using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Interfaces;
using BeFast.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeFast.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetByPredicate(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(x => x.IsActive).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
            if (entity == null) throw new Exception("Registro não encontrado!");
            return entity;
        }

        public virtual async Task<T> CreateAsync(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
            return item;
        }


        public virtual async Task<T> UpdateAsync(T entity)
        {
            var trackedEntity = _context.Set<T>().Local.FirstOrDefault(e => e.Id == entity.Id);
            if (trackedEntity != null)
            {
                _context.Entry(trackedEntity).State = EntityState.Detached;
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdatePartialAsync(Guid id, Action<T> updateAction)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null) throw new Exception("Registro não encontrado!");

            updateAction(entity);

            await _context.SaveChangesAsync();

            return entity;
        }


        public virtual async Task RemoveAsync(Guid id)
        {
            await this.ChangeStaus(id, false);
        }

        public async Task ChangeStaus(Guid id, bool status)
        {
            var entity = await _context.Set<T>().IgnoreQueryFilters().FirstOrDefaultAsync(e => e.Id == id);

            if (entity is null) throw new Exception("Registro não encontrado!");

            entity.IsActive = status;

            await _context.SaveChangesAsync();

        }

        public IQueryable<T> Get() => Get(true);

        public IQueryable<T> Get(bool isNoTracking)
        {
            return (isNoTracking) ? _dbSet.AsNoTracking() : _dbSet.AsQueryable();
        }

        public IQueryable<T> Get(bool isNoTracking, params Expression<Func<T, object>>[] includeProperties)
        {
            return includeProperties
            .Aggregate(
              Get(isNoTracking),
              (current, include) => current.Include(include));
        }
    }
}