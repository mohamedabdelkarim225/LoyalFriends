﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class LookupListResponseObj
    {
        public List<LookupViewmodel> Lookups { get; set; }
        public int TotalCount { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
   
}
