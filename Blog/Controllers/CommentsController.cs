using System;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
	public class CommentsController : Controller
	{
		private readonly BlogContext _context;

		public CommentsController(BlogContext context)
		{
			_context = context;
		}

		// GET: Comments
		public async Task<IActionResult> Index()
		{
			var blogContext = _context.Comments.Include(c => c.Post);
			return View(await blogContext.ToListAsync());
		}

		// GET: Comments/Details/5
		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var comments = await _context.Comments
				.Include(c => c.Post)
				.FirstOrDefaultAsync(m => m.CommentId == id);
			if (comments == null)
			{
				return NotFound();
			}

			return View(comments);
		}

		// GET: Comments/Create
		public IActionResult Create(string PostId)
		{
			return View();
		}

		// POST: Comments/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,UserName,Content,PostId")] Comment comments)
		{
			if (ModelState.IsValid)
			{
				comments.Post = _context.Posts.First(x => x.PostId == comments.PostId);
				comments.Date = DateTime.Now;
				_context.Add(comments);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId", comments.PostId);
			return View(comments);
		}

		// GET: Comments/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var comments = await _context.Comments.FindAsync(id);
			if (comments == null)
			{
				return NotFound();
			}
			ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId", comments.PostId);
			return View(comments);
		}

		// POST: Comments/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Content,PostId")] Comment comments)
		{
			if (id != comments.CommentId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(comments);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CommentsExists(comments.CommentId))
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
			ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId", comments.PostId);
			return View(comments);
		}

		// GET: Comments/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var comments = await _context.Comments
				.Include(c => c.Post)
				.FirstOrDefaultAsync(m => m.CommentId == id);
			if (comments == null)
			{
				return NotFound();
			}

			return View(comments);
		}

		// POST: Comments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var comments = await _context.Comments.FindAsync(id);
			_context.Comments.Remove(comments);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CommentsExists(string id)
		{
			return _context.Comments.Any(e => e.CommentId == id);
		}
	}
}
