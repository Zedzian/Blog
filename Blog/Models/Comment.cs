using System;

namespace Blog.Models
{
	public partial class Comment
	{
		public string CommentId { get; set; }
		public string Content { get; set; }
		public string PostId { get; set; }
		public string UserName { get; set; }
		public DateTime Date { get; set; }

		public Post Post { get; set; }
	}
}
