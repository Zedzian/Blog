using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Data.DataAccessLayer.Contracts;

namespace Data.DataAccessLayer
{
    public class BlogRepository: Repository<Blog>
    {
		public BlogRepository(BlogContext context) : base(context)
		{
		}
	}
}
