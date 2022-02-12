using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class LookupViewmodel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string LookupCategoryName { get; set; }
        public Nullable<int> LookupCategoryID { get; set; }
        public string ServiceProviderName { get; set; }
        public Nullable<int> ServiceProviderID { get; set; }
        public string ServiceQuotaName { get; set; }
        public Nullable<int> ServiceQuotaID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedByName { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}