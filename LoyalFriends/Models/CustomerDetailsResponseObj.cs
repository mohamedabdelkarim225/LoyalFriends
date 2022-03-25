using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class CustomerDetailsResponseObj
    {
        public CustomerViewModel Customer { get; set; }
        public List<CustomerCommentsHistoryviewModel> CommentsHistory { get; set; }
        public List<CustomerStatusHistoryviewModel> StatusHistory { get; set; }
        public List<CustomerRejectedReasonHistoryviewModel> RejectedReasonHistory { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
    public class CustomerCommentsHistoryviewModel
    {
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
    public class CustomerStatusHistoryviewModel
    {
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
    public class CustomerRejectedReasonHistoryviewModel
    {
        public string RejectedReason { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}