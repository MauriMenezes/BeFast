using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Domain.Enums;

namespace BeFast.Application.DTOs
{
    public class UserDto
    {
        public String Name { get; set; } = string.Empty;
        public String Password { get; set; } = string.Empty;
        public String Email { get; set; } = string.Empty;

        public UserType Type { get; set; }
    }
}