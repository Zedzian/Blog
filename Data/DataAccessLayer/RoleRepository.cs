using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;

namespace Data.DataAccessLayer
{
	public class RoleRepository : Repository<Role>
	{
		public RoleRepository(BlogContext context) : base(context)
		{
		}
	}
}
