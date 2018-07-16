using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;

namespace Data.DataAccessLayer
{
	public class UserRepository : Repository<User>
	{
		public UserRepository(BlogContext context) : base(context)
		{
		}
	}
}
