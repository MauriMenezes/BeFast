using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Enums;

namespace BeFast.Domain.Entities
{
    public class User : BaseEntity
    {
        public UserType Type { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}