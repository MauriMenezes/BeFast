using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Domain.Entities.BaseEntities;

namespace BeFast.Domain.Entities
{
    public class PlayerAttendance : BaseEntity
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;
        public bool IsPresent { get; set; }
    }
}