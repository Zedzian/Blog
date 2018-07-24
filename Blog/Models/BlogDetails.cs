using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class BlogDetails
    {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
