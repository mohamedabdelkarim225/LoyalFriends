using System;
using System.Collections.Generic;

namespace Inno.Core.Data
{
    public partial class LookupCategory:BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsManaged { get; set; }
    }
}
