using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class LookupDetailsResponseObj
    {
        public LookupViewmodel Lookup { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
   
}