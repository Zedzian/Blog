using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
	public class Blog : EntityBase
	{
		public string BlogName { get; set; }

		public string Description { get; set; }

		public DateTime CreateDate { get; set; }
	}
}
