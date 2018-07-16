using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class User : EntityBase
	{
		public string UserName { get; set; }

		public int RoleId { get; set; }
	}
}
