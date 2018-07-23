using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Blog.Models
{
	public partial class BlogContext : IdentityDbContext<Users>
	{
		public virtual DbSet<Blogs> Blogs { get; set; }
		public virtual DbSet<Categories> Categories { get; set; }
		public virtual DbSet<Comments> Comments { get; set; }
		public virtual DbSet<Posts> Posts { get; set; }
		public virtual DbSet<Roles> Roles { get; set; }
		public virtual DbSet<RoleUsers> RoleUsers { get; set; }
		public virtual DbSet<Users> Users { get; set; }

		public BlogContext(DbContextOptions<BlogContext> options)
				: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=localhost;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Comments>(entity =>
			{
				entity.HasIndex(e => e.PostId);

				entity.HasIndex(e => e.UserId);

				entity.HasOne(d => d.Post)
					.WithMany(p => p.Comments)
					.HasForeignKey(d => d.PostId)
					.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(d => d.User)
					.WithMany(p => p.Comments)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<Posts>(entity =>
			{
				entity.HasKey(e => e.PostId);

				entity.HasIndex(e => e.UserId);

				entity.HasOne(d => d.User)
					.WithMany(p => p.Posts)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<RoleUsers>(entity =>
			{
				entity.HasKey(e => new { e.RoleId, e.UserId });

				entity.HasIndex(e => e.UserId);

				entity.HasOne(d => d.Role)
					.WithMany(p => p.RoleUsers)
					.HasForeignKey(d => d.RoleId)
					.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(d => d.User)
					.WithMany(p => p.RoleUsers)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});
		}
	}
}
