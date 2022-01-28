using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class UserLoginResponseObj
    {
        public string status { get; set; }
        public string error { get; set; }
        public UserObj User { get; set; }
    }
    public class UserObj
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}