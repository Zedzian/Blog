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

		public DbSet<RoleUser> RoleUsers { get; set; }

		public DbSet<User> Users { get; set; }

		public BlogContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RoleUser>()
				.HasKey(e => new { e.RoleId, e.UserId });

			modelBuilder.Entity<Comment>()
				.HasOne(x => x.Post)
				.WithMany(y => y.Comments)
				.HasForeignKey(z => z.PostId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Comment>()
				.HasOne(x => x.User)
				.WithMany(y => y.Comments)
				.HasForeignKey(z => z.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<RoleUser>()
				 .HasOne(x => x.Role)
				 .WithMany(y => y.RoleUsers)
				 .HasForeignKey(z => z.RoleId)
				 .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<RoleUser>()
				.HasOne(x => x.User)
				.WithMany(y => y.RoleUsers)
				.HasForeignKey(z => z.UserId)
				.OnDelete(DeleteBehavior.Restrict);


		}
	}
}
