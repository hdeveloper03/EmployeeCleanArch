using System;

namespace Employee.Core.Common
{
    public abstract class EntityBase
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
