using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class CustomerListResponseObj
    {
        public List<CustomerViewModel> Customers { get; set; }
        public int TotalCount { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
   
}
