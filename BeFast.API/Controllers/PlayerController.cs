using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeFast.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("GetPlayer")]
        public IActionResult get()
        {
            return Ok();
        }


    }
}