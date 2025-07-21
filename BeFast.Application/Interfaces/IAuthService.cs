
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
        Task<ErroOr<UserResponse>> UserInfo();
    }
}