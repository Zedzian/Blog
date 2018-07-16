using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;

namespace Data.DataAccessLayer
{
	public class PostRepository : Repository<Post>
	{
		public PostRepository(BlogContext context) : base(context)
		{
		}
	}
}
