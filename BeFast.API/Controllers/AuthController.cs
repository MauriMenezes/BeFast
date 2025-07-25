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

        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] loginDto loginDto)
        {
            var result = await _authService.Authenticate(loginDto);

            if (!result.IsSuccess)
                return BadRequest(new ProblemDetails
                {
                    Title = "Erro ao realizar login",
                    Detail = result.Error,
                    Status = StatusCodes.Status400BadRequest
                });

            return Ok(result.Result);

        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var result = await _authService.Register(userDto);

            if (result.IsSuccess)
                return BadRequest(new ProblemDetails
                {
                    Title = "Erro ao registar o Usuario",
                    Detail = result.Error,
                    Status = StatusCodes.Status400BadRequest

                });

            return Ok();


        }

        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetUserInfo()
        {
            var result = await _authService.UserInfo();

            if (result.IsSuccess)
                return BadRequest(new ProblemDetails
                {
                    Title = "Erro ao Buscar Info do Usuario",
                    Detail = result.Error,
                    Status = StatusCodes.Status400BadRequest
                }
                );

            return Ok(result);
        }


        [Authorize(Roles = "Customer")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Autenticado");
        }



    }
}