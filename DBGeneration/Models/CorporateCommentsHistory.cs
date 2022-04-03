using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class CorporateCommentsHistory
    {
        public long ID { get; set; }
        public Nullable<long> CorporateID { get; set; }
        public string Comment { get; set; }
        public string Action { get; set; }
        public Nullable<int> ActionBy { get; set; }
        public Nullable<System.DateTime> ActionOn { get; set; }
    }
}
