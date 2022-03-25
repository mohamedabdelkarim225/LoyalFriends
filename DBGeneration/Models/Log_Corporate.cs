using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class Log_Corporate
    {
        public int ID { get; set; }
        public Nullable<int> CorporateID { get; set; }
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
        public string Action { get; set; }
        public Nullable<int> ActionBy { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
    }
}
