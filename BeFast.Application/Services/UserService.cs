using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeFast.Application.DTOs;
using BeFast.Application.Interfaces;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace BeFast.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly PasswordHasher<object> _passwordHasher;

        public UserService(IBaseRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<object>();
        }

        public async Task<ErroOr<User>> Register(UserDto dto)
        {
            var hashDaSenha = _passwordHasher.HashPassword(dto, dto.Password);

            var userEntity = _mapper.Map<User>(dto);
            userEntity.PasswordHash = hashDaSenha;
            return await base.Add(userEntity);

        }
        public bool IsPasswordCorrect(User user, string password, string passwordHash)
        {
            var resultado = _passwordHasher.VerifyHashedPassword(user, passwordHash, password);

            if (resultado == PasswordVerificationResult.Success)
                return true;

            return false;
        }
    }
}