using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class RoleUsers
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Roles Role { get; set; }
        public Users User { get; set; }
    }
}
