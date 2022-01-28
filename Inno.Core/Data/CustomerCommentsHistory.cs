using System;
using System.Collections.Generic;

namespace Inno.Core.Data
{
    public partial class CustomerCommentsHistory:BaseEntity
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
