using System;

namespace DMS.Data.Entities
{
    public class BaseEntity
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
