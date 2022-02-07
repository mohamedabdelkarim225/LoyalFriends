using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class UserListResponseObj
    {
        public List<UserViewModel> Users { get; set; }
        public int TotalCount { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }
   
}
