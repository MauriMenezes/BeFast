using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Domain.Entities.BaseEntities;

namespace BeFast.Domain.Entities
{
    public class TeamFormation : BaseEntity
    {
        public Guid GameId { get; set; } = Guid.NewGuid();
        public Game Game { get; set; } = null!;
        public Guid TeamId { get; set; } = Guid.NewGuid();
        public Team Team { get; set; } = null!;
        public List<Player> Players { get; set; } = new List<Player>();
    }
}