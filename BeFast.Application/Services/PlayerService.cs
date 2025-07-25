using AutoMapper;
using BeFast.Application.Interfaces;
using BeFast.Domain.Entities;
using BeFast.Domain.Interfaces;

namespace BeFast.Application.Services
{
    public class PlayerService : BaseService<Player>, IPlayerService
    {
        public PlayerService(IBaseRepository<Player> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
