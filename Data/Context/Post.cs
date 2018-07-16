using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
	public class Post : EntityBase
	{
		public string PostName { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Content { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ModifyDate { get; set; }

		public int UserId { get; set; }
	}
}
