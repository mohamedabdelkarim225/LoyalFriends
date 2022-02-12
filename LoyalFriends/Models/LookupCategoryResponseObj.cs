using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class LookupCategoryResponseObj
    {
        public string status { get; set; }
        public string error { get; set; }
        public List<LookupObj> Categories { get; set; }
    }
}