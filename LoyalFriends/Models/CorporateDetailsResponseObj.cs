using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class CorporateDetailsResponseObj
    {
        public CorporateViewModel Corporate { get; set; }
        public List<CorporateHistoryviewModel> History { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
    public class CorporateHistoryviewModel
    {
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}