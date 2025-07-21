using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities;
using BeFast.Domain.Interfaces;
using BeFast.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeFast.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        protected readonly AppDbContext _context;
        protected readonly DbSet<User> _dbSet;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task<ErroOr<User>> GetByEmail(string email)
        {

            var user = await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return new ErroOr<User>("User not found");
            }
            return new ErroOr<User>(user);
        }
    }
}