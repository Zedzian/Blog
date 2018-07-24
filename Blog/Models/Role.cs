using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleUsers = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRole> RoleUsers { get; set; }
    }
}
