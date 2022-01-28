using System;
using System.Collections.Generic;

namespace DBGeneration.Models
{
    public partial class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> UserRoleID { get; set; }
        public bool IsActive { get; set; }
    }
}
