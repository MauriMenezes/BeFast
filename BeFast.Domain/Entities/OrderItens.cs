using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.Domain.Entities
{
    public class OrderItens
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }


        public int OrderId { get; set; }
        public Orders Order { get; set; }

        public int ProductId { get; set; }
        public Products Product { get; set; }
    }
}