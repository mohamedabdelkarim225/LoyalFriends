using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class CorporateViewModel
    {
        public int ID { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyType { get; set; }
        public Nullable<int> LinesNumber { get; set; }
        public Nullable<int> AccountTypeID { get; set; }
        public string AccountType { get; set; }
        public Nullable<int> CustomerStatusID { get; set; }
        public string CustomerStatus { get; set; }
        public Nullable<int> RequestTypeID { get; set; }
        public string RequestType { get; set; }
        public string Comment { get; set; }
        public string ContactDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public string ModifiedOn { get; set; }

    }
}