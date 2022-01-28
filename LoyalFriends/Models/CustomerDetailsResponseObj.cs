using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class CustomerDetailsResponseObj
    {
        public CustomerViewModel Customer { get; set; }
        public List<CustomerHistoryviewModel> History { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
    public class CustomerHistoryviewModel
    {
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}