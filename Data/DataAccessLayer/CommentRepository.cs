using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Data.DataAccessLayer.Contracts;

namespace Data.DataAccessLayer
{
    public class CommentRepository: Repository<Comment>
    {
		public CommentRepository(BlogContext context) : base(context)
		{
		}
	}
}
