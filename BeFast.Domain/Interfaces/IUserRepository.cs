using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities;

namespace BeFast.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<ErroOr<User>> GetByEmail(string email);
    }
}