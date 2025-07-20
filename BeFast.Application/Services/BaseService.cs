using BeFast.Application.Interfaces;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Interfaces;
using System.Linq.Expressions;
using AutoMapper;
using BeFast.CrossCutting.Extension;



namespace BeFast.Application.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErroOr<List<TEntity>>> GetByPredicate(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                var entities = await _repository.GetByPredicate(predicate, includeProperties);
                var response = _mapper.Map<List<TEntity>>(entities);
                return ErroOr<List<TEntity>>.Success(response);
            }
            catch (Exception ex)
            {
                return ex.ToErroOrFailure<List<TEntity>>("Falha na busca dos registros!");
            }
        }

        public async Task<ErroOr<List<TEntity>>> GetAll()
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                var response = _mapper.Map<List<TEntity>>(entities);
                return ErroOr<List<TEntity>>.Success(response);
            }
            catch (Exception ex)
            {
                return ex.ToErroOrFailure<List<TEntity>>("Falha ao buscar todos os registros!");
            }
        }

        public async Task<ErroOr<TEntity>> GetById(Guid id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);

                if (entity is null)
                    return ErroOr<TEntity>.Failure("Registro não encontrado!");

                var response = _mapper.Map<TEntity>(entity);

                return ErroOr<TEntity>.Success(response);
            }
            catch (Exception ex)
            {
                return ex.ToErroOrFailure<TEntity>("Falha ao buscar o registro!");
            }
        }

        public async Task<ErroOr<TEntity>> Add(TEntity item)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(item);
                await _repository.CreateAsync(entity);
                return ErroOr<TEntity>.Success(_mapper.Map<TEntity>(entity));
            }
            catch (Exception ex)
            {
                return ex.ToErroOrFailure<TEntity>("Falha ao adicionar o registro!");
            }
        }

        public async Task<ErroOr<TEntity>> Update(TEntity item)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(item);
                await _repository.UpdateAsync(entity);
                return ErroOr<TEntity>.Success(_mapper.Map<TEntity>(entity));
            }
            catch (Exception ex)
            {
                return ex.ToErroOrFailure<TEntity>("Falha ao atualizar o registro!");
            }
        }

        public async Task<ErroOr<bool>> Remove(Guid id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    return ErroOr<bool>.Failure("Registro não encontrado!");

                await _repository.RemoveAsync(id);
                return ErroOr<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ex.ToErroOrFailure<bool>("Falha ao remover o registro!");
            }
        }

        public async Task<ErroOr<bool>> ChangeStaus(Guid id, bool status)
        {
            try
            {
                await _repository.ChangeStaus(id, status);
                return ErroOr<bool>.Success(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar status do registro!", ex);
            }
        }

        public IQueryable<TEntity> Get() => _repository.Get();

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties) => _repository.Get(true, includeProperties).Where(filter);
    }
}