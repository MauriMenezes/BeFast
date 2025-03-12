using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.Domain.Entities
{
    public class Restaurants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Opening_hours { get; set; }

        // fk
        public int UserId { get; set; }
    }
}