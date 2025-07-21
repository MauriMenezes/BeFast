using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Application.DTOs;
using BeFast.Application.DTOs.User;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities;

namespace BeFast.Application.Interfaces
{
    public interface IAuthService : IBaseService<User>
    {
        Task<ErroOr<User>> Register(UserDto user);
        Task<ErroOr<string>> Authenticate(loginDto login);
    }
}