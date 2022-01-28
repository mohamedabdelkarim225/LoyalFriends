using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class LookupResponseObj
    {
        public string status { get; set; }
        public string error { get; set; }
        public LookupsList Lookups { get; set; }
    }
    public class LookupObj
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class LookupsList
    {
        public List<LookupObj> Governorate { get; set; }
        public List<LookupObj> Offer { get; set; }
        public List<LookupObj> ServiceProvider { get; set; }
        public List<LookupObj> CustomerStatus { get; set; }
        public List<LookupObj> RouterType { get; set; }
        public List<LookupObj> RouterDeliveryMethod { get; set; }
        public List<LookupObj> CustomerType { get; set; }
        public List<LookupObj> ServiceQuota { get; set; }
        public List<LookupObj> AccountType { get; set; }
    }
}