using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BeFast.Application.DTOs;
using BeFast.Application.DTOs.User;
using BeFast.Application.Interfaces;
using BeFast.CrossCutting.extension;
using BeFast.Domain.Entities;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace BeFast.Application.Services
{
    public class AuthService : BaseService<User>, IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<object> _passwordHasher;

        private readonly IConfiguration _configuration;

        public AuthService(IBaseRepository<User> repository, IMapper mapper, IUserRepository userRepository, IConfiguration configuration) : base(repository, mapper)
        {

            _mapper = mapper;
            _passwordHasher = new PasswordHasher<object>();
            _userRepository = userRepository;
            _configuration = configuration;
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

        public async Task<ErroOr<string>> Authenticate(loginDto login)
        {
            var user = await _userRepository.GetByEmail(login.Email);

            if (user.Result is null || !IsPasswordCorrect(user.Result, login.Password, user.Result.PasswordHash))
            {
                return ErroOr<string>.Failure("Email ou senha inválidos");
            }
            string token = GenerateToken(user.Result);

            return ErroOr<string>.Success(token);
        }

        private string GenerateToken(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSettings:SecretKey")));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JwtSettings:Issuer"),
                audience: _configuration.GetValue<string>("JwtSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}