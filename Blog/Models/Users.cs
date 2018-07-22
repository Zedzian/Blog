using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Posts = new HashSet<Posts>();
            RoleUsers = new HashSet<RoleUsers>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<RoleUsers> RoleUsers { get; set; }
    }
}
