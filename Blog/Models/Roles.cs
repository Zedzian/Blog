using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RoleUsers = new HashSet<RoleUsers>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<RoleUsers> RoleUsers { get; set; }
    }
}
