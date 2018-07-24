using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
