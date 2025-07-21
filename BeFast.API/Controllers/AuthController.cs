using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Application.DTOs;
using BeFast.Application.DTOs.User;
using BeFast.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeFast.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] loginDto loginDto)
        {
            var result = await _authService.Authenticate(loginDto);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var result = await _authService.Register(userDto);

            if (result.IsSuccess)
                return CreatedAtAction(nameof(Login), new { email = userDto.Email }, result.Result);

            return BadRequest(result.Error);

        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Autenticado");
        }

    }
}