using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
	public class User : EntityBase
	{
		public string UserName { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }

		public virtual ICollection<RoleUser> RoleUsers { get; set; }

		public virtual ICollection<Post> Posts { get; set; }
	}
}
