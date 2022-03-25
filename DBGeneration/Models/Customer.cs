using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class Customer
    {
        public int ID { get; set; }
        public string RequestNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Central { get; set; }
        public Nullable<System.DateTime> ContactDate { get; set; }
        public string FixedLine { get; set; }
        public string NearestFixedLine { get; set; }
        public Nullable<int> GovernorateID { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string SpecialMark { get; set; }
        public string Mobile { get; set; }
        public string NationalId { get; set; }
        public Nullable<int> OfferID { get; set; }
        public Nullable<int> ServiceProviderID { get; set; }
        public Nullable<int> ServiceQuotaID { get; set; }
        public Nullable<int> CustomerStatusID { get; set; }
        public Nullable<int> RequestTypeID { get; set; }
        public Nullable<int> RouterTypeID { get; set; }
        public Nullable<int> RouterDeliveryMethodID { get; set; }
        public Nullable<int> CustomerTypeID { get; set; }
        public string Comment { get; set; }
        public string RejectedReason { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
