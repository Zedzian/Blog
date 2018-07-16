using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
	public class Comment : EntityBase
	{
		public int UserId { get; set; }

		public string Content { get; set; }
	}
}
