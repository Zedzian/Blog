using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.PostViewModels
{
    public class PostModel
	{
		public PostModel()
		{
			Comments = new HashSet<Comments>();
			CreateDate = DateTime.Now;
			ModifyDate = DateTime.Now;
		}

		public int PostId { get; set; }
		public string PostName { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime ModifyDate { get; set; }
		public string UserId { get; set; }

		public Users User { get; set; }
		public ICollection<Comments> Comments { get; set; }
	}
}
