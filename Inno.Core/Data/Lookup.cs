using System;
using System.Collections.Generic;

namespace Inno.Core.Data
{
    public partial class Lookup:BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> LookupCategoryID { get; set; }
        public bool IsActive { get; set; }
    }

}

