using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyalFriends.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public Nullable<int> UserRoleID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedByName { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}