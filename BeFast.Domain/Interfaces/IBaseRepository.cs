using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeFast.Domain.Entities.BaseEntities;

namespace BeFast.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetByPredicate(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> UpdatePartialAsync(Guid id, Action<T> updateAction);
        Task RemoveAsync(Guid id);
        Task ChangeStaus(Guid id, bool status);
        IQueryable<T> Get();
        IQueryable<T> Get(bool isNoTracking);
        IQueryable<T> Get(bool isNoTracking, params Expression<Func<T, object>>[] includeProperties);
    }
}