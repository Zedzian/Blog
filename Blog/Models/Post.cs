using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
		[Key]
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
		public ICollection<Image> Images { get; set; }
	}
}
