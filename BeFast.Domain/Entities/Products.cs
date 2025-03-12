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

        public int RestaurantId { get; set; }
        public Restaurants Restaurant { get; set; }

        public ICollection<OrderItens> OrderItens { get; set; } = new List<OrderItens>();
    }
}