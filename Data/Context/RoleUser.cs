using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Context
{
    public class RoleUser
	{
		[Key]
		public int RoleId { get; set; }

		[Key]
		public int UserId { get; set; }

		public Role Role { get; set; }

		public User User { get; set; }
	}
}
