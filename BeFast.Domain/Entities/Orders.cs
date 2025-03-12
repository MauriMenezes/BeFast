using System;
using System.Collections.Generic;
using BeFast.Domain.Enums;

namespace BeFast.Domain.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }

        public User Customer { get; set; }
        public int CustomerId { get; set; }

        public Restaurants Restaurant { get; set; }
        public int RestaurantId { get; set; }

        public User DeliveryPerson { get; set; }
        public int? DeliveryPersonId { get; set; }
    }
}