using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
     public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime Updated { get; set; }
    }
}
