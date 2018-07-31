using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
	public partial class BlogContext : IdentityDbContext<User>
	{
		public virtual DbSet<BlogDetails> Blogs { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<UserRole> RoleUsers { get; set; }
		public virtual DbSet<User> Users { get; set; }

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

			modelBuilder.Entity<Comment>(entity =>
			{
				entity.HasIndex(e => e.PostId);

				entity.HasOne(d => d.Post)
					.WithMany(p => p.Comments)
					.HasForeignKey(d => d.PostId);
			});

			modelBuilder.Entity<Post>(entity =>
			{
				entity.HasKey(e => e.PostId);

				entity.HasIndex(e => e.UserId);

				entity.HasOne(d => d.User)
					.WithMany(p => p.Posts)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<UserRole>(entity =>
			{
				entity.HasKey(e => new { e.RoleId, e.UserId });

				entity.HasIndex(e => e.UserId);

				entity.HasOne(d => d.Role)
					.WithMany(p => p.RoleUsers)
					.HasForeignKey(d => d.RoleId);

				entity.HasOne(d => d.User)
					.WithMany(p => p.RoleUsers)
					.HasForeignKey(d => d.UserId);
			});
		}
	}
}
