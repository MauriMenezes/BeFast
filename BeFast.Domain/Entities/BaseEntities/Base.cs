using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.Domain.Entities.BaseEntities
{
    public class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}