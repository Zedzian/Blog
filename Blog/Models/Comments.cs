using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

        public Posts Post { get; set; }
        public Users User { get; set; }
    }
}
