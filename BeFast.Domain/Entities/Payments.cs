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
        public PaymentStatus PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        //fk
        public int OrdersId { get; set; }


    }
}