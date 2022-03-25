using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class CustomerStatusHistory
    {
        public int ID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CustomerStatusID { get; set; }
        public string Action { get; set; }
        public Nullable<int> ActionBy { get; set; }
        public Nullable<System.DateTime> ActionOn { get; set; }
    }
}
