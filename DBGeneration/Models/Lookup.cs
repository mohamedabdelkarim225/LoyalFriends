using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class Lookup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> LookupCategoryID { get; set; }
        public bool IsActive { get; set; }
    }
}
