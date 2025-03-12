using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeFast.Domain.Enums;

namespace BeFast.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Orders> CustomerOrders { get; set; } = new List<Orders>();
        public ICollection<Orders> DeliveryOrders { get; set; } = new List<Orders>();
    }
}