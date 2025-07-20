using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeFast.Application.Interfaces;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Interfaces;


namespace BeFast.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }
    }
}