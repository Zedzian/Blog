using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Helpers
{
    public static class Extensions
    {

		public static bool HasRole(this ClaimsPrincipal user, string roleName)
		{
			var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
			optionsBuilder.UseSqlServer("Server=localhost;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true");

			using (var context = new BlogContext(optionsBuilder.Options))
			{
				return context.RoleUsers.Select(u=>u.Role).Where(x=>x.RoleName==roleName).Any() && context.RoleUsers.Select(u => u.User).Where(x => x.Email == user.Identities.FirstOrDefault().Name).Any();
			}
		}
	}
}
