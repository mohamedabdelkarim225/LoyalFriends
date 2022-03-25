using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class Corporate
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
        public Nullable<int> CustomerStatusID { get; set; }
        public Nullable<int> RequestTypeID { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> ContactDate { get; set; }
        public string RejectedReason { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
