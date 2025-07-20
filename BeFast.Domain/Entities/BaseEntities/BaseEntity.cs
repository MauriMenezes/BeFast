using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.CrossCutting.Helpers;

namespace BeFast.Domain.Entities.BaseEntities
{
    public class BaseEntity : Base
    {
        public string? CreatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public BaseEntity()
        {
            CreatedBy = String.Empty;
            CreatedById = Guid.Empty;
            CreatedAt = DateTimeHelper.GetBrasiliaDateTime();
            IsActive = true;
        }
    }
}