using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Application.DTOs;
using BeFast.Application.Interfaces;
using BeFast.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeFast.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] UserDto user)
        {
            var result = await _userService.Register(user);
            if (result.IsSuccess)
                return Created();

            return BadRequest(result.Error);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user.Result);
        }
    }
}