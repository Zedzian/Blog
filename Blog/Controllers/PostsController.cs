using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Blog.Models;
using Blog.Models.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
	public class PostsController : Controller
	{
		private readonly BlogContext _context;

		[BindProperty]
		public Blog.Models.File File { get; set; }

		public PostsController(BlogContext context)
		{
			_context = context;
		}

		// GET: Posts
		public async Task<IActionResult> Index()
		{
			var posts = _context.Posts.Include(x => x.Comments).ToList();
			var postViewModels = new List<PostViewModel>();
			foreach (var post in posts)
			{
				var postViewModel = new PostViewModel();
				postViewModel.Content = post.Content;
				postViewModel.CreateDate = post.CreateDate;
				var image = _context.Images.Where(i => i.PostId == post.PostId).FirstOrDefault();
				postViewModel.ImageData = GetImageFromByteArray(image.Data);
				postViewModel.ModifyDate = post.ModifyDate;
				postViewModel.PostId = post.PostId;
				postViewModel.Title = post.Title;
				postViewModel.UserId = post.UserId;
				postViewModel.Comments = post.Comments;

				postViewModels.Add(postViewModel);
			}

			return View(postViewModels);
		}

		// GET: Posts/Details/5
		public async Task<IActionResult> Details(string id)
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] PostViewModel postViewModel)
		{
			var ident = User.Identity as ClaimsIdentity;
			var userId = _context.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Id;

			var post = new Post()
			{
				CreateDate = DateTime.Now,
				ModifyDate = DateTime.Now,
				UserId = userId,
				Title = postViewModel.Title,
				Content = postViewModel.Content
			};

			if (userId != null)
			{
				_context.Add(post);
				_context.SaveChanges();

				postViewModel.UserId = userId;
				postViewModel.PostId = post.PostId;
				AddImage(postViewModel);
				return RedirectToAction(nameof(Index));
			}

			ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", postViewModel.PostId);
			return View(postViewModel);
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("PostId,PostName,Title,Description,Content,CreateDate,ModifyDate,UserId")] Post posts)
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
		public async Task<IActionResult> Delete(string id)
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

		private bool PostsExists(string id)
		{
			return _context.Posts.Any(e => e.PostId == id);
		}

		private void AddImage(PostViewModel postViewModel)
		{
			IFormFile uploadedImage = postViewModel.Image;
			if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
			{
				MemoryStream ms = new MemoryStream();
				uploadedImage.OpenReadStream().CopyTo(ms);

				System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

				var imageEntity = new Models.Image()
				{
					ImageSize = postViewModel.Image.Length,
					Title = postViewModel.Image.FileName,
					UploadDT = DateTime.Now,
					Data = ms.ToArray(),
					PostId = postViewModel.PostId
				};

				_context.Images.Add(imageEntity);
				_context.SaveChanges();
			}
		}

		private string GetImageFromByteArray(byte[] byteData)
		{
			string imreBase64Data = Convert.ToBase64String(byteData);
			return string.Format("data:image/png;base64,{0}", imreBase64Data);
		}
	}
}