using System.Linq.Expressions;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities.BaseEntities;

namespace BeFast.Application.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<ErroOr<List<TEntity>>> GetByPredicate(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<ErroOr<List<TEntity>>> GetAll();
        Task<ErroOr<TEntity>> GetById(Guid id);
        Task<ErroOr<TEntity>> Add(TEntity item);
        Task<ErroOr<TEntity>> Update(TEntity item);
        Task<ErroOr<bool>> Remove(Guid id);
        Task<ErroOr<bool>> ChangeStaus(Guid id, bool status);
    }
}