using AutoMapper;
using BeFast.Application.DTOs;
using BeFast.Domain.Entities;

namespace BeFast.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
