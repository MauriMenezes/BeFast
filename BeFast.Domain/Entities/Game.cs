using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Enums;

namespace BeFast.Domain.Entities
{
    public class Game : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public List<Player> Players { get; set; } = new List<Player>();
        public GameStatus Status { get; set; } = GameStatus.Scheduled;
    }
}