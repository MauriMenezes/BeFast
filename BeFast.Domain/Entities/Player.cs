using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Domain.Entities.BaseEntities;

namespace BeFast.Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Position { get; set; } = string.Empty;
        public int Age { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;

    }
}