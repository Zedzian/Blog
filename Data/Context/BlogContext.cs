using System;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
	public class BlogContext : DbContext
	{
		public DbSet<Blog> Blogs { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Post> Posts { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<User> Users { get; set; }

		public BlogContext(DbContextOptions options) : base(options)
		{
		}
	}
}
