using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Blog.Models
{
	public class Users : IdentityUser
	{
		public Users()
		{
			Comments = new HashSet<Comments>();
			Posts = new HashSet<Posts>();
			RoleUsers = new HashSet<RoleUsers>();
		}

		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public ICollection<Comments> Comments { get; set; }
		public ICollection<Posts> Posts { get; set; }
		public ICollection<RoleUsers> RoleUsers { get; set; }
	}
}
