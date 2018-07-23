using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Blog.Models.PostViewModels;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Blog.Controllers
{
	public class PostsController : Controller
	{
		private readonly BlogContext _context;

		public PostsController(BlogContext context)
		{
			_context = context;
		}

		// GET: Posts
		public async Task<IActionResult> Index()
		{
			var blogContext = _context.Posts.Include(p => p.User);
			return View(await blogContext.ToListAsync());
		}

		// GET: Posts/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var posts = await _context.Posts
				.Include(p => p.User)
				.FirstOrDefaultAsync(m => m.PostId == id);
			if (posts == null)
			{
				return NotFound();
			}

			return View(posts);
		}

		// GET: Posts/Create
		[Authorize]
		public IActionResult Create()
		{
			ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
			return View();
		}

		// POST: Posts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PostId,PostName,Title,Description,Content")] Posts posts)
		{
			var ident = User.Identity as ClaimsIdentity;
			var userID = _context.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Id;

			if (ModelState.IsValid && userID != null)
			{
				posts.CreateDate = DateTime.Now;
				posts.ModifyDate = DateTime.Now;
				posts.UserId = userID;

				_context.Add(posts);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", posts.UserId);
			return View(posts);
		}

		// GET: Posts/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var posts = await _context.Posts.FindAsync(id);
			if (posts == null)
			{
				return NotFound();
			}
			ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", posts.UserId);
			return View(posts);
		}

		// POST: Posts/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("PostId,PostName,Title,Description,Content,CreateDate,ModifyDate,UserId")] Posts posts)
		{
			if (id != posts.PostId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(posts);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PostsExists(posts.PostId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", posts.UserId);
			return View(posts);
		}

		// GET: Posts/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var posts = await _context.Posts
				.Include(p => p.User)
				.FirstOrDefaultAsync(m => m.PostId == id);
			if (posts == null)
			{
				return NotFound();
			}

			return View(posts);
		}

		// POST: Posts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var posts = await _context.Posts.FindAsync(id);
			_context.Posts.Remove(posts);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PostsExists(int id)
		{
			return _context.Posts.Any(e => e.PostId == id);
		}
	}
}
