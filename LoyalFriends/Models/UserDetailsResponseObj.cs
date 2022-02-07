using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class UserDetailsResponseObj
    {
        public UserViewModel User { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
   
}