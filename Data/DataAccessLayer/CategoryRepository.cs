using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Data.DataAccessLayer.Contracts;

namespace Data.DataAccessLayer
{
	public class CategoryRepository : Repository<Category>
	{
		public CategoryRepository(BlogContext context) : base(context)
		{
		}
	}
}
