using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class CorporateDetailsResponseObj
    {
        public CorporateViewModel Corporate { get; set; }
        public List<CorporateCommentsHistoryviewModel> CommentsHistory { get; set; }
        public List<CorporateStatusHistoryviewModel> StatusHistory { get; set; }
        public List<CorporateRejectedReasonHistoryviewModel> RejectedReasonHistory { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
    public class CorporateCommentsHistoryviewModel
    {
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
    public class CorporateStatusHistoryviewModel
    {
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
    public class CorporateRejectedReasonHistoryviewModel
    {
        public string RejectedReason { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}