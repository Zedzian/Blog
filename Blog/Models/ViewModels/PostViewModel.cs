using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blog.Models.ViewModels
{
    public class PostViewModel
	{

		public string PostId { get; set; }
		public string PostName { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public DateTime CreateDate { get; set; }
		public IFormFile Image { get; set; }
		public string ImageData { get; set; }
		public DateTime ModifyDate { get; set; }
		public string UserId { get; set; }

		public User User { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
