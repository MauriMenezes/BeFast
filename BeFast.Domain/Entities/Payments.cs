using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Domain.Enums;

namespace BeFast.Domain.Entities
{
    public class Payments
    {
        public int Id { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int OrdersId { get; set; }
        public Orders Order { get; set; }
    }
}