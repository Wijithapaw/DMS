using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Domain.Entities
{
    public class BaseEntity
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
