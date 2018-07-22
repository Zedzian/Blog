using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        public int PostId { get; set; }
        public string PostName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
