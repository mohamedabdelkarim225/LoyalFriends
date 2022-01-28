using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class LookupCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsManaged { get; set; }
    }
}
