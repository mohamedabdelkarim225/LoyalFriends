using System;
using System.Collections.Generic;

namespace Inno.Core.Data
{
    public partial class CustomerStatusHistory:BaseEntity
    {
        public long ID { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public Nullable<int> CustomerStatusID { get; set; }
        public string Action { get; set; }
        public Nullable<int> ActionBy { get; set; }
        public Nullable<System.DateTime> ActionOn { get; set; }
    }
}
