using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.Application.DTOs.User
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}