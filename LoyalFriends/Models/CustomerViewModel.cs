using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class CustomerViewModel
    {
        public int ID { get; set; }
        public string RequestNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Central { get; set; }
        public string ContactDate { get; set; }
        public string FixedLine { get; set; }
        public string NearestFixedLine { get; set; }
        public Nullable<int> GovernorateID { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string SpecialMark { get; set; }
        public string Mobile { get; set; }
        public string NationalId { get; set; }
        public Nullable<int> OfferID { get; set; }
        public string Offer { get; set; }
        public Nullable<int> ServiceProviderID { get; set; }
        public string ServiceProvider { get; set; }
        public Nullable<int> ServiceQuotaID { get; set; }
        public string ServiceQuota { get; set; }
        public Nullable<int> CustomerStatusID { get; set; }
        public string CustomerStatus { get; set; }
        public Nullable<int> RequestTypeID { get; set; }
        public string RequestType { get; set; }
        public Nullable<int> RouterTypeID { get; set; }
        public string RouterType { get; set; }
        public Nullable<int> RouterDeliveryMethodID { get; set; }
        public string RouterDeliveryMethod { get; set; }
        public Nullable<int> CustomerTypeID { get; set; }
        public string CustomerType { get; set; }
        public string Comment { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public string ModifiedOn { get; set; }
    }
}