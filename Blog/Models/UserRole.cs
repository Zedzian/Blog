using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class UserRole
    {
        public int RoleId { get; set; }
        public string UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
