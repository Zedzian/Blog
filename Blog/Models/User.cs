using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

namespace Blog.Models
{
	public class User : IdentityUser
	{
		public User()
		{
			Posts = new HashSet<Post>();
			RoleUsers = new HashSet<UserRole>();
		}

		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public ICollection<Post> Posts { get; set; }
		public ICollection<UserRole> RoleUsers { get; set; }
	}
}
