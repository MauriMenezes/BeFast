using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.Domain.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //fk
        public string RestaurantsId { get; set; }
    }
}