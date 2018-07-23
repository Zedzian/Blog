using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class RoleUsers
    {
        public int RoleId { get; set; }
        public string UserId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
