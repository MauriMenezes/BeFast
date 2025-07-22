using System.ComponentModel.DataAnnotations.Schema;
using BeFast.Domain.Entities.BaseEntities;
using BeFast.Domain.Enums;

namespace BeFast.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public DateTime StartDate { get; set; }
    }
}