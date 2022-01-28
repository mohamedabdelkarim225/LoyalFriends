using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class CustomerCommentsHistory
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
