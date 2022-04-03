using System;
using System.Collections.Generic;

namespace Inno.Core.Data
{
    public partial class CorporateStatusHistory:BaseEntity
    {
        public long ID { get; set; }
        public Nullable<long> CorporateID { get; set; }
        public Nullable<int> CustomerStatusID { get; set; }
        public string Action { get; set; }
        public Nullable<int> ActionBy { get; set; }
        public Nullable<System.DateTime> ActionOn { get; set; }
    }
}
